using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using CharrityAuction.Models;

namespace CharrityAuction.Controllers
{

    public class BidController : BaseController
    {
        // GET: Bid
        [Authorize]
        public ActionResult Index(int id)
        {
            BidModel model = BidModel.GetBidById(id).First();
            if (!model.UserId.Equals(User.Identity.GetUserId()))
            {
                throw new HttpException(404, "Wrong user");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult MakePaymentCard(int id)
        {
            BidModel model = BidModel.GetBidById(id).First();
            return View(model);
        }

        public ActionResult PaymentApproved(int id)
        {
            BidModel bid = BidModel.GetBidById(id).First();
            if (bid.UserId.Equals(User.Identity.GetUserId()))
            {
                ViewBag.BidId = id;
                return View();
            }
            else
            {
                throw new HttpException(404, "User not found");
            }
        }
        [HttpPost]
        [Authorize]
        public JsonResult CreateBid(BidModel bid)
        {
            try
            {
                LotModel lot = LotModel.GetLotById(bid.LotId).First();
                if(lot.DeadLine<DateTime.Now)
                    return Json("@Resource.LotDayPassed", JsonRequestBehavior.AllowGet);

                if (bid.Amount < lot.CurrentBid + lot.Step)
                    return Json("Amount is low than the current bid's", JsonRequestBehavior.AllowGet);
                else
                {
                    bid.UserId = User.Identity.GetUserId();
                    bid.Save();
                    return Json("Bid made successfully. ", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult _LotLastBidPartial(int id)
        {
            var bids = BidModel.GetBidByLotId(id);
            if (bids.Count >= 5)
            {
                var tops = bids.Skip(Math.Max(0, bids.Count() - 5)).Take(5);
                return PartialView(tops);
            }
            else
            {
                return PartialView(bids);
            }
        }
    }
}