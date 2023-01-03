using CarClassLibrary;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Write your name: ");
        string name = Console.ReadLine();
        Account acc = new Account(name, 100);
        Console.WriteLine("Hello " + acc.UserName);
        Console.WriteLine($"Account was created for {acc.UserName} with {acc.Balance} initial balance.\n");
        Console.WriteLine("Welcome to the car store! First you must create some inventory.\n Than you may add some cars to the shopping cart. And then you can buy it ");
        int action = chooseAction();
        Store atb = new Store();



        while (action != 0)
        {


            switch (action)
            {
                //add item to inventory
                case 1:

                    String carMake = "";
                    String carModel = "";
                    Decimal carPrice = 0;
                    String carColor = "";
                    int carYear = 0;
                    Console.WriteLine("You chose to add car to inventory");
                    Console.WriteLine("(0) - add new car\n (1) - add used car");
                    int choice = int.Parse(Console.ReadLine());

                    Console.WriteLine("What is the car make?");
                    carMake = Console.ReadLine();

                    Console.WriteLine("What is the car model");
                    carModel = Console.ReadLine();
                    bool error2 = true;
                    while (error2)
                    {
                        try
                        {
                            Console.WriteLine("What is the price");
                            carPrice = int.Parse(Console.ReadLine());
                            error2 = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Write proper price");
                            error2 = true;
                        }
                    }


                    Console.WriteLine("What is the car color");
                    carColor = Console.ReadLine();
                    bool error1 = true;
                    while (error1)
                    {
                        try
                        {
                            Console.WriteLine("What is the car year");
                            carYear = int.Parse(Console.ReadLine());
                            error1 = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Write proper year");
                            error1 = true;
                        }
                    }
                    if (choice == 1)
                    {
                        Console.WriteLine("How many kilometers has this car traveled yet?");
                        decimal traveledKm = int.Parse(Console.ReadLine());
                        UsedCar newCar = new UsedCar(carMake, carModel, carPrice, carYear, carColor, traveledKm);
                        atb.CarList.Add(newCar);
                    }
                    else
                    {
                        Car newCar = new Car(carMake, carModel, carPrice, carYear, carColor);
                        atb.CarList.Add(newCar);
                    }

                    

                    atb.PrintCarList();
                    break;

                    case 2:
                    Console.WriteLine("You choose to add car to shopping cart");
                    
                    atb.PrintCarList();
                    bool error = false;
                    while(error != true)
                    try
                    {
                        int carChosen = int.Parse(Console.ReadLine());
                        atb.ShoppingList.Add(atb.CarList[carChosen]);
                        
                        atb.PrintShoppingList();
                            error= true;
                    }
                    catch(FormatException) {
                        Console.WriteLine("Write number of car");
                            error = false;
                    }   
                    catch(ArgumentOutOfRangeException) {
                            Console.WriteLine("Choose car from the list");
                            error = false;  
                                }
                    
                    break;

                    //checkout
                    case 3:
                    
                    atb.PrintShoppingList();

                    decimal sum =  atb.Checkout();
                    
                    Console.WriteLine("You sum is: " + sum);
                    Console.WriteLine("Your balance is: "+acc.Balance);
                    Console.WriteLine("Want to make a purchase? (1) YES (2) Make a deposit (3) Menu ");
                    int choice1 = int.Parse(Console.ReadLine());
                    if(choice1 == 1)
                    {
                        acc.BuyCar(atb.ShoppingList,atb.BoughtList, DateTime.Now);
                        Console.WriteLine("Thank you for buying!");
                        Console.WriteLine("You bought:");
                        atb.PrintBoughtList();
                        Console.WriteLine("Your balance is: " + acc.Balance);
                        Console.WriteLine(acc.GetHistory(atb.BoughtList));
                    }
                    else if(choice1 == 2) {
                        Console.WriteLine("What amount of money you want to deposit?");
                        decimal amount1 = int.Parse(Console.ReadLine());
                        acc.MakeDeposit(amount1, DateTime.Now);
                        Console.WriteLine("Your balcance is :" + acc.Balance);
                    }

                    break;

                    case 4:
                    Console.WriteLine("What amount of money you want to deposit?");
                    decimal amount = int.Parse(Console.ReadLine());
                    acc.MakeDeposit(amount, DateTime.Now);
                    Console.WriteLine("Your balcance is :" + acc.Balance);

                    break;

                    case 5:
                    
                    atb.PrintCarList();
                    break;

                    case 6:
                    
                    atb.PrintShoppingList();
                    break;
                    case 7:
                    Console.WriteLine(acc.GetHistory(atb.BoughtList));

                    break;
            }
              action = chooseAction(); 

        }
        
    }

   
    public static int chooseAction()
        {
        bool error = false;
        int choice = 0;
        Console.WriteLine("Choose an action: (0) to quit\n (1) add a new car to inventory\n (2) add car to shopping list\n (3) to checkout(buy) \n(4) to make a deposit\n (5) to check inventory (6) to check shopping list (7) Purchase history ");
        while (error != true && choice >= 0 && choice < 5)
        {
            try
            {
                choice = int.Parse(Console.ReadLine());
                error = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Choose an action (0) to quit (1) add a new car to inventory (2) add car to shopping list (3) to checkout(buy)\n(4) to make a deposit\n (5) to check inventory (6) to check shopping list (7) Purchase history");
                error = false;
            }
        }
        return choice;
        }


        

    
}