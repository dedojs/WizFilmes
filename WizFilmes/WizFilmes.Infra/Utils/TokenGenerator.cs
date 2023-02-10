using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WizFilmes.Domain.Models;


namespace WizFilmes.Infra.Utils
{
    public class TokenGenerator
    {
        public string Generate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(user),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)),
                    SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddDays(1)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private ClaimsIdentity AddClaims(User user)
        {
            var claims = new ClaimsIdentity();

            var userClaims = new List<Claim>()
            {
                new Claim("UserName", user.Name),
                new Claim("UserEmail", user.Email),
                new Claim("UserPassword", user.Password)
            };

            claims.AddClaims(userClaims);

            return claims;
        }
    }
}
