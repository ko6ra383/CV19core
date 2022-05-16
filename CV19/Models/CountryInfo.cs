using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.Models
{
    public class CountryInfo : PlaseInfo
    {
        public IEnumerable<PlaseInfo> ProvinceCounts { get; set; }
    }
}
