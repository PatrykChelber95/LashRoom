﻿using LashRoom.Application.Abstractions;
using LashRoom.Core.Repositories;
using LashRoom.Infrastructure.DAL.Decorators;
using LashRoom.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LashRoom.Infrastructure.DAL
{
    internal static class Extensions
    {
        private const string SectionName = "postgres";

        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {

            var section = configuration.GetSection(SectionName);
            services.Configure<PostgresOptions>(section);
            var options = configuration.GetOptions<PostgresOptions>(SectionName);

            services.AddDbContext<LashroomDbContext>(x => x.UseNpgsql(options.ConnectionString));
            services.AddScoped<IServiceRepository, PostgresServiceRepository>();
            services.AddScoped<IUnitOfWork, PostgresUnitOfWork>();
            services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

            services.AddHostedService<DatabaseInitializer>();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }


        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            var section = configuration.GetSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}
