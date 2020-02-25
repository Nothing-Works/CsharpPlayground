using CsharpPlayground.Kata;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class PrimeFactorsTest
    {
        [Theory, MemberData(nameof(Data))]
        public void It_generates_prime_factors(int input, List<int> output)
        {
            var factors = new PrimeFactors();

            var excepted = factors.Generate(input);

            Assert.Equal(excepted, output);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1, new List<int>() },
                new object[] { 2, new List<int> { 2 } },
                new object[] { 3, new List<int> { 3 } },
                new object[] { 4, new List<int> { 2, 2 } },
                new object[] { 5, new List<int> { 5 } },
                new object[] { 6, new List<int> { 2, 3 } },
                new object[] { 8, new List<int> { 2, 2, 2 } },
                new object[] { 100, new List<int> { 2, 2, 5, 5 } },
                new object[] { 999, new List<int> { 3, 3, 3, 37 } }
            };
    }
}