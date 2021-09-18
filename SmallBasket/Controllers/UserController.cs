using Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using SmallBasket.Generic;
using SmallBasket.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SmallBasket.Controllers
{
    [Filters]
    public class UserController : Controller
    {
        private readonly IOptions<AppSettingsModel> appSettings;
        private ILog log;
        
        public UserController(IOptions<AppSettingsModel> app)
        {
            appSettings = app;
            log = Log.GetInstance;
        }
        public IActionResult Index()
        {
            return View();
        }

        

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Abc = "123";
            return View();
        }

        //[Authorize]
        [HttpGet]
        public IActionResult GetUserDetails(string Username,[FromBody]UserModel Login)
        {
            try
            {
                log.LogInformation(Convert.ToString(Request.Body));
                LoginUser oUser = new LoginUser();
                string result;
                ExecuteData oExecuteData = new ExecuteData();
                oExecuteData.ExecuteReader(string.Format("Select UserName,ID,ContactNumber from UserLogin where UserName='{0}'", Username), out result);
                string[] rslt = result.Split(":");
                oUser.Name = rslt[0];
                oUser.ID = Convert.ToInt32(rslt[1]);
                oUser.ContactNumber = Convert.ToInt32(rslt[2]);
                return Ok(oUser);
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }

        [HttpGet]
        public IActionResult Output(string id)
        {
            ViewBag.Message = id;
            return View();
        }        
    }
}
