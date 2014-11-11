using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatsLambdaReview
{
    class Program
    {
        static void Main(string[] args)
        {
            TextStats("Time to bite the bullet");
            TextStats("I saw the sign");
            TextStats("Don't put baby in a corner");
            Console.ReadKey();


        }

        static void TextStats(string inputString)
        {
            Console.WriteLine("\n\nInput string: {0}", inputString);
            Console.WriteLine("# of chars: {0}", inputString.Replace(" ", "").Length);
            Console.WriteLine("# of words: {0}", inputString.Split(' ').Length);
            Console.WriteLine("# of vowels: {0}", inputString.Count(x => "aeiou".Contains(x.ToString().ToLower())));
            Console.WriteLine("# of consonants: {0}", inputString.Count(x => "qwrtypsdfghjklzxcvbnm".Contains(x.ToString().ToLower())));
            Console.WriteLine("# of special chars: {0}", inputString.Count(x => ". ?'';:$,".Contains(x)));
            Console.WriteLine("Longest word: {0}", inputString.Split(' ').OrderByDescending(x => x.Length).First());
            Console.WriteLine("Shortest word: {0}", inputString.Split(' ').OrderBy(x => x.Length).First());

        }
    }
}
