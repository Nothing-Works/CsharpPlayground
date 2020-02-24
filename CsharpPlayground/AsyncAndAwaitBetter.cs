using CsharpPlayground.AsyncAndAwaitExample;
using System;
using System.Threading.Tasks;

namespace CsharpPlayground
{
    public class AsyncAndAwaitBetter
    {
        public static async Task Go()
        {
            var cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var eggs = await eggsTask;
            Console.WriteLine("eggs are ready");

            var bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            var toast = await toastTask;
            Console.WriteLine("toast is ready");

            var oj = PourOJ();
            Console.WriteLine("Oj is ready");

            Console.WriteLine("all done");
        }

        public static async Task Go1()
        {
            var cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var task = Task.WhenAll(eggsTask, baconTask, toastTask);
            Console.WriteLine("eggs are ready");
            Console.WriteLine("bacon is ready");
            Console.WriteLine("toast is ready");
            var oj = PourOJ();
            Console.WriteLine("Oj is ready");

            Console.WriteLine("all done");
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int howmany)
        {
            var toast = await ToastBreadAsync(howmany);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring Orange Juice");
            return new Juice();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private static void ApplyJam(Toast t) => Console.WriteLine("Putting jam on the toast");
        private static void ApplyButter(Toast t) => Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int i = 0; i < slices; i++)
                Console.WriteLine("Putting a slice of bread in the toaster");
            Console.WriteLine("Start toasting...");

            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int i = 0; i < slices; i++)
                Console.WriteLine("flipping a slice of bacon");
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");
            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }
    }
}