using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "Week 2 Code Challenge";
            Console.WriteLine("Fizzbuzz: except now with Fizz Buzz Crackle Pop.\n");
            for (int i = 0; i < 20; i++)
            {
                FizzBuzz(i);
            }

            Console.WriteLine("\n\t\t\t<Hit enter to see #4: Letter Counter>");
            Console.ReadLine();
            Console.Clear();

         
            Console.ForegroundColor = ConsoleColor.Green;

            LetterCounter('i', "I love biscuits and gravy. It's the best breakfast ever.");
            Console.WriteLine("\n");
            LetterCounter('n', "Never gonna give you up. Never gonna let you down.");
            Console.WriteLine("\n");
            LetterCounter('s', "Sally sells seashells down by the seashore. She's from Sussex.");

            Console.ReadLine();
        }

        static void FizzBuzz(int num)
        {
            if (num % 3 == 0 && num % 5 == 0)
            {
                Console.WriteLine("Fizz Buzz Crackel Pop");
            }
            else if (num % 5 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (num % 3 == 0)
            {
                Console.WriteLine("Buzzin'");
            }
            else
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// counts letters by input and upper and lower
        /// </summary>
        /// <param name="letter">letter to be counted</param>
        /// <param name="inString">string to check</param>
        static void LetterCounter(char letter, string inString)
        {
            //set int equal to the count of uppercase letters in string
            var upperCaseLetters = inString.Count(x => "ABCDEFGHIJKLMNIOPQRSTUVWYXZ".Contains(x.ToString()));
            //set int equal to the count of lowercase letters in input string
            var lowerCaseLetters = inString.Count(x => "abcdefigjklmniopqurstuvwyxz".Contains(x.ToString()));
            //set int equal to the number of searched input letter in string (converting to lower)
            var numberOfLetters = inString.ToLower().Count(x => x.ToString().Contains(letter.ToString()));
            //writes the results to console
            Console.WriteLine("Input: {0}\nNumber of Lowercases: {1}\nNumber of Uppercases: {2}\n" +
                "Total number of letter {4} found: {3}", inString, lowerCaseLetters, upperCaseLetters, numberOfLetters, letter);
           
            
        }
    }
}
