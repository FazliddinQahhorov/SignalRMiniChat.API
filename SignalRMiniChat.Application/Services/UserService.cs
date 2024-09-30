using AutoMapper;
using SignalRMiniChat.Application.DTO;
using SignalRMiniChat.Application.Interfaces;
using SignalRMiniChat.Domain.Models;
using SignalRMiniCHat.Data.Interfaces;
using System.Linq.Expressions;

namespace SignalRMiniChat.Application.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserService(IGenericRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<User> CreatAsync(UserForCreation userCreation, CancellationToken cancellationToken)
    {
        var result = await _userRepository.CreateAsync(_mapper.Map<User>(userCreation));
        _userRepository.SavesChangesAsync(cancellationToken);
        return result;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _userRepository.DeleteAsync(u => u.Id == id);
        _userRepository.SavesChangesAsync(cancellationToken);
        return result;

    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return _userRepository.GetAll();
    }

    public Task<User> GetAsync(Expression<Func<User, bool>> expression)
    {
        throw new NotImplementedException();
    }
}
