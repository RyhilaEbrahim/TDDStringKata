using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public class CalcKata
    {
        private readonly List<string> _delimiters = new List<string>(new [] {",", "\n"});
      
        public int Add(string numbers)
        {
            ExtractDelimiters(numbers);
            var numbersOnlyString = ExtractNumberSection(numbers);

            var splitNumbers = SplitNumbers(numbersOnlyString, _delimiters);
            var convertedNumbers = ConvertNumbers(splitNumbers);
            var charactersConvertedToNumbers = convertedNumbers as int[] ?? convertedNumbers.ToArray();
            var numbersLessThan1000 = FilterNumbersGreaterThan1000(charactersConvertedToNumbers);
            var numberLessThan0 = FilterNumbersLessThan0(charactersConvertedToNumbers);
            ThrowExceptionWhenLessThan0(numberLessThan0);
            var total = CalculateTotal(numbersLessThan1000);
            return total;
        }

        private void ThrowExceptionWhenLessThan0(int[] numberLessThan0)
        {
            var negativeValue = "";
            negativeValue = ConcatenateNegativeValues(numberLessThan0, negativeValue);
            if (numberLessThan0.Length > 0)
            {
                throw new Exception("Negative numbers not allowed " + negativeValue);

            }
        }

        private static string ConcatenateNegativeValues(int[] numberLessThan0, string negativeValue)
        {
            for (var i = 0; i < numberLessThan0.Length; i++)
            {
                negativeValue += numberLessThan0[i];
            }
            return negativeValue;
        }


        private static int[] FilterNumbersLessThan0(IEnumerable<int> convertedNumbers)
        {
            return convertedNumbers.Where(i => i <= 0).ToArray();
        }
        private static int[] FilterNumbersGreaterThan1000(IEnumerable<int> convertedNumbers)
        {
            return convertedNumbers.Where(i => i <= 1000).ToArray();
        }

        private IEnumerable<int> ConvertNumbers(string[] splitNumbers)
        {
            return splitNumbers.Select(Parse);
        }

        private void ExtractDelimiters(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                var delimitersOnly = numbers.Substring(numbers.IndexOf("//", StringComparison.Ordinal) + 2,
                    numbers.IndexOf("\n", StringComparison.Ordinal) - 2);
                var setOfDelimiters = SplitDelimiters(delimitersOnly);
                AddToDefaulDelimiters(setOfDelimiters);
            }
        }
       
        private void AddToDefaulDelimiters(string[] setOfDelimiters)
        {
            _delimiters.AddRange(setOfDelimiters);
        }

        private int CalculateTotal(int[] numbers)
        {
            return numbers.Sum();
        }

        private string ExtractNumberSection(string numbers)
        {
            if(IsUserDelimitersSpecified(numbers))
            {
                var psnNewLine = numbers.IndexOf('\n');
                return numbers.Substring(psnNewLine, numbers.Length - psnNewLine);
            }
            return numbers;
        }

        private static bool IsUserDelimitersSpecified(string numbers)
        {
            return numbers.StartsWith("//");
        }

        private static string[] SplitNumbers(string numbers, List<string> defaultDelimiters)
        {
            return numbers.Split(defaultDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }
        private static string[] SplitDelimiters(string delimiters)
        {
            return delimiters.Split(new []{"[","]"}, StringSplitOptions.RemoveEmptyEntries);
        }

       private int Parse(string numberString)
        {
            if (string.IsNullOrWhiteSpace(numberString)) return 0;
            return int.Parse(numberString);
        }

    }
}