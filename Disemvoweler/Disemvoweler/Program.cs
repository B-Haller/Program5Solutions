using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler
{
    class Program
    {
        static void Main(string[] args)
        {
            Disemvoweler("Nickelback is my favorite band. Their songwriting can't be beat!");
            Disemvoweler("How many bears could bear grylls grill if bear grylls could grill bears?");
            Disemvoweler("I'm a code ninja, baby. I make the functions and I make the calls.");
            Disemvoweler("I'm too sexy for this vowel. Too sexy for this char. I'm too sexy.");

            Console.ReadKey();
        }
        /// <summary>
        /// takes srting, stripping it of vowels, and outputs
        /// consonants minus special chars as string
        /// and vowels as string
        /// </summary>
        /// <param name="input">string to be checked</param>
        static void Disemvoweler(string input)
        {
            //set var to contain variables to be searched
            var vowels = "aeiou";
            //set var that will contain consonants, but is currently empty
            var consonantString = "";
            //set var that will weed out unwanted special chars
            var unwantedJunk = " ,'!.?";
            //set var that will contain vowels, but is currently empty
            var vowelString = "";
            
            //begin for loop, looping through string
            for (int i = 0; i < input.Length; i++)
            {
                //set var that will take on each letter by index, converting that back to string
                //then back to lower
                string singleLetter = input[i].ToString().ToLower();
                //if statment to check if above var is in the vowels string
                if (vowels.Contains(singleLetter))
                {
                    //if true, add single letter to vowel string
                    vowelString += singleLetter;
                }
                //if above was not true, check junk list against 
                else if (unwantedJunk.Contains(singleLetter))
                {
                    //since we don't want this data, we leave the codeblock blank
                    //so it doesn't do anything with it, effectively removing it
                }
                else
                {
                    //puts all remaining characters in var consonant string
                    consonantString += singleLetter;
                }
            }
            Console.WriteLine("Original: {0}\nDisemvowled: {1}\nVowelGnar: {2}\n", input, consonantString, vowelString);
        }
    }
}
