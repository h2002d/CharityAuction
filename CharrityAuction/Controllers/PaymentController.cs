using CharrityAuction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CharrityAuction.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        [Authorize(Roles ="Administrator")]
        public ActionResult Index()
        {
            var payments = Payment.GetPaymentById(null);
            return View(payments);
        }

        [Authorize]
        public ActionResult MakePayment(int id, int type)
        {
            try
            {
                BidModel bid = BidModel.GetBidById(id).First();
                Payment payment = new Payment();
                payment.Amount = bid.Amount;
                payment.BidId = id;
                payment.Type = type;
                payment.UserId = User.Identity.GetUserId();
                int paymentId=payment.Save();
                if (type==1)
                {
                    //Card payment actions
                    return RedirectToAction("Index","Home");

                }
                else
                {
                    return RedirectToAction("PaymentApproved","Bid", new { id = paymentId });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Authorize(Roles ="Administrator")]
        public JsonResult ChangeStatus(int paymentId,int status)
        {
            try
            {
                Payment payment = Payment.GetPaymentById(paymentId).First();
                payment.SetStatus(status);
                return Json("Status changed successfully.", JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}