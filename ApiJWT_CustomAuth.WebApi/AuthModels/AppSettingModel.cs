using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJWT_CustomAuth.WebApi.AuthModels
{
    public class AppSettingModel
    {
        public string MyKey { get; set; }
        public string ValidateIssuer { get; set; }
        public string ValidateAudience { get; set; }
    }
}
