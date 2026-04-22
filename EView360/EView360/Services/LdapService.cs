using EView360Models.Core;
using Microsoft.AspNetCore.Authentication;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace EView360.Services
{
    public class LdapService
    {
        private ILogger _logger { get; set; }
        public DirectoryEntry de { get; set; }
        public LdapService(ILogger<LdapService> logger) 
        {
            _logger = logger;
            de = new DirectoryEntry("LDAP://ncr.com", "am185760", "February@145", AuthenticationTypes.Secure);
        }

        public bool ValidateCredentials(string userName, string password)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "ncr.com", "DC=ncr,DC=com"))
            {
                return pc.ValidateCredentials(userName, password);
            }
        }

        public bool HandleNewUser(string userName)
        {
            SearchResult sr;
            DirectorySearcher ds = new DirectorySearcher(de);
            ds.Filter = "(&(objectCategory=User)(objectClass=person)(name=" + userName + "))";
            sr = ds.FindOne();

            string memberOf = sr.GetPropertyValue("memberOf");
            string email = sr.GetPropertyValue("distinguishedName");
            AppUser appUser = new();
            appUser.UserFullName = userName;
            appUser.UserEmail = email;
            //_context.AppUsers.Add(appUser);
            //adding in user_atms,group_users,

            return true;
        }

    }
}
