using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_ToolsForEver.Data;
using Examen_ToolsForEver.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Examen_ToolsForEver.Models.ViewModels;

namespace Examen_ToolsForEver.Controllers
{
    public class ProductsController : BasicController
    {
        public ProductsController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbcontext, RoleManager<IdentityRole> roleManager) : base(userManager, dbcontext, roleManager)
        {
        }

        #region Custom

        private void PopulateLocationsDropDownList(object SelectedLocation = null)
        {
            var locationQuery = from l in _dbcontext.Locaties
                                orderby l.LocatieNaam
                                select l;
            ViewBag.LocationID = new SelectList(locationQuery.AsNoTracking(), "ID", "LocatieNaam", SelectedLocation);
        }

        #endregion


        // GET: Products
        public async Task<IActionResult> Index(string searchValue)
        {
            var viewModel = new ProductIndexData();

            var alleData = _dbcontext.ProductLocatie
                .Include(p => p.Product)
                    .ThenInclude(f => f.Fabrikant)
                .Include(l => l.Locatie);

            if (!String.IsNullOrEmpty(searchValue))
            {
                ViewData["searchValue"] = searchValue;
                alleData.Where(i => i.Product.Naam == searchValue);
                viewModel.ProductLocaties = alleData.Where(i => i.Product.Naam.Contains(searchValue));
            }
            else
            {
                viewModel.ProductLocaties = alleData;
            }

            viewModel.Locaties = from l in _dbcontext.Locaties
                                 //join a in _dbcontext.ProductLocatie on l.ID equals a.LocatieID
                                 select l;

            return View(viewModel);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _dbcontext.Producten
                .Include(p => p.Fabrikant) // was enkelvoud
                .SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            PopulateLocationsDropDownList();
            ViewData["FabrikantID"] = new SelectList(_dbcontext.Fabrikanten, "ID", "FabrikantNaam");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductLocatieID,FabrikantID,Naam,Type,InkoopWaarde,VerkoopWaarde")] Product product)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Add(product);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            PopulateLocationsDropDownList();
            ViewData["FabrikantID"] = new SelectList(_dbcontext.Fabrikanten, "ID", "FabrikantNaam", product.FabrikantID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _dbcontext.Producten.SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            PopulateLocationsDropDownList(product);
            ViewData["FabrikantID"] = new SelectList(_dbcontext.Fabrikanten, "ID", "FabrikantNaam", product.FabrikantID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductLocatieID,FabrikantID,Naam,Type,InkoopWaarde,VerkoopWaarde")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbcontext.Update(product);
                    await _dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
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
            ViewData["FabrikantID"] = new SelectList(_dbcontext.Fabrikanten, "ID", "FabrikantNaam", product.FabrikantID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _dbcontext.Producten
                .Include(p => p.Fabrikant)
                .SingleOrDefaultAsync(m => m.ID == id);
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
            var product = await _dbcontext.Producten.SingleOrDefaultAsync(m => m.ID == id);
            _dbcontext.Producten.Remove(product);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _dbcontext.Producten.Any(e => e.ID == id);
        }
    }
}
