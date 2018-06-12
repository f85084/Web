using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebShare
{
    public class WebShareConst
    {
        //RegularExpression
        public const string UserAccountExpression = @"^[\w]{0,7}$";
        public const string EmailRegularExpression = @"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$";

        //Validation String
        public const string AccountNotValid = "請輸入正確帳號 英文大小寫 長度最長7";
        public const string EmailNotValid = "請輸入正確的電子郵件位址，如:www@www.com";
        public const string ValidationSummaryTitleString = "請檢查所有欄位.";
    }
}
