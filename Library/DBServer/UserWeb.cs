using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Library.DBServer;

namespace Library
{
    public class UserWeb
    {
        #region 讀取
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                SqlCommand cmd = new SqlCommand(SPName.User.User_Get, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(rdr["Id"]);
                    user.UserAccount = rdr["UserAccount"].ToString();
                    user.UserClass = Convert.ToByte(rdr["UserClass"]);
                    user.Email = rdr["Email"].ToString();
                    user.Password = rdr["Password"].ToString();
                    user.UserName = rdr["UserName"].ToString();
                    user.CreatDate = Convert.ToDateTime(rdr["CreatDate"]);
                    user.MofiyDate = Convert.ToDateTime(rdr["MofiyDate"]);
                    //user.MofiyDate = DBNull.Value==   ? 0:Convert.ToDateTime(rdr["MofiyDate"]) ;
                    user.Delete = Convert.ToBoolean(rdr["Delete"]);
                    users.Add(user);
                }
            }
            return users;
        }
        #endregion

        #region 新增帳號
        public bool AddUser(User user)
        {

            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                SqlCommand cmd = new SqlCommand(SPName.User.User_Add, con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter returnValue = new SqlParameter("@Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(returnValue);

                SqlParameter sqlParamUserAccount = new SqlParameter
                {
                    ParameterName = "@UserAccount",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value = user.UserAccount
                };
                cmd.Parameters.Add(sqlParamUserAccount);

                SqlParameter sqlParamUserClass = new SqlParameter
                {
                    ParameterName = "@UserClass",
                    Value = user.UserClass
                };
                cmd.Parameters.Add(sqlParamUserClass);

                SqlParameter sqlParamEmail = new SqlParameter
                {
                    ParameterName = "@Email",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value = user.Email
                };
                cmd.Parameters.Add(sqlParamEmail);

                SqlParameter sqlParamPassword = new SqlParameter
                {
                    ParameterName = "@Password",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 20,
                    Value = user.Password
                };
                cmd.Parameters.Add(sqlParamPassword);

                SqlParameter sqlParamUserName = new SqlParameter
                {
                    ParameterName = "@UserName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 20,
                    Value = user.UserName
                };
                cmd.Parameters.Add(sqlParamUserName);

                SqlParameter sqlParamCreatDate = new SqlParameter
                {
                    ParameterName = "@CreatDate",
                    Value = DateTime.Now
                };
                cmd.Parameters.Add(sqlParamCreatDate);

                SqlParameter sqlParamMofiyDate = new SqlParameter
                {
                    ParameterName = "@MofiyDate",
                    Value = DateTime.Now
                };
                cmd.Parameters.Add(sqlParamMofiyDate);

                SqlParameter sqlParamDelete = new SqlParameter
                {
                    ParameterName = "@Delete",
                    Value = user.Delete
                };
                cmd.Parameters.Add(sqlParamDelete);

                con.Open();
                cmd.ExecuteNonQuery();

                string Value = returnValue.Value.ToString();

                if (Value == "")
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        #endregion

        #region 更新
        public void SaveUser(User user)
        {

            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                SqlCommand cmd = new SqlCommand(SPName.User.User_Update, con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sqlParamId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = user.Id
                };
                cmd.Parameters.Add(sqlParamId);

                SqlParameter sqlParamUserAccount = new SqlParameter
                {
                    ParameterName = "@UserAccount",
                    Value = user.UserAccount
                };
                cmd.Parameters.Add(sqlParamUserAccount);

                SqlParameter sqlParamUserClass = new SqlParameter
                {
                    ParameterName = "@UserClass",
                    Value = user.UserClass
                };
                cmd.Parameters.Add(sqlParamUserClass);

                SqlParameter sqlParamEmail = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = user.Email
                };
                cmd.Parameters.Add(sqlParamEmail);

                SqlParameter sqlParamPassword = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = user.Password
                };
                cmd.Parameters.Add(sqlParamPassword);

                SqlParameter sqlParamUserName = new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = user.UserName
                };
                cmd.Parameters.Add(sqlParamUserName);

                SqlParameter sqlParamMofiyDate = new SqlParameter
                {
                    ParameterName = "@MofiyDate",
                    Value = DateTime.Now
                };
                cmd.Parameters.Add(sqlParamMofiyDate);

                SqlParameter sqlParamDelete = new SqlParameter
                {
                    ParameterName = "@Delete",
                    Value = user.Delete
                };
                cmd.Parameters.Add(sqlParamDelete);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region 刪除
        public void DeleteUser(int id)
        {

            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                SqlCommand cmd = new SqlCommand(SPName.User.User_Delete, con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParamId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(sqlParamId);

                SqlParameter sqlParamDelete = new SqlParameter
                {
                    ParameterName = "@Delete",
                    Value = 1
                };
                cmd.Parameters.Add(sqlParamDelete);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region 會員登入驗證
        /// <summary>
        /// 檢查帳號密碼是否正確
        /// </summary>
        /// <param name="UserAccount">帳號</param>
        /// <param name="Password">密碼</param>
        /// <returns></returns>
        public User CheckPassword(string UserAccount, string Password)
        {
            User result = null;
            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                SqlCommand cmd = new SqlCommand(SPName.User.CheckLoginAccount_Get, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserAccount", UserAccount);
                cmd.Parameters.AddWithValue("@Password", Password);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        result = new User()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            UserAccount = dr["UserAccount"].ToString(),
                            UserClass = Convert.ToByte(dr["UserClass"]),
                            UserName = dr["UserName"].ToString()
                        };
                    }
                }
            }

            return result;
        }
        #endregion

    }
}