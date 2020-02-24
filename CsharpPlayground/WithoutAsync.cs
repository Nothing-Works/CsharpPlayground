using System;
using System.Threading.Tasks;
using CsharpPlayground.AsyncAndAwaitExample;

namespace CsharpPlayground
{
    public static class WithoutAsync
    {
        public static void Go()
        {
            var cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            var eggs = FryEggs(2);
            Console.WriteLine("eggs are ready");
            var bacon = FryBacon(3);
            Console.WriteLine("bacon is ready");
            var toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            var oj = PourOJ();
            Console.WriteLine("Oj is ready");

            Console.WriteLine("all done");
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring Orange Juice");
            return new Juice();
        }

        private static void ApplyJam(Toast t) => Console.WriteLine("Putting jam on the toast");
        private static void ApplyButter(Toast t) => Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int i = 0; i < slices; i++)
                Console.WriteLine("Putting a slice of bread in the toaster");
            Console.WriteLine("Start toasting...");

            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int i = 0; i < slices; i++)
                Console.WriteLine("flipping a slice of bacon");
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");
            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}