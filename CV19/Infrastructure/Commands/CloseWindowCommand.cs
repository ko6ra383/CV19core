﻿using CV19.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CV19.Infrastructure.Commands
{
    public class CloseWindowCommand : Command
    {
        public override bool CanExecute(object? parameter) => parameter is Window;
        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;
            var window = (Window)parameter;
            window.Close();
        }
    }
    public class CloseDialogCommand : Command
    {
        public bool? DialogResult { get; set; }

        public override bool CanExecute(object? parameter) => parameter is Window;
        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;
            var window = (Window)parameter;
            window.DialogResult = DialogResult;
            window.Close();
        }
    }
}
