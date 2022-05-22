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

        public override string ToString()
        {
            return $"{Name} ({Location})";
        }
        private IEnumerable<ConfirmedCount> _Counts;
        public override IEnumerable<ConfirmedCount> Counts {
            get
            {
                if (_Counts != null) return _Counts;
                var points_counts = ProvinceCounts.FirstOrDefault()?.Counts?.Count() ?? 0;
                if (points_counts == 0) return Enumerable.Empty<ConfirmedCount>();

                var province_points = ProvinceCounts.Select(p => p.Counts.ToArray()).ToArray();

                var points = new ConfirmedCount[points_counts];
                foreach(var province in province_points)
                {
                    for (int i = 0; i < points_counts; i++)
                    {
                        if (points[i].Date == default)
                            points[i] = province[i];
                        else
                            points[i].Count = province[i].Count;
                    }
                }
                return _Counts = points;
            }
            set => _Counts = value;
        }
    }
}
