using CV19.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CV19.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataServices>();
            services.AddTransient<IAsyncDataService, AsyncDataService>();
            services.AddTransient<IWebServerService, HttpListenerWebServer>();
            return services;
        }
    }
}
