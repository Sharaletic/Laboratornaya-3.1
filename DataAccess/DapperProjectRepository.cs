using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;

namespace DataAccess
{
    public class DapperProjectRepository : IRepository<Student>
    {
        string connectionString;

        public DapperProjectRepository()
        {
            this.connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=\"C:\\Users\\Вадим\\Desktop\\project 1\\Laboratornaya 3.2\\DataAccess\\Database1.mdf\";" +
                "Integrated Security=True";
        }

        private void UseScript(string script, Student student)
        {
            if (!string.IsNullOrEmpty(script))
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Execute(script, student);
                }
            }
        }

        public void Create(Student student)
        {
            string script = "INSERT INTO Students ([Name], [Speciality], [Group]) VALUES (@Name, @Speciality, @Group)";
            UseScript(script, student);
        }

        public void Delete(Student student)
        {
            string script = "DELETE FROM Students WHERE Id = " + student.Id;
            UseScript(script, student);
        }

        public Student ReadById(int id)
        {
            Student student;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                student = db.Query<Student>("SELECT * FROM Students WHERE Id =" + id).FirstOrDefault();
            }
            return student;
        }

        public IEnumerable<Student> ReadAll()
        {
            List<Student> students;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                students = db.Query<Student>("SELECT * FROM Students").ToList();
            }
            return students;
        }
    }
}
