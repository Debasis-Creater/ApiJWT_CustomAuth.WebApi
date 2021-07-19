using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJWT_CustomAuth.WebApi.AuthModels
{
    public class UsersModel
    {
   
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
