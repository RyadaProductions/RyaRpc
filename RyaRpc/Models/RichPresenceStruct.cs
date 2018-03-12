using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyaRpc.Models
{
    /// <summary>
    /// Model for a richpresence struct that needs to be passed into the DllImport
    /// </summary>
    public struct RichPresenceStruct
    {
        public RichPresenceStruct(
            string state, string details, long startTimestamp, long endTimestamp, string largeImageKey,
            string largeImageText, string smallImageKey, string smallImageText, string partyId, int partySize,
            int partyMax, string matchSecret, string joinSecret, string spectateSecret, bool instance)
        {
            State = state;
            Details = details;
            StartTimestamp = startTimestamp;
            EndTimestamp = endTimestamp;
            LargeImageKey = largeImageKey;
            LargeImageText = largeImageText;
            SmallImageKey = smallImageKey;
            SmallImageText = smallImageText;
            PartyId = partyId;
            PartySize = partySize;
            PartyMax = partyMax;
            MatchSecret = matchSecret;
            JoinSecret = joinSecret;
            SpectateSecret = spectateSecret;
            Instance = instance;
        }

        public string State { get; }
        public string Details { get; }
        public long StartTimestamp { get; }
        public long EndTimestamp { get; }
        public string LargeImageKey { get; }
        public string LargeImageText { get; }
        public string SmallImageKey { get; }
        public string SmallImageText { get; }
        public string PartyId { get; }
        public int PartySize { get; }
        public int PartyMax { get; }
        public string MatchSecret { get; }
        public string JoinSecret { get; }
        public string SpectateSecret { get; }
        public bool Instance { get; }
    }
}
