using CharrityAuction.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CharrityAuction.DAO
{
    public class BidDAO : DAO
    {

        internal int saveBid(BidModel bid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_UserCreateBid", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Amount", bid.Amount);
                        command.Parameters.AddWithValue("@LotId", bid.LotId);
                        command.Parameters.AddWithValue("@UserId", bid.UserId);

                        return Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal List<BidModel> getBidById(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetBidById", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", id);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<BidModel> bidList = new List<BidModel>();
                        while (rdr.Read())
                        {
                            BidModel bid = new BidModel();
                            bid.Id = Convert.ToInt32(rdr["Id"]);
                            bid.LotId = Convert.ToInt32(rdr["LotId"]);
                            bid.UserId = rdr["UserId"].ToString();
                            bid.Amount = Convert.ToDecimal(rdr["Amount"]);
                            bid.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            bid.isWinner = Convert.ToBoolean(rdr["isWinner"]);
                            bidList.Add(bid);
                        }
                        return bidList;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }

        }

        internal List<BidModel> getBidByLotId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetBidByLot", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                       
                            command.Parameters.AddWithValue("@LotId", id);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<BidModel> bidList = new List<BidModel>();
                        while (rdr.Read())
                        {
                            BidModel bid = new BidModel();
                            bid.Id = Convert.ToInt32(rdr["Id"]);
                            bid.LotId = Convert.ToInt32(rdr["LotId"]);
                            bid.UserId = rdr["UserId"].ToString();
                            bid.isWinner = Convert.ToBoolean(rdr["isWinner"]);

                            bid.Amount = Convert.ToDecimal(rdr["Amount"]);
                            bid.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            bidList.Add(bid);
                        }
                        return bidList;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }

        }

        internal List<BidModel> getBidByUserId(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetBidByUser", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                      
                            command.Parameters.AddWithValue("@UserId", id);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<BidModel> bidList = new List<BidModel>();
                        while (rdr.Read())
                        {
                            BidModel bid = new BidModel();
                            bid.Id = Convert.ToInt32(rdr["Id"]);
                            bid.LotId = Convert.ToInt32(rdr["LotId"]);
                            bid.UserId = rdr["UserId"].ToString();
                            bid.Amount = Convert.ToDecimal(rdr["Amount"]);
                            bid.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            bid.isWinner = Convert.ToBoolean(rdr["isWinner"]);

                            bidList.Add(bid);
                        }
                        return bidList;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }

        }


        internal List<BidModel> getWinnerBidByUserId(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetWinnerBidByUser", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", id);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<BidModel> bidList = new List<BidModel>();
                        while (rdr.Read())
                        {
                            BidModel bid = new BidModel();
                            bid.Id = Convert.ToInt32(rdr["Id"]);
                            bid.LotId = Convert.ToInt32(rdr["LotId"]);
                            bid.UserId = rdr["UserId"].ToString();
                            bid.Amount = Convert.ToDecimal(rdr["Amount"]);
                            bid.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            bid.isWinner = Convert.ToBoolean(rdr["isWinner"]);

                            bidList.Add(bid);
                        }
                        return bidList;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }

        }

        internal int setBidWinner(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_UserBidSetWinner", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);

                        return Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

    }
}