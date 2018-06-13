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
    public class MessageWeb
    {


        #region 讀取
        public IEnumerable<Message> GetMessages()
        {
            List<Message> messages = new List<Message>();
            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                SqlCommand cmd = new SqlCommand(SPName.Message.Message_Get, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Message message = new Message();
                    message.Id = Convert.ToInt32(rdr["Id"]);
                    message.UserId = Convert.ToInt32(rdr["UserId"]);
                    message.UserName = rdr["UserName"].ToString();
                    message.Context = rdr["Context"].ToString();
                    message.CreatDate = Convert.ToDateTime(rdr["CreatDate"]);
                    message.Delete = Convert.ToBoolean(rdr["Delete"]);
                    messages.Add(message);
                }
            }
            return messages;
        }


        public IEnumerable<MessageReply> GetMessageReplys()
        {
            List<MessageReply> result = new List<MessageReply>();

            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                string commend = @"select * 
from Message
left outer join Reply 
on Message.Id = Reply.MessageId
order by Message.Id";
                SqlCommand cmd = new SqlCommand(commend, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int currentID = 0;
                MessageReply item = null;
                while (dr.Read())
                {
                    if (currentID == 0 || int.Parse(dr[0].ToString()) != currentID)
                    {
                        Message msg = new Message()
                        {
                            Id = Convert.ToInt32(dr[0]),
                            UserName = dr[2].ToString(),
                            Context = dr[3].ToString(),
                            CreatDate = Convert.ToDateTime(dr[4].ToString())
                        };
                        item = new MessageReply();
                        item.Messages = msg;
                        item.ReplyList = new List<Reply>();
                        if (dr[7] != DBNull.Value)
                        {

                            Reply reply = new Reply()
                            {
                                UserName = dr[9].ToString(),
                                Context = dr[10].ToString(),
                                CreatDate = Convert.ToDateTime(dr[11].ToString())
                            };
                            item.ReplyList.Add(reply);
                        }

                        result.Add(item);
                        currentID = msg.Id;
                    }
                    else
                    {
                        item.ReplyList.Add(new Reply
                        {
                            UserName = dr[9].ToString(),
                            Context = dr[10].ToString(),
                            CreatDate = Convert.ToDateTime(dr[11].ToString())
                        });
                    }
                }
            }

            return result;
        }

        #endregion


        #region 新增留言
        public void AddMessage(Message message)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                SqlCommand cmd = new SqlCommand(SPName.Message.Message_Add, con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sqlParamUserId = new SqlParameter
                {
                    ParameterName = "@UserId",
                    Value = message.UserId
                };
                cmd.Parameters.Add(sqlParamUserId);

                SqlParameter sqlParamUserName = new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = message.UserName
                };
                cmd.Parameters.Add(sqlParamUserName);

                SqlParameter sqlParamContext = new SqlParameter
                {
                    ParameterName = "@Context",
                    Value = message.Context
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
                    Value = message.Delete
                };
                cmd.Parameters.Add(sqlParamDelete);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region 更新留言
        public void SaveMessage(Message message)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                SqlCommand cmd = new SqlCommand(SPName.Message.Message_Update, con)
                {
                    CommandType = CommandType.StoredProcedure
                };


                SqlParameter sqlParamUserId = new SqlParameter
                {
                    ParameterName = "@UserId",
                    Value = message.UserId
                };
                cmd.Parameters.Add(sqlParamUserId);

                SqlParameter sqlParamUserName = new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = message.UserName
                };
                cmd.Parameters.Add(sqlParamUserName);

                SqlParameter sqlParamContext = new SqlParameter
                {
                    ParameterName = "@Context",
                    Value = message.Context
                };
                cmd.Parameters.Add(sqlParamContext);

                SqlParameter sqlParamCreatDate = new SqlParameter
                {
                    ParameterName = "@CreatDate",
                    Value = DateTime.Now
                };
                cmd.Parameters.Add(sqlParamCreatDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region 刪除
        public void DeleteMessage(int id)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.ConnectString))
            {
                SqlCommand cmd = new SqlCommand(SPName.Message.Message_Delete, con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParamId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(sqlParamId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

    }
}