using Microsoft.AspNetCore.Identity;

namespace TCCPosPucMinas.Domain.Identity
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
