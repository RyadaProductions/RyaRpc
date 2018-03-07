using System;
using RyaRpc.Models;
using Serilog;

namespace RyaRpc
{
    /// <summary>
    /// Controller taking care of the event handlers and Initializing RpcClient
    /// </summary>
    public class RpcController : IDisposable
    {
        /// <summary>
        /// Id of the discordapp application
        /// </summary>
        public string ApplicationId => "410440067530752000";

        private EventHandlers _handlers;

        /// <summary>
        /// Initializes Discord RPC
        /// </summary>
        public RpcController()
        {
            _handlers = new EventHandlers { ReadyCallback = ClientIsReady };
            _handlers.DisconnectedCallback += ClientHasDisconnected;
            _handlers.ErrorCallback += ClientErrorOccured;
            RpcClient.Initialize(ApplicationId, ref _handlers, true, "");
        }

        /// <summary>
        /// Logs when the DiscordRpc is ready and connected.
        /// </summary>
        public void ClientIsReady()
        {
            Log.Information("Discord RPC is ready!");
        }

        /// <summary>
        /// Logs the disconnection from the DiscordRpc service
        /// </summary>
        /// <param name="errorCode">the errorcode that gets send</param>
        /// <param name="message">string containing the disconnect message</param>
        public void ClientHasDisconnected(int errorCode, string message)
        {
            Log.Error($"{errorCode} - {message}");
        }
        
        /// <summary>
        /// Logs the errors that occur in DiscordRpc
        /// </summary>
        /// <param name="errorCode">the errorcode that gets send</param>
        /// <param name="message">string containing the error message</param>
        public void ClientErrorOccured(int errorCode, string message)
        {
            Log.Error($"{errorCode} - {message}");
        }

        public void Dispose()
        {
            RpcClient.Shutdown();
        }
    }
}
