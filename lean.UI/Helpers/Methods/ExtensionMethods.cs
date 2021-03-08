using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace lean.UI.Helpers.Methods
{
    public static class ExtensionMethods
    {
        #region string
        public static string MapPath(this string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
        #endregion



        public static SelectList ToSelectList<T>(this List<T> list, Nullable<long> selected = null) where T : class
        {
            if (typeof(T).GetProperty("Name") == null)
                throw new Exception("Object Doesn't Contains Object With Name 'Name'.");

            return new SelectList(list, "Id", "Name", selected);
        }


        public static int GetCompressValue(this int value, int percentage)
        {
            return value - ((value * percentage) / 100);
        }


        public static DateTime ToLocalZone(this DateTime dateTime)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
            try
            {
                return TimeZoneInfo.ConvertTimeFromUtc(dateTime, timeZoneInfo);
            }
            catch (ArgumentException ex)
            {
                return TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), timeZoneInfo);
            }
        }

    }
}