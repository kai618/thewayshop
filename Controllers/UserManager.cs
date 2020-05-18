using System.Linq;
using thewayshop.Models;
using thewayshop.ViewModel;

namespace thewayshop.Controllers
{
    public class UserManager
    {
        private readonly eshopEntities _ctx = new eshopEntities();

        public bool SignUp(SignupUser user)
        {
            if (UserNameExists(user.UserName) || EmailExists(user.Email)) return false;
            try
            {
                _ctx.KhachHangs.Add(new KhachHang
                {
                    UserName = user.UserName,
                    Password = Utility.GetMd5Hash(user.Password),
                    Email = user.Email,
                    SDT = user.PhoneNumber,
                });
                _ctx.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool UserNameExists(string userName)
        {
            return _ctx.KhachHangs.Any(kh => kh.UserName == userName);
        }

        private bool EmailExists(string email)
        {
            return _ctx.KhachHangs.Any(kh => kh.Email == email);
        }

        public bool SignIn(SignInUser user)
        {
            var validUser = _ctx.KhachHangs.FirstOrDefault(kh => kh.UserName == user.UserName);
            if (validUser == null) return false;

            var hash = Utility.GetMd5Hash(user.Password);
            return validUser.Password == hash;
        }
    }
}