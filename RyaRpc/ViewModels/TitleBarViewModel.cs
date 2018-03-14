using System;
using System.Windows;
using Stylet;

namespace RyaRpc.ViewModels
{
    /// <summary>
    /// Viewmodel for the TitleBar view.
    /// </summary>
    public class TitleBarViewModel
    {
        /// <summary>
        /// Hods the config for the windowManager and some usefull methods 
        /// </summary>
        private readonly IWindowManagerConfig _windowManagerConfig;

        /// <summary>
        /// ViewModel of the trayicon
        /// </summary>
        private readonly TrayIconViewModel _trayIconViewModel;

        /// <summary>
        /// TitleBar user control, capable of moving and closing the window
        /// </summary>
        /// <param name="windowManagerConfig"></param>
        public TitleBarViewModel(IWindowManagerConfig windowManagerConfig, TrayIconViewModel trayIconViewModel)
        {
            _windowManagerConfig = windowManagerConfig;
            _trayIconViewModel = trayIconViewModel;
        }

        /// <summary>
        /// Method invoked when the user is holding leftmouse button over the whole UserControl to be able to drag the window.
        /// </summary>
        public void MoveWindow()
        {
            var window = _windowManagerConfig.GetActiveWindow();
            window.DragMove();
        }

        /// <summary>
        /// Method invoked when the user clicks the minimize button on the window.
        /// This hides the window from the user but keeps it running in the background.
        /// </summary>
        public void MinimizeApplication()
        {
            _trayIconViewModel.IsShellVisible = Visibility.Hidden;
        }

        /// <summary>
        /// Close the application gracefully. 
        /// We close the Rpc thread gracefully here by calling RpcClient.Shutdown();
        /// </summary>
        public void CloseApplication()
        {
            RpcClient.Shutdown();
            Environment.Exit(0);
        }
    }
}
