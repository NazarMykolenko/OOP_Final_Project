using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Account
    {
        public string UserName{ get; set; }
        
        private List<Transaction> allTransactions = new List<Transaction>();
        private List<PurchaseHistory> allPurchases = new List<PurchaseHistory>();
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        
        public Account( string name, decimal initialBalance)
        {
            UserName = name;
            MakeDeposit(initialBalance, DateTime.Now);
        }
         
        public void MakeDeposit(decimal amount, DateTime date)
        {
            if(amount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date);
            allTransactions.Add(deposit);
            
    }
       
        public void BuyCar(List <Car> Shoppinglist,List <Car> BoughtList, DateTime date)
        {
            decimal sum = 0;
            for (int i = 0; i < Shoppinglist.Count; i++)
            {
                BoughtList.Add(Shoppinglist[i]);
                sum = sum + Shoppinglist[i].Price;
            }
                if (sum > Balance)
                {
                    throw new InvalidOperationException("Not enough money for Purchase. Deposit more money");
                }
            var withdrawal = new Transaction(-sum, date);
            allTransactions.Add(withdrawal);
            var purchase = new PurchaseHistory(BoughtList ,sum, date);
            allPurchases.Add(purchase);
                Shoppinglist.Clear();
            }
        public string GetHistory(List<Car> boughtCars)
        {
            var report = new StringBuilder();

            report.AppendLine($"Purchase history of {UserName}");
            report.AppendLine($"Your car:\t Cost:");
            for (int i  = 0; i < boughtCars.Count; i++) {
                report.AppendLine($"{boughtCars[i].Make} {boughtCars[i].Year}\t {boughtCars[i].Price} ");
               
            }
            foreach(var item in allPurchases)
            {
                report.AppendLine($"Total cost: {item.Cost} Date: {item.Date}");
                
            }
            return report.ToString();
        }
        
        }
    }
   

