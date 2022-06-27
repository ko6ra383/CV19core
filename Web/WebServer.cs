﻿using System;
using System.Net.Sockets;
using System.Net;

namespace Web
{

    public class WebServer
    {
        public event EventHandler<RequestReceiverEventArgs> RequestReceived;

        //private TcpListener _Listener = new TcpListener(new IPEndPoint(IPAddress.Any, 8080));
        private HttpListener _Listener;
        private readonly int _Port;
        private bool _Enabled;
        private readonly object _SyncRoot = new object();
        public int Port => _Port;
        public bool Enabled { get => _Enabled; set { if (value) Start(); else Stop(); } }
        public WebServer(int Port) => _Port = Port;
        public void Start()
        {
            if (_Enabled) return;
            lock (_SyncRoot)
            {
                if (_Enabled) return;
                _Listener = new HttpListener();
                _Listener.Prefixes.Add($"http://*:{_Port}/");
                _Listener.Prefixes.Add($"http://+:{_Port}/");
                _Enabled = true;
                ListenAsync();
            }
        }

        public void Stop()
        {
            if (!_Enabled) return;
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

            while (_Enabled)
            {
                var context = await listener.GetContextAsync().ConfigureAwait(false);
                ProcessRequest(context);
            }

            listener.Stop();
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            RequestReceived?.Invoke(this, new RequestReceiverEventArgs(context));
        }
    }

    public class RequestReceiverEventArgs : EventArgs
    {
        public HttpListenerContext Context { get; }

        public RequestReceiverEventArgs(HttpListenerContext context) => Context = context;
    }
}
