using Demo.Helper;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sabji_MartDbContext;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        UserRepository repository = new UserRepository();
        Sabji_MartContext context = new Sabji_MartContext();

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            //var User = repository.checkLogin(user);
            var result = context.Users.ToList();
            var status = false;
            var tokenString = "";
            var userId = 0;

            foreach (var item in result)
            {
                if (item.EmailAdd == user.EmailAdd && EncDscPassword.DecryptPassword( item.Password ) == user.Password)
                {
                    status = true;
                    userId = item.Id;
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);



                    var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44362",
                    audience: "https://localhost:44362",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                    );
                    tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                    break;

                }
                else
                {
                    status = false;

                }
            }
            if (status)
                return Ok(new { tokenString , userId});
            else
                return Unauthorized();

            /*  if (User == null)
                   return BadRequest("Invalid Client Request");
              else 
              {
                  var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                  var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);



                  var tokenOptions = new JwtSecurityToken(
                  issuer: "https://localhost:44392",
                  audience: "https://localhost:44392",
                  claims: new List<Claim>(),
                  expires: DateTime.Now.AddMinutes(5),
                  signingCredentials: signinCredentials
                  );
                  var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                  return Ok(new { Token = tokenString });
              }
              return Unauthorized();*/
        }
    }
}

