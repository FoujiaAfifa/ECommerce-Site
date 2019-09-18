using FancyHomeDecor.Manager.BAL;
using FancyHomeDecor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FancyHomeDecor.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();

        public ActionResult Index()
        {

            var categories = _categoryManager.GetAllCategory();
            return View(categories);
        }


        // GET: Category
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {

            _categoryManager.Add(category);
            return View();
        }

        public ActionResult Edit(int ID)
        {
            var category = _categoryManager.GetByID(ID);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {

            _categoryManager.UpdateCategory(category);
            return RedirectToAction("Show");
        }


        public ActionResult Delete(int ID)
        {
            var category = _categoryManager.GetByID(ID);
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {

             category = _categoryManager.GetByID(category.ID);
            _categoryManager.DeleteCategory(category);
            return RedirectToAction("Show");
        }


        public ActionResult Show()
        {

           var categories=  _categoryManager.GetAllCategory();
            return View(categories);
        }
    }
}