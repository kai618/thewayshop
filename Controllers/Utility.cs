using System;
using System.Globalization;
using System.Threading;
using System.Web.WebPages;

namespace thewayshop.Controllers
{
    public static class Utility
    {
        public static string StringCapitalise(string str)
        {
            //if (str.Trim().IsEmpty()) return null;
            //var words = str.Split(' ');
            //foreach (var word in words)
            //{
            //}


            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(str);
        }
    }
}