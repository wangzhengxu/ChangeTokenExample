using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace ChangeTokenExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
           await Task.Delay(3000);
            var fileProvider = new PhysicalFileProvider("d:\\test");

            //IChangeToken changeToken = fileProvider.Watch("test.txt");
            //changeToken.RegisterChangeCallback(_ =>
            //{
            //    Logger.ToConsole("file changed!",ConsoleColor.DarkGreen);
            //},"");
            ChangeToken.OnChange(
                    () => fileProvider.Watch("test.txt"),
                    () => Logger.ToConsole("file changed!", ConsoleColor.DarkGreen)
                );
            for (int i = 0; i < 3; i++)
            {
                Logger.ToConsole("add text to file", ConsoleColor.DarkGray);
                await File.AppendAllTextAsync(@"d:\test\test.txt", DateTime.Now.ToString());
                await Task.Delay(2000);

            }

            //            Console.WriteLine("start adding books...");
            //            var store = new Bookstore();
            //            for (int i = 1; i <= 5; i++)
            //            {
            //                store.AddBook(i.ToString(), $"书{i}");
            //                await Task.Delay(1000);
            //            }

            Console.ReadKey();
        }
    }
}
