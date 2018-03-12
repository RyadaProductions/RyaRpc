using System.Diagnostics.CodeAnalysis;
using Stylet;

namespace RyaRpc.Models
{
    /// <summary>
    /// The fields used for a RPC message to steam, all properties should exist, but they are entirely optional.
    /// Do not fill properties with data if you do not want to use that in the RPC on discord.
    /// </summary>
    [SuppressMessage("PropertyChangedAnalyzers.PropertyChanged", "INPC003:Notify when property changes.", Justification = "We do not want to notify when Struct changes")]
    public sealed class RichPresence : PropertyChangedBase
    {
        /// <summary>
        /// Each time we need the struct we will generate a new one. This preserves the immutability and the GC can clean up old ones since there will not be a reference anymore.
        /// </summary>
        public RichPresenceStruct Struct => new RichPresenceStruct(_state, _details, _startTimestamp, _endTimestamp, _largeImageKey, _largeImageText, _smallImageKey, _smallImageText, _partyId, _partySize, _partyMax, _matchSecret, _joinSecret, _spectateSecret, _instance);

        private string _state;
        private string _details;
        private long _startTimestamp;
        private long _endTimestamp;
        private string _largeImageKey;
        private string _largeImageText;
        private string _smallImageKey;
        private string _smallImageText;
        private string _partyId;
        private int _partySize;
        private int _partyMax;
        private string _matchSecret;
        private string _joinSecret;
        private string _spectateSecret;
        private bool _instance;
        
        /// <summary>
        /// The user's current status.
        /// Max 128 bytes
        /// </summary>
        public string State
        {
            get => _state;
            set => SetAndNotify(ref _state, value);
        }

        /// <summary>
        /// What the player is currently doing.
        /// Max 128 bytes
        /// </summary>
        public string Details
        {
            get => _details;
            set => SetAndNotify(ref _details, value);
        }

        /// <summary>
        /// Epoch seconds for game start - including will show time as "elapsed".
        /// </summary>
        public long StartTimestamp
        {
            get => _startTimestamp;
            set => SetAndNotify(ref _startTimestamp, value);
        }

        /// <summary>
        /// Epoch seconds for game end - including will show time as "remaining".
        /// </summary>
        public long EndTimestamp
        {
            get => _endTimestamp;
            set => SetAndNotify(ref _endTimestamp, value);
        }

        /// <summary>
        /// Name of the uploaded image for the large profile artwork.
        /// Max 32 bytes
        /// </summary>
        public string LargeImageKey
        {
            get => _largeImageKey;
            set => SetAndNotify(ref _largeImageKey, value);
        }

        /// <summary>
        /// Tooltip for the largeImageKey.
        /// Max 128 bytes
        /// </summary>
        public string LargeImageText
        {
            get => _largeImageText;
            set => SetAndNotify(ref _largeImageText, value);
        }

        /// <summary>
        /// Name of the uploaded image for the small profile artwork,
        /// Max 32 bytes
        /// </summary>
        public string SmallImageKey
        {
            get => _smallImageKey;
            set => SetAndNotify(ref _smallImageKey, value);
        }

        /// <summary>
        /// Tootltip for the smallImageKey,
        /// Max 128 bytes
        /// </summary>
        public string SmallImageText
        {
            get => _smallImageText;
            set => SetAndNotify(ref _smallImageText, value);
        }

        /// <summary>
        /// Id of the player's party, lobby, or group.
        /// Max 128 bytes
        /// </summary>
        public string PartyId
        {
            get => _partyId;
            set => SetAndNotify(ref _partyId, value);
        }

        /// <summary>
        /// Current size of the player's party, lobby, or group.
        /// </summary>
        public int PartySize
        {
            get => _partySize;
            set => SetAndNotify(ref _partySize, value);
        }

        /// <summary>
        /// Maximum size of the player's party, lobby, or group.
        /// </summary>
        public int PartyMax
        {
            get => _partyMax;
            set => SetAndNotify(ref _partyMax, value);
        }

        /// <summary>
        /// Unique hashed string for Spectate and Join.
        /// Max 128 bytes
        /// </summary>
        public string MatchSecret
        {
            get => _matchSecret;
            set => SetAndNotify(ref _matchSecret, value);
        }

        /// <summary>
        /// Unique hashed string for Spectate button.
        /// Max 128 bytes
        /// </summary>
        public string JoinSecret
        {
            get => _joinSecret;
            set => SetAndNotify(ref _joinSecret, value);
        }

        /// <summary>
        /// Unique hashed string for chat invitations and Ask to Join,
        /// Max 128 bytes
        /// </summary>
        public string SpectateSecret
        {
            get => _spectateSecret;
            set => SetAndNotify(ref _spectateSecret, value);
        }

        /// <summary>
        /// Marks the matchSecret as a game session with a specific beginning and end.
        /// </summary>
        public bool Instance
        {
            get => _instance;
            set => SetAndNotify(ref _instance, value);
        }
    }
}
