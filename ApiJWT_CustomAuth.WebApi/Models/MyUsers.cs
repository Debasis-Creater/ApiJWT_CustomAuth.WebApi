using System;
using System.Collections.Generic;

namespace ApiJWT_CustomAuth.WebApi.Models
{
    public partial class MyUsers
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
