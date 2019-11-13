using System;
using System.Linq;
using System.Text.RegularExpressions;
using Unleashed.TechnicalTest.Data;
using Unleashed.TechnicalTest.Utilities;

namespace Unleashed.TechnicalTest.Service
{
    public static class CurrencyService
    {
        public static string CurrencyToWords(decimal number, Currency currency)
        {
            number = Math.Round(number, currency.SecondaryUnitDigit);
            if (Math.Abs(Math.Truncate(number)) > long.MaxValue)
            {
                throw new OverflowException();
            }
            long intPart = (long)Math.Truncate(Math.Abs(number));
            decimal truncatedDecimal = (Math.Abs(number) - Math.Truncate(Math.Abs(number)));
            int decimalPart = (int)(truncatedDecimal * (int)Math.Pow(10, currency.SecondaryUnitDigit));
            if (intPart == 0 && decimalPart == 0)
                return $"Zero {currency.MainUnit}";
            string result = string.Empty;
            if (number < 0)
                result += "Minus ";
            if (intPart != 0)
            {
                result += NumberUtility.IntToWords(intPart) + $" {currency.MainUnit}";
                if (Math.Abs(intPart) > 1)
                    result += "s";
            }
            if (decimalPart != 0)
            {
                if (intPart != 0)
                    result += " and ";
                result += NumberUtility.IntToWords(decimalPart) + $" {currency.SecondaryUnit}";
                if (Math.Abs(decimalPart) > 1)
                    result += "s";
            }
            return result;
        }

        public static CurrencyType? ParseCurrencyType(string input)
        {
            input = new String(input.Where(Char.IsLetter).ToArray());
            if (Enum.IsDefined(typeof(CurrencyType), input))
            {
                return (CurrencyType)Enum.Parse(typeof(CurrencyType), input, ignoreCase: true);
            }
            return null;
        }

        public static bool TryParseCurrency(string input, out decimal result, out CurrencyType? currencyType)
        {
            input = input.Replace(",", "");
            var regex = new Regex(@"([A-Z,a-z]*)\s*(-?[0-9]+(.[0-9]*)?)");
            Match match = regex.Matches(input).FirstOrDefault();
            if (match != null && match.Success)
            {
                currencyType = ParseCurrencyType(match.Groups[1].Value);
                input = match.Groups[2].Value;
                bool success = decimal.TryParse(input, out result);
                if (success)
                {
                    decimal intPart = Math.Truncate(Math.Round(result, 2));
                    if (Math.Abs(intPart) > long.MaxValue)
                        success = false;
                }
                return success;
            }
            else
            {
                currencyType = null;
                result = 0M;
                return false;
            }
        }
    }
}
