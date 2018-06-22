using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Library.WebShare;
using System.Web.Mvc;



namespace Library
{
    //註冊用ViewModel
    public class NewUser
    {
        /// <summary>
        /// 會員帳號
        /// </summary>
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        [RegularExpression(WebShareConst.UserAccountExpression, ErrorMessage = WebShareConst.AccountNotValid)]
        public string NewUserAccount { get; set; }

        /// <summary>
        /// 會員密碼
        /// </summary>
        [Display(Name = "密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }

        /// <summary>
        /// 再次輸入密碼
        /// </summary>
        [Display(Name = "再次輸入密碼")]
        [Required(ErrorMessage = "再次輸入密碼")]
        [Compare("Password", ErrorMessage = "兩次密碼輸入不一致")]
        public string RePassword { get; set; }

    }
}
