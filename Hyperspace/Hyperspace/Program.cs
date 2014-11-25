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

    class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public string Symbol { get; set; }
        public bool IsSpaceRift { get; set; }


        List<string> ObstacleList = new List<string> { "!", "%", "()", "&", "#", "?"};
        Random rng = new Random();

        public Unit(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = ObstacleList[rng.Next(ObstacleList.Count())];
            this.Color = ConsoleColor.Cyan;

        }

        public Unit(int x, int y, ConsoleColor colorSet, string symbolSet, bool isSpaceRift)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbolSet;
            this.Color = colorSet;
            this.IsSpaceRift = isSpaceRift;
        }

        public void Draw()
        {   
            Console.SetCursorPosition(X,Y);
            Console.ForegroundColor = Color;
            Console.Write(Symbol);

        }

    }

    class Hyperspace
    {
        public int PlayerScore { get; set; }
        public int Speed { get; set; }
        public List<Unit> ObstacleList { get; set; }
        public Unit SpaceShip { get; set; } 
        public bool Smashed { get; set; }

        Random rng = new Random();  

        public Hyperspace()
        {
            Console.WindowWidth = 60;
            Console.BufferWidth = 60;
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;
       
            this.PlayerScore = 0;
            this.Speed = 0;
            this.Smashed = false;
            this.ObstacleList = new List<Unit>();
            this.SpaceShip = new Unit((Console.WindowWidth/2)-1, Console.WindowHeight-1, ConsoleColor.Red,"^", false);
            
            
        }

        public void PlayGame()
        {
            while (!Smashed)
            {
                int riftSpawn = rng.Next(10);
                if (riftSpawn > 8)
                {
                    Unit rift = new Unit(rng.Next(Console.WindowWidth-2), 5, ConsoleColor.Green, "@", true);
                    this.ObstacleList.Add(rift);
                }
                else
                {
                    Unit obstacle = new Unit(rng.Next(Console.WindowWidth-2), 5);
                    this.ObstacleList.Add(obstacle);
                }

                MoveShip();
                MoveObstacles();
                DrawGame();

                if (Speed < 170)
                {
                    Speed++;
                }

                System.Threading.Thread.Sleep(170 - Speed);
            }
        }

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
