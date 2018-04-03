using CharrityAuction.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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

                        string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();
                        SqlDataReader rdr = command.ExecuteReader();
                        List<LotModel> lotList = new List<LotModel>();
                        while (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.ImageSource = rdr["ImageSource"].ToString();
                            lot.Name = rdr["Name_" + culture].ToString();
                            lot.Name_AM = rdr["Name_AM"].ToString();
                            lot.Name_EN = rdr["Name_EN"].ToString();
                            lot.Info = rdr["Info_" + culture].ToString();
                            lot.Info_AM = rdr["Info_AM"].ToString();
                            lot.Info_EN = rdr["Info_EN"].ToString();
                            lot.Description = rdr["Description_" + culture].ToString();
                            lot.Description_AM = rdr["Description_AM"].ToString();
                            lot.Description_EN = rdr["Description_EN"].ToString();
                            lot.Policy = rdr["Policy_" + culture].ToString();
                            lot.Policy_AM = rdr["Policy_AM"].ToString();
                            lot.Policy_EN = rdr["Policy_EN"].ToString();

                            lot.CurrentBid = Convert.ToDecimal(rdr["CurrentBid"].ToString());
                            lot.Step = Convert.ToDecimal(rdr["Step"].ToString());
                            lot.EstimatedValue = Convert.ToDecimal(rdr["EstimatedValue"].ToString());

                            lot.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            lot.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            lot.DeadLine = Convert.ToDateTime(rdr["DeadLine"]);
                            lot.OccureDate = Convert.ToDateTime(rdr["OccureDate"]);
                            lot.PartnerId = Convert.ToInt32(rdr["PartnerId"]);
                            lot.isShownCelebrity= Convert.ToBoolean(rdr["isShownCelebrity"]);

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

        internal List<LotModel> getLotByQuery(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetLotsByQuery", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@query", query);

                        string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();
                        SqlDataReader rdr = command.ExecuteReader();
                        List<LotModel> lotList = new List<LotModel>();
                        while (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.ImageSource = rdr["ImageSource"].ToString();
                            lot.Name = rdr["Name_" + culture].ToString();
                            lot.Name_AM = rdr["Name_AM"].ToString();
                            lot.Name_EN = rdr["Name_EN"].ToString();
                            lot.Info = rdr["Info_" + culture].ToString();
                            lot.Info_AM = rdr["Info_AM"].ToString();
                            lot.Info_EN = rdr["Info_EN"].ToString();
                            lot.Description = rdr["Description_" + culture].ToString();
                            lot.Description_AM = rdr["Description_AM"].ToString();
                            lot.Description_EN = rdr["Description_EN"].ToString();
                            lot.Policy = rdr["Policy_" + culture].ToString();
                            lot.Policy_AM = rdr["Policy_AM"].ToString();
                            lot.Policy_EN = rdr["Policy_EN"].ToString();

                            lot.CurrentBid = Convert.ToDecimal(rdr["CurrentBid"].ToString());
                            lot.Step = Convert.ToDecimal(rdr["Step"].ToString());
                            lot.EstimatedValue = Convert.ToDecimal(rdr["EstimatedValue"].ToString());

                            lot.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            lot.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            lot.DeadLine = Convert.ToDateTime(rdr["DeadLine"]);
                            lot.OccureDate = Convert.ToDateTime(rdr["OccureDate"]);
                            lot.PartnerId = Convert.ToInt32(rdr["PartnerId"]);
                            lot.isShownCelebrity = Convert.ToBoolean(rdr["isShownCelebrity"]);

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

        internal List<LotModel> getLotByPartnerId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetLotsByParent", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                       

                            command.Parameters.AddWithValue("@Id", id);

                        string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();
                        SqlDataReader rdr = command.ExecuteReader();
                        List<LotModel> lotList = new List<LotModel>();
                        while (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.ImageSource = rdr["ImageSource"].ToString();
                            lot.Name = rdr["Name_" + culture].ToString();
                            lot.Name_AM = rdr["Name_AM"].ToString();
                            lot.Name_EN = rdr["Name_EN"].ToString();
                            lot.Info = rdr["Info_" + culture].ToString();
                            lot.Info_AM = rdr["Info_AM"].ToString();
                            lot.Info_EN = rdr["Info_EN"].ToString();
                            lot.Description = rdr["Description_" + culture].ToString();
                            lot.Description_AM = rdr["Description_AM"].ToString();
                            lot.Description_EN = rdr["Description_EN"].ToString();
                            lot.Policy = rdr["Policy_" + culture].ToString();
                            lot.Policy_AM = rdr["Policy_AM"].ToString();
                            lot.Policy_EN = rdr["Policy_EN"].ToString();

                            lot.CurrentBid = Convert.ToDecimal(rdr["CurrentBid"].ToString());
                            lot.Step = Convert.ToDecimal(rdr["Step"].ToString());
                            lot.EstimatedValue = Convert.ToDecimal(rdr["EstimatedValue"].ToString());

                            lot.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            lot.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            lot.DeadLine = Convert.ToDateTime(rdr["DeadLine"]);
                            lot.OccureDate = Convert.ToDateTime(rdr["OccureDate"]);
                            lot.PartnerId = Convert.ToInt32(rdr["PartnerId"]);
                            lot.isShownCelebrity = Convert.ToBoolean(rdr["isShownCelebrity"]);

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

        internal List<LotModel> getLotByOrderId(int orderId)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                StringBuilder str = new StringBuilder("SELECT * FROM Lot WHERE isDeleted=0");
                switch (orderId)
                {
                    case 1:
                        str.Append(" ORDER BY DeadLine ASC");
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
                        string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();

                        SqlDataReader rdr = command.ExecuteReader();
                        List<LotModel> lotList = new List<LotModel>();
                        while (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.ImageSource = rdr["ImageSource"].ToString();

                            lot.Name = rdr["Name_" + culture].ToString();
                            lot.Name_AM = rdr["Name_AM"].ToString();
                            lot.Name_EN = rdr["Name_EN"].ToString();
                            lot.Info = rdr["Info_" + culture].ToString();
                            lot.Info_AM = rdr["Info_AM"].ToString();
                            lot.Info_EN = rdr["Info_EN"].ToString();
                            lot.Description = rdr["Description_" + culture].ToString();
                            lot.Description_AM = rdr["Description_AM"].ToString();
                            lot.Description_EN = rdr["Description_EN"].ToString();
                            lot.Policy = rdr["Policy_" + culture].ToString();
                            lot.Policy_AM = rdr["Policy_AM"].ToString();
                            lot.Policy_EN = rdr["Policy_EN"].ToString();
                            lot.CurrentBid = Convert.ToDecimal(rdr["CurrentBid"].ToString());
                            lot.Step = Convert.ToDecimal(rdr["Step"].ToString());
                            lot.EstimatedValue = Convert.ToDecimal(rdr["EstimatedValue"].ToString());

                            lot.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            lot.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            lot.DeadLine = Convert.ToDateTime(rdr["DeadLine"]);
                            lot.OccureDate = Convert.ToDateTime(rdr["OccureDate"]);

                            lot.PartnerId = Convert.ToInt32(rdr["PartnerId"]);
                            lot.isShownCelebrity = Convert.ToBoolean(rdr["isShownCelebrity"]);
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
                        string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();

                        SqlDataReader rdr = command.ExecuteReader();
                        List<LotModel> lotList = new List<LotModel>();
                        while (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.ImageSource = rdr["ImageSource"].ToString();

                            lot.Name = rdr["Name_" + culture].ToString();
                            lot.Name_AM = rdr["Name_AM"].ToString();
                            lot.Name_EN = rdr["Name_EN"].ToString();
                            lot.Info = rdr["Info_" + culture].ToString();
                            lot.Info_AM = rdr["Info_AM"].ToString();
                            lot.Info_EN = rdr["Info_EN"].ToString();
                            lot.Description = rdr["Description_" + culture].ToString();
                            lot.Description_AM = rdr["Description_AM"].ToString();
                            lot.Description_EN = rdr["Description_EN"].ToString();
                            lot.Policy = rdr["Policy_" + culture].ToString();
                            lot.Policy_AM = rdr["Policy_AM"].ToString();
                            lot.Policy_EN = rdr["Policy_EN"].ToString();
                            lot.CurrentBid = Convert.ToDecimal(rdr["CurrentBid"].ToString());
                            lot.Step = Convert.ToDecimal(rdr["Step"].ToString());
                            lot.EstimatedValue = Convert.ToDecimal(rdr["EstimatedValue"].ToString());

                            lot.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            lot.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            lot.DeadLine = Convert.ToDateTime(rdr["DeadLine"]);
                            lot.OccureDate = Convert.ToDateTime(rdr["OccureDate"]);

                            lot.PartnerId = Convert.ToInt32(rdr["PartnerId"]);
                            lot.isShownCelebrity = Convert.ToBoolean(rdr["isShownCelebrity"]);
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
                StringBuilder str = new StringBuilder("SELECT * FROM Lot WHERE isDeleted=0 AND CategoryId=" + categoryId);
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
                        string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();

                        SqlDataReader rdr = command.ExecuteReader();
                        List<LotModel> lotList = new List<LotModel>();
                        while (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.ImageSource = rdr["ImageSource"].ToString();

                            lot.Name = rdr["Name_" + culture].ToString();
                            lot.Name_AM = rdr["Name_AM"].ToString();
                            lot.Name_EN = rdr["Name_EN"].ToString();
                            lot.Info = rdr["Info_" + culture].ToString();
                            lot.Info_AM = rdr["Info_AM"].ToString();
                            lot.Info_EN = rdr["Info_EN"].ToString();
                            lot.Description = rdr["Description_" + culture].ToString();
                            lot.Description_AM = rdr["Description_AM"].ToString();
                            lot.Description_EN = rdr["Description_EN"].ToString();
                            lot.Policy = rdr["Policy_" + culture].ToString();
                            lot.Policy_AM = rdr["Policy_AM"].ToString();
                            lot.Policy_EN = rdr["Policy_EN"].ToString();
                            lot.CurrentBid = Convert.ToDecimal(rdr["CurrentBid"].ToString());
                            lot.Step = Convert.ToDecimal(rdr["Step"].ToString());
                            lot.EstimatedValue = Convert.ToDecimal(rdr["EstimatedValue"].ToString());

                            lot.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            lot.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            lot.DeadLine = Convert.ToDateTime(rdr["DeadLine"]);
                            lot.OccureDate = Convert.ToDateTime(rdr["OccureDate"]);

                            lot.PartnerId = Convert.ToInt32(rdr["PartnerId"]);
                            lot.isShownCelebrity = Convert.ToBoolean(rdr["isShownCelebrity"]);
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

                        command.Parameters.AddWithValue("@Name_AM", lot.Name_AM);
                        command.Parameters.AddWithValue("@Name_EN", lot.Name_EN);
                        command.Parameters.AddWithValue("@Info_AM", lot.Info_AM);
                        command.Parameters.AddWithValue("@Info_EN", lot.Info_EN);

                        command.Parameters.AddWithValue("@Description_AM", lot.Description_AM);
                        command.Parameters.AddWithValue("@Description_EN", lot.Description_EN);

                        command.Parameters.AddWithValue("@Policy_AM", lot.Policy_AM);
                        command.Parameters.AddWithValue("@Policy_EN", lot.Policy_EN);
                        command.Parameters.AddWithValue("@OccureDate", Convert.ToDateTime(lot.OccureDate.ToString("dd MMMM yyyy hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture)));
                        command.Parameters.AddWithValue("@Step", lot.Step);
                        command.Parameters.AddWithValue("@CategoryId", lot.CategoryId);
                        command.Parameters.AddWithValue("@CurrentBid", lot.CurrentBid);
                        command.Parameters.AddWithValue("@ImageSource", lot.ImageSource);
                        command.Parameters.AddWithValue("@DeadLine", Convert.ToDateTime(lot.DeadLine.ToString("dd MMMM yyyy hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture)));
                        command.Parameters.AddWithValue("@EstimatedValue", lot.EstimatedValue);
                        command.Parameters.AddWithValue("@PartnerId", lot.PartnerId);
                        command.Parameters.AddWithValue("@isShownCelebrity", lot.isShownCelebrity);

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
                        string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();

                        SqlDataReader rdr = command.ExecuteReader();
                        if (rdr.Read())
                        {
                            LotModel lot = new LotModel();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.ImageSource = rdr["ImageSource"].ToString();

                            lot.Name = rdr["Name_" + culture].ToString();
                            lot.Name_AM = rdr["Name_AM"].ToString();
                            lot.Name_EN = rdr["Name_EN"].ToString();
                            lot.Info = rdr["Info_" + culture].ToString();
                            lot.Info_AM = rdr["Info_AM"].ToString();
                            lot.Info_EN = rdr["Info_EN"].ToString();
                            lot.Description = rdr["Description_" + culture].ToString();
                            lot.Description_AM = rdr["Description_AM"].ToString();
                            lot.Description_EN = rdr["Description_EN"].ToString();
                            lot.Policy = rdr["Policy_" + culture].ToString();
                            lot.Policy_AM = rdr["Policy_AM"].ToString();
                            lot.Policy_EN = rdr["Policy_EN"].ToString();
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
        #region LotImages
        internal void deleteLotImage(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteLotImage", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal int saveLotImages(LotImages lotImages)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_SaveLotImage", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                       
                        command.Parameters.AddWithValue("@Imagesource", lotImages.Imagesource);
                        command.Parameters.AddWithValue("@LotId", lotImages.LotId);
                        return Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }

        internal List<LotImages> getImagesByLotId(int lotId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetLotImagesByLotId", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@LotId", lotId);

                        SqlDataReader rdr = command.ExecuteReader();
                        List<LotImages> lotList = new List<LotImages>();
                        while (rdr.Read())
                        {
                            LotImages lot = new LotImages();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.Imagesource = rdr["Imagesource"].ToString();
                            lot.LotId = Convert.ToInt32(rdr["LotId"]);
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
    }
}