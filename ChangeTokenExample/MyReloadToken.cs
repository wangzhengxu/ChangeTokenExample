using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Primitives;

namespace ChangeTokenExample
{
    public class MyReloadToken : IChangeToken
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
        public IDisposable RegisterChangeCallback(Action<object> callback, object state)
            => _cts.Token.Register(callback, state);

        public bool HasChanged => _cts.IsCancellationRequested;
        public bool ActiveChangeCallbacks => true;
        public void OnReload() => _cts.Cancel();
    }
}
