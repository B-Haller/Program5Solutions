using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            StringSpeeder("welcome to the world of mean. where all mean is mean, and all nice is mean", 250);
        }
        static void StringSpeeder(string input, int interval)
        {
            foreach (char Char in input.ToCharArray())
            {
                Console.Write(Char);
                System.Threading.Thread.Sleep(interval);
            }
        }

        static void TextPrinter(string textToPrint, int delayTime)
        {
            for (int i = 0; i < textToPrint.Length; i++)
            {
                Console.WriteLine(textToPrint);
                System.Threading.Thread.Sleep(delayTime);
            }
        }
    }
}
