using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPlayground
{
    public static class AdvancedLINQ
    {
        public static void SmallNumbers()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var smallNumbers = numbers.Where(c => c < 5);

            Console.WriteLine("Numbers < 5");

            foreach (var number in smallNumbers)
            {
                Console.WriteLine(number);
            }
        }

        public static void SoldProducts()
        {
            var products = new List<Product>
            {
                new Product { Stock = 1, Name = "Phone" },
                new Product { Stock = 0, Name = "Paper" }
            };

            var outOfStock = products.Where(c => c.Stock == 0);

            foreach (var product in outOfStock)
            {
                Console.WriteLine($"{product.Name} is sold out");
            }
        }

        public static void WhereIndex()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where((c, index) => c.Length < index);

            Console.WriteLine("short digits");

            foreach (var digit in shortDigits)
            {
                Console.WriteLine($"The word {digit} is shorter than its value.");
            }
        }

        public static void Mapping()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var textNums = numbers.Select(c => digits[c]);

            foreach (var textNum in textNums)
            {
                Console.WriteLine(textNum);
            }
        }

        public static void SkipAndTake()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var first3 = numbers.Take(3);
            var numbersLess6 = numbers.TakeWhile(c => c < 6);

            foreach (var i in first3)
            {
                Console.WriteLine(i);
            }

            foreach (var i in numbersLess6)
            {
                Console.WriteLine(i);
            }
        }

        public static void Compare()
        {
            var wordsA = new string[] { "cherry", "apple", "blueberry" };
            var wordsB = new string[] { "cherry", "apple", "blueberry" };
            var wordsC = new string[] { "apple", "apple", "blueberry" };

            var test = wordsA.SequenceEqual(wordsB);
            var test1 = wordsA.SequenceEqual(wordsC);

            Console.WriteLine($"{test}-{test1}");
        }

        public static void Combine()
        {
            int[] A = { 0, 2, 4, 5, 6 };
            int[] B = { 1, 3, 5, 7, 8 };

            int total = A.Zip(B, (a, b) => a * b).Sum();

            Console.WriteLine($"total is {total}");
        }

        public static void SelectMany()
        {
            int[] A = { 0, 2, 4, 5, 6, 8, 9 };
            int[] B = { 1, 3, 5, 7, 8 };

            var a = A.SelectMany(list => B, (p, c) => new { p, c });
        }
    }
}