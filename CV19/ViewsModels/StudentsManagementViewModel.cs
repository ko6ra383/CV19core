using CV19.Models.Decanat;
using CV19.Services.Students;
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
        private readonly StudentsManager _StudentsManager;
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
        public StudentsManagementViewModel(StudentsManager studentsManager) { _StudentsManager = studentsManager; }

    }
}
