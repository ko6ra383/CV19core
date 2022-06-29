using CV19.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace CV19.Models.Decanat
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birtday { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
    }

    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
         
        public string Description { get; set; }
        public IList<Student> Students { get; set; }
    }
}
