using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Bob = new Player();
            Bob.Name = "Bob";

            Goblin goblin = new Goblin();
            goblin.Name = "Goblin";

            bool result = Battle(Bob.HP, Bob.DPT, goblin.HP, goblin.DPT);

            if (result == true)
            {
                Console.WriteLine("You survived.");
            }
            else if (result == false)
            {
                Console.WriteLine("You dead.");
            }

            Console.WriteLine("Press \"Escape\" to exit.");
            while(Console.ReadKey().Key != ConsoleKey.Escape) { }
        }

        public static void Clear()
        {
            ConsoleKeyInfo clear;
            Console.WriteLine("\n\tPress \"C\" to clear the console or press any other key to continue.");
            clear = Console.ReadKey();
            if (clear.Key == ConsoleKey.C)
            {
                Console.Clear();
            }
        }

        public static bool Battle(int HP_Player, int DPT_Player, int HP_Monster, int DPT_Monster)
        {
            ConsoleKeyInfo input;

            Random random = new Random();
            do
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine($"\nYou have {HP_Player} hp.");

                int Dice_Player = random.Next(1, 6);
                Console.WriteLine($"\nYou roll {Dice_Player} on the dice.");
                Console.WriteLine("Press \"a\" to attack.");
                int Dice_Monster = random.Next(1, 6);

                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.A)
                {


                    Console.WriteLine($"\nMonster roll {Dice_Monster} on the dice.");
                    if (Dice_Player > Dice_Monster)
                    {
                        Console.WriteLine("\nYou hit the monster.");
                        HP_Monster -= DPT_Player;
                        Console.WriteLine($"The monster has {HP_Monster} hp.");
                    }
                    else if (Dice_Player == Dice_Monster)
                    {
                        Console.WriteLine("\nYou have exchanged blows.");

                        HP_Monster -= DPT_Player;
                        HP_Player -= DPT_Monster;

                        Console.WriteLine($"The monster has {HP_Monster} hp.");
                    }
                    else
                    {
                        Console.WriteLine("\nThe monster hit you.");
                        HP_Player -= DPT_Monster;
                    }
                }
                else
                {
                    Console.WriteLine("You run away from the battle.");
                }
            } while (input.Key == ConsoleKey.A && HP_Player > 0 && HP_Monster > 0);

            if (HP_Player <= 0)
            {
                return false;
            }

            return true;
        }


    }
}
