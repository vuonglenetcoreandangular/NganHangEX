using System;
using System.Collections.Generic;
using System.Text;

namespace VAYTIENNHANH.Model.Helpers
{
    public static class ConvestValues
    {
        public static string ConvestDateVN(this DateTime dateTime)
        {
            string result = "";
            var DateNow = DateTime.Now;
            if (DateNow.Year == dateTime.Year && DateNow.Month == dateTime.Month)
            {
                if ((DateNow.Day - dateTime.Day) <= 1)
                {
                    var hour = (DateNow.Hour - dateTime.Hour);
                    if(hour == 0)
                    {
                        var minute = DateNow.Minute - dateTime.Minute;
                        result = $"{minute} phút trước";
                    }
                    else
                    {
                        result = $"{hour} giờ trước";
                    }                   
                }
                else if ((DateNow.Day - dateTime.Day) > 1 && (DateNow.Day - dateTime.Day) <= 2)
                {
                    result = "1 ngày trước";
                }
                else if ((DateNow.Day - dateTime.Day) > 2 && (DateNow.Day - dateTime.Day) <= 3)
                {
                    result = "2 ngày trước";
                }
                else if ((DateNow.Day - dateTime.Day) > 3 && (DateNow.Day - dateTime.Day) <= 4)
                {
                    result = "3 ngày trước";
                }
                else if ((DateNow.Day - dateTime.Day) > 4 && (DateNow.Day - dateTime.Day) <= 5)
                {
                    result = "4 ngày trước";
                }
                else if ((DateNow.Day - dateTime.Day) > 5 && (DateNow.Day - dateTime.Day) <= 6)
                {
                    result = "5 ngày trước";
                }
                else if ((DateNow.Day - dateTime.Day) > 6 && (DateNow.Day - dateTime.Day) <= 7)
                {
                    result = "6 ngày trước";
                }
                else if ((DateNow.Day - dateTime.Day) > 7 && (DateNow.Day - dateTime.Day) <= 8)
                {
                    result = "7 ngày trước";
                }
                else
                {
                    result = dateTime.ToString("dd/MM/yyy");
                }
            }
            else
            {
                result = dateTime.ToString("dd/MM/yyy");
            }

            return result;
        }
    }
}
