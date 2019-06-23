using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenID_poc1.Services
{
    public class AuthService
    {
        private IConfiguration configuration { get; set; }

        public AuthService(IConfiguration config)
        {
            this.configuration = config;
        }

        public string GetUserEmail(ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new Exception();
            }
            string userEmail = user.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            if (userEmail == null)
            {
                throw new Exception();
            }
            return userEmail;
        }
    }
}
