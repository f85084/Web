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
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        [Display(Name = "留言內容")]
        [Required(ErrorMessage = "請輸入留言內容")]
        public string Context { get; set; }
        public DateTime? CreatDate { get; set; }
    }
}
