using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBreeze.Models;
using TourBreeze.Server.Service.Interface;

namespace TourBreeze.Server.Service.Implimentation
{
    public class ProductRepo : Repository<Product> ,IProductRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
