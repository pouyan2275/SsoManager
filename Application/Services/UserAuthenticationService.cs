using Application.Bases.Implements.Services;
using Application.Dtos.UserAuthentications;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Infrastructure.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Application.Services;

public class UserAuthenticationService : BaseService<UserAuthenticationDto, UserAuthenticationDtoSelect, UserAuthentication>, IUserAuthenticationService
{
    private readonly IUserAuthenticationRepository _repository;
    private readonly SignInManager<UserAuthentication> _signInManager;
    private readonly IUserStore<UserAuthentication> _userStore;
    private readonly UserManager<UserAuthentication> _userManager;
    private readonly IOptionsMonitor<BearerTokenOptions> _bearerTokenOptions;
    public UserAuthenticationService(IUserAuthenticationRepository repository,
            SignInManager<UserAuthentication> signInManager,
            IUserStore<UserAuthentication> userStore,
            UserManager<UserAuthentication> userManager,
            IOptionsMonitor<BearerTokenOptions> bearerTokenOptions
        ) : base(repository)
    {
        _repository = repository;
        _signInManager = signInManager;
        _userStore = userStore;
        _userManager = userManager;
        _bearerTokenOptions = bearerTokenOptions;
    }
    public async Task<SignInResult> Login(LoginDto loginDto, CancellationToken ct = default)
    {
        var useCookieScheme = loginDto.UseCookies == true ? true : false;
        _signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;
       
        var result = await _signInManager.PasswordSignInAsync(loginDto.NationalCode, loginDto.Password, useCookieScheme, lockoutOnFailure: false);

        return result;
    }
    public async Task<IdentityResult> Register(RegisterDto registerDto, CancellationToken ct = default)
    {
        var user = new UserAuthentication
        {
            UserName = registerDto.NationalCode,
            PhoneNumber = registerDto.PhoneNumber
        };
        await _userStore.SetUserNameAsync(user, registerDto.NationalCode, ct);

        var result = await _userManager.CreateAsync(user, registerDto.PhoneNumber);

        return result;
    }
    public async Task<IdentityResult> ResetPassword(ResetPasswordDto dto,CancellationToken ct = default)
    {
        var user = await _userManager.FindByNameAsync(dto.PhoneNumber) ?? throw new Exception("کاربر یافت نشد");

        var result = await _userManager.ResetPasswordAsync(user, dto.ResetCode, dto.NewPassword);
        if (!result.Succeeded)
            throw new Exception("توکن وارد شده صحیح نیست");
        return result;
    }
    [Authorize]
    public async Task Logout(CancellationToken ct = default)
    {
        await _signInManager.SignOutAsync();
    }

}
