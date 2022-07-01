using CV19.Infrastructure.Commands.Base;
using CV19.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CV19.Infrastructure.Commands
{
    public class ManageStudentsCommand : Command
    {
        private StudentsManagementWindow _Window;
        public override bool CanExecute(object? parameter) => _Window == null;

        public override void Execute(object? parameter)
        {
            var window = new StudentsManagementWindow()
            {
                Owner = Application.Current.MainWindow
            };
            _Window = window;
            window.Closed += OnWindowClosed;
            window.ShowDialog();
        }
        
        private void OnWindowClosed(object? sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnWindowClosed;
            _Window = null;
        }
    }
}
