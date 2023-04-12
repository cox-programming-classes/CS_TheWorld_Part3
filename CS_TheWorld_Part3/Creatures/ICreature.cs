using System.Collections.ObjectModel;
using CS_TheWorld_Part3.GameMechanics;
using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.Creatures;

public interface ICreature
{
    public string Name { get; init; }
    public StatChart Stats { get; init; }
    
    public ReadOnlyDictionary<EquipSlot, IEquipable> Equipment { get; }
    
    public ReadOnlyDictionary<UniqueName, ICarryable> Items { get; }
    
    public Action<ICreature, Command> CombatLogic { get; }
}