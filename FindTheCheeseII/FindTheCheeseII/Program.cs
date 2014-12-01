using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheCheeseII
{
    //enums for types of points
    public enum PointStatus
    {
        Empty,
        Cheese,
        Mouse,
        Cat,
        CatAndCheese
    }
    //class of points
    class Point
    {
        //contains x int
        public int x { get; set; }
        //contains y int
        public int y { get; set; }
        //status of the point based on enum
        public PointStatus Status { get; set; }
        //constructor that takes x and y params
        public Point(int xCoordinate, int yCoordinate)
        {
            //set propertyies according to x and y, default type is empty
            this.x = xCoordinate;
            this.y = yCoordinate;
            this.Status = PointStatus.Empty;
        }
    }
    //class for my mouse
    class MousePoint
    {
        //point that is the mouse
        public Point theMouse { get; set; }
        //energy prop
        public int Energy { get; set; }
        public MousePoint()
        {
            //new randoms for x and y
            Random rng = new Random();
            int mouseXVal = rng.Next(10);
            int mouseYVal = rng.Next(10);
            //place the mouse based on those values
            theMouse = new Point(mouseXVal, mouseYVal);
            //set intial energy level
            this.Energy = 50;
            
        }
    }
    //class for cat
    class CatPoint
    {
        //point that is a cat
        public Point theCat { get; set; }
        //constructor for cat
        public CatPoint()
        {
            //get new randon x an y values and assign them to cat point
            Random rng = new Random();
            int catXVal = rng.Next(10);
            int catYVal = rng.Next(10);
            theCat = new Point(catXVal, catYVal);

        }
    }
    //class for cheese
    class CheesePoint
    {
        //create a prop for cheese point
        public Point theCheese { get; set; }
        public Random rng { get; set; }
        //constructor
        public CheesePoint()
        {
            //new random for x and y, place cheese at those coordinates
            rng = new Random();
            int cheeseXVal = rng.Next(10);
            int cheeseYVal = rng.Next(10);
            theCheese = new Point(cheeseXVal, cheeseYVal);

        }
    }



    class CheeseFinder
    {
        //prop for the grid
        public Point[,] Grid { get; set; }
        //prop for our mouse
        public MousePoint Mouse1 { get; set; }
        //prop for cheese
        public CheesePoint Cheese { get; set; }
        //prop for cat
        public CatPoint Cat { get; set; }
        //list tat hold all out cats
        public List<CatPoint> CatList { get; set; }
        //new rng
        public Random rng { get; set; }
        // holds value for whether mouse has been eaten
        public bool isEatenByCat { get; set; }
        //wether cheese has been found
        public bool cheeseFound { get; set; }
        //counts moves
        public int CurrentRound { get; set; }
        //how many cheese have been eaten
        public int CheeseCount { get; set; }

        //contructor
        public CheeseFinder()
        {
            //grads a new grid, 10 by 10
            Grid = new Point[10, 10];
            //populates it wth a nested for loop
            for (int yVal = 0; yVal < 10; yVal++)
            {
                for (int xVal = 0; xVal < 10; xVal++)
                {
                    Grid[xVal, yVal] = new Point(xVal, yVal);
                }
            }
            //create new cat, mouse, list points 
            this.Cat = new CatPoint();
            this.Mouse1 = new MousePoint();
            this.CatList = new List<CatPoint>();
            //set is eaten and cheese found both to false
            this.cheeseFound = false;
            this.isEatenByCat = false;
            //new rng
            this.rng = new Random();
            //calls place cheese method, placing cheese
            PlaceCheese();
            //while the mouse and cheese occupy the same position
            while (Mouse1.theMouse.x == Cheese.theCheese.x
                && Mouse1.theMouse.y == Cheese.theCheese.y)
            {
                //place the mouse in a new position
                Mouse1.theMouse = new Point(rng.Next(10), rng.Next(10));
            }

            //update the grid to reflect both the mouse and cheese position
            Grid[Mouse1.theMouse.x, Mouse1.theMouse.y].Status = PointStatus.Mouse;
            Grid[Cheese.theCheese.x, Cheese.theCheese.y].Status = PointStatus.Cheese;
            

        }
        //place cheese function
        public CheesePoint PlaceCheese()
        {
            //creates a new cheese object
            Cheese = new CheesePoint();
            //returns that cheese, which has already gotten a new location from its constructor
            return Cheese;
        }
        //adds a cat
        public void AddCat()
        {
            //adds a cat object to our list
            this.CatList.Add(Cat);
        }
        //places cat
        public CatPoint PlaceCat()
        {
            //new rng and flag
            Random rng = new Random();
            bool isPlaced = false;
            do
            {
                //new x and y withh upper x and y of grid as exclusive param
                int randX = rng.Next(Grid.GetUpperBound(0) + 1);
                int randY = rng.Next(Grid.GetUpperBound(1) + 1);
                //assigns those values to cats x and y
                Cat.theCat.x = randX;
                Cat.theCat.y = randY;
                //if that space is empty
                if (Cat.theCat.Status == PointStatus.Empty)
                {
                    //then the cat can be placed
                    isPlaced = true;
                }
            }
            //continue to do this until cat is placed
            while (!isPlaced);
            //return the cat object
            return Cat;
        }
        //moves the cats
        public void MoveCats(CatPoint Cat)
        {
            //set chance of movemnet to 80%
            Random rng = new Random();
            int chanceOfMove = rng.Next(10);
            //if 80% chance was met
            if (chanceOfMove > 1)
            {
                //if the mouse is to the left
                if (Cat.theCat.x - this.Mouse1.theMouse.x > 0)
                {
                    //and if that space is empty
                    if (Grid[Cat.theCat.x - 1, Cat.theCat.y].Status == PointStatus.Empty)
                    {
                        //the old cat position is now empty
                        Grid[Cat.theCat.x, Cat.theCat.y].Status = PointStatus.Empty;
                        //the new position is the cat 
                        Grid[Cat.theCat.x - 1, Cat.theCat.y].Status = PointStatus.Cat;
                        //update the cats position by moving it to the right
                        Cat.theCat.x -= 1;
                        
                    }

                }
                //if the mouse is above the cat
                else if (Cat.theCat.y - this.Mouse1.theMouse.y > 0)
                {
                    //if that space is empty
                    if (Grid[Cat.theCat.x, Cat.theCat.y - 1].Status == PointStatus.Empty)
                    {
                        //move the cat up, update the cats position and modify the grid
                        Grid[Cat.theCat.x, Cat.theCat.y].Status = PointStatus.Empty;
                        Grid[Cat.theCat.x, Cat.theCat.y - 1].Status = PointStatus.Cat;
                        Cat.theCat.y -= 1;

                    }
                }
                    //if the mouse is to the right
                else if (Cat.theCat.x - this.Mouse1.theMouse.x < 0)
                {
                    //if that space is empty
                    if (Grid[Cat.theCat.x + 1, Cat.theCat.y].Status == PointStatus.Empty)
                    {
                        //move the cat left, update the grid and the cats position
                        Grid[Cat.theCat.x, Cat.theCat.y].Status = PointStatus.Empty;
                        Grid[Cat.theCat.x + 1, Cat.theCat.y].Status = PointStatus.Cat;
                        Cat.theCat.x += 1;

                    }
                }
                    //if the mouse is below
                else if (Cat.theCat.y - this.Mouse1.theMouse.y < 0)
                {
                    //if that space is empty
                    if (Grid[Cat.theCat.x, Cat.theCat.y + 1].Status == PointStatus.Empty)
                    {

                        //move the cat down, update grid and cats position
                        Grid[Cat.theCat.x, Cat.theCat.y].Status = PointStatus.Empty;
                        Grid[Cat.theCat.x, Cat.theCat.y + 1].Status = PointStatus.Cat;
                        Cat.theCat.y += 1;
                    }

                    }
                    //if that cat has eaten the mouse
                else if (Cat.theCat.y - this.Mouse1.theMouse.y == 0
                    && Cat.theCat.x - this.Mouse1.theMouse.x == 0)
                    {
                    //mouse dissappears, and grid reflects the cat
                        Grid[Cat.theCat.x, Cat.theCat.y].Status = PointStatus.Cat;
                    //is eaten set to true
                        isEatenByCat = true;
                    }
                    //allows cats to wait to pounce
                else
                {
                    //sets them on the grid
                    Grid[Cat.theCat.x, Cat.theCat.y].Status = PointStatus.Cat;
                }

            }


        }
        //draws grid
        public void DrawGrid()
        {
            //sets console window and height
            Console.Clear();
            Console.WindowWidth = 100;
            Console.WindowHeight = 40;
            //draws the grid
            for (int yVal = 0; yVal < 10; yVal++)
            {
                for (int xVal = 0; xVal < 10; xVal++)
                {
                    //uses a switch statement to populate the grid with pictures
                    switch (Grid[xVal, yVal].Status)
                    {
                        case PointStatus.Empty:
                            Console.Write("|         ");
                            break;
                        case PointStatus.Cheese:
                            Console.Write("|   I>    ");
                            break;
                        case PointStatus.Mouse:
                            Console.Write("|  ~(8:>  ");
                            break;
                        case PointStatus.Cat:
                            Console.Write("|  =^..^= ");
                            break;
                        default:
                            break;
                    }
                }
                //writes the grid to console
                Console.WriteLine();
            }
        }

        //gets user move
        public ConsoleKey GetUserMove()
        {
            //sets up our loop
            while (true)
            {
                //gets user move and sets it to var
                ConsoleKey userMove = Console.ReadKey(true).Key;
                //if it is up, down, left, or right
                if (userMove == ConsoleKey.UpArrow ||
                    userMove == ConsoleKey.DownArrow ||
                    userMove == ConsoleKey.RightArrow ||
                    userMove == ConsoleKey.LeftArrow)
                {
                    //if it is a valid move
                    if (ValidMove(userMove))
                    {
                        //return that move
                        return userMove;
                    }
                    else
                    {
                        //otherwise say you can't move off the grid
                        Console.WriteLine("You can't move off the grid");
                    }
                }
                //if it is not an arrow key, display this message
                Console.WriteLine("Use the arrow keys to move");

            }
        }
        //checks to see if move is valid
        public bool ValidMove(ConsoleKey input)
        {
            //sets up to see if move is within boundaries
            int mouseCurrentX = this.Mouse1.theMouse.x;
            int mouseCurrentY = this.Mouse1.theMouse.y;
            
            switch (input)
            {
                    //checks the move and returns it if it is valid
                case ConsoleKey.UpArrow:
                    return (mouseCurrentY - 1 >= 0);
                case ConsoleKey.DownArrow:
                    return (mouseCurrentY + 1 <= 9);
                case ConsoleKey.RightArrow:
                    return (mouseCurrentX + 1 <= 9);
                case ConsoleKey.LeftArrow:
                    return (mouseCurrentX - 1 >= 0);
            }
            //returns false if it is invalid
            return false;
        }

        //tells the mouse how to move
        public bool MoveMouse(ConsoleKey input)
        {
            int xMove = 0;
            int yMove = 0;
            //switch of movement directions based on input
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
            //updates the mouses position based on input
            Mouse1.theMouse.x = Mouse1.theMouse.x + xMove;
            Mouse1.theMouse.y = Mouse1.theMouse.y + yMove;
            //if the mose occupies the cheese point
            if (Grid[Mouse1.theMouse.x, Mouse1.theMouse.y].Status == PointStatus.Cheese)
            {
                //increment cheese counter and add energy
                CheeseCount++;
                Mouse1.Energy += 25;
                //place new cheese
                PlaceCheese();
                //wait 80 ms so as not to risk rng being reused
                System.Threading.Thread.Sleep(80);
                //while the cat and the cheese occupy the same spot
                while (Cat.theCat.x == Cheese.theCheese.x
                && Cat.theCat.y == Cheese.theCheese.y)
                {
                    //place cheese again
                    PlaceCheese();
                }
                //update the grid
                Grid[Cheese.theCheese.x, Cheese.theCheese.y].Status = PointStatus.Cheese;
                //set cheese found to true
                cheeseFound = true;
            }
            //update the mouses new and old position accordingly
            Grid[Mouse1.theMouse.x - xMove, Mouse1.theMouse.y - yMove].Status = PointStatus.Empty;
            Grid[Mouse1.theMouse.x, Mouse1.theMouse.y].Status = PointStatus.Mouse;
            
            //return false
            return false;

        }

        //plays our game
        public void PlayGame()
        {

            do
            {
               //draws grid
               DrawGrid();
                //writes our energy count and cheese count
               Console.WriteLine("Cheesey Goodness: {0}\nEnergy: {1}", CheeseCount, Mouse1.Energy);
               MoveMouse(GetUserMove());
               //decrease mouse energy every move
               Mouse1.Energy--;
               //counts number of moves
               CurrentRound++;
               //if cheese is found
               if (cheeseFound)
               {
                   //add a cat
                   AddCat();
                   //wait for new rn
                   System.Threading.Thread.Sleep(50);
                   //place the cat
                   PlaceCat();
                   
                   //cheese found now returned to false
                   cheeseFound = false;

                   
               }
                //for every cat in the list
             foreach (CatPoint cat in CatList)
                   {
                 //move cats
                       MoveCats(cat);
                   }  
            }
            //continue to play until energy is 0 or eaten by catt
            while (Mouse1.Energy > 0 && !(isEatenByCat));
            Console.Clear();
            //if energy is 0
            if (Mouse1.Energy == 0)
            {
                Console.WriteLine("You died of exhaustion. But don't worry, you will live in mouse history.\nAnd in the belly of a cat.");
            }
                //if eaten by cat
            else
            {
                Console.WriteLine("You were eaten by a cat.\nWell, hopefully you'll get you have your revenge in about 8 hours.\nHopefully.");
            }

            Console.WriteLine("\n\n\t\t\t\tYou lasted {0} moves", CurrentRound);
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

        class Program
        {
            static void Main(string[] args)
            {
                //call greeting function
                Greeting();
                //create new cheesefinder object
                CheeseFinder newGame = new CheeseFinder();
                //play game
                newGame.PlayGame();
                Console.ReadKey();
            }
            //greets players
            static void Greeting()
            {
                Console.WriteLine("         _   _");
                Console.WriteLine("        (q\\_/p)");
                Console.WriteLine("    .-.  |. .|");
                Console.WriteLine("       \\ =\\,/=");
                Console.WriteLine("        )/ _ \\  |\\");
                Console.WriteLine("       (/\\):(/\\  )\\");
                Console.WriteLine("        \\_   _/ |Oo\\");
                Console.WriteLine("        `''^''` `'''`'");
                Console.WriteLine("\nHi. I'm you. A mouse version of you.\nAnd you and me buddy, we need that cheese delight." +
                " Problem is the cats.\nWe get a chance at it without them sneaky guys. Then they come a running.\n" +
                "They might move, or they might just watch you.\nIf they stay still, they are waiting to pounce, so be careful!\n" +
                "Also, you..I mean me...is cheeseabetic, so cheese is like our insulin.\nWithout it, we'll run out of energy and get eaten anyway." +
                "\nNow let's get some of that Gouda cheese, buddy!\n\n\t\t\t<Press Enter To Chase Down Some Cheese>");
                Console.ReadKey();
                Console.Clear();
            }


        }
    }
}
