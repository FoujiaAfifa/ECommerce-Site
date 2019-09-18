using FancyHomeDecor.Models.Models;
using FancyHomeDecor.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyHomeDecor.Manager.BAL
{
    public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();
        public void Add(Product product)
        {

             _productRepository.Add(product);
        }

        public List<Product> GetAllProduct()
        {
           return _productRepository.GetAllProduct();
        }

        public Product GetByID(int ID)
        {
            return _productRepository.GetByID(ID);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            _productRepository.DeleteProduct(product);
        }
    }
}
