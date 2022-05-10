using System;
using System.Collections.Generic;

namespace CV19.Models.Decanat
{
    public class Student
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime Birtday { get; set; }
        public double Rating { get; set; }
    }

    public class Group
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
}
