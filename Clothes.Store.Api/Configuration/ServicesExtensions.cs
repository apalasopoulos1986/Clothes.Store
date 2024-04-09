using Clothes.Store.Service.Interfaces;
using Clothes.Store.Service.Services;


namespace Clothes.Store.Api.Configuration
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            {
                services.AddTransient<IProductsMigrationService, ProductsMigrationService>();
                services.AddTransient<IUserService, UsersService>();
            }

            return services;
        }

    }
}
