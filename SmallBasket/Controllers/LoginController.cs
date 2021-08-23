using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
    public class LoginController : Controller
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = LoginBL.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = LoginBL.GenerateJSONWebToken(user,_config);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }    
}
