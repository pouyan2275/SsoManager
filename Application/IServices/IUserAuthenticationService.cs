using Application.Bases.Interfaces.IServices;
using Application.Dtos.UserAuthentications;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.IServices
{
    public interface IUserAuthenticationService : IBaseService<UserAuthenticationDto, UserAuthenticationDtoSelect, UserAuthentication>
    {
        public Task<SignInResult> Login(LoginDto loginDto, CancellationToken ct = default);
        public Task<IdentityResult> Register(RegisterDto registerDto, CancellationToken ct = default);
        public Task<IdentityResult> ResetPassword(ResetPasswordDto dto,CancellationToken ct = default);
        public Task Logout(CancellationToken ct = default);



    }
}
