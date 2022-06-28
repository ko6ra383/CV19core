using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CV19.Behaviour
{
    public class DragInCanvas : Behavior<UIElement>
    {
        private Point _StartPoint;
        private Canvas _Canvas;

        public static readonly DependencyProperty XValueProperty =
            DependencyProperty.Register(
                nameof(XValue),
                typeof(double),
                typeof(DragInCanvas),
                new PropertyMetadata(default(double)));
        public double XValue { get => (double)GetValue(XValueProperty); set => SetValue(XValueProperty, value); }

        public static readonly DependencyProperty YValueProperty =
            DependencyProperty.Register(
                nameof(YValue),
                typeof(double),
                typeof(DragInCanvas),
                new PropertyMetadata(default(double)));
        public double YValue { get => (double)GetValue(YValueProperty); set => SetValue(YValueProperty, value); }
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += OnButtonDown;
        }

        private void OnButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((_Canvas ??= VisualTreeHelper.GetParent(AssociatedObject) as Canvas) is null) return;

            _StartPoint = e.GetPosition(AssociatedObject);
            AssociatedObject.CaptureMouse();
            AssociatedObject.MouseMove += OnMouseMove;
            AssociatedObject.MouseUp += OnMouseUp;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var obj = AssociatedObject;
            var curr_pos = e.GetPosition(_Canvas);

            var delta = curr_pos - _StartPoint;
            obj.SetValue(Canvas.LeftProperty, delta.X);
            obj.SetValue(Canvas.TopProperty, delta.Y);

            XValue = delta.X;
            YValue = delta.Y;
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            AssociatedObject.MouseMove -= OnMouseMove;
            AssociatedObject.MouseUp -= OnMouseUp;
            AssociatedObject.ReleaseMouseCapture();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnButtonDown;
            AssociatedObject.MouseMove -= OnMouseMove;
            AssociatedObject.MouseUp -= OnMouseUp;
        }
    }
}
