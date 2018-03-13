# RyaRpc
Discord rich pressence state for games that do not support it themself.

### Currently supported games:
* Counter-Strike: Global Offensive

### Current major issues:
- Discord does not allow us to upload images realtime so they have to be uploaded prematurely.
- Discord does not allow us to change the name of the Game from the application.

### What does it do?
An image says more than a thousand words:
![example](https://i.imgur.com/Pqn3M5o.png)
This image is of an earlier version currently it is way nicer but forgot to take a screenshot.

### How does it work?
RyaRpc works by listening to post requests from CSGO on port 3000 if the game is launched after starting RyaRpc. This is done by using the [GameStateIntegration](https://developer.valvesoftware.com/wiki/Counter-Strike:_Global_Offensive_Game_State_Integration).
When you launch RyaRpc it will add a config file to the CSGO directory that enables the game its post requests to `http://localhost:3000`

### Can I get a VAC ban for this?
It should be impossible to get a VAC ban from using this tool, since this tool does not inject itself nor touch the game process. There are no direct connections with the game nor steam. So it should be 100% safe.
That being said as always I am not responsible for whatever happens with your account.

## Installation

1. Go to the releases tab.
2. Download Setup.exe
3. Run Setup.exe, this will install RyaRpc which automatically updates whenever a new release is available.

## Usage

1. Make sure you have Discord open and logged in.
2. Open RyaRpc, it will automatically add the csgo config to your game.
3. Start the game (if it was already open restart it)

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## Dependencies

* [Stylet](https://github.com/canton7/Stylet) - MVVM framework
* [Serilog](https://github.com/serilog/serilog) - logging framework
* [CSGSI](https://github.com/rakijah/CSGSI) - Gamestate listener and parser for csgo
* [PropertyChangedAlanyzers](https://github.com/DotNetAnalyzers/PropertyChangedAnalyzers) - Analyzer that helps with INPC

## Authors

* **Ryada** - *Initial work* - [RyadaProductions](https://github.com/RyadaProductions)

## License

This project is licensed under the GNU3 License - see the [LICENSE.md](LICENSE.md) file for details
