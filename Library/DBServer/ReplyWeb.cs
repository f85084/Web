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
    public class ReplyWeb
    {

        public void AddReply(Reply reply)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                SqlCommand cmd = new SqlCommand(SPName.Reply.Reply_Add, con)
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
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 20,
                    Value = reply.UserName
                };
                cmd.Parameters.Add(sqlParamUserName);

                SqlParameter sqlParamContext = new SqlParameter
                {
                    ParameterName = "@Context",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200,
                    Value = reply.Context
                };
                cmd.Parameters.Add(sqlParamContext);

                SqlParameter sqlParamCreatDate = new SqlParameter
                {
                    ParameterName = "@CreatDate",
                    Value = DateTime.Now
                };
                cmd.Parameters.Add(sqlParamCreatDate);

                SqlParameter sqlParamDelete = new SqlParameter
                {
                    ParameterName = "@Delete",
                    Value = reply.Delete
                };
                cmd.Parameters.Add(sqlParamDelete);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

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