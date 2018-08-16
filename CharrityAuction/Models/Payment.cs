using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharrityAuction.Models
{
    public class Payment
    {
        #region Properties
        public int Id { get; set; }
        public int BidId { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public Decimal Amount { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public UserViewModel User { get { return new UserViewModel(UserId); } }
        public BidModel Bid { get { return BidModel.GetBidById(BidId).First(); } }
        public LotModel Lot { get { return LotModel.GetAllLotById(Bid.LotId).First(); } }
        static DAO.PaymentDAO DAO = new CharrityAuction.DAO.PaymentDAO();
        #endregion

        public int Save()
        {
            return DAO.savePayment(this);
        } 

        public static List<Payment> GetPaymentById(int? id)
        {
            return DAO.getPaymentById(id);
        }


        public static List<Payment> GetApprovedPaymentById(int? id)
        {
            return DAO.getApprovedPaymentById(id);
        }

        public void SetStatus(int status)
        {
            DAO.saveStatus(this.Id, status);
        }

    }
}