using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Color = Car.Colors.Red;
            myCar.SayColor();
            Console.ReadKey();
        }
    }

    class Car
    {
        public enum Colors
        {
            Red = 1,
            Green,
            Orange,
            Blue,
        }

        public Colors Color { get; set; }

        public void SayColor()
        {
            Console.WriteLine(this.Color);
        }

        public void EnumsWorkGreatWithSwitches()
        {
            switch (this.Color)
            {
                case Colors.Red:
                    break;
                case Colors.Green:
                    break;
                case Colors.Orange:
                    break;
                case Colors.Blue:
                    break;
                default:
                    break;
            }

        }
    }
}
