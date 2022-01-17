using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMS.Data;
using PMS.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Super user")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostEnvironment;

        public ProductsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment )
        {
            _context = context;
            _hostEnvironment = hostingEnvironment;  
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries.ToList(), "CountryId", "CountryName");
            ViewData["CityId"] = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
            ViewData["CompanyId"] = new SelectList(_context.Companies.ToList(), "CompanyId", "CompanyName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Name,ShortDescription,FullDescription,Price,DateTime")] Product product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var searchProduct = _context.Products.FirstOrDefault(c => c.Name == product.Name);
                if(searchProduct == null)
                {
                    ViewBag.messagee = "This product already exist";
                    //TempData["save"] = "Product has been save successfully";
                    ViewData["CountryId"] = new SelectList(_context.Countries.ToList(), "CountryId", "CountryName");
                    ViewData["CityId"] = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
                    ViewData["CompanyId"] = new SelectList(_context.Companies.ToList(), "CompanyId", "CompanyName");
                    return View(product);
                }

                if (image != null)
                {
                    var name = Path.Combine(_hostEnvironment.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    product.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    product.Image = "Images/noimage.PNG";
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["CountryId"] = new SelectList(_context.Countries.ToList(), "CountryId", "CountryName");
            ViewData["CityId"] = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
            ViewData["CompanyId"] = new SelectList(_context.Companies.ToList(), "CompanyId", "CompanyName");
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,UniqueId,Name,Image,ShortDescription,FullDescription,Price,ProductColor,IsAvailable,DateTime,CityId,CompanyId,")] Product product, IFormFile image)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null)
                    {
                        var name = Path.Combine(_hostEnvironment.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                        await image.CopyToAsync(new FileStream(name, FileMode.Create));
                        product.Image = "Images/" + image.FileName;
                    }

                    if (image == null)
                    {
                        product.Image = "Images/noimage.PNG";
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
