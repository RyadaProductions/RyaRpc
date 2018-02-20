namespace RyaRpc.Models
{
    /// <summary>
    /// Eventhandlers used by Discord RPC
    /// </summary>
    public struct EventHandlers
    {
        /// <summary>
        /// Fires when the DiscordRpc is connected
        /// </summary>
        public RpcClient.ReadyCallback ReadyCallback { get; set; }

        /// <summary>
        /// Fires when the DiscordRpc disconnects
        /// </summary>
        public RpcClient.DisconnectedCallback DisconnectedCallback { get; set; }

        /// <summary>
        /// Fires when there is an error in the DiscordRpc
        /// </summary>
        public RpcClient.ErrorCallback ErrorCallback { get; set; }

        /// <summary>
        /// Fires when somebody allows you to join their game
        /// </summary>
        public RpcClient.JoinCallback JoinCallback { get; set; }

        /// <summary>
        /// Fires when you click the spectate button
        /// </summary>
        public RpcClient.SpectateCallback SpectateCallback { get; set; }
        
        /// <summary>
        /// Fires when somebody requests to join your game
        /// </summary>
        public RpcClient.RequestCallback RequestCallback { get; set; }
    }
}
