using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Unleashed.TechnicalTest.Data;
using Unleashed.TechnicalTest.Service;
using Unleashed.TechnicalTest.Utilities;

namespace CurrencyConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Unleashed Technical Test Demo!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Please insert a currency value, then click enter");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Input Format: [IOS4217Code Optional] [Decimal Value]");
            Console.WriteLine("Value Range: -9,223,372,036,854,775,808.99 to 9,223,372,036,854,775,807.99");
            Console.WriteLine("Example: 123.45, NZD 100.10, GBP -12.471");
            Console.WriteLine("-----------------------------------------------------");
            while (true)
            {
                string input = Console.ReadLine();
                // validate input
                bool isValidCurrency  = CurrencyService.TryParseCurrency(input, out decimal number, out CurrencyType? currencyType);
                if (isValidCurrency)
                {
                    // build currency data modal
                    Currency currency = new Currency(currencyType);

                    // call service function to get currency represensation words
                    string numberWords = CurrencyService.CurrencyToWords(number, currency);
                    
                    Console.WriteLine($"Given Number: {number}");
                    Console.WriteLine($"Currency Representation Words: {numberWords}");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Please insert a currency value, then click enter");
                    Console.WriteLine("-----------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("The number privided is invalid, please try again.");
                }

            }


        }


    }
}
