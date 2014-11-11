using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaPracticeHW
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = new List<string>() {"Basketball", "Baseball", "Tennis Raquet", "Running Shoes", "Wrestling Shoes", 
                "Soccer Ball", "Football", "Shoulder Pads", 
                "Trail Running Shoes", "Cycling Shoes", "Kayak", "Kayak Paddles"};


            //declare a variable kayakProducts and set it equal to all products that contain the word "Kayak"
            var kayakProducts = products.Where(x => x.Contains("Kayak")).ToList();

            //print the kayakProducts to the console using a foreach loop.
            kayakProducts.ForEach(Console.WriteLine);

            //declare a variable shoeProducts and set it equal to all products that contain the word "Shoes"
            var shoeProducts = products.Where(x => x.Contains("Shoes")).ToList();

            //print the shoeProducts to the console using a foreach loop or string.Join().
            Console.WriteLine(string.Join(", ", shoeProducts));

            //declare a variable ballProducts and set it equal to all the products that have ball in the name.
            var ballProducts = products.Where(x => x.ToString().ToLower().Contains("ball")).ToList();

            //print the ballProducts to the console using a foreach loop or string.Join().
            Console.WriteLine(string.Join(", ", ballProducts));

            //sort ballProducts alphabetically and print them to the console.
            Console.WriteLine(string.Join(", ", ballProducts.OrderBy(x => x)));

            //add six more items to the products list using .add().
            products.Add("Badmitton");
            products.Add("Tennis Ball");
            products.Add("Lifting Gloves");
            products.Add("Turtlenecks");
            products.Add("Spandex");
            products.Add("Curling Gear");

            //print the product with the longest name to the console using the .First() extension.
            Console.WriteLine(string.Join(", ", products.OrderBy(x => x.Length).Last()));

            //print the product with the shortest name to the console using OrderByDesceding() and the .First() extension.
            Console.WriteLine(string.Join(", ", products.OrderByDescending(x => x.Length).Last()));

            //print the product with the 4th shortest name to the console using an index or Skip/Take (you must convert the results to a list using .ToList()).
            Console.WriteLine(string.Join(", ", products.OrderBy(x => x.Length).Skip(3).Take(1)));

            //print the ballProduct with the 2nd longest name to the console using an index or Skip/Take (you must convert the results to a list using .ToList()).
            Console.WriteLine(string.Join(" ", products.OrderByDescending(x => x.Length).Skip(1).Take(1)));

            //declare a variable reversedProducts and set it equal to all products ordered by the longest word first. (use the OrderByDescending() extension).
            var reversedProducts = products.OrderByDescending(x => x.Length).ToList();

            //print out the reversedProducts to the console using a foreach loop.
            reversedProducts.ForEach(Console.WriteLine);

            //print out all the products ordered by the longest word first using the OrderByDecending() extension and a foreach loop.  
            //Note: you will not use a variable to store your list
            foreach (string value in products.OrderByDescending(x => x.Length))
            {
                Console.WriteLine(value);
            }


            Console.ReadKey();
        }
    }
}
