using EmailSenderApp.Domen.Entities.AuthModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens; //SymmetricSecurityKey tipi ishlashi uchun
using System.Security.Claims; //Claim ishlashi uchun
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Globalization;

namespace EmailSenderApp.Application.AuthService
{
    public class AuthServise : IAuthServise
    {
        public IConfiguration _config;

        public AuthServise(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            if (user.UserName == "Admin" && user.Password == "123")
            {
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]!));
                SigningCredentials credentials=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
                int expirePeriod = Convert.ToInt32(_config["JWT:Expire"]);

                //Claim yasash
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture)),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim("Password",user.Password)
                };

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _config["JWT:ValidIssuer"],
                    audience: _config["JWT:ValidAudience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                    signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return "Aldashga urunmang!";
            }
        }
    }
}
