using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopingOverLists
{
    class Program
    {
        static void Main(string[] args)
        {
            LoopOverAList();
            LoopOverWordsInAString("I went to Mars and sat on a fat martian cat");
            Console.ReadKey();

        }

        static void LoopOverAList()
        {
            //create a list of sports
            List<string> SportsList = new List<string>(){ "baseball", "tennis" };
            //add another sport to spowrts list
            SportsList.Add("football");
            //loop over sports list and display all
            //elements that contail the word ball
            for (int i = 0; i < SportsList.Count(); i++)
            {
                //get thhe current sport out of sports list
                string currentSport = SportsList[i];
                //check to see if it is a sport
                //with the word "ball" in it
                if (currentSport.Contains("ball"))
                {
                    //its true
                    Console.WriteLine(currentSport);
                   
                   
                }

            }
        }
        /// <summary>
        /// Print out each word to a string, one per line
        /// </summary>
        /// <param name="inputString">String to loop over</param>
        static void LoopOverWordsInAString(string inputString)
        {
            List<string> wordList = inputString.Split(' ').ToList();
            for (int i = 0; i < wordList.Count(); i++)
            {
                Console.WriteLine(wordList[i]);
            }
        }

    }
}
