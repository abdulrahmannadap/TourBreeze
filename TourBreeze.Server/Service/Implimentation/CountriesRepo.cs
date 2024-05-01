
using TourBreeze.Models;
using TourBreeze.Server.Data;
using TourBreeze.Server.Service.Interface;

namespace TourBreeze.Server.Service.Implimentation
{
    public class CountriesRepo : Repository<Countrie>, ICountriesRepo
    {
        private readonly ApplicationDbContext _context;
        public CountriesRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
