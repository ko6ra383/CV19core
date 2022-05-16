using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;

namespace CV19.Models
{
    public class CountryInfo : PlaseInfo
    {
        private Point? _Location;
        public override Point Location
        {
            get
            {
                if (_Location != null)
                    return (Point)_Location;
                if (ProvinceCounts is null) return default;
                var average_x = ProvinceCounts.Average(l => l.Location.X);
                var average_y = ProvinceCounts.Average(l => l.Location.Y);
                return (Point)(_Location = new Point(average_x, average_y));
            }
            set => _Location = value;
        }
        public IEnumerable<PlaseInfo> ProvinceCounts { get; set; }
    }
}
