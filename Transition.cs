using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Transaction
{
    public decimal Amount { get; }
    public DateTime Date { get; }
    

    public Transaction(decimal amount, DateTime date) { 
    
        Amount = amount;
        Date = date;
        
    }
}

}