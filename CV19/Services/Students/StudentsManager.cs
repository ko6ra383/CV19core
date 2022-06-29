using CV19.Models.Decanat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.Services.Students
{
    public class StudentsManager
    {
        private readonly StudentsRepository _Students;
        private readonly GroupsRepository _Groups;

        public IEnumerable<Student> Students => _Students.GetAll();
        public IEnumerable<Group> Groups => _Groups.GetAll();
        public StudentsManager(StudentsRepository students, GroupsRepository groups)
        {
            _Students = students;
            _Groups = groups;
        }
    }
}
