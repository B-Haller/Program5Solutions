using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperspace
{
    class Program
    {
        static void Main(string[] args)
        {
            Hyperspace newGame = new Hyperspace();
            newGame.PlayGame();
        }
    }
    //new class for obstacles
    class Unit
    {
        //set x and y prop
        public int X { get; set; }
        public int Y { get; set; }
        //color to print
        public ConsoleColor Color { get; set; }
        //design of obstacle
        public string Symbol { get; set; }
        //determines if it is a space rift
        public bool IsSpaceRift { get; set; }

        //list of obstacles
        List<string> ObstacleList = new List<string> { "!", "%", "()", "&", "#", "?"};
        //new rng var
        Random rng = new Random();

        //constructor
        public Unit(int x, int y)
        {
            //sets values based on params and defaults
            this.X = x;
            this.Y = y;
            this.Symbol = ObstacleList[rng.Next(ObstacleList.Count())];
            this.Color = ConsoleColor.Cyan;

        }
        //constructor with color, string, and bool overloads
        public Unit(int x, int y, ConsoleColor colorSet, string symbolSet, bool isSpaceRift)
        {
            //equates params to property values
            this.X = x;
            this.Y = y;
            this.Symbol = symbolSet;
            this.Color = colorSet;
            this.IsSpaceRift = isSpaceRift;
        }
        //draws units method
        public void Draw()
        {   
            //draws the unit based on x and y, sets the color to color default, and writes the symbol
            Console.SetCursorPosition(X,Y);
            Console.ForegroundColor = Color;
            Console.Write(Symbol);

        }

    }
    //hyperspace class
    class Hyperspace
    {
        //ints for speed and score
        public int PlayerScore { get; set; }
        public int Speed { get; set; }
        //list to hold our obstacles
        public List<Unit> ObstacleList { get; set; }
        //spaceship object
        public Unit SpaceShip { get; set; } 
        //bool whether it is smashed
        public bool Smashed { get; set; }

        //new rng
        Random rng = new Random();  
        //constructor
        public Hyperspace()
        {
            //sets width, height and buffer dimensions
            Console.WindowWidth = 60;
            Console.BufferWidth = 60;
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;
            //sets intial score and speed
            this.PlayerScore = 0;
            this.Speed = 0;
            //is not smashed as deafult
            this.Smashed = false;
            //creates new list of obstaces
            this.ObstacleList = new List<Unit>();
            //creates a new spaceship object using the unit constructor
            this.SpaceShip = new Unit((Console.WindowWidth/2)-1, Console.WindowHeight-1, ConsoleColor.Red,"^", false);
            
            
        }
        //play game method
        public void PlayGame()
        {
            //while the ship isnt smashed
            while (!Smashed)
            {
                //new var for chance of rift
                int riftSpawn = rng.Next(10);
                //rift chance of 10%
                if (riftSpawn > 8)
                {
                    //create new rift using unit contructor
                    Unit rift = new Unit(rng.Next(Console.WindowWidth-2), 5, ConsoleColor.Green, "@", true);
                    //add to list
                    this.ObstacleList.Add(rift);
                }
                else
                {
                    //otherwise create new unit using unit constructor
                    Unit obstacle = new Unit(rng.Next(Console.WindowWidth-2), 5);
                    //adds to list
                    this.ObstacleList.Add(obstacle);
                }
                //moves our ship
                MoveShip();
                //moves our obstacles
                MoveObstacles();
                //draws game
                DrawGame();
                //if speed is less than 170
                if (Speed < 170)
                {
                    //increment speed
                    Speed++;
                }
                //slows the write speed according to speed
                System.Threading.Thread.Sleep(170 - Speed);
            }
        }
        //
        public void MoveShip()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey keyPressed = Console.ReadKey().Key;

                while(Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    

                }
                if (keyPressed == ConsoleKey.RightArrow
                        && SpaceShip.X < (Console.WindowWidth - 2))
                {
                    SpaceShip.X++;
                }
                else if (keyPressed == ConsoleKey.LeftArrow
                    && SpaceShip.X > 0)
                {
                    SpaceShip.X--;
                }
                else
                {
                    Console.WriteLine("Invalid Move");
                }
            }
        }

        public void MoveObstacles()
        {
            List<Unit> newObstacleList = new List<Unit>();

            foreach (Unit obstacle in ObstacleList)
            {
                obstacle.Y++;

                if (obstacle.IsSpaceRift
                    && obstacle.X == SpaceShip.X
                    && obstacle.Y == SpaceShip.Y)
                {
                    Speed -= 50;
                    Smashed = false;
                }
                else if (obstacle.X == SpaceShip.X
                    && obstacle.Y == SpaceShip.Y)
                {
                    Smashed = true;
                }
                if (obstacle.Y < Console.WindowHeight)
                {
                    newObstacleList.Add(obstacle);
                }
                else
                {
                    PlayerScore++;
                    
                }

                
            }
            ObstacleList = newObstacleList;
        }

        public void DrawGame()
        {
            Console.Clear();
            SpaceShip.Draw();

            foreach (Unit obstacle in ObstacleList)
            {
                obstacle.Draw();
            }
            PrintAtPosition(20, 2, "Score: " + this.PlayerScore, ConsoleColor.Green);
            PrintAtPosition(20, 3 , "Speed:" + this.Speed, ConsoleColor.Green);
            
        }

        public void PrintAtPosition(int x, int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);

        }
    }
}
