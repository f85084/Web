//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;

//namespace Library
//{
//    public class MessageReplyWeb
//    {
//        public IEnumerable<MessageReply> MessageReplys
//        {
//            get
//            {
//                string connectionString =
//                    ConfigurationManager.ConnectionStrings["WebContext"].ConnectionString;
//                List<MessageReply> messageReplys = new List<MessageReply>();
//                using (SqlConnection con = new SqlConnection(connectionString))
//                {
//                    SqlCommand cmd = new SqlCommand("spGetUser", con);
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    con.Open();
//                    SqlDataReader rdr = cmd.ExecuteReader();
//                    while (rdr.Read())
//                    {
//                        MessageReply messageReply = new MessageReply();
//                        messageReply.Id = Convert.ToInt32(rdr["Id"]);
//                        messageReply.UserId = Convert.ToInt32(rdr["UserId"]);
//                        messageReply.UserName = rdr["UserName"].ToString();
//                        messageReply.Context = rdr["Context"].ToString();
//                        messageReply.CreatDate = Convert.ToDateTime(rdr["CreatDate"]);
//                        messageReplys.Add(messageReply);
//                    }
//                }
//                return messageReplys;
//            }
//        }
//    }
//}