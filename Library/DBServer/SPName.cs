using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DBServer
{
    public class SPName
    {
        public struct User
        {
            /// <summary>
            /// 取得使用者資料
            /// </summary>
            internal const string User_Get = "usp_User_Get";

            /// <summary>
            /// 新增使用者資料
            /// </summary>
            internal const string User_Add = "usp_User_Add";

            /// <summary>
            /// 編輯使用者資料
            /// </summary>
            internal const string User_Update = "usp_User_Update";

            /// <summary>
            /// 刪除使用者資料
            /// </summary>
            internal const string User_Delete = "usp_User_Delete";
        }

        public struct Message
        {
            /// <summary>
            /// 取得留言資料
            /// </summary>
            internal const string Message_Get = "usp_Message_Get";

            /// <summary>
            /// 新增留言資料
            /// </summary>
            internal const string Message_Add = "usp_Message_Add";

            /// <summary>
            /// 更新留言資料
            /// </summary>
            internal const string Message_Update = "usp_Message_Update";

            /// <summary>
            /// 刪除留言資料
            /// </summary>
            internal const string Message_Delete = "usp_Message_Delete";
        }

        public struct Reply
        {
            /// <summary>
            /// 取得回覆資料
            /// </summary>
            internal const string Reply_Get = "usp_Reply_Get";

            /// <summary>
            /// 新增回覆資料
            /// </summary>
            internal const string Reply_Add = "usp_Reply_Add";
        }

        public struct MessageReply
        {
            /// <summary>
            /// 取得留言回覆資料
            /// </summary>
            internal const string MessageRely_Get = "usp_MessageRely_Get";

        }

    }
}
