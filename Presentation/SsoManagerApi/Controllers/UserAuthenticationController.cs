using Application.Dtos.UserAuthentications;
using Application.IServices;
using Domain.Entities;
using GhasemIranApi.Bases.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SsoManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : BaseController<UserAuthenticationDto,UserAuthenticationDtoSelect,UserAuthentication>
    {
        private readonly IUserAuthenticationService _service;

        public UserAuthenticationController(IUserAuthenticationService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task Login(LoginDto dto, CancellationToken ct = default)
        {
            await _service.Login(dto, ct);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> Register(RegisterDto dto, CancellationToken ct = default)
        {
            var result = await _service.Register(dto, ct);
            if (!result.Succeeded)
                return BadRequest();
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> ResetPassword(ResetPasswordDto dto, CancellationToken ct = default)
        {
            var result = await _service.ResetPassword(dto, ct);
            if (!result.Succeeded)
                return BadRequest();
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> Logout(CancellationToken ct = default)
        {
            await _service.Logout(ct);
            return Ok();
        }
    }
}
