using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.Creatures;
using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.GameMechanics;
using static TextFormatter;

public static partial class Program
{
    /// <summary>
    /// Encapsulate all the basic things that need to happen when a creature is killed.
    /// Use this in the creature.Stats.OnDeath event handler.
    /// </summary>
    /// <param name="creatureUid"></param>
    /// <param name="deadCritter"></param>
    /// <param name="deathMessage"></param>
    private static void OnCreatureDeath(UniqueName creatureUid, ICreature deadCritter, string deathMessage)
    {
        _player.Stats.GainExp(deadCritter.Stats.Exp);
        WriteLineSurprise(deathMessage);
        if (deadCritter.Items.Any())
        {
            WriteLineSurprise($"{deadCritter.Name} drops:");
            foreach (var name in deadCritter.Items.Keys)
            {
                WriteNeutral("\tA [");
                WriteSurprise($"{name}");
                WriteLineNeutral("]");
                // TODO:  There is potentially an error here!  Watchout!
                _currentArea.AddItem(name, (deadCritter.Items[name] as Item)!);
            }
        }
        _currentArea.DeleteCreature(creatureUid);
    }
    
    /// <summary>
    /// Build all the areas and link them together.
    /// </summary>
    /// <returns></returns>
    private static Area InitializeTheWorld()
    {
        // Create a new Area using the init methods for each property.
        var start = new Area()
        {
            Name = "This Place",
            Description = "A barren plane with an ambient temperature around 22C and moderate humidity."
        };

        // Add an item directly into the area.
        // by creating the item directly inside this statement,
        // you can't add more information to the item.
        // Also note that the DataType of "uniqueName" is a
        // UniqueName.  But we are passing a string here!
        // this is the implicit operator at work!
        start.AddItem("rock", 
            new Item()
            {
                Name = "Rock", 
                Description = "It appears to be sandstone and is worn smooth by the wind"
            });
        // create a creature!
        var moth = new Creature()
        {
            Name = "Giant Moth",
            Description = "Holy shit that things huge!",
            Stats = new StatChart(12, 8, Dice.D20, new(1, 6, -1))
        };
        // Here we can assign a lambda expression
        // to be the OnDeath action when the moth is killed
        moth.Stats.OnDeath += (sender, args) =>
        {
            OnCreatureDeath("moth", moth, 
                $"{moth.Name} falls in a flutter of wings and ichor.");
        };
        // Add the Moth to the area.
        start.AddCreature("moth", moth);

        var tundra = new Area()
        {
            Name = "The Tundra",
            Description = "Cold, Barren Wasteland."
        };
        
        start.AddNeighboringArea(new ("NORTH", "Far to the North"), tundra);
        tundra.AddNeighboringArea(new Direction("SOUTH", "Far to the South"), start);
        // return the starting area.
        return start;
    }
}