using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CombatSimulatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayGame();
            Console.ReadKey();

        }
    }

    class Enemy
    {   
        //name property
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //hp property
        private int _hp;
        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }
        //is alive property
        private bool _isAlive;
        public bool IsAlive
        {
            get { 
            if (this.HP > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            }
        }
        //enemy constructor, takes name and hit points
        public Enemy(string name, int intialHitPoints)
        {
            this.Name = name;
            this.HP = intialHitPoints;
        }

        public void DoAttack(Player player)
        {
            //new rng
           Random rng = new Random();

            int damage = 0;
            //new rn for attack chance
            int attack = rng.Next(1, 101);
            //80% chance that attack will hit
            if (attack <= 80)
            {
                //it hits, so get rn for damage
               damage = rng.Next(5, 16);
                //subtract the damage from players hp
               player.HP -= damage;
               Console.WriteLine("The {0} insults you for {1} damage.", this.Name, damage);
               Console.WriteLine("\nPress enter");
               Console.ReadLine();
               Console.Clear();

            }
            else
            {
                //enemy misses
                Console.WriteLine("It Missed!");
                Console.WriteLine("\nPress enter");
                Console.ReadLine();
                Console.Clear();
            }
        }


       
    }
    class Player
    {
        //name property
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //health property
        private int _hp;
        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }
        //is aive property
        private bool _isAlive;
        public bool IsAlive
        {
            get
            {
                if (this.HP > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //type of attacks
        enum AttackType
        {
            Sword = 1,
            Magic = 2,
            Heal = 3
        }
        //player constructor
        public Player(string name, int intialHitPoints)
        {
            this.Name = name;
            this.HP = intialHitPoints;
        }

        private AttackType ChooseAttack()
        {
            //inform player of attack types 
            Console.WriteLine("\n\n<1> Attack with cardboard sword. " +
               "\n<2> Attack with WD-40 and lighter." +
               "\n<3> Heal with pills.\n");
            //get choice and store as int
            var playerChoice = int.Parse(Console.ReadLine());

            //return choice as an attack type             
            return (AttackType)playerChoice;
        }
        //declare a new random number generator
        private Random rng = new Random();

        public void DoAttack(Enemy enemy)
        {


            switch (ChooseAttack())
            {
                case AttackType.Sword:

                    //new rn as attack chance
                    int attack = rng.Next(1, 101);
                    //gives 70% of hitting
                    if (attack <= 70)
                    {
                        //get new rn
                        int damage = rng.Next(20, 36);
                        //less damage from enemy health
                        enemy.HP -= damage;
                        Console.WriteLine("\nYou inflict {0} damage to the {1}", damage, enemy.Name);
                    }

                    else
                    {
                        //player missed
                        Console.WriteLine("\nYou missed {0}.", enemy.Name);

                    }

                    break;

                case AttackType.Magic:

                    //new rng for damage, decrease enemy health by that amount
                    int damageDone = rng.Next(10, 16);
                    enemy.HP -= damageDone;
                    Console.WriteLine("\nYour fireball inflicts {0} damages to the {1}", damageDone, enemy.Name);

                    break;

                case AttackType.Heal:

                    Console.WriteLine("\nYou've selected to heal your wound!");
                    //new rn for healing amount
                    int amountHealed = rng.Next(10, 21);

                    //player hp healed by rn amount
                    this.HP += amountHealed;
                    Console.WriteLine("\nYou has been healed by {0} points", amountHealed);
                    break;

                default:

                    Console.WriteLine("\nYou failed to choose a known attack.\nThe dragon takes advantage of your hesitation and attacks.");
                    break;

            }

        }
    }
        class Game
        {
            public Player Player
            { get; set; }
            public Enemy Enemy
            { get; set; }
            //construct new player and enemy
            public Game()
            {
                this.Player = new Player("Gandalf", 100);
                this.Enemy = new Enemy("Dragon", 200);
            }

            private void DisplayCombatInfo()
            {
                Console.WriteLine("Player Health: {0}\nEnemy Health: {1}", Player.HP, Enemy.HP);
            }

            public void PlayGame()
            {
                Console.WriteLine("Yeah, so you thought it'd be a good idea to wander in the woods.\nThen a dragon got pissed.\nAnd you have to fight him.\nSucks to be you.");
                Console.WriteLine("\nPress Enter to do something.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("You find a sword made of cardboard.\nIt does the most damage, but because you are drunk\nyou only manage to hit 70% of the time.");
                Console.WriteLine("\n\nYou also have some WD-40 and a lighter. Hits everytime, baby!");
                Console.WriteLine("\n\nLast you have some left over pills from the party you just left.\nMaybe they will heal you?");
                Console.WriteLine("\nPress Enter if that makes any sense.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Seriously, that dragon may be a bear.\nWhy would you wander into the woods to fight a bear?");
                Console.WriteLine("\nPress Enter to do battle despite not having your full faculties.");
                Console.ReadLine();
                Console.Clear();
                //while both are alive, keep playing
                while (Player.IsAlive && Enemy.IsAlive)
                {
                    //display the combat info
                    DisplayCombatInfo();
                    //player does attack to enemy
                    this.Player.DoAttack(this.Enemy);
                    //enemy does attack to player
                    this.Enemy.DoAttack(this.Player);
                }
                //if player is still alive, player wins
                if (Player.IsAlive)
                {
                    Console.WriteLine("You, sobering up, realize you have been fighting port-o-pottie.\nYou decide to tell no one about this.\nProbably the best decision of the night.");

                }
                //if not, enemy wins
                else
                {
                    Console.WriteLine("Despite your epic battle, you are malled by a bear.\nA dragon? Seriously?\nYour friends will barely be able to bear your death.");
                }
            }

        }
    
  
}
