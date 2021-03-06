using RyaRpc.Handlers;
using Stylet;

namespace RyaRpc.ViewModels
{
    /// <summary>
    /// ViewModel for the shell that the application is run in
    /// </summary>
    public class ShellViewModel : Screen
    {
        /// <summary>
        /// Reference to an instance of the Titlebar its viewmodel
        /// </summary>
        public TitleBarViewModel TitleBarViewModel { get; }

        /// <summary>
        /// Reference to the TrayIcon its ViewModel
        /// </summary>
        public TrayIconViewModel TrayIconViewModel { get; }

        /// <summary>
        /// Reference to the Singleton GameDetector
        /// </summary>
        public GameDetector GameDetector { get; }

        /// <summary>
        /// ViewModel for the ShellView window, should not be called upon its own and only depend on the things injected in its constructor.
        /// </summary>
        /// <param name="titleBarViewModel">The viewmodel for the title bar</param>
        /// <param name="trayIconViewModel">The viewmodel for the tray icon</param>
        /// <param name="gameDetector">Detects which game started and starts a listener for the gamestates.</param>
        public ShellViewModel(TitleBarViewModel titleBarViewModel, TrayIconViewModel trayIconViewModel, GameDetector gameDetector)
        {
            TitleBarViewModel = titleBarViewModel;
            TrayIconViewModel = trayIconViewModel;
            GameDetector = gameDetector;
            GameDetector.Start();
        }
    }
}
