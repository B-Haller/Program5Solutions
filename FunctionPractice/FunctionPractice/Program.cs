using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld();

            int myAgeDoubled = DoubleIt(24);
            Console.WriteLine(DoubleIt(myAgeDoubled));
            LoopTests();
            VowelCounter3000Tests();

            Console.ReadLine();
        }

        /// <summary>
        /// Writes Hello World to the console
        /// </summary>
        static void HelloWorld()
        {
        Console.WriteLine("Hello World!");
        }
        /// <summary>
        /// Function that will double a number
        /// </summary>
        /// <param name="someNumber">the number to be doubled</param>
        /// <returns>double the input number</returns>
        static int DoubleIt(int someNumber)
        {
            return someNumber * 2;
        }
        /// <summary>
        /// Loops from a start number to and end number
        /// </summary>
        /// <param name="startNumber">start number for loop</param>
        /// <param name="endNumber">end number for loop</param>
        static void LoopSomeNumbers(int startNumber, int endNumber)
        {
            for (int i = startNumber; i <= endNumber; i++)
            {
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// runs a series of test on our loop function
        /// </summary>
        static void LoopTests() 
        {
            LoopSomeNumbers(4, 12);
            LoopSomeNumbers(80, 87);
            LoopSomeNumbers(24, DoubleIt(24));
        }
        /// <summary>
        /// returns the number of vowels
        /// in a string
        /// </summary>
        /// <param name="inputString">the string you want to count
        /// the number of vowels</param>
        /// <returns>returns the number of vowels found</returns>
        static int VowelCounter3000(string inputString)
        {
            //declare a counter for the vowels
            int numberOfVowelsFound = 0;

            //loop over each letter of the string
            for (int i = 0; i < inputString.Length; i++)
            {
                //take a letter from the string and 
                //make it lowercase
                string letter = inputString[i].ToString().ToLower();

                if (letter == "a" || letter == "e" || letter == "i" || letter == "o" || letter == "u")
                {
                    //found a vowel
                    numberOfVowelsFound++;
                }

                //alternate way to see if
                //a letter is a vowel
                if ("aeiou".Contains(letter)) { }
     
            }

            //loop complete, time to write the output
            Console.WriteLine(inputString + " It has " + numberOfVowelsFound + " vowels in it.");
            return numberOfVowelsFound;
        }
        /// <summary>
        /// tests vowel counter function
        /// </summary>
        static void VowelCounter3000Tests()
        {
            //count the total number of vowels counted
            int totalNumberOfVowelsCounted = 0;
            totalNumberOfVowelsCounted += VowelCounter3000("Jackies in general seem to like Nickleback.");
            totalNumberOfVowelsCounted += VowelCounter3000("Bears beats Battlestar Galactica.");
            Console.WriteLine("Total Vowels Counted: " + totalNumberOfVowelsCounted);
        }

    }
}
