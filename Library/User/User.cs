using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Library.WebShare;

namespace Library
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        public string UserAccount { get; set; }
        [Display(Name = "會員類別")]
        [Required(ErrorMessage = "請輸入會員類別")]
        public byte UserClass { get; set; }
        [Display(Name = "會員信箱")]
        [RegularExpression(WebShareConst.EmailRegularExpression, ErrorMessage = WebShareConst.EmailNotValid)]  //EmailAddress Regular Expression
        [Required(ErrorMessage = "請輸入信箱")]
        public string Email { get; set; }
        [Display(Name = "會員密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }
        [Display(Name = "會員名稱")]
        public string UserName { get; set; }
        public DateTime? CreatDate { get; set; }
        public DateTime? MofiyDate { get; set; }
    }
}
