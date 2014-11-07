using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "List of Berries";

            List<string> funTimeList = new List<string>() {"blueberry", "strawberry", "appleberry", "peachberry", "bacon", "soy"};

            Console.WriteLine(string.Join(", ", funTimeList.OrderBy(x => x)) + "\n");

            Console.WriteLine(string.Join(", ", funTimeList.Where(x => x.Contains("berry")))+ "\n");

            Console.WriteLine(string.Join(", ", funTimeList.Where(x => !x.Contains("berry")).OrderBy(x => x.Length))+ "\n");

            Console.WriteLine(string.Join(", ", funTimeList.Where(x => x.Length >= 5))+ "\n");

            Console.WriteLine("Total number of characters: {0}\nAverage number of characters: {1}\n", funTimeList.Sum(x => x.Length) + "\n", funTimeList.Average(x => x.Length));

            Console.WriteLine(string.Join("", funTimeList.Select(x => x + " has " + x.Count(y => "aeiou".Contains(y))+ " vowels in it.\n")));

            string countMyVowels = "beefhardchest and the rock steady seven";
            int numOfVowels = countMyVowels.Count(x => "aeiou".Contains(x.ToString().ToLower()));

            Console.WriteLine(numOfVowels);


;
            
            Console.ReadLine();
        }
    }
}
