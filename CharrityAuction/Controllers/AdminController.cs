using CharrityAuction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharrityAuction.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Categories = CategoryModel.GetCategoryById(null);
            return View();
        }
        #region Lot logic
        public ActionResult CreateLot()
        {
            ViewBag.Categories = CategoryModel.GetCategoryById(null);
            return View();
        }

        public ActionResult EditLot(int id)
        {
            LotModel lot = LotModel.GetLotById(id).First();
            ViewBag.Categories = CategoryModel.GetCategoryById(null);
            return View("CreateLot", lot);
        }

        [HttpPost]
        public ActionResult CreateLot(LotModel newLot)
        {
            int id = newLot.Save();
            return RedirectToAction("Lots");
        }

        public ActionResult Lots(int? id)
        {
            if (id == null)
                id = CategoryModel.GetCategoryById(null).First().Id;
            var lots = LotModel.GetLotByCategoryId(Convert.ToInt32(id));
            return View(lots);
        }

        public ActionResult Lot(int id)
        {
            LotModel lot = LotModel.GetLotById(id).First();
            return View(lot);
        }

        [HttpPost]
        public JsonResult DeleteLot(int id)
        {
            LotModel.RemoveLotById(id);
            return Json("Լոթը ջնջված է");

        }

        [HttpPost]
        public JsonResult SaveTopLot(int index, int lotId)
        {
            LotModel.SaveTopLot(index, lotId);
            return Json(string.Format("Lot saved on Top {0}", index), JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Category logic
        public ActionResult CreateCategory()
        {
            return View();
        }

        public ActionResult EditCategory(int id)
        {
            CategoryModel category = CategoryModel.GetCategoryById(id).First();
            return View("CreateCategory", category);
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryModel newCategory)
        {
            int id = newCategory.Save();
            return RedirectToAction("Categories");
        }

        public ActionResult Categories()
        {
            var categories = CategoryModel.GetCategoryById(null);
            return View(categories);
        }

        [HttpPost]
        public JsonResult DeleteCategory(int id)
        {
            CategoryModel.Delete(id);
            return null;
        }
        #endregion
        public JsonResult FileUpload()
        {
            try
            {
                HttpPostedFile file = null;
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    file = System.Web.HttpContext.Current.Request.Files["HttpPostedFileBase"];
                }
                string stamp = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
                string filename = file.FileName;
                string pic = System.IO.Path.GetFileName(filename);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/lots"), pic);
                // file is uploaded
                file.SaveAs(path);
             
                // after successfully uploading redirect the user
                return Json("File Uploaded", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Eror");
            }
        }
    }
}