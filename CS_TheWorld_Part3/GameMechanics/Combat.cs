using CS_TheWorld_Part3.Creatures;
namespace CS_TheWorld_Part3.GameMechanics;
using static TextFormatter;

public static partial class Program
{
    private static List<UniqueName> _battleCommands = new() {"attack", "defend", "flee"};

    public static void DoBattle(Creature creature)
    {
        WriteLineWarning($"You engage {creature.Name} in combat!");
        while (_player.Stats.HP > 0 && creature.Stats.HP > 0)
        {
            var command = (Command)GetPlayerInput("(battle) ");
            if (!_battleCommands.Contains(command.CommandWord))
            {
                WriteLineWarning($"{command.CommandWord} is not a valid command word.");
                continue;
            }

            _player.CombatLogic(creature, command);
            creature.CombatLogic(_player, "");

            if (command.CommandWord == "flee")
            {
                break;
            }
        }
    }
}
