using CharrityAuction.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace CharrityAuction.DAO
{
    public class LotDAO : DAO
    {
        #region Getters
        internal List<LotModel> getLotById(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetLots", sqlConnection))
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
                        List<LotModel> lotList = new List<LotModel>();
                        while (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.Description = rdr["Description"].ToString();
                            lot.Info = rdr["Info"].ToString();
                            lot.ImageSource = rdr["ImageSource"].ToString();
                            lot.Policy = rdr["Policy"].ToString();
                            lot.Name = rdr["Name"].ToString();
                            lot.CurrentBid = Convert.ToDecimal(rdr["CurrentBid"].ToString());
                            lot.Step = Convert.ToDecimal(rdr["Step"].ToString());
                            lot.EstimatedValue = Convert.ToDecimal(rdr["EstimatedValue"].ToString());

                            lot.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            lot.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            lot.DeadLine = Convert.ToDateTime(rdr["DeadLine"]);
                            lot.OccureDate = Convert.ToDateTime(rdr["OccureDate"]);

                            lotList.Add(lot);
                        }
                        return lotList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal List<LotModel> getLotByCategoryId(int categoryId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetLotByCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryId", categoryId);

                        SqlDataReader rdr = command.ExecuteReader();
                        List<LotModel> lotList = new List<LotModel>();
                        while (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.Description = rdr["Description"].ToString();
                            lot.Info = rdr["Info"].ToString();
                            lot.ImageSource = rdr["ImageSource"].ToString();
                            lot.Name = rdr["Name"].ToString();
                            lot.Policy = rdr["Policy"].ToString();
                            lot.CurrentBid = Convert.ToDecimal(rdr["CurrentBid"].ToString());
                            lot.Step = Convert.ToDecimal(rdr["Step"].ToString());
                            lot.EstimatedValue = Convert.ToDecimal(rdr["EstimatedValue"].ToString());

                            lot.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            lot.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            lot.DeadLine = Convert.ToDateTime(rdr["DeadLine"]);
                            lot.OccureDate = Convert.ToDateTime(rdr["OccureDate"]);

                            lotList.Add(lot);
                        }
                        return lotList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        internal List<LotModel> getLotByCategoryIdOrder(int categoryId,int orderId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                StringBuilder str = new StringBuilder("SELECT * FROM Lot WHERE CategoryId=" + categoryId);
                switch(orderId)
                {
                    case 1:
                        str.Append(" ORDER BY DeadLine DESC");
                        break;
                    case 2:
                        str.Append(" ORDER BY Id DESC");

                        break;
                    case 3:
                        str.Append(" ORDER BY CurrentBid DESC");
                        break;
                }
                using (SqlCommand command = new SqlCommand(str.ToString(), sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.Text;

                        SqlDataReader rdr = command.ExecuteReader();
                        List<LotModel> lotList = new List<LotModel>();
                        while (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.Description = rdr["Description"].ToString();
                            lot.Info = rdr["Info"].ToString();
                            lot.ImageSource = rdr["ImageSource"].ToString();
                            lot.Name = rdr["Name"].ToString();
                            lot.Policy = rdr["Policy"].ToString();
                            lot.CurrentBid = Convert.ToDecimal(rdr["CurrentBid"].ToString());
                            lot.Step = Convert.ToDecimal(rdr["Step"].ToString());
                            lot.EstimatedValue = Convert.ToDecimal(rdr["EstimatedValue"].ToString());

                            lot.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            lot.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            lot.DeadLine = Convert.ToDateTime(rdr["DeadLine"]);
                            lot.OccureDate = Convert.ToDateTime(rdr["OccureDate"]);

                            lotList.Add(lot);
                        }
                        return lotList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        #endregion
        #region Setters
        internal int saveLot(LotModel lot)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminCreateLot", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (lot.Id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", lot.Id);

                        command.Parameters.AddWithValue("@Info", lot.Info);
                        command.Parameters.AddWithValue("@Name", lot.Name);
                        command.Parameters.AddWithValue("@OccureDate", lot.OccureDate);
                        command.Parameters.AddWithValue("@Policy", lot.Policy);
                        command.Parameters.AddWithValue("@Step", lot.Step);
                        command.Parameters.AddWithValue("@CategoryId", lot.CategoryId);
                        command.Parameters.AddWithValue("@CurrentBid", lot.CurrentBid);
                        command.Parameters.AddWithValue("@ImageSource", lot.ImageSource);
                        command.Parameters.AddWithValue("@DeadLine", lot.DeadLine);
                        command.Parameters.AddWithValue("@Description", lot.Description);
                        command.Parameters.AddWithValue("@EstimatedValue", lot.EstimatedValue);

                        return Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        internal void deleteLot(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminDeleteLot", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
                        //command.Parameters.AddWithValue("@DateBirth", user.DateBirth);
                        command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        #endregion
        #region Top Lots
        internal LotModel getTopLots(int index)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetTopLots", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Index", index);

                        SqlDataReader rdr = command.ExecuteReader();
                        if (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.Description = rdr["Description"].ToString();
                            lot.Info = rdr["Info"].ToString();
                            lot.ImageSource = rdr["ImageSource"].ToString();
                            lot.Policy = rdr["Policy"].ToString();
                            lot.Name = rdr["Name"].ToString();
                            lot.CurrentBid = Convert.ToDecimal(rdr["CurrentBid"].ToString());
                            lot.Step = Convert.ToDecimal(rdr["Step"].ToString());
                            lot.EstimatedValue = Convert.ToDecimal(rdr["EstimatedValue"].ToString());

                            lot.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            lot.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            lot.DeadLine = Convert.ToDateTime(rdr["DeadLine"]);
                            lot.OccureDate = Convert.ToDateTime(rdr["OccureDate"]);

                            return lot;
                        }
                        return null;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        internal void saveTopLot(int index, int lotId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminCreateTopLot", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Index", index);
                        command.Parameters.AddWithValue("@LotId", lotId);

                        //command.Parameters.AddWithValue("@DateBirth", user.DateBirth);
                        command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        #endregion
    }
}