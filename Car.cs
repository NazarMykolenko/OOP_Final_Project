using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car()
        {
            Make = "NoName";
            Model = "NoModel";
            Price = 0.00M;
        }
        public Car(string make, string model, decimal price, int year, string color)
        {
            Make = make;
            Model = model;
            Price = price;
            Year = year;
            Color = color; 
        }

        override public string ToString()
        {
            return "Make: " + Make + " Model: " + Model +" Year: " + Year + " Color: "+ Color + " Price: $" + Price;
        }
    }
}
