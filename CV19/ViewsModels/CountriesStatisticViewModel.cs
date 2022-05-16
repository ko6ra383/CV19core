using CV19.Infrastructure.Commands;
using CV19.Models;
using CV19.Services;
using CV19.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CV19.ViewsModels
{
    public class CountriesStatisticViewModel : BaseViewModel
    {
        private DataServices _DataService;
        public MainWindowViewModel MainModel { get; }

        #region Countries
        /// <summary>
        ///             Статистика по странам
        /// </summary>
        private IEnumerable<CountryInfo> _Countries;

        public IEnumerable<CountryInfo> Countries
        {
            get => _Countries; 
            private set => Set(ref _Countries, value);
        }

        #endregion

        #region Команды
        public ICommand RefreshDataCommand { get; }
        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _DataService.GetData();
        }
        
        #endregion

        public CountriesStatisticViewModel(MainWindowViewModel MainModel)
        {
            this.MainModel = MainModel;
            _DataService = new DataServices();

            #region Команды
            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
            #endregion
        }

    }
}
