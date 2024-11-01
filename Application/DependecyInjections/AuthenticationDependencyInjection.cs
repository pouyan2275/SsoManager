using Domain.Entities;
using Infrastructure.Bases.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependecyInjections;

public static class AuthenticationDependencyInjection
{
    public static IServiceCollection AddBaseAuthentication(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddIdentityApiEndpoints<UserAuthentication>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.ConfigureApplicationCookie(options =>
        {
            //1 year
            options.ExpireTimeSpan = TimeSpan.FromMinutes(525960);
        });
        services.Configure<IdentityOptions>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedAccount = false;
        });

        return services;
    }
}
