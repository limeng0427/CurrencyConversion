using System;
using Unleashed.TechnicalTest.Utilities;
using Xunit;

namespace Unleashed.TechnicalTest.Tests
{
    public class NumberUtilityTest
    {
        #region IntToWords

        [Fact]
        public void IntToWords_Zero_ReturnZero()
        {
            // range
            int number = 0;
            // act
            string actual = NumberUtility.IntToWords(number);
            // assert
            string expected = "Zero";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IntToWords_PostiveNumber_ReturnRightString()
        {
            // range
            int number = 123;
            // act
            string actual = NumberUtility.IntToWords(number);
            // assert
            string expected = "One Hundred and Twenty-Three";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IntToWords_PostiveNumberVeryLarge_ReturnRightString()
        {
            // range
            int number = 1234567890;
            // act
            string actual = NumberUtility.IntToWords(number);
            // assert
            string expected = $"One Billion Two Hundred " +
                $"and Thirty-Four Million Five Hundred " +
                $"and Sixty-Seven Thousand Eight Hundred " +
                $"and Ninety";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IntToWords_NegativeNumber_ReturnRightString()
        {
            // range
            int number = -123;
            // act
            string actual = NumberUtility.IntToWords(number);
            // assert
            string expected = "Minus One Hundred and Twenty-Three";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IntToWords_NegativeNumberVerySmall_ReturnRightString()
        {
            // range
            int number = -1234567890;
            // act
            string actual = NumberUtility.IntToWords(number);
            // assert
            string expected = $"Minus One Billion Two Hundred " +
                $"and Thirty-Four Million Five Hundred " +
                $"and Sixty-Seven Thousand Eight Hundred " +
                $"and Ninety";
            Assert.Equal(expected, actual);
        }

        #endregion

    }
}
