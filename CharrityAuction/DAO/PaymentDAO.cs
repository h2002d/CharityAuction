using CharrityAuction.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CharrityAuction.DAO
{
    public class PaymentDAO:DAO
    {
        internal List<Payment> getPaymentById(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetPayment", sqlConnection))
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
                        List<Payment> newsList = new List<Payment>();
                        while (rdr.Read())
                        {
                            Payment payment = new Payment();
                            payment.Id = Convert.ToInt32(rdr["Id"]);
                            payment.BidId = Convert.ToInt32(rdr["BidId"]);
                            payment.Type= Convert.ToInt32(rdr["Type"]);
                            payment.Status = Convert.ToInt32(rdr["Status"]);
                            payment.UserId = rdr["UserId"].ToString();
                            payment.Amount = Convert.ToDecimal(rdr["Amount"]);
                            payment.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);

                            newsList.Add(payment);
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

        internal List<Payment> getApprovedPaymentById(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetApprovedPayment", sqlConnection))
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
                        List<Payment> newsList = new List<Payment>();
                        while (rdr.Read())
                        {
                            Payment payment = new Payment();
                            payment.Id = Convert.ToInt32(rdr["Id"]);
                            payment.BidId = Convert.ToInt32(rdr["BidId"]);
                            payment.Type = Convert.ToInt32(rdr["Type"]);
                            payment.Status = Convert.ToInt32(rdr["Status"]);
                            payment.UserId = rdr["UserId"].ToString();
                            payment.Amount = Convert.ToDecimal(rdr["Amount"]);
                            payment.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);

                            newsList.Add(payment);
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
        internal int savePayment(Payment payment)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_UserCreatePayment", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                       
                            command.Parameters.AddWithValue("@Id", payment.Id);
                        command.Parameters.AddWithValue("@Amount", payment.Amount);
                        command.Parameters.AddWithValue("@BidId", payment.BidId);
                        command.Parameters.AddWithValue("@Type", payment.Type);
                        command.Parameters.AddWithValue("@UserId", payment.UserId);
                        
                        return Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal void saveStatus(int paymentId, int status)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_SetPaymentStatus", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentId", paymentId);
                        command.Parameters.AddWithValue("@Status",status);
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