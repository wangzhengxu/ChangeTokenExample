using System;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace ChangeTokenExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //            Console.WriteLine("start monitoring dir...");
            //            var phyFileProvider = new PhysicalFileProvider("d:\\test");
            //            ChangeToken.OnChange(
            //                () => phyFileProvider.Watch("*.*"),
            //                () => Console.WriteLine("file changed!")
            //            );
            Console.WriteLine("start adding books...");
            var store = new Bookstore();
            for (int i = 1; i <= 5; i++)
            {
                store.AddBook(i.ToString(), $"书{i}");
                await Task.Delay(1000);
            }

            Console.ReadKey();
        }
    }
}
