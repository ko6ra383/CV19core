using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CV19.Behaviour
{
    public class WindowTitleBarDrag : Behavior<UIElement>
    {
        private Window _Window;
        protected override void OnAttached()
        {
            _Window = AssociatedObject as Window ?? AssociatedObject.FindVisualParent<Window>();
            AssociatedObject.MouseLeftButtonDown += OnMouseDown;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1) return;
            _Window?.DragMove();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnMouseDown;
            _Window = null;
        }
    }
}
