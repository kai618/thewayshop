using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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

        public static string GetMd5Hash(string text)
        {
            MD5 md5Sv = new MD5CryptoServiceProvider();
            // Convert the input string to a byte array and compute the hash.
            md5Sv.ComputeHash(Encoding.ASCII.GetBytes(text));
            var bytes = md5Sv.Hash;

            var strBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            foreach (var b in bytes) strBuilder.Append(b.ToString("x2"));
            return strBuilder.ToString();
        }
    }
}