using CV19.Models.Decanat;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CV19.Services.Students
{
    public class TestData
    {
        public static Group[] Groups { get; } = Enumerable.Range(1, 10)
            .Select(x => new Group { Name = $"Группа {x}" })
            .ToArray();
        public static Student[] Students { get; } = CreateStudents(Groups);

        private static Student[] CreateStudents(Group[] groups)
        {
            var random = new Random();
            var students = new List<Student>(100);
            int id = 1;
            foreach(var g in groups)
            {
                for (var i = 0; i < 10; i++)
                    g.Students.Add(new Student
                    {
                        Name = $"Студент {id}",
                        Surname = $"Фамилия {id++}",
                        Birtday = DateTime.Now.Subtract(TimeSpan.FromDays(300 * random.Next(19, 30))),
                        Rating = random.Next() * 100
                    });
            }
            return groups.SelectMany(g => g.Students).ToArray();
        }
    }
}
