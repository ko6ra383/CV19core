using CV19.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.ViewsModels
{
    internal class MainWindowViewModel:BaseViewModel
    {
        #region Свойства

        #region Заголовок окна
        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { Set(ref _Title, value); }
        }

        #endregion

        #endregion

        #region Команды

        #endregion
        public MainWindowViewModel()
        {
            #region Команды

            #endregion
        }
    }
}
