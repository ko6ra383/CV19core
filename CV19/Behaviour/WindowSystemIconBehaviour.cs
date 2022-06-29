using CV19.Infrastructure.Extensions;
using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace CV19.Behaviour
{
    public class WindowSystemIconBehaviour : Behavior<Image>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += OnButtonClick;
        }

        private void OnButtonClick(object sender, MouseButtonEventArgs e)
        {
            if (!(AssociatedObject.FindVisualRoot() is Window window)) return;

            e.Handled = true;

            if (e.ClickCount > 1) window.Close();
            else
                window.SendMessage(WM.SYSCOMMAND, SC.KEYMENU);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnButtonClick;
        }
    }
}
