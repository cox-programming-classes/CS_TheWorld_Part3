
using System.Collections.ObjectModel;
using CS_TheWorld_Part3.GameMechanics;
using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.Creatures;


/// <summary>
/// Player in a game
/// </summary>
public class Player : ICreature
{
    /* ------------------------------------------------------- *
     * Properties (or Attributes)
     * Nouns that describe the "State" of the object.
     * ------------------------------------------------------- */
    
    /// <summary>
    /// The Player's Name.  This can only be set upon initialization.
    /// </summary>
    public string Name { get; init; }
    
    public StatChart Stats { get; init; }


    public Player(string name)
    {
        Name = name;
        Stats = new(10, 10, Dice.D20, new(2, 4));
        
        // By "Adding" a method handler to each of these Events
        // we can define what happens for the player when each
        // of these things happens.
        Stats.OnLevelUp += OnLevelUp;
        Stats.OnDeath += OnOnDeath;
    }

    private void OnOnDeath(object? sender, EventArgs e)
    {
        if (e is OnDeathEventArgs deathArgs)
        {
            TextFormatter.WriteNegative($"Oof that hurt:  Your HP hit {deathArgs.Overkill}");
        }
    }

    private void OnLevelUp(object? sender, EventArgs e)
    {
        TextFormatter.WriteLinePositive($"Congratz You're now Level {Stats.Level}");
    }


    private Dictionary<EquipSlot, IEquipable> _equipment = new();
    public ReadOnlyDictionary<EquipSlot, IEquipable> Equipment => _equipment.AsReadOnly();
    private Dictionary<UniqueName, ICarryable> _items = new();
    public ReadOnlyDictionary<UniqueName, ICarryable> Items => _items.AsReadOnly();
    

    public Action<ICreature, Command> CombatLogic =>
        (creature, command) =>
    {
        
    };
}
