using Microsoft.EntityFrameworkCore;
using SignalRMiniChat.Domain.Models;
using SignalRMiniCHat.Data.AppDbContexts;
using SignalRMiniCHat.Data.Interfaces;
using System.Linq.Expressions;

namespace SignalRMiniCHat.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Base
{
    private readonly AppDbContext _dbcontext;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _dbcontext = context;
        _dbSet = context.Set<TEntity>();
    }

    public async ValueTask<TEntity> CreateAsync(TEntity entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        return entry.Entity;
    }

    public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entityToDelete = await _dbSet.SingleOrDefaultAsync(expression);

        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
            return true;
        }

        return false;
    }

    // Get method with Include for related entities
    public async ValueTask<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;

        // Apply Include for all related entities
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(expression);
    }

    // GetAll method with Include for related entities
    public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;

        // Apply Include for all related entities
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query.AsQueryable();
    }

    public async Task<int> SavesChangesAsync(CancellationToken cancellationToken)
    {
        return await _dbcontext.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var updating = await _dbSet.FindAsync(entity.Id);
        if (updating != null)
        {
            _dbcontext.Entry(updating).CurrentValues.SetValues(entity);
            _dbSet.Update(updating);
        }
        return updating;
    }
}
