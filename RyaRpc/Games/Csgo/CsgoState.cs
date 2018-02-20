﻿using System;
using CSGSI;
using CSGSI.Nodes;
using RyaRpc.Models;
using Stylet;

namespace RyaRpc.Games.Csgo
{
    public class CsgoState : PropertyChangedBase, IGameState
    {
        private readonly GameStateListener _gamestateListener;
        private RichPresence _presence;
        
        /// <summary>
        /// The current state of presence, its only a get and should be notifying updates by doing:
        /// NotifyOnPropertyChange(nameof(Presence));
        /// </summary>
        public RichPresence Presence => _presence;

        /// <summary>
        /// A CsgoState that listens for connections on localhost:3000 and sends a new RPC to discord
        /// </summary>
        public CsgoState()
        {
            _gamestateListener = new GameStateListener(3000);

            _gamestateListener.NewGameState += OnNewGameState;

            // Start the gamestatelistener and if it fails to start close the application with code 1
            if (!_gamestateListener.Start())
            {
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Handler for when there is a new gamestate available.
        /// Changes the RichPresence field and sends the new one to discord
        /// </summary>
        /// <param name="gameState">The new gamestate generated by the gamestatelistener</param>
        private void OnNewGameState(GameState gameState)
        {
            var details = GetGameDetails(gameState.Map);
            // if the gamemode changed reset the start timestamp
            if (_presence.Details != details)
            {
                _presence.StartTimestamp = (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            }

            // get the current gamemode
            _presence.Details = details;

            // gets the current score
            _presence.State = GetGameState(gameState);

            // Set the image to the csgo image
            _presence.LargeImageKey = "csgo";
            _presence.LargeImageText = "Counter Strike";

            RpcClient.UpdatePresence(ref _presence);

            NotifyOfPropertyChange(nameof(Presence));
        }

        /// <summary>
        /// Retrieves a string based on the current gamemode
        /// </summary>
        /// <param name="mapNode">Node which hold all details of the map</param>
        /// <returns>string with the mapname + gamemode</returns>
        private static string GetGameDetails(MapNode mapNode)
        {
            switch (mapNode.Mode)
            {
                case MapMode.Casual:
                    return $"{mapNode.Name} | Casual";
                case MapMode.Competitive:
                    return $"{mapNode.Name} | Competitive";
                case MapMode.DeathMatch:
                    return $"{mapNode.Name} | DeathMatch";
                case MapMode.GunGameProgressive:
                    return $"{mapNode.Name} | Arms Race";
                case MapMode.GunGameTRBomb:
                    return $"{mapNode.Name} | Demolition";
                case MapMode.CoopMission:
                    return $"{mapNode.Name} | Co-op";
                case MapMode.ScrimComp2v2:
                    return $"{mapNode.Name} | Wingman";
                case MapMode.Custom:
                    return $"{mapNode.Name} | Custom";
                default:
                    return "Chilling";
            }
        }

        /// <summary>
        /// Retrieves a string based on the current gamemode
        /// </summary>
        /// <param name="gameState">The current gamestate</param>
        /// <returns>string with a mode dependent score format</returns>
        private static string GetGameState(GameState gameState)
        {
            switch (gameState.Map.Mode)
            {
                case MapMode.Casual:
                case MapMode.Competitive:
                case MapMode.GunGameTRBomb:
                case MapMode.ScrimComp2v2:
                    return $"{gameState.Map.TeamCT.Score} - {gameState.Map.TeamT.Score}";
                case MapMode.DeathMatch:
                    return $"Kills: {gameState.Player.MatchStats.Kills} | Deaths: {gameState.Player.MatchStats.Deaths}";
                case MapMode.GunGameProgressive:
                    return $"Weapon: {gameState.Player.Weapons.ActiveWeapon}";
                case MapMode.CoopMission:
                    return "Friends are important";
                case MapMode.Custom:
                    return "Unknown stats";
                default:
                    return "Hanging out in menu";
            }
        }

        public void Dispose()
        {
            _gamestateListener.Stop();
        }
    }
}
