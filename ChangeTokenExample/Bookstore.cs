using System;
using Microsoft.Extensions.Primitives;

namespace ChangeTokenExample
{
    public class Bookstore:DataProvider,IDisposable
    {
        private readonly IDisposable _changeTokenRegistration;
        public Bookstore()
        {
            _changeTokenRegistration = ChangeToken.OnChange(GetReloadToken,PrintBooks);
        }
        public void AddBook(string sn,string bookName)
        {
            Set(sn,bookName);
            OnReload();
        }

        private void PrintBooks()
        {
            Console.WriteLine("=======book list=========");
            foreach (var (key, value) in Data)
            {
                Console.WriteLine($"sn:{key} book:{value}");
            }
            Console.WriteLine("=========================");
        }

        public void Dispose() => Dispose(true);
        
        protected virtual void Dispose(bool disposing)
        {
            _changeTokenRegistration?.Dispose();
        }
    }
}