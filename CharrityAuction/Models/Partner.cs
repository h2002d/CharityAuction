using CharrityAuction.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharrityAuction.Models
{
    public class Partner
    {
        #region Properties
        public int? Id { get; set; }
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name_EN { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name_AM { get; set; }
        public string Description { get; set; }
        [Required]
        public string Description_EN { get; set; }
        [Required]
        public string Description_AM { get; set; }

        public string ImageSource { get; set; }
        public bool isCelebrity { get; set; }
        static PartnerDAO DAO = new PartnerDAO();

        #endregion
        //Celebrities 0 Organizations 1
        #region Methods
        public static List<Partner> GetPartner(int? id,int? type)
        {
            return DAO.getPartnerById(id, type);
        }  

        public void Save()
        {
            DAO.savePartner(this);
        }

        public static void Delete(int id)
        {
            DAO.deletePartner(id);
        }
        #endregion
    }
}