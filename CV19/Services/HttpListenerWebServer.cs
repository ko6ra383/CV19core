using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CV19.Services.Interfaces;
using System.Threading.Tasks;
using Web;
using System.IO;

namespace CV19.Services
{
    public class HttpListenerWebServer : IWebServerService
    {
        private WebServer _Server = new WebServer(8080);
        public bool Enable { get => _Server.Enabled; set => _Server.Enabled = value; }

        public void Start() => _Server.Start();

        public void Stop() =>_Server.Stop();

        public HttpListenerWebServer()
        {
            _Server.RequestReceived += OnRequestReceived;
        }

        private static void OnRequestReceived(object sender, RequestReceiverEventArgs e)
        {
            using(var sw = new StreamWriter(e.Context.Response.OutputStream))
            {
                sw.WriteLine("CV19 app "+DateTime.Now);
            }
        }
    }
}
