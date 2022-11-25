using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Regen_2022.Models;
using Regen_2022.MyDbContext;
using Regen_2022.Service;

namespace Regen_2022.Controllers
{
    public class CustomersController : Controller
    {
     //   private readonly EshopDbContext _context;

        private readonly IMarket _service;


        public CustomersController(IMarket service)
        {
            _service = service;
        }

 // GET: Customers
        public async Task<IActionResult> Index2(int ?id)
        {
              return View("Index", await _service.ReadByCategoryAsync(id));
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return View(await _service.ReadAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.CustomerExist())
            {
                return NotFound();
            }

            var customer = await _service.ReadAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CustomerCategory")] Customer customer)
        {
            if (ModelState.IsValid)
            {
               await _service.CreateCustomerAsync(customer);
                
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.CustomerExist())
            {
                return NotFound();
            }

            var customer = await _service.ReadAsync(id);   
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await  _service.UpdateAsync(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _service.CustomerExist())
            {
                return NotFound();
            }
            var customer = await _service.ReadAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service.CustomerExist())
            {
                return Problem("Entity set 'EshopDbContext.Customers'  is null.");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
