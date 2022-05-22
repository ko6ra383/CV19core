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
    public class LocationPointToStr : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (!(value is Point point)) return null;
            return $"Lat:{point.X};Lon:{point.Y}";
        }

        public object ConvertBack(object value, Type t, object p, CultureInfo c)
        {
            var str = value as string;
            if (str is null) return null;

            var components = str.Split(';');
            var latstr = components[0].Split(':')[1];
            var lonstr = components[1].Split(':')[1];

            var lat = double.Parse(latstr);
            var lon = double.Parse(lonstr);
            return new Point(lat, lon);
        }
    }
}
