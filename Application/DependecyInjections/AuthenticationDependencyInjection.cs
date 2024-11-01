using Domain.Entities;
using Infrastructure.Bases.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependecyInjections;

public static class AuthenticationDependencyInjection
{
    public static IServiceCollection Add(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddIdentityApiEndpoints<UserAuthentication>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        //services.ConfigureApplicationCookie(options =>
        //{
        //    //1 year
        //    options.ExpireTimeSpan = TimeSpan.FromMinutes(525960);
        //});
        //services.Configure<IdentityOptions>(options =>
        //{
        //    options.SignIn.RequireConfirmedEmail = false;
        //});

        return services;
    }
}
