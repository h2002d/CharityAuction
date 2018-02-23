using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharrityAuction.Models
{
    public class BidModel
    {
        #region Properties
        static DAO.BidDAO DAO = new DAO.BidDAO();
        public int Id { get; set; }
        public Decimal Amount { get; set; }
        public string UserId { get; set; }
        public int LotId { get; set; }
        public DateTime CreateDate { get; set; }
        #endregion

        #region Methods
        public int Save()
        {
            return DAO.saveBid(this);
        }

        public static List<BidModel> GetBidById(int? Id)
        {
            return DAO.getBidById(Id);
        }

        public static List<BidModel> GetBidByLotId(int Id)
        {
            return DAO.getBidByLotId(Id);
        }

        public static List<BidModel> GetBidByUserId(int Id)
        {
            return DAO.getBidByUserId(Id);
        }

        #endregion

    }
}