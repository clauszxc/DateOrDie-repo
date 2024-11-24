// See https://aka.ms/new-console-template for more information

using DateOrDie;
using System.Reflection.Emit;
using System.Xml.Linq;

//int playerHighScore = 1;
//int playerCurrentScore = 1;

Console.WriteLine("Who's playing?");
string playerName = Console.ReadLine();

Console.WriteLine($"\nChoose special attack...\n 1. Bad Boy Beam\n 2. Rizz Raygun\n 3. Lover Boy Blast");
var chosenSpecialAttack = Console.ReadKey().Key;

var chosenChosenSpecialAttack = "Boy Boy Beam";

if (chosenSpecialAttack == ConsoleKey.D1)
{
    chosenChosenSpecialAttack = "Bad Boy Beam";
}
if (chosenSpecialAttack == ConsoleKey.D2)
{
    chosenChosenSpecialAttack = "Rizz Raygun";
}
if (chosenSpecialAttack == ConsoleKey.D3)
{
    chosenChosenSpecialAttack = "Lover Boy Blast";
}
else
{
    Console.WriteLine("Invalid input...");
}

Console.Clear();
Player player = new Player(playerName, 1, 200, 25, chosenChosenSpecialAttack, 100);

Console.WriteLine($"Player: {player.Name} has entered the Dating Zone");
Console.WriteLine($"Level: {player.Level}");
Console.WriteLine($"Health: {player.HitPoints}");
Console.WriteLine($"Attack Power: {player.AttackPower}");
Console.WriteLine($"Special Attack: {player.SpecialAttack}");
Console.WriteLine($"Press any key to continue...");
Console.ReadKey();
Console.Clear();

while (player.HitPoints > 0)
{
    Enemy enemy = new Enemy(player.Level);

    Console.WriteLine($"A Wild {enemy.Name}, the {enemy.Type} Appeared!");
    Console.WriteLine($"Enemy HP: {enemy.HitPoints} Enemy Attack Power: {enemy.AttackPower}");

    while (enemy.HitPoints > 0 && player.HitPoints > 0)
    {
        Console.WriteLine($"What do you want to do...\nPress 1 to attack\nPress 2 to use special attack.");
        var actionChoice = Console.ReadKey().Key;

        Console.Clear();

        if (actionChoice == ConsoleKey.D1)
        {
            DateOrDie.Action.PlayerRegularAttack(player, enemy);
            Console.WriteLine($"You hit the enemy! Enemy HP is now {enemy.HitPoints}!");
        }
        else if (actionChoice == ConsoleKey.D2)
        {
            DateOrDie.Action.PlayerSpecialAttack(player, enemy);
            var (specialAttackResult, updatedHitPoints) = DateOrDie.Action.PlayerSpecialAttack(player, enemy);
            Console.WriteLine($"{specialAttackResult} You hit the enemy with {player.SpecialAttack}! Enemy HP is now {enemy.HitPoints}!");
        }
        else
        {
            Console.WriteLine($"Invalid input");
            continue;
        }

        if (enemy.HitPoints > 0)
        {
            player.TakeDamage(enemy.AttackPower);
            Console.WriteLine($"The enemy hit you! Your HP is now {player.HitPoints}");
        }
    } 

    if (player.HitPoints <= 0)
    {
        Console.WriteLine($"Game over! You made it to level {player.Level}");
        break;
    }
    else
    {
        Console.WriteLine($"You defeated {enemy.Name} and gained experience!");
        player.XPToLevel -= 50;

        if (player.XPToLevel <= 0)
        {
            Console.WriteLine($"You leveled up! Level is now {player.Level}");
            player.Level++;
            player.XPToLevel = 100;
        }
    }

    Console.WriteLine("Press anything to continue...");
    Console.ReadKey();
    Console.Clear();
}
