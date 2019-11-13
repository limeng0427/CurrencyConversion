using System;
using System.Collections.Generic;
using System.Text;
using Unleashed.TechnicalTest.Data;
using Unleashed.TechnicalTest.Service;
using Xunit;

namespace Unleashed.TechnicalTest.Tests
{
    public class CurrencyServiceTest
    {
        #region CurrencyToWords

        [Fact]
        public void CurrencyToWords_Zero_ReturnZero()
        {
            // range
            decimal number = 0M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expectd = "Zero Dollar";
            Assert.Equal(expectd, actual);
        }

        [Fact]
        public void CurrencyToWords_PostiveNumberWithDecimal_ReturnRightString()
        {
            // range
            decimal number = 123.45M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            Assert.Equal("One Hundred and Twenty-Three Dollars and Forty-Five Cents", actual);
        }

        [Fact]
        public void CurrencyToWords_PostiveNumberWithoutDecimal_ReturnRightString()
        {
            // range
            decimal number = 67M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            Assert.Equal("Sixty-Seven Dollars", actual);
        }

        [Fact]
        public void CurrencyToWords_PostiveNumberLessThanOne_ReturnRightString()
        {
            // range
            decimal number = 0.89M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            Assert.Equal("Eighty-Nine Cents", actual);
        }

        [Fact]
        public void CurrencyToWords_PostiveNumberVeryLarge_ReturnRightString()
        {
            // range
            decimal number = 1234567890.12M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expected = $"One Billion Two Hundred " +
                $"and Thirty-Four Million Five Hundred " +
                $"and Sixty-Seven Thousand Eight Hundred " +
                $"and Ninety Dollars " +
                $"and Twelve Cents";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrencyToWords_PostiveNumberWithMoreThan2DigitRoundDown_ReturnRightString()
        {
            // range
            decimal number = 1.234M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expected = $"One Dollar and Twenty-Three Cents";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrencyToWords_PostiveNumberWithMoreThan2DigitRoundUp_ReturnRightString()
        {
            // range
            decimal number = 1.236M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expected = $"One Dollar and Twenty-Four Cents";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrencyToWords_NegativeNumberWithDecimal_ReturnRightString()
        {
            // range
            decimal number = -123.45M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            Assert.Equal("Minus One Hundred and Twenty-Three Dollars and Forty-Five Cents", actual);
        }

        [Fact]
        public void CurrencyToWords_NegativeNumberWithoutDecimal_ReturnRightString()
        {
            // range
            decimal number = -67M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            Assert.Equal("Minus Sixty-Seven Dollars", actual);
        }
        [Fact]
        public void CurrencyToWords_NegativeNumberLessThanOne_ReturnRightString()
        {
            // range
            decimal number = -0.89M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            Assert.Equal("Minus Eighty-Nine Cents", actual);
        }

        [Fact]
        public void CurrencyToWords_NegativeNumberVeryLarge_ReturnRightString()
        {
            // range
            decimal number = -1234567890.12M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expected = $"Minus One Billion Two Hundred " +
                $"and Thirty-Four Million Five Hundred " +
                $"and Sixty-Seven Thousand Eight Hundred " +
                $"and Ninety Dollars " +
                $"and Twelve Cents";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrencyToWords_NegativeNumberWithMoreThan2DigitRoundDown_ReturnRightString()
        {
            // range
            decimal number = -1.234M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expected = $"Minus One Dollar and Twenty-Three Cents";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrencyToWords_NegativeNumberWithMoreThan2DigitRoundUp_ReturnRightString()
        {
            // range
            decimal number = -1.236M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expected = $"Minus One Dollar and Twenty-Four Cents";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrencyToWords_NullCurrencyInfo_ReturnDefaultNZD()
        {
            // range
            decimal number = -1.236M;
            Currency currency = new Currency(null);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expected = $"Minus One Dollar and Twenty-Four Cents";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrencyToWords_3SecondaryUnitDigit_ReturnRightString()
        {
            // range
            decimal number = -1.623M;
            Currency currency = new Currency(CurrencyType.IQD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expected = $"Minus One Dinar and Six Hundred and Twenty-Three Fils";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrencyToWords_BoundaryValueExtraLarge_ReturnRightString()
        {
            // range
            decimal number = 9223372036854775807.99M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expected = $"Nine Billion Two Hundred and Twenty-Three Million " +
                $"Three Hundred and Seventy-Two Thousand and Thirty-Six Billion " +
                $"Eight Hundred and Fifty-Four Million " +
                $"Seven Hundred and Seventy-Five Thousand " +
                $"Eight Hundred and Seven Dollars " +
                $"and Ninety-Nine Cents";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrencyToWords_BoundaryValueOutOfRange_ThrowException()
        {
            // range
            decimal number = 9223372036854775807.996M;
            Currency currency = new Currency(CurrencyType.NZD);
              //act
            Action act = () => CurrencyService.CurrencyToWords(number, currency);
            //assert
            Assert.Throws<OverflowException>(act);
        }

        [Fact]
        public void CurrencyToWords__ReturnRightString()
        {
            // range
            decimal number = 9223372036854775807.99M;
            Currency currency = new Currency(CurrencyType.NZD);
            // act
            string actual = CurrencyService.CurrencyToWords(number, currency);
            // assert
            string expected = $"Nine Billion Two Hundred and Twenty-Three Million " +
                $"Three Hundred and Seventy-Two Thousand and Thirty-Six Billion " +
                $"Eight Hundred and Fifty-Four Million " +
                $"Seven Hundred and Seventy-Five Thousand " +
                $"Eight Hundred and Seven Dollars " +
                $"and Ninety-Nine Cents";
            Assert.Equal(expected, actual);
        }

        #endregion
        #region ParseCurrencyType
        [Fact]
        public void ParseCurrencyType_ExisingType_ReturnRightType()
        {
            // range
            string input = "NZD";
            // act
            CurrencyType? actual = CurrencyService.ParseCurrencyType(input);
            // assert
            CurrencyType? expectd = CurrencyType.NZD;
            Assert.Equal(expectd, actual);
        }

        [Fact]
        public void ParseCurrencyType_NotExisingType_ReturnNull()
        {
            // range
            string input = "ABC";
            // act
            CurrencyType? actual = CurrencyService.ParseCurrencyType(input);
            // assert
            Assert.Null(actual);
        }

        [Fact]
        public void ParseCurrencyType_ExisingTypeWithOtherInfo_ReturnRightType()
        {
            // range
            string input = "NZD -123.45";
            // act
            CurrencyType? actual = CurrencyService.ParseCurrencyType(input);
            // assert
            CurrencyType? expectd = CurrencyType.NZD;
            Assert.Equal(expectd, actual);
        }
        #endregion
        #region TryParseCurrency
        [Fact]
        public void TryParseCurrency_CurrencyTypeAndNumberInput_ReturnRightInfo()
        {
            // range
            string input = "NZD 123.45";
            // act
            bool actualResult = CurrencyService.TryParseCurrency(input, out decimal actualNumber, out CurrencyType? actualCurrencyType);
            // assert
            CurrencyType? expectedCurrencyType = CurrencyType.NZD;
            decimal expectedNumber = 123.45M;
            bool expectedResult = true;
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedNumber, actualNumber);
            Assert.Equal(expectedCurrencyType, actualCurrencyType);
        }
        [Fact]
        public void TryParseCurrency_NumberOnlyInput_ReturnRightInfo()
        {
            // range
            string input = "-123.45";
            // act
            bool actualResult = CurrencyService.TryParseCurrency(input, out decimal actualNumber, out CurrencyType? actualCurrencyType);
            // assert
            CurrencyType? expectedCurrencyType = null;
            decimal expectedNumber = -123.45M;
            bool expectedResult = true;
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedNumber, actualNumber);
            Assert.Equal(expectedCurrencyType, actualCurrencyType);
        }

        [Fact]
        public void TryParseCurrency_InvalidInput_ReturnRightInfo()
        {
            // range
            string input = "ABC1A2A3ABC";
            // act
            bool actualResult = CurrencyService.TryParseCurrency(input, out decimal actualNumber, out CurrencyType? actualCurrencyType);
            // assert
            CurrencyType? expectedCurrencyType = null;
            decimal expectedNumber = 0M;
            bool expectedResult = false;
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedNumber, actualNumber);
            Assert.Equal(expectedCurrencyType, actualCurrencyType);
        }

        [Fact]
        public void TryParseCurrency_BoundaryValueExtraLarge_ReturnRightInfo()
        {
            // range
            string input = "9223372036854775807.99";
            // act
            bool actualResult = CurrencyService.TryParseCurrency(input, out decimal actualNumber, out CurrencyType? actualCurrencyType);
            // assert
            CurrencyType? expectedCurrencyType = null;
            decimal expectedNumber = 9223372036854775807.99M;
            Assert.True(actualResult);
            Assert.Equal(expectedNumber, actualNumber);
            Assert.Equal(expectedCurrencyType, actualCurrencyType);
        }

        [Fact]
        public void TryParseCurrency_BoundaryValue_ReturnFalse()
        {
            // range
            string input = "9223372036854775808";
            // act
            bool actualResult = CurrencyService.TryParseCurrency(input, out decimal actualNumber, out CurrencyType? actualCurrencyType);
            // assert
            Assert.False(actualResult);

        }

        #endregion
    }
}
