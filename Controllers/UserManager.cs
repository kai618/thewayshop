using System.Linq;
using System.Security.Cryptography;
using System.Text;
using thewayshop.Models;

namespace thewayshop.Controllers
{
    public static class UserManager
    {
        private static readonly eshopEntities Ctx = new eshopEntities();

        public static bool UserNameExists(string userName)
        {
            return Ctx.KhachHangs.Any(kh => kh.TenKH == userName);
        }

        public static bool EmailExists(string email)
        {
            return Ctx.KhachHangs.Any(kh => kh.Email == email);
        }

        public static bool PasswordMatches(string userName, string password)
        {
            var user = Ctx.KhachHangs.FirstOrDefault(kh => kh.TenKH == userName);
            if (user == null) return false;

            var hash = GetMd5Hash(password);
            return user.Password == hash;
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