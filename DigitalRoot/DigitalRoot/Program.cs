using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            DigitalRoot("31337");
            Console.ReadKey();
        }

        static void DigitalRoot(string rootThis)
        {
            //loops while number is greater than one
            while (rootThis.Length > 1)
            {
                //calls rootit function, with params of rootThis, then assigns it
                //back to rootthis, continually reducing the amount of numbers
                rootThis = RootIt(rootThis);
            }
            //writes answer as number
            Console.WriteLine(int.Parse(rootThis));
        }

        
        static string RootIt(string rootNumber)
        {
            //var to store our total
            int total = 0;
            //new list to store digits
            List<int> listOfDigits = new List<int>(); 
            //loop through each index of rootNumber
            for (int i = 0; i < rootNumber.Length; i++)
            {
                //create var to store converted index of string to number
                int individualNumber = int.Parse(rootNumber[i].ToString());
                //add number to list of numbers
                listOfDigits.Add(individualNumber);
            }
            //for each number in the list
            foreach (var value in listOfDigits)
            {
                //add the number from list to our total
                total += value;
            }
            //returns the total as a string
            return total.ToString();

        }
        
    }
}
