using CharrityAuction.Models;
using ImageResizer;
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
            ViewBag.Partners = Partner.GetPartner(null, null);
            var lot = new LotModel();
            return View(lot);
        }

        public ActionResult EditLot(int id)
        {
            LotModel lot = LotModel.GetLotById(id).First();
            ViewBag.Partners = Partner.GetPartner(null, null);
            ViewBag.Categories = CategoryModel.GetCategoryById(null);
            return View("CreateLot", lot);
        }

        [HttpPost]
        public ActionResult CreateLot(LotModel newLot)
        {
            int id = newLot.Save();
            return RedirectToAction("Lots");
        }
        [HttpPost]
        public JsonResult DeleteLotImage(int id)
        {
            try
            {
                LotImages.Delete(id);
                return Json("Նկարը հաջողությամբ ջբջված է", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json("Ձախողում! չի հաջողվել ջնջել:",JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Lots(int? id)
        {
            if (id == null)
                id = CategoryModel.GetCategoryById(null).First().Id;
            var lots = LotModel.GetLotByCategoryId(Convert.ToInt32(id));
            ViewBag.Categories = CategoryModel.GetCategoryById(null);
            
            return View(lots);
        }

        [HttpPost]
        public ActionResult GalleryUpload(int id)
        {
            try
            {
                HttpPostedFile file = null;
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    file = System.Web.HttpContext.Current.Request.Files["HttpPostedFileBase"];
                }
                string stamp = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
                string filename = file.FileName.Split('.')[0] + stamp + "." + file.FileName.Split('.')[1];
                string pic = System.IO.Path.GetFileName(filename);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/lots"), pic);
                // file is uploaded
                file.SaveAs(path);
                LotImages images = new LotImages();
                images.Imagesource = "/images/lots/"+pic;
                images.LotId = id;
               images.Id= images.Save();
                // after successfully uploading redirect the user
                return PartialView("ImagePartial",images);
            }
            catch(Exception ex)
            {
                return Json("ՁՍԽՈՂՈՒՄ:Աշխատանքը վերբեռնված չէ");
            }
        }

        public ActionResult ImagePartial(int id)
        {
            return PartialView(id);
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

       

        public ActionResult Bids(int id)
        {
            var bids = BidModel.GetBidByLotId(id);
            return View(bids);
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
        #region Charity logic
        public ActionResult CharityCreate()
        {
            return View();
        }

        public ActionResult Charities()
        {
            var charities = Charity.GetCharityById(null);
            return View(charities);
        }

        public ActionResult EditCharity(int id)
        {
            var charity = Charity.GetCharityById(id);
            return View("CharityCreate", charity);
        }

        [HttpPost]
        public JsonResult DeleteCharity(int id)
        {
            Charity.Delete(id);
            return Json("Charity is deleted");
        }

        [HttpPost]
        public ActionResult CharityCreate(Charity charity)
        {
            charity.Save();
            return RedirectToAction("Charities");
        }
        #endregion
        #region News logic
        public ActionResult Newsfeed()
        {
            var news = NewsModel.GetNewsById(null);
            return View(news);
        }

        public ActionResult CreateNews()
        {
            NewsModel model = new NewsModel();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateNews(NewsModel news)
        {
            news.Save();
            return RedirectToAction("Newsfeed");
        }

        public ActionResult EditNews(int id)
        {
            NewsModel model = NewsModel.GetNewsById(id).First();
            return View("CreateNews", model);
        }

        public ActionResult DeleteNews(int id)
        {
            NewsModel.Delete(id);
            return Json("News is deleted");
        }
        [HttpPost]
        public ActionResult NewsImageUpload(int id)
        {
            try
            {
                HttpPostedFile file = null;
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    file = System.Web.HttpContext.Current.Request.Files["HttpPostedFileBase"];
                }
                string stamp = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
                string filename = file.FileName.Split('.')[0] + stamp + "." + file.FileName.Split('.')[1];
                string pic = System.IO.Path.GetFileName(filename);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/news"), pic);
                // file is uploaded
                file.SaveAs(path);
                NewsImages images = new NewsImages();
                images.ImageSource = "/images/news/" + pic;
                images.NewsId = id;
                images.Id = images.Save();
                // after successfully uploading redirect the user
                return PartialView("NewsImagePartial", images);
            }
            catch (Exception ex)
            {
                return Json("Error occured");
            }
        }
        public ActionResult NewsImagePartial(int id)
        {
            return PartialView(id);
        }
        [HttpPost]
        public JsonResult DeleteNewsImage(int id)
        {
            try
            {
                NewsImages.Delete(id);
                return Json("Նկարը հաջողությամբ ջբջված է", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json("Ձախողում! չի հաջողվել ջնջել:", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region Partners logic
        public ActionResult CreatePartner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePartner(Partner partner)
        {
            try
            {
                partner.Save();
                return RedirectToAction("Partners");
            }
            catch(Exception e )
            {
                return View();
            }
        }

        public ActionResult EditPartner(int id)
        {
            Partner partner = Partner.GetPartner(id, null).First();
            return View("CreatePartner", partner);
        }

        [HttpPost]
        public JsonResult DeletePartner(int id)
        {
            try
            {
                Partner.Delete(id);
                return Json("Partner deleted successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult Partners()
        {
            var partner = Partner.GetPartner(null, 0);
            return View(partner);
        }

        public ActionResult PartnersPartial(int category)
        {
            var partners = Partner.GetPartner(null, category);
            return PartialView(partners);
        }

        [HttpPost]
        public JsonResult FilePartnersUpload()
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
                string thumbnailpic = System.IO.Path.GetFileName(file.FileName.Split('.')[0] + "_thumb." + file.FileName.Split('.')[1]);

                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/partners"), pic);
                string thumbpath = System.IO.Path.Combine(
                                        Server.MapPath("~/images/partners"), thumbnailpic);
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
        #endregion

        [HttpPost]
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
                string thumbnailpic = System.IO.Path.GetFileName(file.FileName.Split('.')[0] + "_thumb." + file.FileName.Split('.')[1]);

                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/lots"), pic);
                string thumbpath = System.IO.Path.Combine(
                                        Server.MapPath("~/images/lots"), thumbnailpic);
                // file is uploaded
                file.SaveAs(path);

                ResizeSettings resizeSetting = new ResizeSettings
                {

                    Width = 220,
                    Height=220,
                    Format = file.FileName.Split('.')[1]
                };
                ImageBuilder.Current.Build(path, thumbpath, resizeSetting);
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