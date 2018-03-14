using System;
using System.IO;
using System.Threading.Tasks;
using RyaRpc.Extensions;
using RyaRpc.Games.Csgo;
using Stylet;
using StyletIoC;
using RyaRpc.ViewModels;
using Serilog;
using Squirrel;

namespace RyaRpc
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            builder.Bind<TrayIconViewModel>().ToSelf().InSingletonScope();
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
            
            CsgoConfig.SaveToGameFolder();

            var folder = Path.Combine(Path.GetTempPath(), "RyaRpc");
            Directory.CreateDirectory(folder);

            Task.Run(StartUpdater);

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
        /// Start the Squirrel.Windows update mechanism.
        /// </summary>
        /// <returns></returns>
        private static async Task StartUpdater()
        {
            Log.Information("Starting the Updater");

            using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/RyadaProductions/RyaRpc/releases/latest"))
            {
                await mgr.Result.UpdateApp();
            }

            Log.Information("Updater started succesfully");
        }

        /// <summary>
        /// Display the root view and enable blur on the window
        /// </summary>
        /// <param name="rootViewModel">ViewModel that we base the RootView on</param>
        protected override void DisplayRootView(object rootViewModel)
        {
            base.DisplayRootView(rootViewModel);

            GetActiveWindow().EnableBlur();

            Log.Information("Applied the WPF window hack to gain a blurred background");
        }
    }
}
