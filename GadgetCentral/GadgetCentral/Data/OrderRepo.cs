using GadgetCentral.Models;
using Microsoft.EntityFrameworkCore;

namespace GadgetCentral.Data
{
    public class OrderRepo
    {
        private readonly AppDBContext _context;

        public OrderRepo(AppDBContext context)
        {
            _context = context;
        }

        public Customer? GetCustomerByEmail(string email)
        {
            return _context.Customers.FirstOrDefault(c => c.Email == email);
        }

        public List<Product> GetProductsByIds(List<int> ids)
        {
            return _context.Products.Where(p => ids.Contains(p.Id)).ToList();
        }

        public bool Create(Order order)
        {
            if (order == null) return false;

            _context.Orders.Add(order);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders
                           .Include(o => o.Customer)
                           .Include(o => o.Products)
                           .FirstOrDefault(o => o.Id == id);
        }
    }
}
