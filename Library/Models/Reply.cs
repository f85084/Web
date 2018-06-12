using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Library.WebShare;

namespace Library
{
    public class Reply
    {
        /// <summary>
        /// 回覆編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 會員帳號
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 留言編號  --對應 Message 的 ID
        /// </summary>
        public int MessageId { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// 回覆內容
        /// </summary>
        [Display(Name = "留言內容")]
        [Required(ErrorMessage = "請輸入留言內容")]
        [StringLength(100, ErrorMessage = "留言內容不可超過100字元")]
        public string Context { get; set; }

        /// <summary>
        /// 回覆時間
        /// </summary>
        public DateTime? CreatDate { get; set; }

        /// <summary>
        /// 刪除回覆
        /// </summary>
        [Display(Name = "刪除回覆")]
        public bool Delete { get; set; }
    }
}
