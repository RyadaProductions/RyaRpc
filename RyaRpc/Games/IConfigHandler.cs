namespace RyaRpc.Games
{
    public interface IConfigHandler
    {
        /// <summary>
        /// Adds a config file to the game files if needed to enable listening to their api
        /// </summary>
        void AddConfig();
    }
}
