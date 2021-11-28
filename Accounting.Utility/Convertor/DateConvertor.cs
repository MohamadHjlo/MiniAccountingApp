using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


using System.Data;
using System.Windows.Forms;

namespace Accounting.Utility.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00") + "    " + pc.GetHour(value) + ":" + pc.GetMinute(value) + ":" + pc.GetSecond(value).ToString("00");

        }
        public static string ToShamsiCalender(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00");

        }
        public static DateTime ToMiladi(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new System.Globalization.PersianCalendar());
        }
    }
}
