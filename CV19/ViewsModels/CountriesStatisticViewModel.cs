using CV19.Services;
using CV19.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.ViewsModels
{
    public class CountriesStatisticViewModel : BaseViewModel
    {
        private DataServices _DataService;
        public MainWindowViewModel MainModel { get; }


        public CountriesStatisticViewModel(MainWindowViewModel MainModel)
        {
            this.MainModel = MainModel;
        }

    }
}
