using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        static Random rng = new Random();
        static int playerHP = 100;
        static int computerHP = 200;
        static string computerName = "His Supreme Undying Holy Kim Jung Ill, Touched By God";
        static int sanctionsCount = 0;
        static int tittyTwisterCount = 0;


        static void Main(string[] args)
        {

        }

        static void DiplomacySimulator()
        {

        }


        static void userAttack(int userInput)
        {
          int attackChance = rng.Next(0,101);

          switch (userInput)
          {
              case 1:
                  if (attackChance < 30)
                  {
                      Console.ForegroundColor = ConsoleColor.Red;
                      Console.WriteLine("\n\nBad news. {0} has evaded your titty twister by slapping it away.", computerName);
                      tittyTwisterCount++;
                  }
                  else if (30 <= attackChance && attackChance < 90)
                  {
                      Console.ForegroundColor = ConsoleColor.Green;
                      int damageDelt = rng.Next(12, 20);
                      Console.WriteLine("\n\nGood news, everyone. Your titty twister made {0}/ncry, and did {1} damage.", computerName, damageDelt);                      
                      computerHP -= damageDelt;
                      tittyTwisterCount++;
                  }
                  else if (90 <= attackChance && attackChance < 95)
                  {
                      Console.ForegroundColor = ConsoleColor.White;
                      int healthRestore = rng.Next(5,25);
                      Console.WriteLine("\n\nYou tweaked your own nipples. That feels nice. You been aroused and restored {0} HP.", healthRestore);
                      playerHP += healthRestore;
                      tittyTwisterCount++;
                  }
                  else
                  {
                      Console.ForegroundColor = ConsoleColor.Red;
                      int healthRestore = rng.Next(5,25);
                      Console.WriteLine("\n\nYou tweaked {0}'s nipples. He became aroused and it restored {1} of his HP.", computerName, healthRestore);
                      computerHP += healthRestore;
                      tittyTwisterCount++;
                  }
                  Console.WriteLine("\n\n\t\t\t<Press enter to plan your next move>");
                  Console.ReadLine();
                  Console.Clear();
                  break;

              case 2:

                  Console.ForegroundColor = ConsoleColor.Green;
                  int damageDeltSanctions = rng.Next(6,14);
                  Console.WriteLine("\n\nYou sanctioned {0}, dealing {1} damage. Way to go Henry Kissinger.", computerName, damageDeltSanctions);
                  Console.WriteLine("\n\n\t\t\t<Press enter to plan your next move>");
                  Console.ReadLine();
                  Console.Clear();
                  break;

              case 3:

                  int healingDone = rng.Next(6,15);
                  Console.ForegroundColor = ConsoleColor.Green;
                  Console.WriteLine("You just farted in a diplomatic meeting.\nBut damn that felt good. HP increased by {0}.", healingDone);
                  playerHP += healingDone;
                  if (healingDone >= 13)
                  {
                      Console.ForegroundColor = ConsoleColor.Red;
                      Console.WriteLine("Your fart, which built from a falafel, into the equivalent of nerve gas");
                  }

          }
            }
        }
    }
}
