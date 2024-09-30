using Microsoft.AspNetCore.Mvc;
using SignalRMiniChat.Application.DTO;
using SignalRMiniChat.Application.Interfaces;
using SignalRMiniChat.Domain.Models;

namespace SignalRMiniChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContreoller : ControllerBase
    {
        private readonly IUserService service;

        public UserContreoller(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateAsync(UserForCreation admin, CancellationToken cancellationToken)
        {
            return Ok(await service.CreatAsync(admin, cancellationToken));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await service.DeleteAsync(id, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllASync()
        {
            return Ok(await service.GetAllAsync());
        }
    }
}
