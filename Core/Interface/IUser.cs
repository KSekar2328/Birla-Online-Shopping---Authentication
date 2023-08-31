using CoreAuthentication.Models;
using Microsoft.AspNetCore.Identity;

namespace CoreAuthentication.Interface
{
    public interface IUser
    {
        string GetJWTToken(IdentityUser user, List<string> roles);
    }
}
