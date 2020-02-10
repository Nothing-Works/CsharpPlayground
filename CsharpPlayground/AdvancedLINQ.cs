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
    }
}