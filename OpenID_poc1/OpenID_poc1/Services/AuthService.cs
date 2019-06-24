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
                throw new Exception("User not found");
            }
            string userEmail = user.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            if (userEmail == null)
            {
                throw new Exception("Email not found");
            }
            return userEmail;
        }

        public string GetUserName(ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new Exception("User not found");
            }
            string givenName = user.Claims.First(claim => claim.Type == ClaimTypes.GivenName).Value;
            string surname = user.Claims.First(claim => claim.Type == ClaimTypes.Surname).Value;
            if (givenName == null && surname == null)
            {
                throw new Exception("Username not found");
            }
            return givenName + " " + surname;
        }
    }
}
