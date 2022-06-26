using System;
using System.Threading;
namespace testConsol
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";

            var thread = new Thread(ThreadMethod);
            thread.Name = "Other Thread";

            thread.Start();
            CheckThread();
        }
        private static void ThreadMethod()
        {
            CheckThread();

            while (true)
            {
                Thread.Sleep(100);
                Console.Title = DateTime.Now.ToString();
            }
        }
        private static void CheckThread()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine($"{thread.ManagedThreadId} : {thread.Name}");
        }
    }
}
