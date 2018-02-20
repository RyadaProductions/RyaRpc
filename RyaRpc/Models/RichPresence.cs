namespace RyaRpc.Models
{
    /// <summary>
    /// The fields used for a RPC message to steam, all properties should exist, but they are entirely optional.
    /// Do not fill properties with data if you do not want to use that in the RPC on discord.
    /// </summary>
    public struct RichPresence
    {
        /// <summary>
        /// The user's current status.
        /// Max 128 bytes
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// What the player is currently doing.
        /// Max 128 bytes
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Epoch seconds for game start - including will show time as "elapsed".
        /// </summary>
        public long StartTimestamp { get; set; }

        /// <summary>
        /// Epoch seconds for game end - including will show time as "remaining".
        /// </summary>
        public long EndTimestamp { get; set; }

        /// <summary>
        /// Name of the uploaded image for the large profile artwork.
        /// Max 32 bytes
        /// </summary>
        public string LargeImageKey { get; set; }

        /// <summary>
        /// Tooltip for the largeImageKey.
        /// Max 128 bytes
        /// </summary>
        public string LargeImageText { get; set; }

        /// <summary>
        /// Name of the uploaded image for the small profile artwork,
        /// Max 32 bytes
        /// </summary>
        public string SmallImageKey { get; set; }

        /// <summary>
        /// Tootltip for the smallImageKey,
        /// Max 128 bytes
        /// </summary>
        public string SmallImageText { get; set; }

        /// <summary>
        /// Id of the player's party, lobby, or group.
        /// Max 128 bytes
        /// </summary>
        public string PartyId { get; set; }

        /// <summary>
        /// Current size of the player's party, lobby, or group.
        /// </summary>
        public int PartySize { get; set; }

        /// <summary>
        /// Maximum size of the player's party, lobby, or group.
        /// </summary>
        public int PartyMax { get; set; }

        /// <summary>
        /// Unique hashed string for Spectate and Join.
        /// Max 128 bytes
        /// </summary>
        public string MatchSecret { get; set; }

        /// <summary>
        /// Unique hashed string for Spectate button.
        /// Max 128 bytes
        /// </summary>
        public string JoinSecret { get; set; }

        /// <summary>
        /// Unique hashed string for chat invitations and Ask to Join,
        /// Max 128 bytes
        /// </summary>
        public string SpectateSecret { get; set; }

        /// <summary>
        /// Marks the matchSecret as a game session with a specific beginning and end.
        /// </summary>
        public bool Instance { get; set; }
    }
}
