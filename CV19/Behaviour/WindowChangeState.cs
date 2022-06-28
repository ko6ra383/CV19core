using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CV19.Behaviour
{
    public class WindowChangeState : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = AssociatedObject;
            var window = button.FindVisualRoot() as Window;
            if (window is null) return;
            switch (window.WindowState)
            {
                case WindowState.Normal:
                    window.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    window.WindowState = WindowState.Normal;
                    break;
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnButtonClick;
        }
    }
    public class MinimizeWindow : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = AssociatedObject;
            var window = button.FindVisualRoot() as Window;
            if (window is null) return;
            window.WindowState = WindowState.Minimized;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnButtonClick;
        }
    }
}
