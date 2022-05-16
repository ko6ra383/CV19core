using CV19.Infrastructure.Commands;
using CV19.Models.Decanat;
using CV19.ViewsModels.Base;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace CV19.ViewsModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        /* ------------------------------------------------------------------------------------------------------------------- */
        #region Свойства
        #region Непонятный элемент
        public object[] CompositeCollection { get; }
        private object _SelectedCompositeValue;

        public object SelectedCompositeValue
        {
            get { return _SelectedCompositeValue; }
            set { Set(ref _SelectedCompositeValue, value); }
        }

        #endregion


        #region SelectedGroup
        public ObservableCollection<Group> Groups { get; set; }
        private Group _SelectedGroup;
        public Group SelectedGroup
        {
            get { return _SelectedGroup; }
            set { 
                if(!(Set(ref _SelectedGroup, value))) return;
                _SelectedGroupStudents.Source = value?.Students;
                OnPropertyChanged(nameof(SelectedGroupStudents));
            }
        }
        #endregion
        #region SelectedGroupStudents + Filter
        private readonly CollectionViewSource _SelectedGroupStudents = new CollectionViewSource();
        public ICollectionView SelectedGroupStudents => _SelectedGroupStudents?.View;

        /// <summary>
        /// Текст фильтра студентов
        /// </summary>
        private string _StudentFilterText;

        public string StudentFilterText
        {
            get { return _StudentFilterText; }
            set
            {
                if (!(Set(ref _StudentFilterText, value))) return;
                _SelectedGroupStudents.View.Refresh();
            }
        }

        private void OnStudentFiltred(object s, FilterEventArgs e)
        {
            if (!(e.Item is Student stud) || string.IsNullOrEmpty(stud.Name) || string.IsNullOrEmpty(stud.Surname))
            {
                e.Accepted = false;
                return;
            }
            var filterText = _StudentFilterText;
            if (string.IsNullOrWhiteSpace(filterText)) return;
            if (stud.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (stud.Surname.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            e.Accepted = false;
        }
        #endregion



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
   
        private int _SelectedTabIndex = 1;
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

        
        public IEnumerable<Student> TestStudents => Enumerable.Range(1, App.IsDesingnMode ? 10 : 100).Select(i => new Student
        {
            Name = $"Имя {i}",
            Surname = $"Фамилия {i}"
        });

        #region DiskData for TreeView
        public DirectoryViewModel DiskRootDir { get; } = new DirectoryViewModel("d:\\");
        private DirectoryViewModel _SelectedDirectory;

        public DirectoryViewModel SelectedDirectory
        {
            get { return _SelectedDirectory; }
            set
            {
                Set(ref _SelectedDirectory, value);
            }
        }
        #endregion



        #endregion

        /* ------------------------------------------------------------------------------------------------------------------- */

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

        #region CreateNewGroup
        public ICommand CreateNewGroup { get; }
        private bool CanCreateNewGroupExecute(object p) => true;
        private void OnCreateNewGroupExecuting(object p)
        { 
            var groupMaxId = Convert.ToInt32(Groups.Last().Name.Split()[1]) + 1;
            var newGroup = new Group
            {
                Name = $"Группа {groupMaxId}",
                Students = new ObservableCollection<Student>()
            };
            Groups.Add(newGroup);
        }
        #endregion
        #region DeleteGroup
        public ICommand DeleteGroup { get; }

        private bool CanDeleteGroupExecute(object p) => p is Group group && Groups.Contains(group);
        private void OnDeleteGroupExecuting(object p)
        {
            if (!(p is Group group)) return;
            var id = Groups.IndexOf(group);
            Groups.Remove(group);
            if (id < Groups.Count)
                SelectedGroup = Groups[id];
        }
        #endregion
        #endregion

        /* ------------------------------------------------------------------------------------------------------------------- */
        public MainWindowViewModel()
        {
            #region Команды
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuting, CanCloseApplicationCommandExecute);
            ChangePageCommand = new LambdaCommand(OnChangePageCommandExecuting, CanChangePageCommandExecute);
            CreateNewGroup = new LambdaCommand(OnCreateNewGroupExecuting, CanChangePageCommandExecute);
            DeleteGroup = new LambdaCommand(OnDeleteGroupExecuting, CanDeleteGroupExecute);
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

            int studID = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {studID}",
                Surname = $"Surname {studID++}",
                Birtday = DateTime.Now,
                Rating = 0
            });
            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });
            Groups = new ObservableCollection<Group>(groups);

            var dataList = new List<object>();
            dataList.Add("Hello world");
            dataList.Add(228);
            var group = Groups[1];
            dataList.Add(group);
            dataList.Add(group.Students[1]);
            CompositeCollection = dataList.ToArray();

            _SelectedGroupStudents.Filter += OnStudentFiltred;
            //сортировка в обратном порядке по имени
            //_SelectedGroupStudents.SortDescriptions.Add(new SortDescription("Name",ListSortDirection.Descending));
        }

        /* ------------------------------------------------------------------------------------------------------------------- */
    }
}
