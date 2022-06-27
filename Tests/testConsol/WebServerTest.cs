using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web;

namespace testConsol
{
    public class WebServerTest
    {
        public static void Run()
        {
            var server = new WebServer(8080);
            server.RequestReceived += OnRequestReseived;
            server.Start();
            Console.WriteLine("Server start");
            Console.ReadLine();
        }

        private static void OnRequestReseived(object sender, RequestReceiverEventArgs e)
        {
            var context = e.Context;
            Console.WriteLine($"Connection {context.Request.UserHostAddress}");

            using(var writer = new StreamWriter(context.Response.OutputStream))
            {
                writer.WriteLine("Hello from test server");
            }
        }
    }
}
