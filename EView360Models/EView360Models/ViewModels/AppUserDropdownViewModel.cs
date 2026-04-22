using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class AppUserDropdownViewModel
    {
        public long UserId { get; set; }

        public string UserLogin { get; set; }



        public static explicit operator EView360Models.Core.AppUser(AppUserDropdownViewModel appUser)
        {
            if (appUser == null)
            {
                return null;
            }

            EView360Models.Core.AppUser result = new EView360Models.Core.AppUser();

            result.UserId = appUser.UserId;
            result.UserLogin = appUser.UserLogin;

            return result;
        }

        public static explicit operator AppUserDropdownViewModel(EView360Models.Core.AppUser appUser)
        {
            if (appUser == null)
            {
                return null;
            }

            AppUserDropdownViewModel result = new AppUserDropdownViewModel();
            result.UserId = appUser.UserId;
            result.UserLogin = appUser.UserLogin;

            return result;
        }

    }
}
