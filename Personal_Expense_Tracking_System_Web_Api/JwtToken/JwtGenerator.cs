using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Personal_Expense_Tracking_System_Web_Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Personal_Expense_Tracking_System_Web_Api.JwtToken
{
    public class JwtGenerator
    {

        private readonly JwtConfig _jwtConfig;

        public JwtGenerator(IOptionsMonitor<JwtConfig> optionsMonitor) 
        {
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        public string CreateJwt(User obj)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secrete);
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Iss, "http://localhost:4200/"),
                new Claim(JwtRegisteredClaimNames.Aud, "http://localhost:4200/"),
                new Claim("UserID", obj.UserID.ToString()),
                new Claim("UserRole", obj.UserRole.ToString()),
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = credentials,
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }

    }
}
