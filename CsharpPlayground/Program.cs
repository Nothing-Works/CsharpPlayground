using System;
using System.Threading.Tasks;

namespace CsharpPlayground
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Foo(1);
            // var a = new IEnumerablePlay();
            // var e = a.Get();
            //
            // foreach (var i in e)
            // {
            //     Console.WriteLine(i);
            // }
            // var e = new Email
            // {
            //     EmailAddress = "test"
            // };
            //
            // using var context = new PeopleContext();
            // context.Emails.Add(e);
            // context.SaveChanges();

            // Console.WriteLine("Hello World!");
            // AdvancedLINQ.SmallNumbers();
            // AdvancedLINQ.SoldProducts();
            // AdvancedLINQ.WhereIndex();
            // AdvancedLINQ.Mapping();
            // AdvancedLINQ.SkipAndTake();
            // AdvancedLINQ.Compare();
            // AdvancedLINQ.Combine();
            // AdvancedLINQ.SelectMany();
            // AdvancedLINQ.LazyQuery();
            // AdvancedLINQ.EagerQuery();
            // AdvancedLINQ.RunQueryTwoTimes();
            // WithoutAsync.Go();
            // await AsyncAndAwait.Go();
            // await AsyncAndAwaitBetter.Go();
            // await AsyncAndAwaitBetter.Go1();
            // await AsyncAndAwaitFinal.Go();
        }

        //tail-call
        private static void Foo(int i)
        {
            if (i == 1000000)
            {
                return;
            }

            if (i % 100 == 0)
            {
                Console.WriteLine(i);
            }

            Foo(i + 1);
        }
    }
}