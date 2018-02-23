using CharrityAuction.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace CharrityAuction.DAO
{
    public class CategoryDAO : DAO
    {
        internal List<CategoryModel> getCategoryById(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminGetCategory", sqlConnection))
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
                        List<CategoryModel> categoryList = new List<CategoryModel>();
                        while (rdr.Read())
                        {
                            CategoryModel category = new CategoryModel();
                            category.Id = Convert.ToInt32(rdr["Id"]);
                            category.Name = rdr["Name_"+culture].ToString();
                            categoryList.Add(category);
                        }
                        return categoryList;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
        }

        internal int saveCategory(CategoryModel category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminCreateCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (category.Id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", category.Id);
                        command.Parameters.AddWithValue("@Name_EN", category.Name_EN);
                        command.Parameters.AddWithValue("@Name_AM", category.Name_AM);
                        return Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        internal void deleteCategory(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminDeleteCategory", sqlConnection))
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