using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1CodeChallengeReview
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 1; i <= 20; i++)
            //{
            //    FizzBuzz(i);
            //}

            //Yodaizer("I like code.");
            //TextStats("I love to eat great green grasshopers.");

            IsPrime(15);
            //DashInsert(8675309);

            Console.ReadKey();
        }
        static void FizzBuzz(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (number % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (number % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(number);
            }
        }

        static void Yodaizer(string input)
        {
            List<string> wordList = new List<string>(input.Replace(".","").Split(' ').ToList());

            if (wordList.Count() == 3)
            {
                Console.Write(wordList[2] + ", " + wordList[0] + " " + wordList[1]+ "\n");
            }
            else
            {
                for (int i = wordList.Count() - 1; i >= 0; i--)
                {

                    Console.Write(wordList[i] + " ");
                }
            }
        }

        static void TextStats(string input)
        {
            int numberOfCharacters = input.Length;
            int numberOfWords = input.Split(' ').Length;
            int numberOfVowels = 0;
            int numberOfSpecialCharacters = 0;
            int numberOfConsonants = 0;
            string vowels = "aeiou";
            string specialChars = " .?!';:'/$#%^&*()";
            string singleLetter = input.ToLower();

            for (int i = 0; i < input.Length; i++)
			{
			    if (vowels.Contains(singleLetter[i]))
                {
                    numberOfVowels++;
                }
                else if (specialChars.Contains(singleLetter[i]))
                {
                    numberOfSpecialCharacters++;
                }
                else
                {
                    numberOfConsonants++;
                }
			}

            Console.WriteLine("Input: {0}\nChars: {1}\nVowels: {2}\nConsonants: {3}\nSpecial Chars: {4}", input, numberOfCharacters, numberOfVowels, numberOfConsonants, numberOfSpecialCharacters); 
           
        }

        static void IsPrime(int number)
        {
            bool isPrime = true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                }

            }

            if (isPrime == false)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("prime");
            }

            
        }

        static void DashInsert(int number)
        {
            string numberString = number.ToString();
            string outputstring = string.Empty;

            for (int i = 0; i < numberString.Length-1; i++)
            {
                int currentDigit = int.Parse(numberString[i].ToString());
                int nextDigit = int.Parse(numberString[i + 1].ToString());

                if (currentDigit % 2 != 0 && nextDigit % 2 != 0)
                {
                    outputstring += currentDigit + "-";
                }
                else
                {
                    outputstring += currentDigit;
                }
            }
            outputstring += numberString[numberString.Length - 1];

            Console.Write(outputstring);
        }
    }
}
