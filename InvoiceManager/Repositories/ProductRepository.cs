using InvoiceManager.Models;
using InvoiceManager.Models.Domains;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManager.Repositories
{
    public class ProductRepository
    {
        public List<Product> GetProducts()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int productId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.Single(x => x.Id == productId);
            }
        }
    }
}