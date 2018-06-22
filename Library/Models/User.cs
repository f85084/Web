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
    public class User
    {
        /// <summary>
        /// 會員ID  --由系統自動取得
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 會員帳號
        /// </summary>
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        [RegularExpression(WebShareConst.UserAccountExpression, ErrorMessage = WebShareConst.AccountNotValid)]
        public string UserAccount { get; set; }

        /// <summary>
        /// 會員類別
        /// </summary>
        [Display(Name = "類別")]
        [Required(ErrorMessage = "請輸入會員類別")]
        public byte UserClass { get; set; }

        /// <summary>
        /// 會員信箱
        /// </summary>
        [Display(Name = "信箱")]
        [RegularExpression(WebShareConst.EmailRegularExpression, ErrorMessage = WebShareConst.EmailNotValid)]
        [Required(ErrorMessage = "請輸入信箱")]
        public string Email { get; set; }

        /// <summary>
        /// 會員密碼
        /// </summary>
        [Display(Name = "密碼")]
        [StringLength(10, ErrorMessage = "密碼最長為10")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }

        /// <summary>
        /// 再次輸入密碼
        /// </summary>
        [Display(Name = "再次輸入密碼")]
        [Required(ErrorMessage = "再次輸入密碼")]
        [Compare("Password", ErrorMessage = "兩次密碼輸入不一致")]
        public string RePassword { get; set; }

        /// <summary>
        /// 會員名稱
        /// </summary>
        [Display(Name = "名稱")]
        [StringLength(10, ErrorMessage = "名稱最長為10")]
        public string UserName { get; set; }

        /// <summary>
        /// 會員建立時間
        /// </summary>
        public DateTime? CreatDate { get; set; }

        /// <summary>
        /// 會員修改時間
        /// </summary>
        public DateTime? MofiyDate { get; set; }

        /// <summary>
        /// 刪除會員
        /// </summary>
        [Display(Name = "狀態")]
        public bool Delete { get; set; }
    }

    public class CheckLogin
    {

        /// <summary>
        /// 會員帳號
        /// </summary>
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        [RegularExpression(WebShareConst.UserAccountExpression, ErrorMessage = WebShareConst.AccountNotValid)]
        public string UserAccount { get; set; }

        /// <summary>
        /// 會員密碼
        /// </summary>
        [Display(Name = "密碼")]
        [StringLength(10, ErrorMessage = "密碼最長為10")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }

    }
}
