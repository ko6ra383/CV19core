using CV19.Models.Decanat;
using CV19.Services.Base;
using System.Linq;

namespace CV19.Services.Students
{
    public class GroupsRepository : RepositoryInMemory<Group>
    {
        public GroupsRepository() : base(TestData.Groups)
        {

        }
        protected override void Update(Group Source, Group Destination)
        {
            Destination.Name = Source.Name;
            Destination.Description = Source.Description;
        }

        public Group GetName(string name) => GetAll().FirstOrDefault(g => g.Name == name);
    }
}
