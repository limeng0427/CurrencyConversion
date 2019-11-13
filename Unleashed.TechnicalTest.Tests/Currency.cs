using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Unleashed.TechnicalTest.Data;

namespace Unleashed.TechnicalTest.Tests
{
    public class CurrencyTest
    {
        #region Currency

        [Fact]
        public void Currency_NullCurrencyType_ReturnDefaultCurrencyType()
        {
            // range
            CurrencyType? currencyType = null;
            // act
            Currency currency = new Currency(currencyType);
            // assert
            Assert.NotNull(currency);
            Assert.Equal("Dollar", currency.MainUnit);
            Assert.Equal("Cent", currency.SecondaryUnit);
            Assert.Equal(2, currency.SecondaryUnitDigit);
        }

        [Fact]
        public void Currency_CurrencyTypeWith2SecondaryUnitDigit_ReturnRightInfo()
        {
            // range
            CurrencyType? currencyType = CurrencyType.NZD;
            // act
            Currency currency = new Currency(currencyType);
            // assert
            Assert.NotNull(currency);
            Assert.Equal("Dollar", currency.MainUnit);
            Assert.Equal("Cent", currency.SecondaryUnit);
            Assert.Equal(2, currency.SecondaryUnitDigit);
        }

        [Fact]
        public void Currency_CurrencyTypeWith3SecondaryUnitDigit_ReturnRightInfo()
        {
            // range
            CurrencyType? currencyType = CurrencyType.IQD;
            // act
            Currency currency = new Currency(currencyType);
            // assert
            Assert.NotNull(currency);
            Assert.Equal("Dinar", currency.MainUnit);
            Assert.Equal("Fil", currency.SecondaryUnit);
            Assert.Equal(3, currency.SecondaryUnitDigit);
        }
        #endregion
    }
}
