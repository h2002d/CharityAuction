using CharrityAuction.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CharrityAuction.DAO
{
    public class UserDAO:DAO
    {
        internal int saveUser(UserViewModel user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_RegisterUserInfo", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", user.UserId);
                        command.Parameters.AddWithValue("@Name", user.Name);
                        command.Parameters.AddWithValue("@LastName", user.LastName);
                        command.Parameters.AddWithValue("@Nickname", user.Nickname);
                        command.Parameters.AddWithValue("@Phone", user.Phone);

                        return Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal List<UserViewModel> getUserById(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetUserInfo", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@Id", id);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<UserViewModel> userList = new List<UserViewModel>();
                        while (rdr.Read())
                        {
                            UserViewModel user = new UserViewModel();
                            user.UserId =rdr["Id"].ToString();
                            user.Name = rdr["Name"].ToString();
                            user.LastName = rdr["LastName"].ToString();
                            user.Nickname=rdr["Nickname"].ToString();
                            user.Phone = rdr["Phone"].ToString();

                            userList.Add(user);
                        }
                        return userList;
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