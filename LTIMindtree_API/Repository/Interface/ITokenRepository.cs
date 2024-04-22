using Microsoft.AspNetCore.Identity;

namespace LTIMindtree_API.Repository.Interface
{
    public interface ITokenRepository
    {
        string CreateToken (IdentityUser user, List<string> roles);
    }
}
