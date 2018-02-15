using CharrityAuction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharrityAuction.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
           var top=LotModel.GetTopLots(1);
            ViewBag.Top = top;
            var secondTop = LotModel.GetTopLots(2);
            ViewBag.SecondTop = secondTop;
            var thirdTop= LotModel.GetTopLots(3);
            ViewBag.ThirdTop = thirdTop;
            var lots = LotModel.GetLotById(null);
            lots.RemoveAll(l => l.Id == top.Id);
            lots.RemoveAll(l => l.Id == secondTop.Id);
            lots.RemoveAll(l => l.Id == thirdTop.Id);
            ViewBag.Categories = CategoryModel.GetCategoryById(null);

            return View(lots);
        }
        public ActionResult ChangeLanguage(string lang)
        {
            new SiteLanguages().SetLanguage(lang);
            return RedirectToAction("Index", "Home");
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

        public ActionResult Item(int id)
        {
            var lot = LotModel.GetLotById(id).First();
            return View(lot);
        }

        public ActionResult Category(int id)
        {
            ViewBag.Category = CategoryModel.GetCategoryById(id).First();
            var lots = LotModel.GetLotByCategoryId(id);
            return View(lots);
        }
        public ActionResult CategoryPartial(string id,string sortId)
        {
            var lots = LotModel.GetLotByCategoryIdOrder(Convert.ToInt32(id), Convert.ToInt32(sortId));
            return PartialView(lots);

        }
    }
}