using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program5WordLetterFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            //calling function and inputing params
            LetterFinder("Whatyouwannaeat", "A");
            Console.ReadKey();

        }

        /// <summary>
        /// finds a letter in a word or string
        /// </summary>
        /// <param name="mainStringToSearch">the word or string to search</param>
        /// <param name="letterToFind">letter that will be found and counted</param>
        static void LetterFinder(string mainStringToSearch, string letterToFind)
        {
            //sets a variable to hold count
            //since we have yet to find one
            //it starts at zero
            int letterCount = 0;
            //have to set what to loop through
            for (int i = 0; i < mainStringToSearch.Length; i++)
            {
                //set a variable to contain current letter being searched
                //converting it to a string so it is no longer a char
                //and converting it to lower case to avoid detection problems
                string currentLetter = mainStringToSearch[i].ToString().ToLower();
                //ask if the the letter to find is equal to the current letter
                //making sure to convert to lower case to avoid detection issues
                if (letterToFind.ToLower() == currentLetter)
                {
                    //incrementing varaible for letter count based on results
                    letterCount++;
                }

            }
            //print output to console
            Console.WriteLine("The number of " + letterToFind + " in " + mainStringToSearch + " is " + letterCount);
        }
    }
}
