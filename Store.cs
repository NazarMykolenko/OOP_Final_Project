using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Store
    {
        public List <Car> CarList { get; set; }
        public List <Car> ShoppingList { get; set; }
        public List <Car> BoughtList { get; set; }

        public Store() {
            ShoppingList = new List <Car>();
            CarList = new List <Car>();
            BoughtList= new List <Car>();
        }
        public decimal Checkout()
        {
            decimal sum = 0;
            foreach (var item in ShoppingList)
                sum = sum + item.Price;
            return sum;   
        }
        public void PrintCarList()
        {
            for(int i = 0; i < CarList.Count; i++)
            {
                Console.WriteLine(CarList[i]);
            }
        }
        public void PrintShoppingList()
        {
            for (int i = 0; i < ShoppingList.Count; i++)
            {
                Console.WriteLine(ShoppingList[i]);
            }
        }
        public void PrintBoughtList()
        {
            for (int i = 0; i < BoughtList.Count; i++)
            {
                Console.WriteLine(BoughtList[i]);
            }
        }

        }

}
