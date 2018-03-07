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
    }
}
