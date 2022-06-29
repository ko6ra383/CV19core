﻿using CV19.Models.Decanat;
using CV19.Services.Base;

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
    }
}
