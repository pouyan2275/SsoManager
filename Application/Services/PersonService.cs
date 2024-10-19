using Application.Bases.Implements.Services;
using Application.Dtos.Persons;
using Application.IServices;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Application.Services;

public class PersonService : BaseService<PersonDto, PersonDtoSelect, Person>, IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly SignInManager<Person> _signInManager;
    private readonly IUserStore<Person> _userStore;
    private readonly UserManager<Person> _userManager;
    private readonly LinkGenerator _linkGenerator;
    private readonly IOptionsMonitor<BearerTokenOptions> _bearerTokenOptions;
    private readonly IEmailSender _emailSender;
    public PersonService(IPersonRepository repository,
            SignInManager<Person> signInManager,
            IUserStore<Person> userStore,
            UserManager<Person> userManager,
            LinkGenerator linkGenerator,
            IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
            IEmailSender emailSender
        ) : base(repository)
    {
        _repository = repository;
        _signInManager = signInManager;
        _userStore = userStore;
        _userManager = userManager;
        _linkGenerator = linkGenerator;
        _bearerTokenOptions = bearerTokenOptions;
        _emailSender = emailSender;
    }
    public async Task<SignInResult> Login(LoginDto loginDto, CancellationToken ct = default)
    {
        var useCookieScheme = (loginDto.UseCookies == true) || (loginDto.UseSessionCookies == true);
        var isPersistent = (loginDto.UseCookies == true) && (loginDto.UseSessionCookies != true);
        _signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

        var result = await _signInManager.PasswordSignInAsync(loginDto.PhoneNumber, loginDto.Password, isPersistent, lockoutOnFailure: false);

        if (result.RequiresTwoFactor)
        {
            if (!string.IsNullOrEmpty(loginDto.TwoFactorCode))
            {
                result = await _signInManager.TwoFactorAuthenticatorSignInAsync(loginDto.TwoFactorCode, isPersistent, rememberClient: isPersistent);
            }
            else if (!string.IsNullOrEmpty(loginDto.TwoFactorRecoveryCode))
            {
                result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(loginDto.TwoFactorRecoveryCode);
            }
        }
        return result;
    }

}
