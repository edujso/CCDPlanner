using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Data.Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CCDPlanner.Api.Models;

namespace CCDPlanner.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]/{id?}")]
    public class AuthController : Controller
    {
        private ILogger<AuthController> _logger;
        private SignInManager<User> _signInMgr;
        private UserManager<User> _userMgr;
        private IPasswordHasher<User> _hasher;
        private IConfigurationRoot _config;

        public AuthController(SignInManager<User> signInMgr,
          UserManager<User> userMgr,
          IPasswordHasher<User> hasher,
          ILogger<AuthController> logger,
          IConfigurationRoot config)
        {
            _signInMgr = signInMgr;
            _logger = logger;
            _userMgr = userMgr;
            _hasher = hasher;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] CredentialModel model)
        {
            try
            {
                var user = await _userMgr.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    if (_hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
                    {
                        var userClaims = await _userMgr.GetClaimsAsync(user);

                        var claims = new[]
                        {
              new Claim(ClaimTypes.Role, "Admin")
              //new Claim(ClaimTypes.Name, user.UserName),
              //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              //new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
              //new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
              //new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }.Union(userClaims);

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                          issuer: _config["Tokens:Issuer"],
                          audience: _config["Tokens:Audience"],
                          claims: claims,
                          expires: DateTime.UtcNow.AddMinutes(15),
                          signingCredentials: creds
                          );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while creating JWT: {ex}");
            }

            return BadRequest("Failed to generate token");
        }
    }
}