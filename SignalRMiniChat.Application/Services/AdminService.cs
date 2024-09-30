using AutoMapper;
using SignalRMiniChat.Application.DTO;
using SignalRMiniChat.Application.Interfaces;
using SignalRMiniChat.Domain.Models;
using SignalRMiniCHat.Data.Interfaces;
using System.Linq.Expressions;

namespace SignalRMiniChat.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IGenericRepository<Admin> _repository;
        private readonly IMapper _mapper;

        public AdminService(IGenericRepository<Admin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Admin> CreatAsync(AdminForCreation userCreation, CancellationToken cancellationToken)
        {
            var result =  await _repository.CreateAsync(_mapper.Map<Admin>(userCreation)); 
            var saves = _repository.SavesChangesAsync(cancellationToken);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync(u => u.Id == id);
            _repository.SavesChangesAsync(cancellationToken);
            return result;
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return _repository.GetAll();
        }

        public async Task<Admin> GetAsync(Expression<Func<Admin, bool>> expression)
        {
            return await _repository.GetAsync(expression);
        }
    }
}
