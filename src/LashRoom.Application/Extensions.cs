using LashRoom.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LashRoom.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ICommandHandler<>).Assembly;

            services.Scan(s => s.FromAssemblies(applicationAssembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }
    }
}
