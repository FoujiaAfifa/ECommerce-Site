using FancyHomeDecor.Manager.BAL;
using FancyHomeDecor.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FancyHomeDecor.Controllers
{
    public class HomeController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.Categories = _categoryManager.GetAllCategory();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}