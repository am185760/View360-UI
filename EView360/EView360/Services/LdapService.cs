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
        private readonly IConfiguration _configuration;

        public LdapService(ILogger<LdapService> logger, IConfiguration configuration) 
        {
            _logger = logger;
            _configuration = configuration;
            de = new DirectoryEntry(_configuration["LdapSettings:LdapUrl"]!);
        }

        public bool ValidateCredentials(string userName, string password)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, _configuration["LdapSettings:DomainName"], _configuration["LdapSettings:BaseDN"]))
            {
                return pc.ValidateCredentials(userName, password);
            }
        }



    }
}
