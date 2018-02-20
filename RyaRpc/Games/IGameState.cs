using System;
using RyaRpc.Models;

namespace RyaRpc.Games
{
    public interface IGameState : IDisposable
    {
        /// <summary>
        /// The current state of presence, its only a get and should be notifying updates by doing:
        /// NotifyOnPropertyChange(nameof(Presence));
        /// </summary>
        RichPresence Presence { get; }
    }
}
