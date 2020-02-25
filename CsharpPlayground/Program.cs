using EFDataAccess;
using System.Threading.Tasks;

namespace CsharpPlayground
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var e = new Email
            {
                EmailAddress = "test"
            };

            using var context = new PeopleContext();
            context.Emails.Add(e);
            context.SaveChanges();

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
            await AsyncAndAwaitFinal.Go();
        }
    }
}