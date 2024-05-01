using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TourBreeze.Server.Data;
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

        public T Get(Expression<Func<T, bool>> felter, string? includeProp = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (!string.IsNullOrEmpty(includeProp))
            {
                foreach (var includeProps in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault(felter);
        }

        public IEnumerable<T> GetAll(string? includeProp = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if(!string.IsNullOrEmpty(includeProp))
            {
                foreach(var includeProps in includeProp.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))
                {
                   query = query.Include(includeProps);
                }
            }

            return query.ToList();
        }

       
    }
}
