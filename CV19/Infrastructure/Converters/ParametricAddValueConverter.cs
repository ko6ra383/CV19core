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
    public class ParametricMultiplyValueConverter : Freezable, IValueConverter
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(ParametricMultiplyValueConverter),
                new PropertyMetadata(1.0));

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        public object Convert(object v, Type t, object p, CultureInfo c)
        {
            var value = System.Convert.ToDouble(v, c);
            return value * Value;
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c)
        {
            var value = System.Convert.ToDouble(v, c);
            return value / Value;
        }

        protected override Freezable CreateInstanceCore() => new ParametricMultiplyValueConverter { Value = Value};
    }
}
