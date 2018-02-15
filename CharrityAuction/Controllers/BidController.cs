using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharrityAuction.Controllers
{
    
    public class BidController : BaseController
    {
        // GET: Bid
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public JsonResult Bid()
        {
            try
            {

                return Json("Bid made successfully. ", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
    }
}