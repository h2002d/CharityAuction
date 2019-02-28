using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharrityAuction.Models;
using System.Data.SqlClient;
using System.Threading;
using System.Data;

namespace CharrityAuction.DAO
{
    public class CharityDAO:DAO
    {
        internal List<Charity> getCharityById(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetCharity", sqlConnection))
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
                        List<Charity> lotList = new List<Charity>();
                        while (rdr.Read())
                        {
                            Charity lot = new Charity();
                            lot.Id = Convert.ToInt32(rdr["Id"]);
                            lot.Help = rdr["Help_"+culture].ToString();
                            lot.Help_AM = rdr["Help_AM"].ToString();
                            lot.Help_EN = rdr["Help_EN"].ToString();

                            lot.Money = Convert.ToDecimal(rdr["Money"].ToString());
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

        internal int saveCharity(Charity charity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminCreateCharity", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (charity.Id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", charity.Id);
                        command.Parameters.AddWithValue("@Help_EN", charity.Help_EN);
                        command.Parameters.AddWithValue("@Help_AM", charity.Help_AM);
                        command.Parameters.AddWithValue("@Money", charity.Money);
                        command.Parameters.AddWithValue("@OccureDate", charity.OccureDate);

                        return Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal void deleteCharity(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminDeleteCharity", sqlConnection))
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