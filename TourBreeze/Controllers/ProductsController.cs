using Microsoft.AspNetCore.Mvc;
using TourBreeze.Models;
using TourBreeze.Server.Service.Interface;

namespace TourBreeze.Controllers
{
    public class ProductsController : Controller
    {
        #region Dependanceis And Cunstructor
        private readonly IProductRepo _repo;
        private readonly IWebHostEnvironment _webHost;
        public ProductsController(IProductRepo repo, IWebHostEnvironment webHost)
        {
            _repo = repo;
            _webHost = webHost;
        }
        #endregion

        #region Product List Method
        public IActionResult ProductList()
        {
            var productDbList = _repo.GetAll().ToList();

            return View(productDbList);
        }
        #endregion

        #region Product Add Edit Get Method
        [HttpGet]
        public IActionResult ProductUpsert(int? id)
        {

            if (id == null || id == 0)
            {

                return View("ProductUpsert", new Product());
            }

            var fromdb = _repo.Get(p => p.Id == id);
            return View("ProductUpsert", fromdb);


        }
#endregion

        #region Product Add Edit Post Method
        [HttpPost]
        public IActionResult ProductUpsert(Product product, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {

                    string fileExtensionName = Path.GetExtension(file.FileName);
                    string newFileName = "Image" + Guid.NewGuid().ToString().Substring(0, 5) + fileExtensionName;
                    string webRootpath = _webHost.WebRootPath;

                    // Edit method Of File Update
                    if (!string.IsNullOrEmpty(product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(webRootpath, product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }


                    //string finalDestination = webRootpath + @"\images\products";
                    string finalDestination = Path.Combine(webRootpath, @"images\products");
                    //Using Block Background Call Dispos Method
                    using (FileStream fileStream = new FileStream(Path.Combine(finalDestination, newFileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    //Reletive path
                    //product.ImageUrl = @"\images\products\" + newFileName;
                    product.ImageUrl = Path.Combine(@"\images\products\", newFileName);

                  
                }


                if (product.Id == null || product.Id == 0)
                {
                    _repo.Add(product);
                    _repo.Save();
                }
                else
                {
                    
                    _repo.Edit(product);

                    _repo.Save();
                }

                return RedirectToAction("ProductList");
            }
            return BadRequest("ProductUpsert");

        }
        #endregion

        #region Product Delete Method 
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                string webRootpath = _webHost.WebRootPath;

               
                var comingFormDeleteP = _repo.Get(id);
                _repo.Delete(comingFormDeleteP);

                if (!string.IsNullOrEmpty(comingFormDeleteP.ImageUrl))
                {
                    
                    string oldImagePath = Path.Combine(webRootpath, comingFormDeleteP.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                _repo.Save();
            }
            return RedirectToAction("ProductList", "Products");
        }
        #endregion

    }
}
