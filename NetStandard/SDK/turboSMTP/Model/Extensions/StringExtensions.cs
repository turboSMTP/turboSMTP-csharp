using System;
using System.Collections.Generic;

namespace TurboSMTPSDK.Model.Extensions
{
    public static class StringExtensions
    {
        public static DateTime FromTSDatetimes(this string str)
        {
            DateTime result;
            string format = "yyyy-MM-dd HH:mm:ss";
            if (DateTime.TryParseExact(str, format, null, System.Globalization.DateTimeStyles.None, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"Invalid date format, expected {format}, value was: {str}");
            }
        }
        public static DateTime? FromNullableTSDatetimes(this string str)
        {
            if(String.IsNullOrEmpty(str))
                return null;
            return FromTSDatetimes(str);
        }

        public static string ToCommaSeparated(this List<string> values)
        {
            return values == null ? null : string.Join(",", values);
        }
    }
}
