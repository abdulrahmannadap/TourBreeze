
using TourBreeze.Models;

namespace TourBreeze.Server.Service.Interface
{
    public interface IProductRepo :IRepository<Product>
    {
        void Save();
    }
}
