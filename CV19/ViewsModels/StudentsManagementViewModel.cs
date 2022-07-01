using CV19.Infrastructure.Commands;
using CV19.Models.Decanat;
using CV19.Services.Interfaces;
using CV19.Services.Students;
using CV19.Views.Windows;
using CV19.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CV19.ViewsModels
{
    public class StudentsManagementViewModel : BaseViewModel
    {
        private readonly StudentsManager _StudentsManager;
        private readonly IUserDialogService userDialog;

        public IEnumerable<Student> Students => _StudentsManager.Students;
        public IEnumerable<Group> Groups => _StudentsManager.Groups;

        #region tst
        private string  _Title = "Управление студентами";

        public string Title
        {
            get => _Title;
            private set => Set(ref _Title, value);
        }
        #endregion
        #region SelectedStudent
        private Student _SelectedStudent;

        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set => Set(ref _SelectedStudent, value);
        }
        #endregion
        #region SelectedGroup
        private Group _SelectedGroup;

        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => Set(ref _SelectedGroup, value);
        }
        #endregion
        #region Команды
        #region EditStudentCommand
        private ICommand _EditStudentCommand;
        private bool CanEditStudentCommandExecute(object p) => p is Student;
        private void OnEditStudentCommandExecute(object p)
        {
            
            if (userDialog.Edit(p))
            {
                _StudentsManager.Update((Student)p);
                userDialog.ShowInformation("Студент отредактирован", "Менеджер студентов");
            }
            else
                userDialog.ShowWarning("Отмена редактирования", "Менеджер студентов");

        }
        public ICommand EditStudentCommand => _EditStudentCommand ??= new LambdaCommand(OnEditStudentCommandExecute, CanEditStudentCommandExecute);
        #endregion
        #region CreateStudentCommand
        private ICommand _CreateStudentCommand;
        private bool CanCreateStudentCommandExecute(object p) => p is Group;
        private void OnCreateStudentCommandExecute(object p)
        {
            var group = (Group)p;
            var student = new Student();
            if (!userDialog.Edit(student) || _StudentsManager.Create(student, group.Name))
            {
                OnPropertyChanged(nameof(Students));
                return;
            }

            if (userDialog.Confirme("Неудалось создать пользователя", "Менеджер студентов"))
                OnCreateStudentCommandExecute(p);
        }
        public ICommand CreateStudentCommand => _CreateStudentCommand ??= new LambdaCommand(OnCreateStudentCommandExecute, CanCreateStudentCommandExecute);
        #endregion
        #endregion
        public StudentsManagementViewModel(StudentsManager studentsManager, IUserDialogService UserDialog) { 
            _StudentsManager = studentsManager;
            userDialog = UserDialog;
        }

    }
}
