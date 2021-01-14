using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Primitives;

namespace ChangeTokenExample
{
    public class DataProvider
    {
      
        private MyReloadToken _reloadToken=new MyReloadToken();
        protected IDictionary<string, string> Data { get; set; }

        public DataProvider()
        {
            Data=new Dictionary<string, string>();
        }
        public virtual void Set(string key, string value)
            => Data[key] = value;
        public IChangeToken GetReloadToken()
        {
            return _reloadToken;
        }
        protected void OnReload()
        {
            MyReloadToken previousToken = Interlocked.Exchange(ref _reloadToken, new MyReloadToken());
            previousToken.OnReload();
        }

    }
}