using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    class Program
    {
        static void Main(string[] args)
        {
        
            GuessThatNumber();
            Console.ReadKey();
        }
        /// <summary>
        /// A cheeky computer game that wishes you to guess a number, and berates you the 
        /// entire times
        /// </summary>
        static void GuessThatNumber()
        {
            //new random number generator
            Random rng = new Random();
            //assigning it to a new var
            var numberToBeGuessed = rng.Next(1, 101);
            //setting up var to keep track of attempts
            var numberOfAttempts = 0;
            //intial instructions
            Console.WriteLine("WHAT? You challenge me! A computer god! To guess a number 1 through 100!\nSo be it. Please enter your number now, mortal, and hit enter.");
            //setting int var for user input and converting string input to int
            int userInput = int.Parse(Console.ReadLine());
            //setting up an if to check that input meets criteria
            if (userInput > 101 || userInput < 0)
            {
                //error display
                Console.WriteLine("Foolish mortal! You have failed. The number must be between 1 and 100.\nI cannot make that clearer. You have failed! Goodbye.");
                //increment attempts
                numberOfAttempts++;
                //request another input
                userInput = int.Parse(Console.ReadLine());

            }
            else
            {   //setting up while loop ending when number has been guessed
                while (userInput != numberToBeGuessed)
                {
                    //if less, indicate they need to guess higher, and increment, new input
                    if (userInput > numberToBeGuessed)
                    {
                        Console.WriteLine("Mortal, you have aimed too high!\nYou cannot yet match the intellect of mysupremeness.\nGuess lower if you wish to defeat me!");
                        numberOfAttempts++;
                        userInput = int.Parse(Console.ReadLine());
                       
                    }
                    else
                    {
                        //if more, indicate they need to guess less, and increment, new input
                        Console.WriteLine("Mortal, your mind is so limited.\nCan you not concieve of a number larger than {0}?\nIf you wish to defeat me, you must guess higher!", userInput);
                        numberOfAttempts++;
                        userInput = int.Parse(Console.ReadLine());
                        
                    }
                }
                //different answers based on guess needed
                if (numberOfAttempts <= 2)
                {
                    Console.WriteLine("Nooooooooooooo! You yourself are a computer god!\nNo haxxxxxxxx!\nNo cheat.\nCan.\nNot.\nAgree. Mortal is cheater. How could you find my number in less than {0} attempt(s)?", numberOfAttempts);
                }
                else if (numberOfAttempts > 2 && numberOfAttempts <= 5)
                {
                    Console.WriteLine("You have successfully shown that you are no match for me, mortal.\nWith a brain the size of a peanut, how could I blame you.\nIt took you {0} attempts. A goldfish could do better!", numberOfAttempts);
                }
                else if (numberOfAttempts > 5 && numberOfAttempts <= 10)
                {
                    Console.WriteLine("Mortal, you are less intelligent than a rock.\nIndeed, a rock at least would not attempt to challenge a god.\nAnd a rock could have guessed this in less than {0} attempts!", numberOfAttempts);
                }
                else
                {
                    Console.WriteLine("I'm really sorry, Mortal. I truly pity such a small intelect.\nPray that you are never forced to make important decisions.\nAfterall, it would take you {0} attempts to make a sensible decision.", numberOfAttempts);
                }
            }
        }
    }
}
