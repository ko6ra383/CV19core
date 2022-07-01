using CV19.Models.Decanat;
using CV19.Services.Base;

namespace CV19.Services.Students
{
    public class StudentsRepository : RepositoryInMemory<Student>
    {
        public StudentsRepository() : base(TestData.Students )
        {

        }
        protected override void Update(Student Source, Student Destination)
        {
            Destination.Name = Source.Name;
            Destination.Surname = Source.Surname;
            Destination.Birtday = Source.Birtday;
            Destination.Rating = Source.Rating;
            Destination.Description = Source.Description;
        }
    }
}
