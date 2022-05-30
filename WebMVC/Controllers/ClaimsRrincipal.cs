using System.Security.Claims;
using System.Security.Principal;

namespace WebMVC.Controllers
{
    internal class ClaimsRrincipal : ClaimsPrincipal
    {
        public ClaimsRrincipal(IIdentity identity) : base(identity)
        {
        }
    }
}