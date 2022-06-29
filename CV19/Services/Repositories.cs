using CV19.Models.Decanat;
using CV19.Services.Base;

namespace CV19.Services
{
    public class StudentsRepository : RepositoryInMemory<Student>
    {
        protected override void Update(Student Source, Student Destination)
        {
            Destination.Name = Source.Name;
            Destination.Surname = Source.Surname;
            Destination.Birtday = Source.Birtday;
            Destination.Rating = Source.Rating;
            Destination.Description = Source.Description;
        }
    }
    public class GroupsRepository : RepositoryInMemory<Group>
    {
        protected override void Update(Group Source, Group Destination)
        {
            Destination.Name = Source.Name;
            Destination.Description = Source.Description;
        }
    }
}
