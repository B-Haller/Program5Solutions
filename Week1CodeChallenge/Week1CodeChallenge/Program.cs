using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 20; i++)
            {
                FizzBuzz(i);
            }

            for (int i = 92; i >= 72; i--)
            {
                FizzBuzz(i);
            }

            Yodaizer("I like code");

            TextStats("I believe in a thing called love. Just listen to the rythmn of my heart. Theres a chance we could make it now.");

            for (int i = 1; i <= 25; i = i + 2)
            {
                IsPrime(i);
            }

            Dashinsert(8675309);

            Console.ReadKey();
        }
        /// <summary>
        /// Analyses a number to see if it is divisble by 5, 3, or both
        /// printing fizz, buzz, fizzbuzz repectively
        /// </summary>
        /// <param name="number">number to check</param>
        static void FizzBuzz(int number)
        {
            //checking to see if it is divisible by both
            //5 and 3, if so print fizzbuzz
            if (number % 5 == 0 && number % 3 == 0)
            {
                Console.WriteLine("FizzBuzz!");
            }
            //check if divisible by 5, if yes fizz
            else if (number % 5 == 0)
            {
                Console.WriteLine("Fizz");
            }
            //check if divisble by 3, if yes buzz
            else if (number % 3 == 0)
            {
                Console.WriteLine("Buzz");
            }
            //if not, print number
            else
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// takes a input and yodifies it
        /// </summary>
        /// <param name="text">input to be yodified</param>
        static void Yodaizer(string text)
        {
            //new list creation, populating it ny spliting input
            List<string> yodaSpeak = new List<string>(text.Split());
            //set up bonus condition
            if (yodaSpeak.Count() == 3)
            {
                Console.WriteLine(yodaSpeak[2] + ", " + yodaSpeak[0] + "  " + yodaSpeak[1]);
            }
            //if not three words
            else
            {
                //set up to loop words backwards
                for (int i = yodaSpeak.Count() - 1; i >= 0; i--)
                {


                    Console.Write(yodaSpeak[i] + " ");
                }
            }

        }

        /// <summary>
        /// checks an input for characters, word count, vowel count
        /// consonant count, and special characters
        /// </summary>
        /// <param name="input">input to be checked</param>
        static void TextStats(string input)
        {
            //setting up the needed varaibles
            int charCount = 0;
            int wordCount = 0;
            int vowelCount = 0;
            int consonantCount = 0;
            int specialChar = 0;
            //starting for loop to loop through input
            for (int i = 0; i < input.Length; i++)
            {
                //increasing character count for each item
                charCount++;
            }
            //creating new string, and splitting input in order
            //to break it up by words
            List<string> inputList = new List<string>(input.Split());
            //searching through words
            for (int i = 0; i < inputList.Count(); i++)
            {
                //incrementing for words found
                wordCount++;
            }
            //for loop to check for vowels, characters, or letters
            for (int i = 0; i < input.Length; i++)
            {
                //converting input to string, and making it lowercase
                //to avoid detection problems
                string currentLetter = input[i].ToString().ToLower();
                //setting conditions for vowels
                if (currentLetter == "a" || currentLetter == "e" || currentLetter == "i" || currentLetter == "o" || currentLetter == "u")
                {
                    //increasing vowel count if found
                    vowelCount++;
                }
                //setting conditions for special char
                else if (currentLetter == " " || currentLetter == "." || currentLetter =="?")
                {
                    //increasing speacial char count
                    specialChar++;
                }
                //otherwise increase consonant count
                else
                {
                    consonantCount++;
                }

            }
                //write results to console
                Console.WriteLine("Number of characters: " + charCount);
                Console.WriteLine("Number of words: " + wordCount);
                Console.WriteLine("Number of vowels: " + vowelCount);
                Console.WriteLine("Number of consonants: " + consonantCount);
            
        }
        /// <summary>
        /// checks a number to see if it is prime
        /// </summary>
        /// <param name="number">number to check</param>
        static void IsPrime(int number)
        {
            //set a variable to hold a boolean value
            bool isNotAPrime = true;
            //see if numbers are 1 or two, since both are prime
            if (number == 1 || number == 2)
            {
                //print that it found a prime
                Console.WriteLine(number+ " is a prime");
            }
            //begin for loop to check other numbers
            for (int i = 2; i < number; i++)
			{
               //if number is divisible by any number
               //it is not a prime
			   if (number % i == 0)
                {
                   //if it coud not be divided change variable to false
                    isNotAPrime = false;
                }
              
            }
            //if number couldnt be divided by any other number
            if (isNotAPrime != false)
            {   
                //write that the number is false
                Console.WriteLine(number + " is a prime");
            }
                //otherwise just write the number
            else
            {
                Console.WriteLine(number);
            }
            
            

        }

        /// <summary>
        /// to insert a dash in between numbers that are odd in a string
        /// </summary>
        /// <param name="number">number to check</param>
        static void Dashinsert(int number)
        {
            //converting interger input to string to allow us
            //to loop through
            string stringNumber = number.ToString();
            //create new list from string, spliting it so each number is 
            //seperate
            List<string> numberList = new List<string>(stringNumber.Split());
            //loop through this list, starting at index 0 and going until the
            //length of the list, increasing by 1
            for (int i = 0; i <= numberList.Count()-1; i++)
            {
                //converting indexed char from number list and 
                //assigning it to a string
                string outputString = numberList[i].ToString();
                //same aa above, except increasing index by one to
                //to check if second number is odd
                string secondNumber = numberList[i].ToString();
                //set a variable to include last number since it was left out
                string lastNumber = numberList[numberList.Count() - 1].ToString();
                
                //set if conditions by checking char assigned to variable against conditions
                if (int.Parse(outputString) % 2 != 0 && int.Parse(outputString) != 0)
                {
                    //if the previous condition is met, check to see if the next index
                    //is also not divisble by 2
                    if (int.Parse(secondNumber) % 2 != 0)
                    {
                        //if both conditions have been met, convert back to string,
                        //inserting a dash at index i
                        numberList.ToString().Insert(i, "-");
                    }
                    else if (int.Parse(lastNumber) % 2 != 0)
                    {
                        //if both conditions have been met, convert back to string,
                        //inserting a dash at index i
                        numberList.ToString().Insert(i, "-");
                    }
                }
                 Console.WriteLine(outputString);
            }
               
            
        }
    }
}
