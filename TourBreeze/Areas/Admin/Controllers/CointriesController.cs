using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;
using TourBreeze.Models;
using TourBreeze.Server.Service.Interface;

namespace TourBreeze.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CointriesController : Controller
    {
        private readonly ICountriesRepo _countriesRepo;

        public CointriesController(ICountriesRepo countriesRepo)
        {
            _countriesRepo = countriesRepo;
        }

        // GET: CointriesController
        public ActionResult Index()
        {

           var listFromDb = _countriesRepo.GetAll().ToList();
            return View(listFromDb);
        }

        // GET: CointriesController/Details/5
        public ActionResult Details(int id)
        {
            var fromdb = _countriesRepo.Get(p => p.Id == id);
            return View(fromdb);
        }

        // GET: CointriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CointriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Countrie countrie)
        {
            if (ModelState.IsValid)
            {
                

                try
                {
                    if (countrie.Id == null || countrie.Id == 0)
                    {
                        _countriesRepo.Add(countrie);
                        _countriesRepo.Save();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }
            return BadRequest();
               
        }

        // GET: CointriesController/Edit/5
        public ActionResult Edit(int id)
        {
            
            var fromdb = _countriesRepo.Get(p => p.Id == id);
            return View(fromdb);
        }

        // POST: CointriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Countrie countrie)
        {
           
            try
            {
                if (countrie.Id == null || countrie.Id == 0)
                {
                    _countriesRepo.Edit(countrie);
                    _countriesRepo.Save();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CointriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var fromdb = _countriesRepo.Get(p => p.Id == id);
            return View(fromdb);
        }

        // POST: CointriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (id == 0)
            {
                return NotFound();
            }
            try
            {

                var comingFormDeleteP = _countriesRepo.Get(id);
                _countriesRepo.Delete(comingFormDeleteP);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
