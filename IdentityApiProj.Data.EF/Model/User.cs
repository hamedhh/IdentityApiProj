using Microsoft.AspNetCore.Identity;

namespace IdentityApiProj.Data.EF.DbContext
{
    public class User:IdentityUser<int>

    {
        public string Name { get; set; }
        public string ProfileUrl { get; set; }
    }
}