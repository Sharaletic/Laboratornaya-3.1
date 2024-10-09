using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EntityProjectRepository : IRepository<Student>
    {
        private readonly DataContext _context;
        public EntityProjectRepository()
        {
            _context = new DataContext();
        }

        public void Create(Student student)
        {
            _context.Set<Student>().Add(student);
            _context.SaveChanges();
        }

        public Student ReadById(int id)
        {
            return _context.Students.Where(o => o.Id == id).FirstOrDefault();
        }

        public void Delete(Student student)
        {
            _context.Set<Student>().Remove(student);
            _context.SaveChanges();
        }

        public IEnumerable<Student> ReadAll()
        {
            return new List<Student>(_context.Set<Student>());
        }
    }
}
