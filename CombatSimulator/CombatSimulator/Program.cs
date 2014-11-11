using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        //declare globals for other functions
        static Random rng = new Random();
        //health
        static int playerHP = 100;
        static int computerHP = 200;
        static string computerName = "The Supreme Leader, Kim Jung-Il";
        //stat counters
        static int sanctionsCount = 0;
        static int tittyTwisterCount = 0;
        static int healingFarts = 0;
        static int diplomacyTries = 0;
        static int computerAngerLevel = 0;


        static void Main(string[] args)
        {
            DiplomacySimulator();

        }

        /// <summary>
        /// plays the diplomacy simulator
        /// </summary>
        static void DiplomacySimulator()
        {
            //sets colors, title, greeting, and recieves user name
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Diplomacy Simulator V.1";
            Console.WriteLine("\n\t\t\tWelcome to the Diplomacy Simulator.\n\n\n\n\n\nPlease enter your name and hit enter to begin.\n");
            var userName = Console.ReadLine();
            Console.Clear();
            //instructions
            Console.WriteLine("Greetings President {0}.\n\nThis is a training simulation for your upcoming negotiations.\n\nThis software has been "
            + "modeled based on all available data.\nIn order to avoid hostilities with North Korea, you must defeat its leader\n{1} with extreme prejudice." + 
            "\nYou have a number of tactics to choose from, some with unforseen complications.", userName, computerName);
            Console.WriteLine("\n\n\t\t\t\t<Press enter>");
            Console.ReadLine();
            Console.Clear();
            //list of choices
            Console.WriteLine("The following are your Diplomacy options:\n\n\n<1> Physical Negotiations. This does the most damage but only works sometimes.\n"
            + "<2> Political Sanctions: This does less damage, but works every time.\n<3> Mental Respite: This heals your fatigue and health."
            + "\n<4> Verbal Negotiations. This almost always fails. Almost always.\n<5> Anger Management: This abates {0}'s anger. If he becomes too angry,"
            +" negotiations may turn ugly.\n<6> CIA Mental Fortififcation Pills: Has since been redacted. \n\n\n<Please press enter to confirm you are ready to begin simulation>\n", computerName);
            Console.ReadLine();
            Console.Clear();
            bool Playing = true;
            //what to do while playing
            while (Playing)
            {
                //display stats for player and comp
                Console.WriteLine("President {0}'s Health: {1}\n{2}'s Health: {3}\n{2}'s Anger: {4}", userName, playerHP, computerName, computerHP, computerAngerLevel);
                //sets warning if anger level gets too high
                if (computerAngerLevel == 11)
                {
                    Console.WriteLine("\n\nWARNING: {0}'s anger is going critical.\n\n", computerName);
                }
                //sets conditions to stop playing
                if (computerHP <= 0 || playerHP <= 0 || computerAngerLevel >= 12)
                {
                    Playing = false;
                    Console.Clear();
                    break;
                }
                //what to do if we are still playing
                else
                {
                    //offer choices of action
                    Playing = true;
                    Console.WriteLine("\nChoose your method of de-escalation, then hit enter.\n\n<1>Physical Negotiation\n<2>Sanctions\n<3>Health\n<4>Verbal Negotiate\n<5>Anger Management Therapy\n\n");
                    //get user choice
                    int userInput = int.Parse(Console.ReadLine());
                    //pass that choice to user attack function
                    userAttack(userInput);
                    //call computer attack function
                    computerAttack();

                }
            }
            //set condition for both parties to lose
            if (computerAngerLevel >= 12)
            {
                Console.WriteLine("That's it, President {0}.\n\nWhatever you just did was the last straw.\n{1} just began a nuclear war.\n\n\n\n\n\n\t\t\tChances are high you will not get relected.", userName, computerName);
                Console.ReadKey();
            }
            //set condition for player loss
            else if (playerHP <= 0)
            {
                Console.WriteLine("Well that went well.\n\nAnd by well, I mean terrible.\n\nAnd by terrible, I mean you just made {0}\nKing of America. Glad I didn't vote for you.", computerName);
                Console.ReadKey();
            }
            //else player wins
            else
            {
                Console.WriteLine("Well, as a computer, that was the strangest negotiation I have ever modeled.\nSeriously, how did that work?\n\nYour methodology for negotiations will be"
                + "taught for thousands of years.\nHell, they'll probably put your face on space dollars.\nSpace dollars.\n\nNice job sir.");
                Console.ReadKey();
            }

        }

        /// <summary>
        /// runs a series of commands based on user choice
        /// </summary>
        /// <param name="userInput">user choice for attack</param>
        static void userAttack(int userInput)
        {
            //new random number
            int attackChance = rng.Next(0, 101);

            switch (userInput)
            {
                //different cases depending on user options
                case 1:
                    //percent miss
                    if (attackChance < 30)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nBad news.\n{0} has evaded your titty twister by slapping it away.", computerName);
                        tittyTwisterCount++;
                    }
                    //percent hit
                    else if (30 <= attackChance && attackChance < 90)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        int damageDelt = rng.Next(12, 20);
                        Console.WriteLine("\n\nGood news, everyone.\nYour titty twister made {0}\ncry, and did {1} damage.", computerName, damageDelt);
                        computerHP -= damageDelt;
                        tittyTwisterCount++;
                        computerAngerLevel++;
                    }
                    //percent unintended good event
                    else if (90 <= attackChance && attackChance < 95)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        int healthRestore = rng.Next(5, 25);
                        Console.WriteLine("\n\nYou tweaked your own nipples. That feels nice. You been aroused and restored {0} HP.", healthRestore);
                        playerHP += healthRestore;
                        tittyTwisterCount++;
                    }
                    else
                    //else unintended bad event
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        int healthRestore = rng.Next(5, 25);
                        Console.WriteLine("\n\nYou tweaked {0}'s nipples. He became aroused and it restored {1} of his HP.", computerName, healthRestore);
                        computerHP += healthRestore;
                        tittyTwisterCount++;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n\t\t\t<Press enter to see advisary's responce>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                //for santioning
                case 2:
                    //new rn, attack health by that much
                    Console.ForegroundColor = ConsoleColor.Green;
                    int damageDeltSanctions = rng.Next(6, 14);
                    Console.WriteLine("\n\nYou sanctioned {0}, dealing {1} damage.\nWay to go Henry Kissinger.", computerName, damageDeltSanctions);
                    sanctionsCount++;
                    Console.WriteLine("\n\n\t\t\t<Press enter to see advisary's responce>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                //for healing
                case 3:
                    //heal based on new rn
                    int healingDone = rng.Next(10, 21);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You just fart in a diplomatic meeting.\nBut damn that felt good. HP increased by {0}.", healingDone);
                    playerHP += healingDone;
                    healingFarts++;
                    //special healing with adverse affects for comp and user if criteria is met
                    if (healingDone >= 13)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        int fartDamage = rng.Next(15, 20);
                        Console.WriteLine("\n\nYour fart, which built from a falafel, detonated and decimates the room.\nYou and {0} take {1} nerve gas damage.", computerName, fartDamage);
                        playerHP -= fartDamage;
                        computerHP -= fartDamage;
                        computerAngerLevel++;
                    }

                    Console.WriteLine("\n\n\t\t\t<Press enter to see advisary's responce>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                //diplomacy choice
                case 4:
                    //new random number, 5 percent chance of dealing major damage
                    int diplomacyDamage = rng.Next(1, 101);
                    if (diplomacyDamage < 95)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You, in your poor knowledge of the language, have just insulted {0}\nby telling him" +
                        "that he has man-boobs. This has angered him, understandbly.", computerName);
                        computerAngerLevel++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        int burpDamage = rng.Next(40, 60);
                        computerHP -= burpDamage;
                        Console.WriteLine("You literally just burped in his face.\nIt smells so horrid he passes out, knocking his head on"
                          + " the negotiation table, receiving {0} damage", burpDamage);
                    }

                    diplomacyTries++;
                    Console.WriteLine("\n\n\t\t\t<Press enter to see advisary's responce>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                //anger management
                case 5:
                    //offer different verbal cues based on new rn, and heal based on second new rn
                    int reduceHisAnger = rng.Next(1, 4);
                    int angerReduced = rng.Next(1, 4);
                    if (reduceHisAnger == 1)
                    {
                        Console.WriteLine("You just pretended to be invisible, shouting, 'You can't see me!'\n You made {0} giggle, reducing his anger by {1}.", computerName, angerReduced);
                        computerAngerLevel -= angerReduced;
                    }
                    else if (reduceHisAnger == 2)
                    {
                        Console.WriteLine("You just did a spot on Bill Cosby impression, complete with a 'Theooo' and a 'Jellooo'.\nYou reduced his anger by {0}.", angerReduced);
                        computerAngerLevel -= angerReduced;
                    }
                    else
                    {
                        Console.WriteLine("You just took off your socks and did sock puppets, delighting {0}. His anger abated by {1}", computerName, angerReduced);
                        computerAngerLevel -= angerReduced;
                    }
                    Console.WriteLine("\n\n\t\t\t<P<Press enter to see advisary's responce>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                //hidden CIA option
                case 6:

                    Console.WriteLine("\t\tYou just snorted an experimental drug the CIA gave you.\n\n\t\t/tThis is going to get weird.\n\n\t\t\tHold on tight.\n");
                    //calls tripping function
                    IsTripping();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    //two new rn for damage, for self and comp
                    int kungFuDamage = rng.Next(40, 60);
                    int tripDamage = rng.Next(15, 30);
                    Console.WriteLine("Quick thinking. Unfortunately, you awake to find you are naked doing kungfu.\nYou have knocked out everyone around you, including {0}." +
                    "\nYou check the pulse, realizing you did {1} damage. Plus, your head feels like\nmarshmellows, and you recieve {2} damage.", computerName, kungFuDamage, tripDamage);
                    computerHP -= kungFuDamage;
                    playerHP -= tripDamage;
                    Console.WriteLine("\n\n\t\t\t<Press enter to see advisary's responce>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                //if user input is unexpected, loose turn
                default:

                    Console.WriteLine("I did not understand your choice.\nBut {0} will respond anyway.", computerName);
                    break;

            }

        }

        /// <summary>
        /// runs a series of commands based on user choice
        /// </summary>
        /// <param name="userInput">user choice for attack</param>
       /// <summary>
        /// five options for computer attack
        /// </summary>
        static void computerAttack()
        {
            //new rn to generate computers attack
            switch (rng.Next(0, 5))
            {
                    //verbal assualt
                case 0:
                    //new rn to see how much damage was done
                    int talkDamage = rng.Next(5, 17);
                    Console.WriteLine("{0} begins a long oral history of his life,\nbeginning with how he was born beneath a triple rainbow.\nYou doze, " +
                    "smacking your head on the table. You recieve {1} damage", computerName, talkDamage);
                    playerHP -= talkDamage;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n\t\t<Press enter to plan your next move>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                    //physical attack miss
                case 1:
                    //missed attack
                    Console.WriteLine("{0} takes a swing, but you duck, evading his attack but making him angry.", computerName); 
                    computerAngerLevel++;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n\t\t<Press enter to plan your next move>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                    //propganda video damage
                case 2:
                    //new rn, damage increment
                    int propagandaVideoDamage = rng.Next(8, 13);
                    Console.WriteLine("{0} forces you to watch a propoganda video that      makes you look fat. You cry, recieving {1} self-esteem damage", computerName, propagandaVideoDamage);
                    playerHP -= propagandaVideoDamage;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n\t\t<Press enter to plan your next move>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                    //health restore
                case 3:
                    //new rn for healing done
                    int healComputer = rng.Next(5, 11);
                    Console.WriteLine("{0} ate Cheetos, restoring {1} health.", computerName, healComputer);
                    computerHP += healComputer;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n\t\t<Press enter to plan your next move>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                    //super attack
                case 4:
                    //twenty percent chance of super attack
                    int superAttack = rng.Next(10, 20);
                    Console.WriteLine("{0} removes his toupe and begins to choke you with  it. This is highly effective and causes {1} damage.", computerName, superAttack);
                    playerHP -= superAttack;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n\t\t<Press enter to plan your next move>");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }

        }
        /// <summary>
        /// performs CIA acid trip for easter egg
        /// </summary>
        static void IsTripping()
        {
            //sets tripping to true and sets up counters and new RNG
            bool tripping = true;
            var redCounter = 0;
            var blueCounter = 0;
            var whiteCounter = 0;
            Random newRNG = new Random();
            //starts tripping
            while (tripping)
            {
                Console.Write(" ");
                Console.Beep(200, 200);
                                
                //switch that continuallys grabs new rn
                switch (newRNG.Next(0, 3))
                {
                        //if 0, print red, increment red counter
                    case 0:
                        Console.BackgroundColor = ConsoleColor.Red;
                        
                        redCounter++;
                        //if red = 75, stops tripping
                        if (redCounter >= 75)
                        {
                            tripping = false;
                            break;
                        }
                        break;
                        //if 1, print blue, increment blue counter
                    case 1:
                        Console.BackgroundColor = ConsoleColor.Blue;
                        
                        blueCounter++;
                        //if blue = 75, stops tripping
                        if (blueCounter >= 75)
                        {
                            tripping = false;
                            break;
                        }
                        break;
                        //if 2, print white, increment white counter
                    case 2:
                        Console.BackgroundColor = ConsoleColor.White;
                       
                        whiteCounter++;
                        //if white = 75, stop tripping
                        if (whiteCounter >= 75)
                        {
                            tripping = false;
                            break;
                        }
                        break;
                }
                
            }

        }
    }
}
