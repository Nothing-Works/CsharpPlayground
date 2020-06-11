using System;
using System.Collections.Generic;

namespace CsharpPlayground
{
    public class IEnumerablePlay
    {
        public IEnumerable<int> Get()
        {
            Console.WriteLine(1);
            yield return 1;
            Console.WriteLine(2);
            yield return 2;
            Console.WriteLine(3);
        }
    }
}