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
            for (int i = 0; i < productsList.Count; i = i + 1)
            {
                Console.WriteLine(productsList[i] + " has " + productsList[i].Count() + " letters in it.");
            }


            Greeting("Beef Hardchest");
            Greeting(myName);
            DoubleIt(1337);
            DoubleIt(myAge);
            Multiply(2, 8);
            Multiply(3, myAge);
            LoopThis(20, 30);
            LoopThis(0, myAge);
            SuperLoop(0, 100, 15);
            SuperLoop(0, 200, myAge);
            Console.WriteLine(NewGreeting("Neil deGrasse-Tyson"));
            Console.WriteLine(10 + " tripled is " + TripleIt(10));
            Console.WriteLine(myAge + " tripled is " + TripleIt(myAge));
            Console.WriteLine(RealMultiply(5, 10));
            Console.WriteLine(RealMultiply(2, myAge));
            SuperLoop(RealMultiply(1, 5), TripleIt(myAge), TripleIt(myAge - 10));
            SuperLoop(RealMultiply(1, TripleIt(3)), TripleIt(RealMultiply(myAge, 7)), TripleIt(myAge - RealMultiply(2, 4)));
            Console.ReadKey();

        }
        /// <summary>
        /// A function to print Hello name
        /// </summary>
        /// <param name="name">name to be printed</param>
        static void Greeting(string name)
        {
            Console.WriteLine("Hello " + name);
        }
        /// <summary>
        /// Doubles number
        /// </summary>
        /// <param name="number">number to be doubled</param>
        /// <returns>doubled number</returns>
        static void DoubleIt(int number)
        {
            Console.WriteLine(number + " doubled is " + number * 2);
        }
        /// <summary>
        /// will multiply a number
        /// </summary>
        /// <param name="num1">intial number to be multiplied</param>
        /// <param name="num2">multiplying number</param>
        /// <returns>results of numbers being multiplied</returns>
        static void Multiply(int num1, int num2)
        {
            Console.WriteLine (num1 + " times " + num2 + " is " + num1 * num2);
        }
        /// <summary>
        /// Loops thorugh a series of numbers, displaying 
        /// numbers to be looped through
        /// </summary>
        /// <param name="startNum">number that will start loop</param>
        /// <param name="endNum">number that will end loop</param>
        static void LoopThis(int startNum, int endNum)
        {
            Console.WriteLine("I'm looping from " + startNum + " to " + endNum);

            for (int i = startNum; i <= endNum; i++)
            {
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// Loops through a series of numbers, incrementing by third number
        /// and also displays the amount of times that the loop executed
        /// </summary>
        /// <param name="startNum">number too begin loop</param>
        /// <param name="endNum">number that ends loop</param>
        /// <param name="increment">number to increment start number by each loop</param>
        static void SuperLoop(int startNum, int endNum, int increment)
        {
            int loopCount = 0;

            Console.WriteLine("I'm looping from " + startNum + " to " + endNum + ", incrementing by " + increment + " each time.");
            
 
            for (int i = startNum; i <= endNum; i = i + increment)
            {
                Console.WriteLine(i);
                loopCount++;
            }
            Console.WriteLine("That loop was craaaaaazy, we looped " + loopCount + " times.");
        }

        /// <summary>
        /// Creates a new greeting that must be written by the console
        /// </summary>
        /// <param name="name">Name of person greeted</param>
        /// <returns>Greeting</returns>
        static string NewGreeting(string name)
        {
            return "Hello, " + name;
        }

        /// <summary>
        /// Triples a number
        /// </summary>
        /// <param name="number">number to be tripled</param>
        /// <returns>the number tripled</returns>
        static int TripleIt(int number)
        {
            return number * number * number;
        }
        /// <summary>
        /// multiplies two numbers
        /// </summary>
        /// <param name="num1">first number to be multiplied</param>
        /// <param name="num2">second number to be multiplied</param>
        /// <returns>the result of the numbers being multiplied</returns>
        static int RealMultiply(int num1, int num2)
        {
            return num1 * num2;
        }

    }
}
