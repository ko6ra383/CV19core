using CV19.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.ViewsModels
{
    public class StudentsManagementViewModel : BaseViewModel
    {
        #region tst
        private string  _Title = "Управление студентами";

        public string Title
        {
            get => _Title;
            private set => Set(ref _Title, value);
        }
        #endregion
    }
}
