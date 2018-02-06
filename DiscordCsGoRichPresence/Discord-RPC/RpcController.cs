using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordCsGoRichPresence.Discord_RPC
{
    internal class RpcController
    {
        public RpcClient.RichPresence Presence;
        public string ApplicationId { get; set; } = "410440067530752000";
        public string OptionalSteamId { get; set; }

        RpcClient.EventHandlers _handlers;

        /// <summary>
        ///     Initializes Discord RPC
        /// </summary>
        public void Initialize()
        {
            _handlers = new RpcClient.EventHandlers();
            _handlers.readyCallback = ReadyCallback;
            _handlers.disconnectedCallback += DisconnectedCallback;
            _handlers.errorCallback += ErrorCallback;
            RpcClient.Initialize(ApplicationId, ref _handlers, true, OptionalSteamId);
        }

        public void ReadyCallback()
        {
            Debug.WriteLine("Discord RPC is ready!");
        }

        public void DisconnectedCallback(int errorCode, string message)
        {
            Debug.WriteLine($"Error: {errorCode} - {message}");
        }

        public void ErrorCallback(int errorCode, string message)
        {
            Debug.WriteLine($"Error: {errorCode} - {message}");
        }
    }
}
