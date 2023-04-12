using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.Creatures;

namespace CS_TheWorld_Part3.GameMechanics;

using static TextFormatter;

public static partial class Program
{
    #region Global Variables
    /// <summary>
    /// The Player playing the game.
    /// Initialized at the beginning of the Main method.
    /// </summary>
    private static Player _player = null!;
    
    /// <summary>
    /// The area the player is currently in.
    /// Initialized as the result returned by the
    /// InitializeTheWorld() method.
    /// </summary>
    private static Area _currentArea = null!;
    #endregion // global variables
    
    /// <summary>
    /// This is the Explicit start of the program.
    /// </summary>
    /// <param name="args">Not used</param>
    public static void Main(string[] args)
    {
        _currentArea = InitializeTheWorld();
        _player = new(GetPlayerInput("What is your name?"));
        
        WriteLinePositive($"Hello, {_player.Name}");
        string command = GetPlayerInput();
        while (command != "quit")
        {
            ProcessCommandString(command);
            command = GetPlayerInput();
        }
        
        WriteLinePositive("BYE!");
    }
}