using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_ToolsForEver.Data;
using Examen_ToolsForEver.Models;

namespace Examen_ToolsForEver.Controllers
{
    public class ProductLocatiesController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public ProductLocatiesController(ApplicationDbContext context)
        {
            _dbcontext = context;    
        }

        // GET: ProductLocaties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _dbcontext.ProductLocatie.Include(p => p.Locatie).Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductLocaties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLocatie = await _dbcontext.ProductLocatie
                .Include(p => p.Locatie)
                .Include(p => p.Product)
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (productLocatie == null)
            {
                return NotFound();
            }

            return View(productLocatie);
        }

        // GET: ProductLocaties/Create
        public IActionResult Create()
        {
            ViewData["LocatieID"] = new SelectList(_dbcontext.Locaties, "ID", "LocatieNaam");
            ViewData["ProductID"] = new SelectList(_dbcontext.Producten, "ID", "Naam");
            return View();
        }

        // POST: ProductLocaties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Aantal,MinVoorraad,LocatieID,ProductID")] ProductLocatie productLocatie)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Add(productLocatie);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["LocatieID"] = new SelectList(_dbcontext.Locaties, "ID", "LocatieNaam", productLocatie.LocatieID);
            ViewData["ProductID"] = new SelectList(_dbcontext.Producten, "ID", "Naam", productLocatie.ProductID);
            return View(productLocatie);
        }

        // GET: ProductLocaties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLocatie = await _dbcontext.ProductLocatie.SingleOrDefaultAsync(m => m.ProductID == id);
            if (productLocatie == null)
            {
                return NotFound();
            }
            ViewData["LocatieID"] = new SelectList(_dbcontext.Locaties, "ID", "LocatieNaam", productLocatie.LocatieID);
            ViewData["ProductID"] = new SelectList(_dbcontext.Producten, "ID", "Naam", productLocatie.ProductID);
            return View(productLocatie);
        }

        // POST: ProductLocaties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Aantal,MinVoorraad,LocatieID,ProductID")] ProductLocatie productLocatie)
        {
            if (id != productLocatie.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbcontext.Update(productLocatie);
                    await _dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductLocatieExists(productLocatie.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["LocatieID"] = new SelectList(_dbcontext.Locaties, "ID", "LocatieNaam", productLocatie.LocatieID);
            ViewData["ProductID"] = new SelectList(_dbcontext.Producten, "ID", "Naam", productLocatie.ProductID);
            return View(productLocatie);
        }

        // GET: ProductLocaties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLocatie = await _dbcontext.ProductLocatie
                .Include(p => p.Locatie)
                .Include(p => p.Product)
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (productLocatie == null)
            {
                return NotFound();
            }

            return View(productLocatie);
        }

        // POST: ProductLocaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productLocatie = await _dbcontext.ProductLocatie.SingleOrDefaultAsync(m => m.ProductID == id);
            _dbcontext.ProductLocatie.Remove(productLocatie);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductLocatieExists(int id)
        {
            return _dbcontext.ProductLocatie.Any(e => e.ProductID == id);
        }
    }
}
