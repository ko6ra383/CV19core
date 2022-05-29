using CV19.Infrastructure.Commands;
using CV19.Models;
using CV19.Services;
using CV19.Services.Interfaces;
using CV19.ViewsModels.Base;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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
        private IDataService _DataService;
        public MainWindowViewModel MainModel { get; set; }

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

        #region SelectedCounty
        private CountryInfo _SelectedCounty;

        public CountryInfo SelectedCounty
        {
            get => _SelectedCounty;
            set
            {
                Set(ref _SelectedCounty, value);
                //Graf.Series.Clear();
                var graf = new PlotModel();
                graf.PlotType = PlotType.XY;
                graf.Axes.Add(new DateTimeAxis() { Title = "День", Position = AxisPosition.Bottom });
                graf.Axes.Add(new LinearAxis() { Title = "Количество", Position = AxisPosition.Left });
                var areaSeries = new LineSeries();
                areaSeries.ItemsSource = SelectedCounty.Counts; 
                areaSeries.StrokeThickness = 2;
                areaSeries.Color = OxyColor.FromRgb(200,30,30);
                areaSeries.DataFieldX = "Date";
                areaSeries.DataFieldY = "Count";
                graf.Series.Add(areaSeries);
                Graf = graf;
                OnPropertyChanged("Graf");
            }
        }
        public PlotModel Graf { get; set; }

        #endregion

        #region Команды
        public ICommand RefreshDataCommand { get; }
        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _DataService.GetData();
        }

        #endregion

        public CountriesStatisticViewModel(IDataService dataServices)
        {
            _DataService = dataServices;

            #region Команды
            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
            #endregion

            Graf = new PlotModel();
            Graf.PlotType = PlotType.XY;
            Graf.Axes.Add(new DateTimeAxis() { Title = "День", Position = AxisPosition.Bottom });
            Graf.Axes.Add(new LinearAxis() { Title = "Количество", Position = AxisPosition.Left });
            
        }

    }
}
