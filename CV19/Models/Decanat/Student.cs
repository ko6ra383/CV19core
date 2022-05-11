using System;
using System.Collections.Generic;

namespace CV19.Models.Decanat
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birtday { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
    }

    public class Group
    {
        public string Name { get; set; }
        public IList<Student> Students { get; set; }
    }
}
