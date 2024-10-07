using Domain.Entities;
using Infrastructure.Bases.Data;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SsoManager.Server.Bases;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        #region Authentication
        services.AddAuthorization();
        services.AddIdentityApiEndpoints<Person>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        //services.Configure<IdentityOptions>(options =>
        //{

        //});
        services.ConfigureApplicationCookie(options =>
        {
            //1 year
            options.ExpireTimeSpan = TimeSpan.FromMinutes(525960);
        });

        #endregion Authentication

        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(
            options => options
            .SchemaFilter<EnumSchemaFilter>()
            );
        return services;
    }

    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                schema.Enum = context.Type.GetEnumNames()
                    .Select(name => new OpenApiString(name))
                    .ToList<IOpenApiAny>();
            }
        }
    }
}
