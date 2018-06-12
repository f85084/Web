using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.WebShare
{
    public class WebShareConst
    {
        //RegularExpression
        public const string EmailRegularExpression = @"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$";

        //Validation String
        public const string EmailNotValid = "Email不符合規定";
        public const string ValidationSummaryTitleString = "請檢查所有欄位.";
    }
}
