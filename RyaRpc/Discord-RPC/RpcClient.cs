using System.Runtime.InteropServices;
using RyaRpc.Models;

namespace RyaRpc
{
    /// <summary>
    /// Contains all the DllImported methods from the discord rpc api and the unmanaged callbacks
    /// </summary>
    public class RpcClient
    {
        /// <summary>
        /// Starts and initializes the discordRpc client
        /// </summary>
        /// <param name="applicationId">Id of the application (game)</param>
        /// <param name="handlers">reference to an instance of the event handlers</param>
        /// <param name="autoRegister"></param>
        /// <param name="optionalSteamId">Id of the game if it is sold on steam</param>
        [DllImport("discord-rpc", EntryPoint = "Discord_Initialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Initialize(string applicationId, ref EventHandlers handlers, bool autoRegister, string optionalSteamId);

        /// <summary>
        /// Shutsdown the RpcClient Connection
        /// </summary>
        [DllImport("discord-rpc", EntryPoint = "Discord_Shutdown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Shutdown();

        /// <summary>
        /// Runs all the subscribed callbacks.
        /// </summary>
        [DllImport("discord-rpc", EntryPoint = "Discord_RunCallbacks", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunCallbacks();

        /// <summary>
        /// Updates the Rpc in discord with new data
        /// </summary>
        /// <param name="presence">reference to an instance of RichPresence</param>
        [DllImport("discord-rpc", EntryPoint = "Discord_UpdatePresence", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdatePresence(ref RichPresence.InnerPresence presence);

        /// <summary>
        /// Clears the current game presence
        /// </summary>
        [DllImport("discord-rpc", EntryPoint = "Discord_ClearPresence", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearPresence();

        /// <summary>
        /// Fires when the client is ready
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ReadyCallback();

        /// <summary>
        /// Fires when we get disconnected from discord
        /// </summary>
        /// <param name="errorCode">Code that we receive from the Discord Client</param>
        /// <param name="message">Message containing the reason we got disconnected</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DisconnectedCallback(int errorCode, string message);

        /// <summary>
        /// Fires when DiscordRpc encounters an Error
        /// </summary>
        /// <param name="errorCode">Code that we receive from the Discord Client</param>
        /// <param name="message">Message containing the error message</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ErrorCallback(int errorCode, string message);
        
        /// <summary>
        /// Possible responses from the JoinRequest
        /// </summary>
        public enum Reply
        {
            No = 0,
            Yes = 1,
            Ignore = 2
        }
    }
}
