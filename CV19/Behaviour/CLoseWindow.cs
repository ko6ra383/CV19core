using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace CV19.Behaviour
{
    public class CLoseWindow : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = AssociatedObject;

            DependencyObject root = button;
            do
            {
                var parent = VisualTreeHelper.GetParent(root);
                if (parent is null) break;
                root = parent;
            } while (true);

            (root as Window)?.Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnButtonClick;
        }
    }
}
