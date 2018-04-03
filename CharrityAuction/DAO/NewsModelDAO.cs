using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharrityAuction.Models;
using System.Data.SqlClient;
using System.Data;

namespace CharrityAuction.DAO
{
    public class NewsModelDAO : DAO
    {
        internal List<NewsModel> getNewsById(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetNews", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", id);

                        string culture = System.Threading.Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();
                        SqlDataReader rdr = command.ExecuteReader();
                        List<NewsModel> newsList = new List<NewsModel>();
                        while (rdr.Read())
                        {
                            NewsModel news = new NewsModel();
                            news.Id = Convert.ToInt32(rdr["Id"]);
                            news.Name = rdr["Name_" + culture].ToString();
                            news.Name_AM = rdr["Name_AM"].ToString();
                            news.Name_EN = rdr["Name_EN"].ToString();
                            news.Description = rdr["Description_" + culture].ToString();
                            news.Description_AM = rdr["Description_AM"].ToString();
                            news.Description_EN = rdr["Description_EN"].ToString();
                            news.VideoSource = rdr["VideoSource"].ToString();
                            news.Link = rdr["Link"].ToString();

                            news.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);

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
        
        internal int saveNews(NewsModel news)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminCreateNews", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (news.Id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", news.Id);
                        command.Parameters.AddWithValue("@Name_EN", news.Name_EN);
                        command.Parameters.AddWithValue("@Name_AM", news.Name_AM);
                        command.Parameters.AddWithValue("@Description_EN", news.Description_EN);
                        command.Parameters.AddWithValue("@Description_AM", news.Description_AM);
                        if (String.IsNullOrEmpty(news.VideoSource))
                            command.Parameters.AddWithValue("@VideoSource", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@VideoSource", news.VideoSource);
                        if (String.IsNullOrEmpty(news.Link))
                            command.Parameters.AddWithValue("@Link", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Link", news.Link);

                        return Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal void deleteNews(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminDeleteNews", sqlConnection))
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

        #region Images
        internal int saveNewsImages(NewsImages newsImages)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_SaveNewsImage", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ImageSource", newsImages.ImageSource);
                        command.Parameters.AddWithValue("@NewsId", newsImages.NewsId);
                        return Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal void deleteNewsImage(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteNewsImage", sqlConnection))
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

        internal List<NewsImages> getImagesByNewsId(int newsId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetNewsImagesByNewsId", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NewsId", newsId);

                        SqlDataReader rdr = command.ExecuteReader();
                        List<NewsImages> newsList = new List<NewsImages>();
                        while (rdr.Read())
                        {
                            NewsImages news = new NewsImages();
                            news.Id = Convert.ToInt32(rdr["Id"]);
                            news.ImageSource = rdr["ImageSource"].ToString();
                            news.NewsId = Convert.ToInt32(rdr["NewsId"]);
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
        #endregion
    }
}