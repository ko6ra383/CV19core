﻿using Microsoft.Extensions.DependencyInjection;

namespace CV19.ViewsModels
{
    public static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CountriesStatisticViewModel>();
            return services;
        }
    }
}
