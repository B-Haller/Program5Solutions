using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //created a new list of flyable things
            List<IFlyable> canFlyList = new List<IFlyable>();
            
            canFlyList.Add(new Bird());
            canFlyList.Add(new Plane());
            canFlyList.Add(new UFO());
            canFlyList.Add(new Bird());
            canFlyList.Add(new Plane());
            canFlyList.Add(new UFO());


            foreach (IFlyable item in canFlyList)
            {
                item.Fly();
            }
            Console.ReadKey();
        }
    }

    //interfaces always go the same level as classes
    interface IFlyable
    {
        //anything that implements this interface will have the following methods or properties
        void Fly();
    }

    public class Bird :IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flap flap flap");
        }
    }

    public class Plane : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Vrom vrom vrom!");
        }
    }

    public class UFO : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Woogie woogie woogie");
        }
    }
}
