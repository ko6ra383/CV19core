using CV19.Services.Interfaces;
using CV19.Models.Decanat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CV19.Views.Windows;

namespace CV19.Services
{
    public class WindowsUserDialogService : IUserDialogService
    {
        public bool Confirme(string Message, string Caption, bool Exlamation = false)
        => MessageBox.Show(Message,
            Caption, MessageBoxButton.YesNo,
            Exlamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
            == MessageBoxResult.Yes;

        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException();
            switch (item)
            {
                case Student student:
                    return EditStudent(student);

                default: throw new NotSupportedException();

            }
        }

        private bool EditStudent(Student student)
        {
            var dlg = new StudentsEditorWindow
            {
                Name =    student.Name,
                SurName = student.Surname,
                Birthday= student.Birtday,
                Rating =  student.Rating
            };
            if (dlg.ShowDialog() != true) return false;

            student.Name = dlg.Name;
            student.Surname = dlg.SurName;
            student.Birtday = dlg.Birthday;
            student.Rating = dlg.Rating;

            return true;
        }

        public void ShowError(string Message, string Caption)
         => MessageBox.Show(Message,
            Caption, MessageBoxButton.OK, MessageBoxImage.Error);

        public void ShowInformation(string Message, string Caption)
        => MessageBox.Show(Message,
            Caption, MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string Message, string Caption)
        => MessageBox.Show(Message,
            Caption, MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}
