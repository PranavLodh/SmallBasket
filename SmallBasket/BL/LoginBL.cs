using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SmallBasket.Controllers;
using SmallBasket.Generic;
using SmallBasket.Models;
using System;
using System.Collections;
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
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] + userInfo.UserName));
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
            ArrayList list = new ArrayList();
            oExecuteData.ExecuteReader("Select UserName,Password from UserLogin", out result,out list);
            List<UserModel> user = new List<UserModel>();
            user=JsonConvert.DeserializeObject<List<UserModel>>(result);            
            for(int i=0;i<user.Count;i++)
            {
                if(user[i].UserName!=login.UserName)
                {
                    login.UserName = null;
                }
            }
            return login;
        }
    }
}
