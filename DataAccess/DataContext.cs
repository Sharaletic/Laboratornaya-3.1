using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DataContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=\"C:\\Users\\Вадим\\Desktop\\project 1\\Laboratornaya 3.2\\DataAccess\\Database1.mdf\";" +
            "Integrated Security=True")
        { }
    }
}
