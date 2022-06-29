using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
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

            (button.FindVisualRoot() as Window)?.Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnButtonClick;
        }
    }
}
