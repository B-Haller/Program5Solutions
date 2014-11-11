using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalRootPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DigitalRootWithRecursion("87653"));
            Console.WriteLine(DigitalRootWithWhileLoop("86753"));
            Console.ReadKey();
        }

        static int DigitalRootWithRecursion(string rootThis)
        {
            if (int.Parse(rootThis) < 10)
            {
                //only one digit, returns the number
                return int.Parse(rootThis);
            }
            else
            {
                //its more than one digit
                return DigitalRootWithRecursion(rootThis.Sum(x => int.Parse(x.ToString())).ToString());
            }
        }

        static int DigitalRootWithWhileLoop(string rootThis)
        {
            if (rootThis.All(x => char.IsNumber(x)))
            {
                
                while (rootThis.Length > 1)
                {
                    int total = 0;
                    foreach (char digit in rootThis)
                    {
                        total += int.Parse(digit.ToString());
                    }

                    rootThis = total.ToString();
                }

                return int.Parse(rootThis);
                
            }
            else
            {
                return -1;
            }
        }
    }
}
