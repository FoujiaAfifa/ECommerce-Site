using FancyHomeDecor.DatabaseContext.DatabaseContext;
using FancyHomeDecor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyHomeDecor.Repository.Repository
{
    public class ProductRepository
    {
        HomeDecorContext _db = new HomeDecorContext();
        public void Add(Product product)
        {

            _db.Products.Add(product);

            _db.SaveChanges();
        }

        public List<Product> GetAllProduct()
        {
            return _db.Products.ToList();
        }

        public Product GetByID(int ID)
        {
            return _db.Products.Find(ID);
        }

        public void UpdateProduct(Product product)
        {
            _db.Entry(product).State = System.Data.Entity.EntityState.Modified;

            _db.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _db.Products.Remove(product);

            _db.SaveChanges();
        }
    }
}
