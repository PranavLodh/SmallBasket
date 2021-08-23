using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmallBasket.Controllers;
using SmallBasket.Generic;
using SmallBasket.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBasket.BL
{
    public class LoginBL
    {
        public static string GenerateJSONWebToken(UserModel userInfo, IConfiguration _config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] + userInfo.Username));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static UserModel AuthenticateUser(UserModel login)
        {
            ExecuteData oExecuteData = new ExecuteData();
            string result;
            oExecuteData.ExecuteReader("Select UserName,Password from UserLogin", out result);
            UserModel user = new UserModel();
            string[] rslt = result.Split(":");
            if (Convert.ToString(login.Username) == rslt[0] && Convert.ToString(login.Password) == rslt[1])
            {
                user.Username = login.Username;
            }
            return user;
        }
    }
}
