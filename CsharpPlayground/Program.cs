using System;

namespace CsharpPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AdvancedLINQ.SmallNumbers();
            AdvancedLINQ.SoldProducts();
            AdvancedLINQ.WhereIndex();
            AdvancedLINQ.Mapping();
            AdvancedLINQ.SkipAndTake();
            AdvancedLINQ.Compare();
            AdvancedLINQ.Combine();
            AdvancedLINQ.SelectMany();
        }
    }
}
