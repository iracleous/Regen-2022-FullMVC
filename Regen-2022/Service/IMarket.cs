using Microsoft.EntityFrameworkCore;
using Regen_2022.Models;
using Regen_2022.MyDbContext;

namespace Regen_2022.Service
{
    public interface IMarket
    {
        public Task<List<Customer>> ReadAsync();
        public Task<List<Customer>> ReadByCategoryAsync(int? categoryId);


        public Task<Customer> ReadAsync(int? customerId);
        public Task<Customer> CreateCustomerAsync(Customer customer);
        public Task   UpdateAsync(Customer Customer);
        public Task   DeleteAsync(int id);

        public bool CustomerExist();
        public bool CustomerExists(int id);
    }

    

}
