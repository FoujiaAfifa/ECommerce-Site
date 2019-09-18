using FancyHomeDecor.Manager.BAL;
using FancyHomeDecor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FancyHomeDecor.Controllers
{
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();

        public ActionResult Index()
        {
            return View();
        }


        // GET: Product
        public ActionResult Add()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {

            _productManager.Add(product);
            return RedirectToAction("Show");
        }


        public ActionResult Show( string search)
        {
            var products = _productManager.GetAllProduct();

            if(string.IsNullOrEmpty(search)== false)
            {

                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return PartialView(products);
        }

        public ActionResult Edit(int ID)
        {
            var product= _productManager.GetByID(ID);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {

            _productManager.UpdateProduct(product);
            return RedirectToAction("Show");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            var product = _productManager.GetByID(ID);
            _productManager.DeleteProduct(product);

            return RedirectToAction("Show");
        }

    }
}