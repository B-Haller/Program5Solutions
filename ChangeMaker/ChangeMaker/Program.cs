using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangeMaker(3.18);
            ChangeMaker(0.99);
            ChangeMaker(12.93);
            Console.ReadKey();
        }
        /// <summary>
        /// will determine how much change when given amount
        /// </summary>
        /// <param name="amountToMakeChange">amount to check for change</param>
        static void ChangeMaker(double amountToMakeChange)
        {
            //set up integers, also creating integer that multiplies by 100
            //and rounds it so it is a whole number
            int changeModified = (int)Math.Round(amountToMakeChange*100);
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;
                //begin series of if statements, starting with quarters
                if (changeModified >= 25)
                {
                    //adding to quarters based on var divided by 25
                    quarters += changeModified/25;
                    //subtracting value of all quaters from var
                    changeModified -= 25*quarters;
                }
                if (changeModified >= 10)
                {
                    //adding dimes based on var / 10
                    dimes += changeModified/10;
                    //decreasing by value of all dimes from var
                    changeModified -= 10*dimes;
                }
                if (changeModified >= 5)
                {   //same as above, except nickels
                    nickels += changeModified / 5;
                    //subtracting by value of all nickels
                    changeModified -= 5*nickels;
                    //assigning left over change to pennies
                    
                }
                pennies = changeModified;

                Console.WriteLine("Amount: ${0}\nQuarters: {1}\nDimes: {2}\nNickels: {3}\nPennies: {4}", amountToMakeChange, quarters, dimes, nickels, pennies);
            }
            
        
    }
}
