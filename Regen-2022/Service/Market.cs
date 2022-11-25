using Microsoft.EntityFrameworkCore;
using Regen_2022.Models;
using Regen_2022.MyDbContext;

namespace Regen_2022.Service
{

    public class Market : IMarket
    {
        private readonly EshopDbContext _context;
        public Market(EshopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> ReadAsync()
        {
            return await _context.Customers.ToListAsync();
        }

     

        public async Task<Customer> ReadAsync(int? customerId)
        {
            return await _context
                .Customers
                 .Include(customer => customer.CustomerCategory)
                .FirstOrDefaultAsync(m => m.Id == customerId);
        }


        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Add(customer);

            var id = await _context.SaveChangesAsync();

            return await ReadAsync(id);
        }

        public async Task UpdateAsync(Customer Customer)
        {
            _context.Customers.Update(Customer);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            var customer = await ReadAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
        }


        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        public bool CustomerExist()
        {
            return _context.Customers == null;
        }

        public async Task<List<Customer>> ReadByCategoryAsync(int? categoryId)
        {
            return await _context
                .Customers
                .Where(customer => customer.CustomerCategory.Id == categoryId)
                .ToListAsync();
        }
    }
}
