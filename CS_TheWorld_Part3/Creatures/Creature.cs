using System.Collections.ObjectModel;
using CS_TheWorld_Part3.GameMechanics;
using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.Creatures;

public class Creature : ICreature
{
    public string Name { get; init; }
    
    public string Description { get; init; }
    
    /// <summary>
    /// Note that in a Creature, the StatChart.Exp is how much experience the Player gets from 
    /// </summary>
    public StatChart Stats { get; init; }

    public ReadOnlyDictionary<EquipSlot, IEquipable> Equipment { get; init; }
    public ReadOnlyDictionary<UniqueName, ICarryable> Items { get; init; }
    public Action<ICreature, Command> CombatLogic { get; init; }
}