using System;

namespace RyaRpc.Models
{
    /// <summary>
    /// Join Request. This might be removed in the future if i decide to not implement joining/spectating
    /// </summary>
    [Serializable]
    public struct JoinRequest
    {
        /// <summary>
        /// The UserId of the player asking to join.
        /// Max 24 chars
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The username of the player asking to join.
        /// Max 344 chars
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The avatar hash of the player asking to join.
        /// This will be an empty string if the user has no avatar set
        /// </summary>
        public string Avatar { get; set; }
    }
}
