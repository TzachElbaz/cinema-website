using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll_to_dbCinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Web_Api_to_dbCinema.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        dbCinemaEditor Data = new dbCinemaEditor();
        readonly IConfiguration config1;
        public LoginController(IConfiguration c)
        {
            config1 = c;
        }


        // POST <LoginController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] Client userData)
        {
            Client client1 = Data.login(userData.Email, userData.Password);

            if (client1 != null)
            {
                string role = client1.Role;
                var securityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config1["jwt:secretKey"]));
                var cred1 = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims1 = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub,"abc"),
                    new Claim(ClaimTypes.Name,userData.Email),
                    new Claim(ClaimTypes.Role,role),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                var token1 = new JwtSecurityToken(issuer: config1["jwt:issuer"],
                    audience: config1["jwt:audience"], claims: claims1,
                    expires: DateTime.Now.AddHours(24), signingCredentials: cred1);
                string tok = new JwtSecurityTokenHandler().WriteToken(token1);
                return Ok(new { tok1 = tok, clientData = client1 });
            }
            return Unauthorized(new { message="Incorrect email or password" });
        }

    }
}
