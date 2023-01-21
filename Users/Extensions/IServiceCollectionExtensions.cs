using MediatR;
using Microsoft.EntityFrameworkCore;
using Pomelo;
using Users.AutoMapper;
using Users.Controllers;
using Users.Persistence;

namespace Users.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddServiceSetup(this IServiceCollection services, IConfiguration config)
        {
            services.AddPersistence(config);
            services.AddAutoMapper(typeof(UsersProfile));
            services.AddMediatR(typeof(UsersController));
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

            services.AddDbContext<UsersContext>(opt =>
            {
                opt.UseMySql(configuration.GetConnectionString("Database") ?? "", serverVersion);
            });

            return services;
        }
    }
}
