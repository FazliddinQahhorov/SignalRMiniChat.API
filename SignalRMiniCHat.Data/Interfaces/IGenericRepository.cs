using SignalRMiniChat.Domain.Models;
using System.Linq.Expressions;

namespace SignalRMiniCHat.Data.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : Base
{
    /// <summary>
    /// Ma`lumotlar bazasiga ma`lumot qo`shadi
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public ValueTask<TEntity> CreateAsync(TEntity? entity);
    /// <summary>
    /// Ma`lumotlar bazasidagi ma`lumotlarni bazadan olib kelib beradi
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IQueryable<TEntity> GetAll( params Expression<Func<TEntity, object>>[] includes);
    /// <summary>
    /// Ma`lumotlar bazasidan bizga kerakli malumotni olib beradi
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public ValueTask<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
    /// <summary>
    /// Kerakli ma`lumotni yangilaydi
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public ValueTask<TEntity> UpdateAsync(TEntity? entity);
    /// <summary>
    /// Kiritilgan id dagi malumotni bazadan o`chirib tashlaydi
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
    public Task<int> SavesChangesAsync(CancellationToken cancellationToken);
}
