using SignalRMiniChat.Application.DTO;
using SignalRMiniChat.Domain.Models;
using System.Linq.Expressions;

namespace SignalRMiniChat.Application.Interfaces;

public interface IAdminService
{
    public Task<Admin> CreatAsync(AdminForCreation userCreation, CancellationToken cancellationToken);
    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<Admin> GetAsync(Expression<Func<Admin, bool>> expression);
    public Task<IEnumerable<Admin>> GetAllAsync();
}
