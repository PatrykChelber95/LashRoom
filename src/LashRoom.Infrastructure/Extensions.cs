using LashRoom.Application.Abstractions;
using LashRoom.Infrastructure.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LashRoom.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var section = configuration.GetSection("app");
            services.Configure<AppOptions>(section);
            services.AddPostgres(configuration);

            var infrastructureAssembly = typeof(AppOptions).Assembly;

            services.Scan(s => s.FromAssemblies(infrastructureAssembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication application)
        {
            application.MapControllers();

            return application;
        }
    }
}
