using CV19.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CV19.Services
{
    public class AsyncDataService : IAsyncDataService
    {
        private const int _SleepTime = 7000;
        public string GetResult(DateTime Time)
        {
            Thread.Sleep(_SleepTime);
            return $"Result value {Time}";
        }
    }
}
