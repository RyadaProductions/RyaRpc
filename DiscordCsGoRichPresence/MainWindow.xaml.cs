using System;
using System.Linq;
using System.Windows;
using CSGSI;
using CSGSI.Nodes;
using DiscordCsGoRichPresence.Discord_RPC;

namespace DiscordCsGoRichPresence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RpcController Controller = new RpcController();

        private GameStateListener _gamestateListener = new GameStateListener(3000);

        public MainWindow()
        {
            InitializeComponent();

            Controller.Initialize();

            RpcClient.UpdatePresence(ref Controller.Presence);
            TestGameState();
        }

        private void TestGameState()
        {
            // first line of details
            Controller.Presence.details = $"Map: de_dust2 | Score: T 0-15 CT";
            // State is 2nd line
            Controller.Presence.state = $"Score: 20|0|5|4";
            // Test
            Controller.Presence.largeImageKey = "csgo";
            Controller.Presence.largeImageText = "Counter Strike";

            RpcClient.UpdatePresence(ref Controller.Presence);
        }

        private void OnNewGameState(GameState gameState)
        {
            // first line of details
            Controller.Presence.details = GetGameDetails(gameState);
            // State is 2nd line
            Controller.Presence.state = GetGameState(gameState);
            // Test
            Controller.Presence.largeImageKey = "csgo";
            Controller.Presence.largeImageText = "Counter Strike";

            RpcClient.UpdatePresence(ref Controller.Presence);
        }

        private string GetGameDetails(GameState gameState)
        {
            //return $"{gameState.Map.Name} | {gameState.Map.Mode}";

            switch (gameState.Map.Mode)
            {
                case MapMode.Casual:
                    return $"{gameState.Map.Name} | Casual";
                case MapMode.Competitive:
                    return $"{gameState.Map.Name} | Competitive";
                case MapMode.DeathMatch:
                    return $"{gameState.Map.Name} | DeathMatch";
                case MapMode.GunGameProgressive:
                    return $"{gameState.Map.Name} | Arms Race";
                case MapMode.GunGameTRBomb:
                    return $"{gameState.Map.Name} | Demolition";
                case MapMode.CoopMission:
                    return $"{gameState.Map.Name} | Co-op";
                case MapMode.ScrimComp2v2:
                    return $"{gameState.Map.Name} | Wingman";
                case MapMode.Custom:
                    return $"{gameState.Map.Name} | Custom";
                default:
                case MapMode.Undefined:
                    return $"Chilling";
            }
        }

        private string GetGameState(GameState gameState)
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
                    return $"{gameState.Map.Name} | Co-op";
                case MapMode.Custom:
                    return "Unknown details";
                default:
                case MapMode.Undefined:
                    return "Hanging out in menu";
            }
        }
    }
}
