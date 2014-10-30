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

            Flip(10);    

            Console.ReadKey();

        }
        static void Flip(int numFlip)
        {
            Random rng = new Random();
            int randomNumber = rng.Next(0, 2);

            int numberOfHeads = 0;
            int numberOfTails = 0;

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

            Console.WriteLine("We flipped a coin {0} times\nHeads: {1}\nTails: {2}", numFlip, numberOfHeads, numberOfTails);
        }
    }
}
