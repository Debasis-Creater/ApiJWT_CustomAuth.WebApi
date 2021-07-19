using System;
using System.Collections.Generic;

namespace ApiJWT_CustomAuth.WebApi.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual UserRoles Role { get; set; }
    }
}
