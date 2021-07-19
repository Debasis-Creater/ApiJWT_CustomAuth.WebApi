using ApiJWT_CustomAuth.WebApi.AuthModels;
using ApiJWT_CustomAuth.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiJWT_CustomAuth.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MyAuthController : ControllerBase
    {
        private readonly TestdatabaseContext _context;
        private readonly AppSettingModel _appSetting;

        public MyAuthController(TestdatabaseContext context, IOptions<AppSettingModel> appSettings)
        {
            _context = context;
            _appSetting = appSettings.Value;
        }
        [HttpPost]
        public IActionResult Login([FromBody] UsersModel model)
        {
            var user = _context.MyUsers.Where(x => x.UserName == model.UserName && x.Password == model.Password).SingleOrDefault();
            if (user == null)
            {
                return BadRequest( new { status = "error" , message ="invalid credentials"});

            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.MyKey);
            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                }),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescripter);
            var NewToken = tokenHandler.WriteToken(token);
            user.Password = null;
            return Ok(new
            {
               UserName = model.UserName,
               Token = NewToken
            });
        }
    }
}
