using System.Collections.Generic;
using MyCreek.Roles.Dto;
using MyCreek.Users.Dto;

namespace MyCreek.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}