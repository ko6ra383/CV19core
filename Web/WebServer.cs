using System;
using System.Net.Sockets;
using System.Net;

namespace Web
{
    
    public class WebServer
    {
        private HttpListener _Listener;
        private readonly int _Port;
        private bool _Enabled;
        private readonly object _SyncRoot = new object();

        private event EventHandler<RequestReceiverEventArgs> RequestReceiver;

        public int Port => _Port;
        public bool Enabled {get=> _Enabled;set { if (value) Start(); else Stop(); } }
        public WebServer(int port)=> _Port = port;
        public void Start()
        {
            if (_Enabled) return;
            lock (_SyncRoot)
            {
                if (_Enabled) return;
                _Listener = new HttpListener();
                _Listener.Prefixes.Add($"http://*:{Port}");
                _Listener.Prefixes.Add($"http://+:{Port}");
                _Enabled = true;
            }
            ListenAsync();
        }

        public void Stop()
        {
            lock (_SyncRoot)
            {
                if (!_Enabled) return;
                _Listener = null;
                _Enabled = false;
            }
        }
        private async void ListenAsync()
        {
            var listener = _Listener;
            listener.Start();

            HttpListenerContext context = null;
            while (_Enabled)
            {
                var contex = await listener.GetContextAsync().ConfigureAwait(false);
                ProcessRequest(context);
            }
            listener.Stop();
        }
        private void ProcessRequest(HttpListenerContext context)
        {
            RequestReceiver?.Invoke(this, new RequestReceiverEventArgs(context));
        }
        public class RequestReceiverEventArgs : EventArgs
        {
            public HttpListenerContext Context { get; set; }
            public RequestReceiverEventArgs(HttpListenerContext context) => Context = context;
        }
    }
}
