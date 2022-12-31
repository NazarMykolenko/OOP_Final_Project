using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class PurchaseHistory
    {
        public List<Car> BoughtCars { get; set; }

        public decimal Cost { get; set; }

        public DateTime Date { get; }

        public PurchaseHistory(List<Car> boughtCars, decimal cost, DateTime date)
        {
            BoughtCars = boughtCars;
            Cost = cost;
            Date = date;
        } 
    }
}
