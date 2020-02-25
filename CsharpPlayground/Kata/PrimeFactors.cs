using System.Collections.Generic;

namespace CsharpPlayground.Kata
{
    public class PrimeFactors
    {
        public List<int> Generate(int number)
        {
            var factors = new List<int>();

            for (var divider = 2; number > 1; divider++)
            {
                for (; number % divider == 0; number /= divider)
                    factors.Add(divider);
            }

            return factors;
        }
    }
}