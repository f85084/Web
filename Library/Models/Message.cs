using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Library.WebShare;

namespace Library
{
    public class Message
    {
        /// <summary>
        /// 留言編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 留言帳號
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 留言名稱
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 留言內容
        /// </summary>
        [Display(Name = "留言內容")]
        [Required(ErrorMessage = "請輸入留言內容")]
        [StringLength(100, ErrorMessage = "留言內容不可超過100字元")]
        public string Context { get; set; }

        /// <summary>
        /// 留言時間
        /// </summary>
        public System.DateTime CreatDate { get; set; }

        /// <summary>
        /// 刪除留言
        /// </summary>
        [Display(Name = "刪除留言")]
        public bool Delete { get; set; }
    }
}
