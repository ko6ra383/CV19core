using System;
using System.Windows;

namespace CV19.Views.Windows
{
    public partial class StudentsEditorWindow : Window
    {
        #region Name
        public static DependencyProperty NameProperty = DependencyProperty.Register(
            nameof(Name),
            typeof(string),
            typeof(StudentsEditorWindow),
            new PropertyMetadata(null));
        public string Name { get => (string)GetValue(NameProperty); set=>SetValue(NameProperty, value); }
        #endregion
        #region SurName
        public static DependencyProperty SurNameProperty = DependencyProperty.Register(
            nameof(SurName),
            typeof(string),
            typeof(StudentsEditorWindow),
            new PropertyMetadata(null));
        public string SurName { get => (string)GetValue(SurNameProperty); set => SetValue(SurNameProperty, value); }
        #endregion
        #region Rating
        public static DependencyProperty RatingProperty = DependencyProperty.Register(
            nameof(Rating),
            typeof(double),
            typeof(StudentsEditorWindow),
            new PropertyMetadata(null));
        public double Rating { get => (double)GetValue(RatingProperty); set=>SetValue(RatingProperty, value); }
        #endregion
        #region Birthday
        public static DependencyProperty BirthdayProperty = DependencyProperty.Register(
            nameof(Birthday),
            typeof(DateTime),
            typeof(StudentsEditorWindow),
            new PropertyMetadata(null));
        public DateTime Birthday { get => (DateTime)GetValue(BirthdayProperty); set=>SetValue(BirthdayProperty, value); }
        #endregion
        public StudentsEditorWindow()
        {
            InitializeComponent();
        }
    }
}
