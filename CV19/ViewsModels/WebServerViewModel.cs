using CV19.Infrastructure.Commands;
using CV19.Services.Interfaces;
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

        public bool Enable
        {
            get { return Server.Enable; }
            set
            { 
                Server.Enable = value;
                OnPropertyChanged();
            }
        }

        #region StartCommand
        private ICommand _StartCommdand;
        private bool CanStartCommandExecute(object p) => !Enable;
        private void OnStartCommandExecute(object p)
        {
            Server.Start();
            OnPropertyChanged("Enable");

        }
        public ICommand StartCommdand => _StartCommdand ??= new LambdaCommand(OnStartCommandExecute, CanStartCommandExecute);
        #endregion

        #region StopCommand
        private ICommand _StopCommdand;
        private bool CanStopCommandExecute(object p) => Enable;
        private void OnStopCommandExecute(object p)
        {
            Server.Stop();
            OnPropertyChanged("Enable");
        }
        public ICommand StopCommdand => _StopCommdand ??= new LambdaCommand(OnStopCommandExecute, CanStopCommandExecute);

        public IWebServerService Server { get; }
        #endregion

        public WebServerViewModel(IWebServerService Server)
        {
            this.Server = Server;
        }
    }
}
