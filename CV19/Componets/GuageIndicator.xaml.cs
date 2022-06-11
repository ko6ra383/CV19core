using System;
using System.Windows;
using System.Windows.Controls;

namespace CV19.Componets
{
    public partial class GaugeIndicator
    {
        #region ValueProperty
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(GaugeIndicator),
                new PropertyMetadata(default(double), OnValuePropertyChanged, OnCourceValue),
                OnValidateValue);

        private static bool OnValidateValue(object value)
        {
            //проверка валидации - вернет false привязки не будет
            return true;
        }

        private static object OnCourceValue(DependencyObject d, object baseValue)
        {
            //корректирует значение
            var val = (double)baseValue;
            return Math.Max(-100, Math.Min(100, val));
        }

        private static void OnValuePropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        {
            //если свойство изменилось
            //var gauge = (GaugeIndicator)D;
            //gauge.ArrowRotator.Angle = (double)E.NewValue;
        }
        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        } 
        #endregion

        public GaugeIndicator()
        {
            InitializeComponent();
        }
    }
}
