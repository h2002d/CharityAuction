using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharrityAuction.Models
{
    public class NewsModel
    {
        #region Properties
        public int? Id { get; set; }

        public string Name { get; set; }
        public string Name_EN { get; set; }
        public string Name_AM { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Description_EN { get; set; }
        [AllowHtml]
        public string Description_AM { get; set; }
        public string VideoSource { get; set; }
        public DateTime CreateDate { get; set; }
        public string Link { get; set; }
        public List<NewsImages> Images { get { return NewsImages.GetImagesByNewsId(Convert.ToInt32(Id)); } set { } }

        static DAO.NewsModelDAO DAO = new CharrityAuction.DAO.NewsModelDAO();
        #endregion
        public NewsModel()
        {
            this.Images = new List<NewsImages>();
        }
        #region Methods
        public void Save()
        {
            DAO.saveNews(this);
        }

        public static List<NewsModel> GetNewsById(int? id)
        {
            return DAO.getNewsById(id);
        }

        public static void Delete(int id)
        {
            DAO.deleteNews(id);
        }
        #endregion
    }

    public class NewsImages
    {
        #region Properties
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string ImageSource { get; set; }

        static DAO.NewsModelDAO DAO = new CharrityAuction.DAO.NewsModelDAO();
        #endregion

        #region Methods
        public static List<NewsImages> GetImagesByNewsId(int newsId)
        {
            return DAO.getImagesByNewsId(newsId);
        }
        public static void Delete(int id)
        {
            DAO.deleteNewsImage(id);
        }
        public int Save()
        {
            return DAO.saveNewsImages(this);
        }
        #endregion
    }
}