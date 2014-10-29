using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program5Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare a string variable
            string myName = "Brandon Haller";
            //declare a number variable
            int myAge = 24;
            //declare a bool variable
            bool myBool = true;
            //declare a new list
            List<string> productsList = new List<string>() { "basketball", "basketball glove", "tennis shoes", "hockey puck" };
            //writes name and string to console
            Console.WriteLine("My name is " + myName + " and I'm a beast of a programmer.");
            //writes age and string to console
            Console.WriteLine("I am " + myAge + " years awesome.");
            //writes boolean and string to console
            Console.WriteLine("I set my boolean value equal to " + myBool + ".");
            //uses for loop to print out each value of list
            for (int i = 0; i < productsList.Count(); i++)
            {
                Console.WriteLine(productsList[i]);
            }
            //Using for loop to list 1-10
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
            //Using for loop to list 10-1
            for (int i = 10; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
                
            //Using a loop that prints out the even numbers 10-30
            for (int i = 10; i <= 30; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            //Using a loop that prints out the numbers 100-75
            //every 5th number printed
            for (int i = 100; i >= 75; i = i-5)
            {
                {
                    Console.WriteLine(i);
                }
            }

            //Using a while loop  to print out the numbers from 1-10
            int num = 1;
            while (num <= 10)
            {
                Console.WriteLine(num);
                num++;
            }
            //Using a while loop to print numbers from 10-1
            int num1 = 10;
            while (num1 >= 1)
            {
                Console.WriteLine(num1);
                num1--;
            }

            //Using a while loop to print 15-30, only even
            int num2 = 15;
            while (num2 <= 30)
            {
                if (num2 % 2 == 0)
                {
                    Console.WriteLine(num2);
                }
                num2++;
            }

            //Create a while loop to print 100-75, every fifth number
            int num3 = 100;
            while (num3 >= 75)
            {
                Console.WriteLine(num3);
                num3 = num3 - 5;
            }

           
            //Using a while loop to print out numbers 1-10, 
            //stoping when a number is divisible by 4
            int j = 1;
            while (myBool)
            {
                if(j % 4 == 0)
                {
                    myBool = false;
                }
                else
                {
                    Console.WriteLine(j);
                    j++;
                }
             
            

            }

            //Prints out the number of letter in my name
            Console.WriteLine("My name " + myName + " has " + myName.Count() + " letters in it.");

            //Prints out the number of items in the list
            Console.WriteLine("My product list has " + productsList.Count() + " products in it.");

            //Print out the number of letters in productList
            for (int i = productsList.ToString; i < productsList; i++)
			{
			 
			}
            Console.WriteLine("");
        }
            
    }
}
