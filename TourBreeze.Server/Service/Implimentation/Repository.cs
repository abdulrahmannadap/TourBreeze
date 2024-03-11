using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TourBreeze.Server.Service.Interface;

namespace TourBreeze.Server.Service.Implimentation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteMultipal(IEnumerable<T> entity)
        {
           _context.Set<T>().RemoveRange(entity);
        }

        public void Edit(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Get(Expression<Func<T, bool>> felter)
        {
           return _context.Set<T>().FirstOrDefault(felter);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
