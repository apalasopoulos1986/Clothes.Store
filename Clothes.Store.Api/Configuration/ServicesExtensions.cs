using Clothes.Store.Db.Context;
using Clothes.Store.Db.Interfaces;
using Clothes.Store.Db.Repository;
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
               
            }
            
            return services;
        }
      
    }
}
