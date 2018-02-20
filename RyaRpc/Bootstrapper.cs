using System;
using System.IO;
using RyaRpc.Extensions;
using RyaRpc.Games.Csgo;
using Stylet;
using StyletIoC;
using RyaRpc.ViewModels;
using Serilog;

namespace RyaRpc
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
        }

        /// <summary>
        /// Executed on start of the application before
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();

            SetupLogger();

            new CsgoConfig().AddConfig();

            var folder = Path.Combine(Path.GetTempPath(), "RyaRpc");
            Directory.CreateDirectory(folder);

            Log.Information("Startup Completed");
        }

        /// <summary>
        /// Setup Serilog so we can log stuff. We do this at startup so that it is setup before we setup the DiContainer
        /// </summary>
        private static void SetupLogger()
        {
            var windowsAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appDataFolder = Path.Combine(windowsAppDataFolder, "Ryada", "RyaRpc");

            Directory.CreateDirectory(appDataFolder);

            var logFile = Path.Combine(appDataFolder, "RyaRpc-.log");

            // Seting up serilog to save to a log file.
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(logFile, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        /// <summary>
        /// Display the root view and enable blur on the window
        /// </summary>
        /// <param name="rootViewModel">ViewModel that we base the RootView on</param>
        protected override void DisplayRootView(object rootViewModel)
        {
            base.DisplayRootView(rootViewModel);

            GetActiveWindow().EnableBlur();
        }
    }
}
