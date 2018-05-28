using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class ReplyWeb
    {
        public IEnumerable<Reply> Replys
        {
            get
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["webContext"].ConnectionString;
                List<Reply> replys = new List<Reply>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetReply", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Reply reply = new Reply();
                        reply.Id = Convert.ToInt32(rdr["Id"]);
                        reply.UserId = Convert.ToInt32(rdr["UserId"]);
                        reply.MessageId = Convert.ToInt32(rdr["MessageId"]);
                        reply.UserName = rdr["UserName"].ToString();
                        reply.Context = rdr["Context"].ToString();
                        reply.CreatDate = Convert.ToDateTime(rdr["CreatDate"]);
                        replys.Add(reply);
                    }
                }
                return replys;
            }
        }

        DateTime dt = DateTime.Now; //現在時間 

        public void AddReply(Reply reply)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["webContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddReply", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sqlParamUserId = new SqlParameter
                {
                    ParameterName = "@UserId",
                    Value = reply.UserId
                };
                cmd.Parameters.Add(sqlParamUserId);

                SqlParameter sqlParamMessageId = new SqlParameter
                {
                    ParameterName = "@MessageId",
                    Value = reply.MessageId
                };
                cmd.Parameters.Add(sqlParamMessageId);

                SqlParameter sqlParamUserName = new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = reply.UserName
                };
                cmd.Parameters.Add(sqlParamUserName);

                SqlParameter sqlParamContext = new SqlParameter
                {
                    ParameterName = "@Context",
                    Value = reply.Context
                };
                cmd.Parameters.Add(sqlParamContext);

                SqlParameter sqlParamCreatDate = new SqlParameter
                {
                    ParameterName = "@CreatDate",
                    Value = dt
                };
                cmd.Parameters.Add(sqlParamCreatDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //public void SaveMessage(Message message)
        //{
        //    string connectionString =
        //        ConfigurationManager.ConnectionStrings["webContext"].ConnectionString;

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("spSaveMessage", con)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };


        //        SqlParameter sqlParamUserId = new SqlParameter
        //        {
        //            ParameterName = "@UserId",
        //            Value = message.UserId
        //        };
        //        cmd.Parameters.Add(sqlParamUserId);

        //        SqlParameter sqlParamUserName = new SqlParameter
        //        {
        //            ParameterName = "@UserName",
        //            Value = message.UserName
        //        };
        //        cmd.Parameters.Add(sqlParamUserName);

        //        SqlParameter sqlParamContext = new SqlParameter
        //        {
        //            ParameterName = "@Context",
        //            Value = message.Context
        //        };
        //        cmd.Parameters.Add(sqlParamContext);

        //        SqlParameter sqlParamCreatDate = new SqlParameter
        //        {
        //            ParameterName = "@CreatDate",
        //            Value = dt
        //        };
        //        cmd.Parameters.Add(sqlParamCreatDate);

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        //public void DeleteMessage(int id)
        //{
        //    string connectionString =
        //            ConfigurationManager.ConnectionStrings["webContext"].ConnectionString;

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("spDeleteMessage", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter sqlParamId = new SqlParameter
        //        {
        //            ParameterName = "@Id",
        //            Value = id
        //        };
        //        cmd.Parameters.Add(sqlParamId);

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}


    }
}