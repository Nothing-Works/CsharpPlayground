using CsharpPlayground.Event;
using System;

namespace CsharpPlayground
{
    class Program
    {
        private static void FilterMain(string path)
        {
            Console.WriteLine("filter main");
        }

        static void Main(string[] args)
        {
            var email = new EmailService();
            var videoEncoding = new VideoEncoder();
            videoEncoding.VideoEncoded2 += email.OnVideoEncoded;
            videoEncoding.Encoding();
            // PhotoProcessor.FilterHandler filter = FilterMain;
            // Action<string> filter = FilterMain;

            // var p = new PhotoProcessor();
            // p.Process(filter);

            // Foo(1);
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