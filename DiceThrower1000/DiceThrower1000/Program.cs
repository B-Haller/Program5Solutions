using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceThrower1000
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceThrower1000("8d4 6d2");

            Console.ReadKey();
        }

        static void DiceThrower1000(string input)
        {
            List<string> inputTotals = new List<string>(input.Split(' '));
            

            for (int n = 0; n < inputTotals.Count(); n++)
            {


                List<string> inputData = new List<string>(inputTotals[n].Split('d'));

                var numberOfDiceToRoll = int.Parse(inputData[0]);
                var numberOfSidesOnDice = int.Parse(inputData[1]);
                var output = "";
                int totalNumber = 0;


                Random rng = new Random();

                for (int i = 0; i < numberOfDiceToRoll; i++)
                {
                    int randomNum = rng.Next(1, numberOfSidesOnDice + 1);

                    output += randomNum + " ";
                    totalNumber += randomNum;

                }

                var averageOfRolls = totalNumber / numberOfDiceToRoll;

                Console.Write("Your awesome roll resulted in the following: " + output + "\n");
                Console.WriteLine("The average of which, if you care, is: " + averageOfRolls);
            }
        }
    }
}
