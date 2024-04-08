using Clothes.Store.Common.Models.Settings;
using Clothes.Store.Common.Settings;

namespace Clothes.Store.Api.Configuration
{
    public static class SettingsOptionsExtensions
    {
        public static void AddOptions(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<StoreSettings>(
                builder.Configuration.GetSection(nameof(StoreSettings)));
            builder.Services.Configure<PathSettings>(
               builder.Configuration.GetSection(nameof(PathSettings)));
        }
    }
}
