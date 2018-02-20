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
        public TitleBarViewModel TitleBarViewModel { get; set; }

        /// <summary>
        /// Reference to the Singleton GameDetector
        /// </summary>
        public GameDetector GameDetector { get; set; }

        /// <summary>
        /// ViewModel for the ShellView window, should not be called upon its own and only depend on the things injected in its constructor.
        /// </summary>
        /// <param name="titleBarViewModel">The viewmodel for the title bar</param>
        /// <param name="gameDetector">Detects which game started and starts a listener for the gamestates.</param>
        public ShellViewModel(TitleBarViewModel titleBarViewModel, GameDetector gameDetector)
        {
            TitleBarViewModel = titleBarViewModel;
            GameDetector = gameDetector;
            GameDetector.Start();
        }
    }
}
