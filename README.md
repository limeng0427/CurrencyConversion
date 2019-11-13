# Unleashed Technical Test - Currency Conversion
## Task Description  
Write a piece of code in C# to convert any amount to its English currency representation in words.   
Example:   
Input - 1.15  
Output - "One Dollar and Fifteen Cents"   
Include all your code (with unit tests) and any supporting references that are needed to compile and run the solution.   
Also include instructions for how to run/use your application, including any limitations or assumptions.  
You may wrap the code in a web app or command-line tool - whatever you prefer.  

## Installation and Instruction    

Open Solution File using Visual Studio with.Net Core 3.0.  
Run default start-up Command Line Project "Unleashed.TechnicalTest.CurrencyConversion".  
Follow prompt and input decimal values, the representation words will show on the screen.   

```
Input Format: [IOS4217Code Optional] [Decimal Value]  
Value Range: -9,223,372,036,854,775,807.99 to 9,223,372,036,854,775,807.99  
Example:   
123.45 to One Hundred and Twenty-Three Dollars and Forty-Five Cents  
NZD 100.10 to One Hundred Dollars and Ten Cents  
GBP -12.47 to Minus Twelve Pounds and Forty-Seven Pences  
```

## Solution Layout  

Unleashed.TechnicalTest.CurrencyConversion: Command Line Project to demonstrate the completed task.  
Unleashed.TechnicalTest.Service: Class Library used for storing business logic e.g. ParseCurrency, CurrencyToWords  
Unleashed.TechnicalTest.Data: Class Library used for storing  data modals e.g. Currency, CurrencyType  
Unleashed.TechnicalTest.Utility: Class Library used for storing utility functions e.g. IntToWords  
Unleashed.TechnicalTest.Test: Unit Test Project using xUnit.  

## Testing  
Unit Test 34 Cases in 3 Groups. All Passed.  
Test cases include normal value, extra large value, invalid value etc.  
