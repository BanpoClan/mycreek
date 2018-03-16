using Abp.Authorization;
using MyCreek.Authorization.Roles;
using MyCreek.Authorization.Users;

namespace MyCreek.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
