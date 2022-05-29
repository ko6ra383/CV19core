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
using System.Runtime.CompilerServices;
using System.IO;
using CV19.Services.Interfaces;

namespace CV19
{
    public partial class App : Application
    {
        public static bool IsDesingnMode { get; private set; } = true;

        private static IHost _Host;
        public static IHost Host => _Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();


        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesingnMode = false;
            var host = Host;

            base.OnStartup(e);

            await host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _Host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<IDataService,DataServices>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CountriesStatisticViewModel>();
        }

        public static string CurrentDirectory =>
            IsDesingnMode ? Path.GetDirectoryName(GetSourceCodePath()) : Environment.CurrentDirectory;

        private static string GetSourceCodePath([CallerFilePath] string Path = null) => Path;
    }
}
