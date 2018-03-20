using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharrityAuction.Models;
using System.Data.SqlClient;
using System.Data;

namespace CharrityAuction.DAO
{
    public class PartnerDAO : DAO
    {
        internal List<Partner> getPartnerById(int? id, int? type)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetCelebrity", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", id);
                        if (type == null)
                            command.Parameters.AddWithValue("@isCelebrity", DBNull.Value);
                        else
                        command.Parameters.AddWithValue("@isCelebrity", type);
                        string culture = System.Threading.Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();
                        SqlDataReader rdr = command.ExecuteReader();
                        List<Partner> newsList = new List<Partner>();
                        while (rdr.Read())
                        {
                            Partner news = new Partner();
                            news.Id = Convert.ToInt32(rdr["Id"]);
                            news.Name = rdr["Name_" + culture].ToString();
                            news.Name_AM = rdr["Name_AM"].ToString();
                            news.Name_EN = rdr["Name_EN"].ToString();
                            news.Description = rdr["Description_" + culture].ToString();
                            news.Description_AM = rdr["Description_AM"].ToString();
                            news.Description_EN = rdr["Description_EN"].ToString();
                            news.ImageSource = rdr["ImageSource"].ToString();
                            news.isCelebrity = Convert.ToBoolean(rdr["isCelebrity"].ToString());


                            newsList.Add(news);
                        }
                        return newsList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal void savePartner(Partner partner)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminCreatePartner", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (partner.Id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", partner.Id);
                        command.Parameters.AddWithValue("@Name_EN", partner.Name_EN);
                        command.Parameters.AddWithValue("@Name_AM", partner.Name_AM);
                        command.Parameters.AddWithValue("@Description_EN", partner.Description_EN);
                        command.Parameters.AddWithValue("@Description_AM", partner.Description_AM);
                        command.Parameters.AddWithValue("@ImageSource", partner.ImageSource);
                       
                            command.Parameters.AddWithValue("@isCelebrity", partner.isCelebrity);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal void deletePartner(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminDeletePartner", sqlConnection))
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
    }
}