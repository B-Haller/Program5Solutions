using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatsLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            TextStats("I like tacos and burritos. Come on and give me tacos honey. Taco flavored kisses.");
            Console.ReadKey();
        }
        //checks stats on input string
        static void TextStats(string input)
        {
            //new list based on string, splitting on spaces
            List<string> inputList = new List<string>(input.Split(' '));
            //count chars in list by summing lengths of each item
            var numberOfChars = inputList.Sum(x => x.Length);
            //count number of words in list
            var numberOfWords = inputList.Count();
            //count number of vowels contained in string
            var numberOfVowels = input.Count(x => "aeiou".Contains(x.ToString().ToLower()));
            //count number of consonants contained in string
            var numberOfConsonants = input.Count(x => !"aeiou".Contains(x.ToString().ToLower()));
            //count number of special chars in string
            var numberOfSpecialChars = input.Count(x => " !?,.'".Contains(x.ToString()));
            //order list by longest word first, taking that fist one
            var longestWord = inputList.OrderByDescending(x => x.Length).First();
            //order list by shortest word first, taking that one
            var shortestWord = inputList.OrderBy(x => x.Length).First();

            Console.WriteLine("Numbers of characters: {0}\nNumber of words: {1}\nNumber of vowels: {2}\nNumber of consonants: {3}" +
            "\nNumber of special chars: {4}\nLongest word: {5}\nShortest word: {6}", numberOfChars, numberOfWords, numberOfVowels, numberOfConsonants,
            numberOfSpecialChars, longestWord, shortestWord);
            
        }
    }
}
