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

            for (int i = 0; i <= numFlip; i++)
            {
                randomNumber = rng.Next(0, 2);
                Console.WriteLine();
                
            }
        }
    }
}
