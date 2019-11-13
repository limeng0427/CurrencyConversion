using System;

namespace Unleashed.TechnicalTest.Utilities
{
    public static class NumberUtility
    {
        public static string IntToWords(long number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + IntToWords(Math.Abs(number));

            string words = string.Empty;

            if ((number / 1000000000) > 0)
            {
                words += IntToWords(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += IntToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += IntToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += IntToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (!string.IsNullOrWhiteSpace(words))
                    words += "and ";

                var baseMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += baseMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + baseMap[number % 10];
                }
            }

            return words.TrimEnd();
        }
    }
}
