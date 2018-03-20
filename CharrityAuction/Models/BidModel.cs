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
        public bool isWinner { get; set; }
        public DateTime CreateDate { get; set; }
        public UserViewModel User { get { return new UserViewModel(UserId); } }
        #endregion

        #region Methods
        public int Save()
        {
            return DAO.saveBid(this);
        }

        public static void SetWinner(int id)
        {
            DAO.setBidWinner(id);
        }
        public static List<BidModel> GetBidById(int? Id)
        {
            return DAO.getBidById(Id);
        }

        public static List<BidModel> GetBidByLotId(int Id)
        {
            return DAO.getBidByLotId(Id);
        }

        public static List<BidModel> GetBidByUserId(string Id)
        {
            return DAO.getBidByUserId(Id);
        }

        public static  List<BidModel> GetWinnerBids(string userId)
        {
            return DAO.getWinnerBidByUserId(userId);
        }
        #endregion

    }
}