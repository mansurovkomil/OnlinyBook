using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlinyBook.Domain.Entities.Users;
using OnlinyBook.Service.Intefaces.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlinyBook.Service.Service.Common
{
	public class AuthService : IAuthManager
	{
		private readonly IConfiguration _config;
		public AuthService(IConfiguration config)
		{
			_config = config.GetSection("Jwt");
		}
		public string GenerateToken(User user)
		{
			var claims = new[]
			   {
				new Claim("Id", user.Id.ToString()),
				new Claim("FirstName", user.FirstName),
				new Claim("LastName", user.LastName),
				new Claim("ImagePath", (user.ImagePath is null)?"":user.ImagePath),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim("Money", user.Money.ToString()),
				new Claim(ClaimTypes.Role, "User")
			};

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

			var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
				expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
		}
	}
}
