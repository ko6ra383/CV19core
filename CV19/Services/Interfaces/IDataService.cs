using CV19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.Services.Interfaces
{
    public interface IDataService
    {
        IEnumerable<CountryInfo> GetData();
    }
}
