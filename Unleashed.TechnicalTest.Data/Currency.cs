using System;
using Unleashed.TechnicalTest.Utilities;

namespace Unleashed.TechnicalTest.Data
{
    public enum CurrencyType
    {
        USD,
        EUR,
        GBP,
        AUD,
        NZD,
        IQD,
    }
    public class Currency:INumber
    {
        public string IOS4217Code { get; set; }
        public string MainUnit { get; set; }
        public string SecondaryUnit { get; set; }
        public int SecondaryUnitDigit { get; set; }
        public Currency(CurrencyType? type)
        {
            switch (type)
            {
                case CurrencyType.EUR:
                    MainUnit = "Euro";
                    SecondaryUnit = "Cent";
                    SecondaryUnitDigit = 2;
                    break;
                case CurrencyType.GBP:
                    MainUnit = "Pound";
                    SecondaryUnit = "Pence";
                    SecondaryUnitDigit = 2;
                    break;
                case CurrencyType.IQD:
                    MainUnit = "Dinar";
                    SecondaryUnit = "Fil";
                    SecondaryUnitDigit = 3;
                    break;
                case CurrencyType.USD:
                case CurrencyType.AUD:
                case CurrencyType.NZD:
                default:
                    MainUnit = "Dollar";
                    SecondaryUnit = "Cent";
                    SecondaryUnitDigit = 2;
                    break;
            }
        }
    }

}
