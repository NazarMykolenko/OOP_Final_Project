using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class UsedCar : Car    {
        public decimal TraveledKm { get; set; }

        public UsedCar(string make, string model, decimal price, int year, string color, decimal traveledKm) : base(make, model, price, year, color)
        {
            TraveledKm = traveledKm;
        }

        override public  string ToString()
        {
            return "Make: " + Make + " Model: " + Model + " Year: " + Year + " Color: " + Color + " Price: $" + Price + " Traveled: "+ TraveledKm+"km";
        }
    }
}
