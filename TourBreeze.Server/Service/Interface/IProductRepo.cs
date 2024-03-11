using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBreeze.Models;

namespace TourBreeze.Server.Service.Interface
{
    public interface IProductRepo :IRepository<Product>
    {
        void Save();
    }
}
