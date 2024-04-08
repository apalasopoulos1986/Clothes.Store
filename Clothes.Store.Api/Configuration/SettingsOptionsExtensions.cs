using Clothes.Store.Common.Models.Settings;

namespace Clothes.Store.Api.Configuration
{
    public static class SettingsOptionsExtensions
    {
        public static void AddOptions(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<StoreSettings>(
                builder.Configuration.GetSection(nameof(StoreSettings)));
        }
    }
}
