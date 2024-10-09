using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;

namespace BusinessLogic
{
    public class Logic
    {
        IRepository<Student> repository = new EntityProjectRepository();
        //IRepository<Student> repository = new DapperProjectRepository();

        public void AddStudent(string name, string speciallity, string group)
        {
            repository.Create(new Student { Name = name, Speciality = speciallity, Group = group });
        }

        public void RemoveStudent(int id)
        {
            repository.Delete(repository.ReadById(id));
        }

        public List<string[]> GetListStudents()
        {
            List<string[]> listOfStudents1 = new List<string[]>();
            List<Student> students = repository.ReadAll().ToList();
            for (int i = 0; i < students.Count; i++)
            {
                listOfStudents1.Add(new string[] { students[i].Id.ToString(), students[i].Name, students[i].Speciality, students[i].Group });
            }
            return listOfStudents1;
        }

        public Dictionary<string, int> DistributionStudents()
        {
            var sortStudents = (from student in repository.ReadAll()
                                group student by student.Speciality into g
                                select g).ToDictionary(g => g.Key, g => g.Count());
            return sortStudents;
        }
    }
}