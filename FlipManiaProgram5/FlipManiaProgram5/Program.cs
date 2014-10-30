using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipManiaProgram5
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Flip(10000);
            FlipForHeads(10000);
    

            Console.ReadKey();

        }
        /// <summary>
        /// flips a coin, keep track of heads and tails
        /// </summary>
        /// <param name="numFlip">number of times to flip</param>
        static void Flip(int numFlip)
        {
            //new random number and setting it to a variable
            Random rng = new Random();
            int randomNumber = rng.Next(0, 2);

            //set variables to track heads and trail
            int numberOfHeads = 0;
            int numberOfTails = 0;
            //loop and conditions to continue flip
            for (int i = 0; i <= numFlip; i++)
            {
                randomNumber = rng.Next(0, 2);
                if (randomNumber == 0)
                {
                    numberOfHeads++;
                }
                else
                    numberOfTails++;
                
            }
            Console.WriteLine("We flipped a coin " + numFlip + " times.");
            Console.WriteLine("Number of Heads: " + numberOfHeads);
            Console.WriteLine("Number of Tails: " + numberOfTails);

            //Console.WriteLine("We flipped a coin {0} times\nHeads: {1}\nTails: {2}", numFlip, numberOfHeads, numberOfTails);
        }
        /// <summary>
        /// Function will flip a coin trying to find
        /// a set number of heads, tracking number of
        /// flips needed
        /// </summary>
        /// <param name="numberOfHeads">number of heads we want to find</param>
        static void FlipForHeads(int numberOfHeads)
        {
            //set variables for number of heads found
            //and total number of flips
            int numberOfHeadsFlipped = 0;
            int totalFlips = 0;
            //new random number generator
            Random rng = new Random();
            
            //loop setting conditions so it will stop
            //when we reach  designated numbers
            while (numberOfHeads != numberOfHeadsFlipped)
            {
                //setting variable to a new random number
                int randomNumber = rng.Next(0, 2);

                //conditions for flip
                if (randomNumber == 0)
                {
                    //found heads, incrmenting variable
                    numberOfHeadsFlipped++;
                }
                //incrementing variable regardless
                totalFlips++;
            }
            //write outcome to console
            Console.WriteLine("We are flipping a coin until we find {0} heads\nIt took {1} to find {2} heads.", numberOfHeads, totalFlips, numberOfHeads);
        }
    }
}
