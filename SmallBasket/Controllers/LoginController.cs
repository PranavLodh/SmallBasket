using Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SmallBasket.BL;
using SmallBasket.Generic;
using SmallBasket.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmallBasket.Controllers.UserController;

namespace SmallBasket.Controllers
{
    [Filters]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private ILog log;

        public LoginController(IConfiguration config)
        {
            _config = config;
            log = Log.GetInstance;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            log.LogInformation("Request Received is " + JsonConvert.SerializeObject(login));
            IActionResult response = Unauthorized();
            var user = LoginBL.AuthenticateUser(login);
            LoginResult oLoginResult = new LoginResult();
            if (user.UserName != null)
            {
                var tokenString = LoginBL.GenerateJSONWebToken(user, _config);
                oLoginResult.Username = login.UserName;
                oLoginResult.Status = "Sucess";
                oLoginResult.Token = tokenString;
                response = Ok(oLoginResult);
            }

            return response;
        }


    }

    public class LoginResult
    {
        public string Token { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
    }
}
