using CharrityAuction.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharrityAuction.Models
{
    public class Charity
    {
        #region Properties
        public int? Id { get; set; }
        public string Help { get; set; }
        public string Help_AM { get; set; }
        public string Help_EN { get; set; }
        public Decimal Money { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime OccureDate { get; set; }

        static CharityDAO DAO = new CharityDAO();
        #endregion
        public static List<Charity> GetCharityById(int? id)
        {
            return DAO.getCharityById(id);
        }

        public void Save()
        {
            DAO.saveCharity(this);
        }

        public static void Delete(int id)
        {
            DAO.deleteCharity(id);
        }
    }
}