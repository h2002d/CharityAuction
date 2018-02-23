using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharrityAuction.DAO;
namespace CharrityAuction.Models
{
    public class CategoryModel
    {
        #region Properties
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Name_EN { get; set; }
        public string Name_AM { get; set; }

        static CategoryDAO DAO = new CategoryDAO();
        #endregion

        #region Methods
        public static List<CategoryModel> GetCategoryById(int? Id)
        {
            return DAO.getCategoryById(Id);
        }

        public int Save()
        {
            return DAO.saveCategory(this);
        }
        public static void Delete(int id)
        {
             DAO.deleteCategory(id);
        }

      
        #endregion
    }
}