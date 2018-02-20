using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace RyaRpc.Games.Csgo
{
    public class CsgoConfig
    {
        /// <summary>
        /// Add the cfg file to enable Gamestates to the csgo folder
        /// </summary>
        public void AddConfig()
        {
            var steamPath = GetSteamPath();
            var steamLibraries = GetSteamLibraries(steamPath);
            var csFolder = GetCsgoPath(steamLibraries);

            var originalFile = Path.Combine(Environment.CurrentDirectory, "ConfigFile", "gamestate_integration_rpc.cfg");
            var destinationFile = Path.Combine(csFolder, "csgo", "cfg", "gamestate_integration_rpc.cfg");

            using (var origin = File.OpenRead(originalFile))
            using (var destination = File.Create(destinationFile))
            {
                origin.CopyTo(destination);
            }
        }

        /// <summary>
        /// Get the installation folder of steam based on the registery
        /// </summary>
        /// <returns>A string containing the Path to the steam installation</returns>
        private static string GetSteamPath()
        {
            var steamKey = Registry.LocalMachine.OpenSubKey(@"Software\Valve\Steam") ??
                           Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Valve\Steam");
            return steamKey?.GetValue("InstallPath").ToString() ?? string.Empty;
        }

        /// <summary>
        /// Retrieve all steam libraries based on the steam configuration
        /// </summary>
        /// <param name="steamPath">string with the Path to the steam installation</param>
        /// <returns>List of Path which contains all steam libraries</returns>
        private static IEnumerable<string> GetSteamLibraries(string steamPath)
        {
            var folders = new List<string> { steamPath };
            var configFile = Path.Combine(steamPath, "config", "config.vdf");

            var regex = new Regex("BaseInstallFolder[^\"]*\"\\s*\"([^\"]*)\"");

            foreach (var line in File.ReadAllLines(configFile))
            {
                if (regex.IsMatch(line))
                {
                    folders.Add(Regex.Unescape(line));
                }
            }

            return folders;
        }

        /// <summary>
        /// Get the path to the CounterStrike global offensive installation
        /// </summary>
        /// <param name="libraries">IEnumerable with paths that could contain CSGO</param>
        /// <returns>A string that contains a Path to the Csgo folder, it returns an empty string if it can't find the installation</returns>
        private static string GetCsgoPath(IEnumerable<string> libraries)
        {
            var appFolders = libraries.Select(x => Path.Combine(x, "SteamApps", "common", "Counter-Strike Global Offensive"));

            return appFolders.FirstOrDefault(Directory.Exists) ?? string.Empty;
        }
    }
}
