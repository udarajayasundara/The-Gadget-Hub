using TechWorld.Models;

namespace TechWorld.Data
{
    public class CustomerRepo
    {
        private AppDBContext dBContext;
        public CustomerRepo(AppDBContext appDBContext)
        {
            dBContext = appDBContext;
        }
        public bool Save()
        {
            int count = dBContext.SaveChanges();
            if (count > 0)
                return true;
            return false;
        }
        public bool Create(Customer customer)
        {
            if (customer != null) { 
            
                dBContext.Customers.Add(customer);
                return Save();
            }
            return false;
        }
    }
}
