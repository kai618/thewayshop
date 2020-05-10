using System;
using System.Collections.Generic;
using System.Threading;

namespace thewayshop.Controllers
{
    public static class Utility
    {
        public static string StringCapitalise(string str)
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(str);
        }

        public static List<T> GetRandomElements<T>(List<T> list, int count)
        {
            var ran = new Random();
            if (count > list.Count || count < 1) count = list.Count;

            var clonedList = new List<T>(list.Count);
            var randomisedList = new List<T>(count);

            list.ForEach(e => clonedList.Add(e));

            for (var i = 0; i < count; i++)
            {
                var product = clonedList[ran.Next(clonedList.Count)];
                randomisedList.Add(product);
                clonedList.Remove(product);
            }

            return randomisedList;
        }
    }
}