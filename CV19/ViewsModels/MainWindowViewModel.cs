﻿using CV19.Infrastructure.Commands;
using CV19.ViewsModels.Base;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CV19.ViewsModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        #region Свойства

        #region Заголовок окна
        private string _Title = "анализ CV19";

        public string Title
        {
            get { return _Title; }
            set { Set(ref _Title, value); }
        }

        #endregion
        #region Статус программы
        /// <summary>Статус программы</summary>
        private string _Status = "Готово";
        /// <summary>Статус программы</summary>
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
        #endregion

        #region Текущая вкладка
        private int _SelectedTabIndex = 0;
        public int SelectedTabIndex
        {
            get => _SelectedTabIndex;
            set => Set(ref _SelectedTabIndex, value);
        }
        #endregion
        #region TestDataPoints
        /// <summary>Тестовый набор данных для визуализации графиков</summary>
        public PlotModel Graf { get; set; }

        private IEnumerable<OxyPlot.DataPoint> _TestDataPoints;
        public IEnumerable<OxyPlot.DataPoint> TestDataPoints
        {
            get => _TestDataPoints;
            set => Set(ref _TestDataPoints, value);
        }
        #endregion
        #endregion

        #region Команды
        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuting(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion
        #region ChangePageCommand
        public ICommand ChangePageCommand { get; }
        private bool CanChangePageCommandExecute(object p) => SelectedTabIndex >= 0;
        private void OnChangePageCommandExecuting(object p)
        {
            if (p is null) return;
            SelectedTabIndex += Convert.ToInt32(p);
        }
        #endregion
        #endregion
        public MainWindowViewModel()
        {
            #region Команды
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuting, CanCloseApplicationCommandExecute);
            ChangePageCommand = new LambdaCommand(OnChangePageCommandExecuting, CanChangePageCommandExecute);
            #endregion

            var data_points = new List<OxyPlot.DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new OxyPlot.DataPoint(x, y));
            }
            TestDataPoints = data_points;
            var series = new LineSeries();
            foreach (var dataPoint in data_points)
            {
                series.Points.Add(dataPoint);
            }
            Graf = new PlotModel();
            Graf.PlotType = PlotType.XY;
            Graf.Series.Add(series);
        }
    }
}
