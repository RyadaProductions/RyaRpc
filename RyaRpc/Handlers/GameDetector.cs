﻿using System;
using System.Management;
using RyaRpc.Games;
using RyaRpc.Games.Csgo;

namespace RyaRpc.Handlers
{
    /// <summary>
    /// Detects if csgo starts and watches started/closed processes to see if it is csgo
    /// </summary>
    public class GameDetector : IDisposable
    {
        /// <summary>
        /// True = a game is currently running,
        /// False = no game is currently running
        /// </summary>
        public bool IsGameRunning { get; set; }

        /// <summary>
        /// string that represents the current state of the application
        /// </summary>
        public string CurrentAppState => IsGameRunning ? $"{_currentGame} is running" : "Waiting for a game to start";

        private readonly ManagementEventWatcher _processStartWatcher;
        private readonly ManagementEventWatcher _processStopWatcher;

        private RpcController _rpcController;

        private string _currentGame;
        public IGameState CurrentStateHandler { get; set; }

        /// <summary>
        /// Watches if applications start/close and changes the current rpc state based upon that
        /// </summary>
        public GameDetector()
        {
            _rpcController = new RpcController();
            _rpcController.Initialize();

            _processStartWatcher = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            _processStartWatcher.EventArrived += NewProcessStarted;

            _processStopWatcher = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            _processStopWatcher.EventArrived += ProcessStopped;
        }

        /// <summary>
        /// Starts the process watchers for starting and closing applications
        /// </summary>
        public void Start()
        {
            _processStartWatcher.Start();
            _processStopWatcher.Start();
        }

        /// <summary>
        /// Called whenever windows or the user starts a new process.
        /// </summary>
        /// <param name="sender">The ManagementEventWatcher that called this handler</param>
        /// <param name="e">Used to check the name of the new process</param>
        private void NewProcessStarted(object sender, EventArrivedEventArgs e)
        {
            // if a game is running do not check what process was started since we are not interested in that
            if (IsGameRunning) return;

            switch (e.NewEvent.Properties["ProcessName"].Value as string)
            {
                case ProcessNames.Csgo:
                    _currentGame = ProcessNames.Csgo;
                    CurrentStateHandler = new CsgoState();
                    IsGameRunning = true;
                    break;
            }

        }

        /// <summary>
        /// Called when windows or the user closes a process
        /// </summary>
        /// <param name="sender">The ManagementEventWatcher that called this handler</param>
        /// <param name="e">Used to check the name of the closed process</param>
        private void ProcessStopped(object sender, EventArrivedEventArgs e)
        {
            // If no game is running do not continue
            if (!IsGameRunning) return;

            // If the stopped process is not the same as the game then do not continue
            if (e.NewEvent.Properties["ProcessName"].Value as string != _currentGame) return;

            _currentGame = string.Empty;
            CurrentStateHandler.Dispose();
            CurrentStateHandler = null;
            RpcClient.ClearPresence();
            IsGameRunning = false;
        }

        /// <inheritdoc />
        /// <summary>
        /// Stop both watchers when disposing of this object.
        /// </summary>
        public void Dispose()
        {
            _processStartWatcher.Stop();
            _processStopWatcher.Stop();
            CurrentStateHandler.Dispose();
            CurrentStateHandler = null;
            _rpcController.Dispose();
            _rpcController = null;
        }
    }
}
