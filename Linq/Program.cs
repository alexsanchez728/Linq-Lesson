using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {


            // Restriction / Filtering Operations


            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            var LFruits =
                from fruit in fruits
                where fruit[0].ToString() == "L"
                select fruit;

            foreach (var fruit in LFruits)
            {
            Console.WriteLine("{0} is a fruit that starts with an 'L'", fruit);
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>() { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96 };

            var fourSixMultiples = numbers
                .Where(number => number % 4 == 0 || number % 6 == 0);

            foreach (var multiple in fourSixMultiples)
            {
                Console.WriteLine("{0} is a number in the list that is a multiple of 4 or 6", multiple);
            }


            //Ordering Operations

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
                {
                    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                    "Francisco", "Tre"
                };

            var descend =
                from name in names
                orderby name descending
                select name;

            Console.WriteLine("Students is descending alphabetical order:");
            foreach (var student in descend)
            {
                Console.WriteLine("{0}", student);
            }

            // Build a collection of these numbers sorted in ascending order

            var ascend =
                from num in numbers
                orderby num
                select num;

            Console.WriteLine("numbers is ascending order:");
            foreach (var number in ascend)
            {
                Console.WriteLine("{0}", number);
            }


            // Aggregate Operations

            // Output how many numbers are in this list

            var howMany = numbers.Count();

            Console.WriteLine("there are {0} numbers in the list", howMany);

            // How much money have we made?
            List<double> purchases = new List<double>() { 2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65 };

            var howMuchTotal = purchases.Sum(purchase => purchase);

            Console.WriteLine("LOOK $ AT $ ALL $ OUR $ MONEYS ${0}", howMuchTotal);

            // What is our most expensive product?
            List<double> prices = new List<double>() { 879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76 };

            var mostExpensive = purchases.Max(purchase => purchase);

            Console.WriteLine("Our most expensive product is worth: ${0}", mostExpensive);

            //Partitioning Operations
            /*
                Store each number in the following List until a perfect square
                is detected.
            */
            List<int> wheresSquaredo = new List<int>() { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14 };

            var untilSquare = wheresSquaredo.TakeWhile(number => Math.Sqrt(number % 2) == 0);

            Console.WriteLine("These are all the numbers in the list until we hit a perfect square:");
            foreach (var number in untilSquare)
            {
                Console.WriteLine("{0}", number);
            }

            List<Customer> customers = new List<Customer>()
                {
                    new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                    new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                    new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                    new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                    new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                    new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                    new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                    new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                    new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                    new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
                };

            var millionaires =
                from customer in customers
                where customer.Balance >= 1000000
                select customer;

            var millionaireBankCount = millionaires.GroupBy(millionaire => millionaire.Bank);

            foreach (var bank in millionaireBankCount)
            {
                Console.WriteLine($"{bank.Key} {bank.Count()}");
            }


            // Introduction to Joining Two Related Collections
            //    TASK:
            //    As in the previous exercise, you're going to output the millionaires,
            //    but you will also display the full name of the bank.You also need
            //    to sort the millionaires' names, ascending by their LAST name.

            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Far go", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            var millionaireReport =
                from bank in banks
                join millionaire in millionaires
                    on bank.Symbol equals millionaire.Bank
                orderby millionaire.Name.Split(' ').Last()
                select new { CustomerName = millionaire.Name, CustomerBank = bank.Name};
            // ^^ In more plain english (I hope) :
            // take each bank in bank,
            // take each millionaire in millionaires,
            // join these two groups together comparing the bank.Symbol to the millionaire.Bank when joining
            // split the names of the millionaires on the space seperating their first and last name...
            // ...only keep the last element of that sequence (their Last Name)...
            // ...use orderby to order the resulting names ascending alphabetically
            // now give millionaireReport a new IEnumerable to return which holds the millionaries name and the bank name (spelled out from List<Bank> banks)


            foreach (var customer in millionaireReport)
            {
                Console.WriteLine($"{customer.CustomerName} at {customer.CustomerBank}");
            }

            Console.ReadKey();
        }
    }
}
