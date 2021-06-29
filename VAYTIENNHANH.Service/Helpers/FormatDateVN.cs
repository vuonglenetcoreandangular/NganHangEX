using System;
using System.Collections.Generic;
using System.Text;

namespace VAYTIENNHANH.Service.Helpers
{
    public static class FormatDateVN
    {
        public static string ConvestDateVN(this DateTime dateTime)
        {
            string result = "";
            var DateNow = DateTime.Now;
            if((DateNow - dateTime).TotalDays >=1)
            {
                var hour = (DateNow - dateTime).TotalHours;               
                result = $"{hour} giờ trước";
            }
            else if ((DateNow - dateTime).TotalDays >= 2)
            {
                result = "1 ngày trước";
            }
            else if((DateNow - dateTime).TotalDays >= 3)
            {
                result = "2 ngày trước";
            }
            else
            {
                result = dateTime.ToString("dd/MM/yyy");
            }
            return result;
        }
    }
}
