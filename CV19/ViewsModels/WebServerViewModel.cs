using CV19.Infrastructure.Commands;
using CV19.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CV19.ViewsModels
{
    public class WebServerViewModel : BaseViewModel
    {
        private bool _Enable;

        public bool Enable
        {
            get { return _Enable; }
            set { Set(ref _Enable, value); }
        }

        #region StartCommand
        private ICommand _StartCommdand;
        private bool CanStartCommandExecute(object p) => !_Enable;
        private void OnStartCommandExecute(object p)
        {
            Enable = true;

        }
        public ICommand StartCommdand => _StartCommdand ??= new LambdaCommand(OnStartCommandExecute, CanStartCommandExecute);
        #endregion

        #region StopCommand
        private ICommand _StopCommdand;
        private bool CanStopCommandExecute(object p) => _Enable;
        private void OnStopCommandExecute(object p)
        {
            Enable = false;
        }
        public ICommand StopCommdand => _StopCommdand ??= new LambdaCommand(OnStopCommandExecute, CanStopCommandExecute);
        #endregion

    }
}
