﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid game = new Grid();
            game.PlayGame();
        }
    }
    
    class Point
    {
        //represents a single point of the Battleship grid
        public enum PointStatus
        {
            Empty,
            Ship,
            Hit,
            Miss
        }
        //or public enum PointStatus{Empty, Ship, Hit, Miss}

        public int X { get; set; }
        public int Y { get; set; }
        public PointStatus Status { get; set; }

        //Constructor
        public Point(int x, int y, PointStatus p)
        {
            this.X = x;
            this.Y = y;
            this.Status = p;
           
        }


    }
    class Ship
    {   //enums of ships
        public enum ShipType
        {
            Carrier,
            Battleship,
            Cruiser,
            Submarine,
            Minesweeper
        }
        public ShipType Type { get; set; }
        
        //list of occupied points
        private List<Point> _occupiedPoints = new List<Point>();
        public List<Point> OccupiedPoints
        {
            get { return _occupiedPoints; }
            set { _occupiedPoints = value; }
        }
        //number of ships destoryed
        public int ShipsDestroyed { get; set; }

        //set length: How many cells does the ship occupy?
        public int Length { get; set; }

        //bool to determine whether the ship is destroyed
        public bool IsDestroyed
        {
            get
            {

                if (OccupiedPoints.All(x => x.Status == Point.PointStatus.Hit))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set { ;}
        }
        //constructor
        public Ship(ShipType typeOfShip)
        {
            this.Type = typeOfShip;
            this.ShipsDestroyed = 0;

            //set the length
            switch (typeOfShip)
            {
                case ShipType.Carrier:
                    this.Length = 5;
                    break;
                case ShipType.Battleship:
                    this.Length = 4;
                    break;
                case ShipType.Cruiser:
                    this.Length = 3;
                    break;
                case ShipType.Submarine:
                    this.Length = 3;
                    break;
                case ShipType.Minesweeper:
                    this.Length = 2;
                    break;
                default:
                    break;
                //no methods
            }
        }
    }
    //GRID -- core of the game, contains points and ships
    class Grid
    {
        public enum PlaceShipDirection
        {
            Horizontal,
            Vertical
        }
        //create a multidimensional array of points using [,]
        private Point[,] _ocean = new Point[10, 10];
        public Point[,] Ocean
        {
            get { return _ocean; }
            set { Ocean = value; }
        }
        //make a list of ships (what ships does the grid hold?)
        private List<Ship> _listOfShips = new List<Ship>();
        public List<Ship> ListOfShips
        {
            get { return _listOfShips; }
            set { ListOfShips = value; }
        }
        //bool AllShipsDestroyed (returns true if all ships IsDestroyed)
        public bool AllShipsDestroyed
        {
            get
            {
                if (this.ListOfShips.All(x => x.IsDestroyed))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //int combatRound
        private int _combatRound = 0;
        public int CombatRound
        {
            get { return _combatRound; }
            set { _combatRound = value; }
        }
        // ---------Constructor---------

        public Grid()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    this.Ocean[x, y] = new Point(x, y, Point.PointStatus.Empty);
                }
            }

            //place ships using place ship

            ListOfShips.Add(new Ship(Ship.ShipType.Carrier));
            ListOfShips.Add(new Ship(Ship.ShipType.Battleship));
            ListOfShips.Add(new Ship(Ship.ShipType.Cruiser));
            ListOfShips.Add(new Ship(Ship.ShipType.Submarine));
            ListOfShips.Add(new Ship(Ship.ShipType.Minesweeper));

            //place ships (all vertically in line by size, just because easier for debugging)
            PlaceShip(ListOfShips[0], PlaceShipDirection.Vertical, 0, 0);
            PlaceShip(ListOfShips[1], PlaceShipDirection.Vertical, 1, 0);
            PlaceShip(ListOfShips[2], PlaceShipDirection.Vertical, 2, 0);
            PlaceShip(ListOfShips[3], PlaceShipDirection.Vertical, 3, 0);
            PlaceShip(ListOfShips[4], PlaceShipDirection.Vertical, 4, 0);

        }
        //-------METHODS-----------
        //place ships

        public void PlaceShip(Ship shipToPlace, PlaceShipDirection direction, int startX, int startY)
        {
            //for loop as many times as the ship is long
            for (int i = 0; i < shipToPlace.Length; i++)
            {
                switch (direction)
                {
                    case PlaceShipDirection.Horizontal:
                        this.Ocean[startX + i, startY].Status = Point.PointStatus.Ship;
                        shipToPlace.OccupiedPoints.Add(new Point(startX + i, startY, Point.PointStatus.Ship));
                        break;
                    case PlaceShipDirection.Vertical:
                        this.Ocean[startX, startY + i].Status = Point.PointStatus.Ship;
                        shipToPlace.OccupiedPoints.Add(new Point(startX, startY + i, Point.PointStatus.Ship));
                        break;

                }

            }
        }
        //displayOcean
        public void DisplayOcean()
        {
            //this displays the grid to the user
            //write the x axis to the console,
            Console.WindowWidth = 50;
            Console.WriteLine(" 0  1  2  3  4  5  6  7  8  9  X ");

            for (int y = 0; y < 10; y++)
            {
                //for each row y
                //write the xaxis notation "||"
                Console.Write("\n"+ y);
                for (int x = 0; x < 10; x++)
                {
                    //for each column x get the point from the ocean using x,y
                    //write the cell to the console using "[x]" for a Hit and "[o]" for a miss
                    switch (Ocean[x, y].Status)
                    {
                        case Point.PointStatus.Hit:
                            Console.Write("[X]");
                            break;
                        case Point.PointStatus.Miss:
                            Console.Write("[O]");
                            break;
                        default:
                            Console.Write("[ ]");
                            break;
                    }

                }
            }
        }
        //controls targeting
        public void Target(int x, int y)
        {

            //if the point chosen is a ship
            if (Ocean[x, y].Status == Point.PointStatus.Ship)
            {
                //change status to hit
                Ocean[x, y].Status = Point.PointStatus.Hit;
                
                

            }
                //if the point chosen is empty
            else if (Ocean[x, y].Status == Point.PointStatus.Empty)
            {
                //change status to miss
                Ocean[x,y].Status = Point.PointStatus.Miss;
                

            }

           
        }
        //handles our play game logic
        public void PlayGame()
        {
            Greeting();

            //while there are still ships
            while(!AllShipsDestroyed)
            {
                //clear the console
                Console.Clear();
                //display the ocean
                DisplayOcean();
                //empty strings
                string userX = " ";
                string userY = " ";
                //while the user x and user y does not contain coordinates
                while (!"1234567890".Contains(userX) && !"123456789".Contains(userY))
                {
                    //ask user to enter y coordinate
                    Console.WriteLine("\nPlease enter a Y coordinate:");
                    userX = Console.ReadLine();
                    //ask user to x coordinate
                    Console.WriteLine("\nPlease enter a X coordinate:");
                    userY = Console.ReadLine();

                }
                //target that position
                Target(int.Parse(userX),int.Parse(userY));
                //increment combat round
                this.CombatRound++;

            }

            EndGreeting();

        }

        public void Greeting()
        {
            Console.WriteLine("Welcome to a Battleship Simulator.\nChoose a x and a y coordinate and try and sink the enemy's hidden ships.");
            Console.WriteLine("\n\nPress Enter To Play!");
            Console.ReadLine();
        }

        public void EndGreeting()
        {
            Console.WriteLine("You have sunk all of the enemy's ships!\nIt took you {0} shots.", CombatRound);
        }

    }
}

