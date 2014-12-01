using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheCheese
{
    public enum PointStatus
    {
        Empty,
        Cheese,
        Mouse,
        Cat
    }
    class Program
    {
        static void Main(string[] args)
        {
            CheeseFinder theGame = new CheeseFinder();
            theGame.PlayGame();
            Console.ReadKey();
        }
    }

    class Point
    {
        public int x { get; set; }

        public int y { get; set; }

        public PointStatus Status { get; set; }

        public Point(int xCoordinate, int yCoordinate)
        {
            this.x = xCoordinate;
            this.y = yCoordinate;
            this.Status = PointStatus.Empty;
        }
    }


    class CheeseFinder
    {
        public Point[,] Grid { get; set; }
        public Point Mouse { get; set; }
        public Point Cheese { get; set; }
        public Point Cat { get; set; }
        public int CurrentRound { get; set; }
        //public int DistanceToTrap { get; set; }

        public string AlertMessage { get; set; }
        public string CheeseSniffer { get; set; }

        public CheeseFinder()
        {
            Grid = new Point[10, 10];
            for (int yVal = 0; yVal < 10; yVal++)
            {
                for (int xVal = 0; xVal < 10; xVal++)
                {
                    Grid[xVal, yVal] = new Point(xVal, yVal);
                }
            }

            Random rng = new Random();

            int mouseXVal = rng.Next(10);
            int mouseYVal = rng.Next(10);
            Mouse = new Point(mouseXVal, mouseYVal);

            int cheeseXVal = rng.Next(10);
            int cheeseYVal = rng.Next(10);
            while (mouseXVal == cheeseXVal && mouseYVal == cheeseYVal)
            {
                cheeseXVal = rng.Next(10);
                cheeseYVal = rng.Next(10);
            }
            Cheese = new Point(cheeseXVal, cheeseYVal);
            //this will sometimes throw an exception as index is out of bounds
            //to fix this just remove the cheese + part
            int catXVal = rng.Next(10);
            int catYVal = rng.Next(10);

            while ((mouseXVal == catXVal && 
                mouseYVal == catYVal)||
                (cheeseXVal == catXVal &&
                cheeseYVal == catYVal))
            {
                //sames as above
                catXVal = rng.Next(10);
                catYVal = rng.Next(10);
            }
            Cat = new Point(catXVal, catYVal);
            

            Grid[mouseXVal, mouseYVal] = Mouse;
            Grid[mouseXVal, mouseYVal].Status = PointStatus.Mouse;
            Grid[cheeseXVal, cheeseYVal] = Cheese;
            Grid[cheeseXVal, cheeseYVal].Status = PointStatus.Cheese;
            Grid[catXVal, catYVal] = Cat;
            Grid[catXVal, catYVal].Status = PointStatus.Cat;
            
        }

        void DrawGrid()
        {
            Console.Clear();
            Console.WindowWidth = 100;
            Console.WindowHeight = 40;
            for (int yVal = 0; yVal < 10; yVal++)
            {
                for (int xVal = 0; xVal < 10; xVal++)
                {
                    switch (Grid[xVal, yVal].Status)
                    {
                        case PointStatus.Empty:
                            Console.Write("[        ]");
                            break;
                        case PointStatus.Cheese:
                            Console.Write("[  I>    ]");
                            break;
                        case PointStatus.Mouse:
                            Console.Write("[~(,, )'>]");
                            break;
                        case PointStatus.Cat:
                            Console.Write("[   |>}  ]");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }


        ConsoleKey GetUserMove()
        {
            while (true)
            {
                ConsoleKey userMove = Console.ReadKey(true).Key;
                if (userMove == ConsoleKey.UpArrow ||
                    userMove == ConsoleKey.DownArrow ||
                    userMove == ConsoleKey.RightArrow ||
                    userMove == ConsoleKey.LeftArrow)
                {
                    if (ValidMove(userMove))
                    {
                        return userMove;
                    }
                    else
                    {
                        Console.WriteLine("You can't move off the grid");
                    }
                }

                Console.WriteLine("Use the arrow keys to move");

            }
        }

        bool ValidMove(ConsoleKey input)
        {
            int mouseCurrentX = this.Mouse.x;
            int mouseCurrentY = this.Mouse.y;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    return (mouseCurrentY - 1 >= 0);
                case ConsoleKey.DownArrow:
                    return (mouseCurrentY + 1 <= 9);
                case ConsoleKey.RightArrow:
                    return (mouseCurrentX + 1 <= 9);
                case ConsoleKey.LeftArrow:
                    return (mouseCurrentX - 1 >= 0);
            }
            return false;
        }


        bool MoveMouse(ConsoleKey input)
        {
            int xMove = 0;
            int yMove = 0;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    yMove = -1;
                    break;
                case ConsoleKey.DownArrow:
                    yMove = 1;
                    break;
                case ConsoleKey.RightArrow:
                    xMove = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    xMove = -1;
                    break;
            }

            if (Grid[Mouse.x + xMove, Mouse.y + yMove].Status == PointStatus.Cheese)
            {
                return true;
            }
            if (CurrentRound == 0)
            {
                AlertMessage = "Avoid the trap. It's invisible.";
            }
            else if ((Math.Abs(Mouse.x - Cat.x) + Math.Abs(Mouse.y - Cat.y)) == 0)
            {
                AlertMessage = "You found the trap. With your head. Ouch!";
            }
            else if ((Math.Abs(Mouse.x - Cat.x) + Math.Abs(Mouse.y - Cat.y)) < 3)
            {
                AlertMessage = "You smell a trap!";
            }
            else if ((Math.Abs(Mouse.x - Cat.x) + Math.Abs(Mouse.y - Cat.y)) > 3 &&
                (Math.Abs(Mouse.x - Cat.x) + Math.Abs(Mouse.y - Cat.y)) < 6)
            {
                AlertMessage = "You heard a trap snap nearby.";
            }
            else
            {
                AlertMessage = "No traps yet...";
            }
            if (CurrentRound == 0)
            {
                CheeseSniffer = "To find the cheese, follow your nose!";
            }
            else if ((Math.Abs(Mouse.x - Cheese.x) + Math.Abs(Mouse.y - Cheese.y)) == 0)
            {
                CheeseSniffer = "That cheese tastes Gouda!";
            }
            else if ((Math.Abs(Mouse.x - Cheese.x) + Math.Abs(Mouse.y - Cheese.y)) < 2)
            {
                CheeseSniffer = "That cheese smells cheezy good.";
            }
            else if ((Math.Abs(Mouse.x - Cheese.x) + Math.Abs(Mouse.y - Cheese.y)) > 2 &&
                (Math.Abs(Mouse.x - Cheese.x) + Math.Abs(Mouse.y - Cheese.y)) < 6)
            {
                CheeseSniffer = "You catch a whif of cut cheese.";
            }
            else
            {
                CheeseSniffer = "It is a wasteland of smellessness.";
            }

            Grid[Mouse.x, Mouse.y].Status = PointStatus.Empty;
            Grid[Mouse.x + xMove, Mouse.y + yMove].Status = PointStatus.Mouse;
            Mouse.x = Mouse.x + xMove;
            Mouse.y = Mouse.y + yMove;
            return false;

        }


        public void PlayGame()
        {
            DrawGrid();

            while (!MoveMouse(GetUserMove()))
            {
                DrawGrid();
                CurrentRound++;
                Console.WriteLine("\nTrapSniffer: {0}", AlertMessage);
                Console.WriteLine("\nCheeseSniffer: {0}", CheeseSniffer);
            }

            Console.WriteLine("\n\n\t\t\t\tYou won! It took you {0} moves", CurrentRound);
            Console.WriteLine("            _   _");
            Console.WriteLine("           (q\\_/p)");
            Console.WriteLine("            /. .\\        __");
            Console.WriteLine("     ,__   =\\_t_/=      .'o O'-.");
            Console.WriteLine("        )   /   \\      / O o_.-`|   _   _");
            Console.WriteLine("       (   ((   ))    /O_.-'  O |  (q\\_/p)");
            Console.WriteLine("        \\  /\\) (/\\    | o   o  o|   /. .\\.-`````-.     ___,");
            Console.WriteLine("         `-\\  Y  /    |o   o O.-`  =\\_t_/=     /  `\\  (");
            Console.WriteLine("            nn^nn     | O _.-'       )\\ ))__ __\\   |___)");
            Console.WriteLine("                      '--`          (/-(/`  `nn---'");
            
        }




    }
}