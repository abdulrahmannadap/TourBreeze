using System.Linq.Expressions;

namespace TourBreeze.Server.Service.Interface
{
    public interface IRepository
        <T> where T : class
    {
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void DeleteMultipal(IEnumerable<T> entity);

        IEnumerable<T> GetAll();
        T Get(int id);
        T Get(Expression<Func<T, bool>> felter);

    }
}
