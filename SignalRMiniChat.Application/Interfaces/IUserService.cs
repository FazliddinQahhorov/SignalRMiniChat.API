using SignalRMiniChat.Application.DTO;
using SignalRMiniChat.Domain.Models;
using System.Linq.Expressions;

namespace SignalRMiniChat.Application.Interfaces;

public interface IUserService
{
    public Task<User> CreatAsync(UserForCreation userCreation, CancellationToken cancellationToken);
    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<User> GetAsync(Expression<Func<User, bool>> expression);
    public Task<IEnumerable<User>> GetAllAsync();
}
