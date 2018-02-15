using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharrityAuction.Models
{
    public class LotModel
    {
        static DAO.LotDAO DAO = new CharrityAuction.DAO.LotDAO();
        #region Properties

        public int? Id { get; set; }
        public int CategoryId { get; set; }

        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]
        public string Info { get; set; }
        [AllowHtml]
        public string Policy { get; set; }
        public string ImageSource { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DeadLine { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime OccureDate { get; set; }

        public Decimal CurrentBid { get; set; }
        public Decimal Step { get; set; }
        public Decimal EstimatedValue { get; set; }

        #endregion
        #region Static methods
        public static List<LotModel> GetLotById(int? Id)
        {
            return DAO.getLotById(Id);
        }

        public static List<LotModel> GetLotByCategoryId(int CategoryId)
        {
            return DAO.getLotByCategoryId(CategoryId);
        }
        public static List<LotModel> GetLotByCategoryIdOrder(int CategoryId,int OrderId)
        {
            return DAO.getLotByCategoryIdOrder(CategoryId,OrderId);
        }
        public static void RemoveLotById(int Id)
        {
            DAO.deleteLot(Id);
        }

        #endregion
        #region Methods
        public int Save()
        {
            return DAO.saveLot(this);
        }
        #endregion
        #region TopLot
        public static LotModel GetTopLots(int index)
        {
            return DAO.getTopLots(index);
        }
        public static void SaveTopLot(int index, int lotId)
        {
            DAO.saveTopLot(index, lotId);
        }
        #endregion
    }
}