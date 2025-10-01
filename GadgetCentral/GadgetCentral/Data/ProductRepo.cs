using GadgetCentral.Models;

namespace GadgetCentral.Data
{
    public class ProductRepo
    {
        private AppDBContext dBContext;

        public ProductRepo(AppDBContext appDBContext)
        {
            dBContext = appDBContext;
        }
        public Product GetProduct(int id)
        {
            return dBContext.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
