using MapControl;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CV19.Infrastructure.Converters
{
    public class PointToMapLocation : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Point p)) return null;
            return new Location(p.X, p.Y);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Location l)) return null;
            return new Point(l.Latitude, l.Longitude);
        }
    }
}
