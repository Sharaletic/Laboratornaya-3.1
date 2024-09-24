using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public class Logic
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(string name, string speciallity, string group)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(speciallity) && !string.IsNullOrEmpty(group))
            {
                Student student = new Student { Name = name, Speciality = speciallity, Group = group };
                students.Add(student);
            }
        }

        public void RemoveStudent(int index)
        {
            students.Remove(students[index]);
        }

        public Logic()
        {
            students.Add(new Student { Name = "Алексей Иванов", Speciality = "Программирование", Group = "КИ21-15" });
            students.Add(new Student { Name = "Людмила Леонова", Speciality = "Архитектура", Group = "КИ20-19" });
        }

        public List<string[]> GetListStudents()
        {
            List<string[]> listOfStudents = new List<string[]>();
            for (int i = 0; i < students.Count; i++)
            {
                string[] array = new string[] { students[i].Name, students[i].Speciality, students[i].Group };
                listOfStudents.Add(array);
            }
            return listOfStudents;
        }

        public Dictionary<string, int> DistributionStudents()
        {
            var sortStudents = (from student in students
                                group student by student.Speciality into g
                                select g).ToDictionary(g => g.Key, g => g.Count());


            return sortStudents;
        }
    }
}