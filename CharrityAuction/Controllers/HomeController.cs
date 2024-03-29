﻿using CharrityAuction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
            try{
            lots.RemoveAll(l => l.Id == top.Id);
            lots.RemoveAll(l => l.Id == secondTop.Id);
            lots.RemoveAll(l => l.Id == thirdTop.Id);
            }
            catch{
            }
            ViewBag.Categories = CategoryModel.GetCategoryById(null);
            if (Request.IsAuthenticated)
            {
                ViewBag.WinnedBids = BidModel.GetWinnerBids(User.Identity.GetUserId());
            }
            
                return View(lots);
        }
        public ActionResult ChangeLanguage(string lang)
        {
            new SiteLanguages().SetLanguage(lang);
            return Redirect(Request.UrlReferrer.ToString());
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
        public ActionResult Ended()
        {
            ViewBag.Categories = CategoryModel.GetCategoryById(null);

            var lots = LotModel.GetEndedLots();
            return View(lots);
        }
        public ActionResult Search(string query)
        {
            ViewBag.Categories = CategoryModel.GetCategoryById(null);

            ViewBag.Query = query;
            var lots = LotModel.GetLotByQuery(query);
            return View(lots);
        }

        public ActionResult Item(int id)
        {
            var lot = LotModel.GetLotById(id).First();
            return View(lot);
        }

        public ActionResult Category(int id)
        {
            ViewBag.Categories = CategoryModel.GetCategoryById(null);
            ViewBag.Category = CategoryModel.GetCategoryById(id).First();
            var lots = LotModel.GetLotByCategoryId(id);
            return View(lots);
        }
        public ActionResult CategoryPartial(string id,string sortId)
        {
            var lots = LotModel.GetLotByCategoryIdOrder(Convert.ToInt32(id), Convert.ToInt32(sortId));
            return PartialView(lots);

        }
        public ActionResult Charities()
        {
            var charities = Charity.GetCharityById(null);
            return View(charities);
        }

        public ActionResult IndexPartial(string sortId)
        {
            var lots = LotModel.GetLotByOrder( Convert.ToInt32(sortId));
            return PartialView(lots);

        }

        public ActionResult NewsFeed()
        {
            var news = NewsModel.GetNewsById(null);
            return View(news);
        }

        public ActionResult News(int id)
        {
            var news = NewsModel.GetNewsById(id).First();
            return View(news);
        }

        public ActionResult Partners(int id)
        {
            ViewBag.Title = id == 0 ? Resource.MenuStars : Resource.MenuCoWorkers;
            var partners = Partner.GetPartner(null, id);
            return View(partners);
        }

        public ActionResult PartnerItems(int id)
        {
            var partner = Partner.GetPartner(id, null).First();
            ViewBag.Partner = partner;
            var lots = LotModel.GetLotByPartnerId(id);
            return View(lots);
        }

        public ActionResult Buyers()
        {
            var payments = Payment.GetApprovedPaymentById(null);
            return View(payments);
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
