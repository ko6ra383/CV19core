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
            Listen();
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
        private void Listen()
        {

        }
    }
}
