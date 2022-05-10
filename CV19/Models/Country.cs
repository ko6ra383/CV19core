using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CV19.Models
{
    public class PlaseInfo
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public IEnumerable<ConfirmedCount> Counts { get; set; }
    }

    public class CountryInfo : PlaseInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
    public class ProvinceInfo : PlaseInfo
    {

    }
    public struct ConfirmedCount
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }

    }

    public struct DataPoint
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }
}
