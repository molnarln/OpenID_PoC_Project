using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenID_poc1.Services
{
    public interface IAuthService
    {
        string GetUserEmail(ClaimsPrincipal user);
        string GetUserName(ClaimsPrincipal user);

    }
}
