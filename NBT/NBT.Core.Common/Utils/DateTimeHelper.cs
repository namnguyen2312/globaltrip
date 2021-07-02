using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Common.Utils
{
    public static class DateTimeHelper
    {
        public static DateTimeOffset FromDate(DateTimeOffset fromDate)
        {
            var date = ConvertTimeZoneVN(fromDate);
            date = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, new TimeSpan(7, 0, 0));
            return date;
        }
        public static DateTimeOffset ToDate(DateTimeOffset toDate)
        {
            var date = ConvertTimeZoneVN(toDate);
            date = new DateTimeOffset(date.Year, date.Month, date.Day, 23, 59, 59, new TimeSpan(7, 0, 0));
            return date;
        }

        public static DateTimeOffset ConvertTimeZoneVN(DateTimeOffset dateTime)
        {
            var vietNamZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            dateTime = TimeZoneInfo.ConvertTime(dateTime, vietNamZone);
            return dateTime;
        }

        public static DateTimeOffset GetDateTimeFromUtc(this DateTime dateTimeUtc, TimeZoneInfo timeZoneInfo)
        {
            var dateTimeWithTimeZone = TimeZoneInfo.ConvertTime(dateTimeUtc, timeZoneInfo);
            return dateTimeWithTimeZone;
        }
    }
}
