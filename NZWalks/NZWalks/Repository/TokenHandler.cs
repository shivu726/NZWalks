using Microsoft.IdentityModel.Tokens;
using NZWalks.Models.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.Repository
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _config;

        public TokenHandler(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> CreateTokenAsync(UserInfo userInfo)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, userInfo.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, userInfo.LastName));
            claims.Add(new Claim(ClaimTypes.Email, userInfo.EmailAddress));

            userInfo.Roles.ForEach((roles) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, roles));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credential
                );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
