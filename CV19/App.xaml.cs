using CV19.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CV19.ViewsModels;

namespace CV19
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesingnMode { get; private set; } = true;

      
        protected override void OnStartup(StartupEventArgs e)
        {
            IsDesingnMode = false;
            base.OnStartup(e);


        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<DataServices>();
            services.AddSingleton<CountriesStatisticViewModel>();
        }
    }
}
