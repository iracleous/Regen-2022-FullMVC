using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Regen_2022.Models;
using Regen_2022.MyDbContext;

namespace Regen_2022.Controllers
{
    public class CustomerCategoriesController : Controller
    {
        private readonly EshopDbContext _context;

        public CustomerCategoriesController(EshopDbContext context)
        {
            _context = context;
        }

        // GET: CustomerCategories
        public async Task<IActionResult> Index()
        {
              return View(await _context.CustomerCategories.ToListAsync());
        }

        // GET: CustomerCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomerCategories == null)
            {
                return NotFound();
            }

            var customerCategory = await _context.CustomerCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerCategory == null)
            {
                return NotFound();
            }

            return View(customerCategory);
        }

        // GET: CustomerCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CustomerCategory customerCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerCategory);
        }

        // GET: CustomerCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomerCategories == null)
            {
                return NotFound();
            }

            var customerCategory = await _context.CustomerCategories.FindAsync(id);
            if (customerCategory == null)
            {
                return NotFound();
            }
            return View(customerCategory);
        }

        // POST: CustomerCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CustomerCategory customerCategory)
        {
            if (id != customerCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerCategoryExists(customerCategory.Id))
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
            return View(customerCategory);
        }

        // GET: CustomerCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomerCategories == null)
            {
                return NotFound();
            }

            var customerCategory = await _context.CustomerCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerCategory == null)
            {
                return NotFound();
            }

            return View(customerCategory);
        }

        // POST: CustomerCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomerCategories == null)
            {
                return Problem("Entity set 'EshopDbContext.CustomerCategories'  is null.");
            }
            var customerCategory = await _context.CustomerCategories.FindAsync(id);
            if (customerCategory != null)
            {
                _context.CustomerCategories.Remove(customerCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerCategoryExists(int id)
        {
          return _context.CustomerCategories.Any(e => e.Id == id);
        }
    }
}
