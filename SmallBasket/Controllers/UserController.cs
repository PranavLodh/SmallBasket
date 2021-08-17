using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
    public class UserController : Controller
    {
        private readonly IOptions<AppSettingsModel> appSettings;

        public UserController(IOptions<AppSettingsModel> app)
        {
            appSettings = app;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        //[EnableCors]
        public IActionResult UserLogin()       
        {
            ExecuteData oExecuteData = new ExecuteData();
            oExecuteData.ExecuteReader("Select * from UserLogin");
            /*SqlConnection conn = new SqlConnection(appSettings.Value.DbConn);
            SqlCommand cmd = new SqlCommand("Select * from visits", conn);
            conn.Close();
            conn.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            
            while (dr.Read())
            {
                oresult.username=dr[""]   
            }*/

            /*if (oLoginRequest.username == "Pranav" && oLoginRequest.password == "Pranav1234")
            {
                oresult.username = oLoginRequest.username;
                oresult.Status = "Sucess";
            }*/
            Result oresult = new Result();            
            oresult.Status = "Failed";
            return Ok(oresult);
        }

        [HttpGet]
        public async Task<IActionResult> Login(User user)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V2QRB31.Pranav Lodh,database=Hello-World");
            conn.Open();
            string TableName = "Users";
            string value=await LowLevelSample.GetOutputFromTable(TableName, new string[] { "id", "password" }, new string[] { user.ID, user.Password }, new string[] { "Name" });
            if (value != "Failed")
                return RedirectToAction("Output",new { id="Welcome " + value});
            else 
                return RedirectToAction("Output", new { id = value });
        }

        [HttpGet]
        public IActionResult GetUserDetails(string Username)
        {
            LoginUser oUser = new LoginUser();
            oUser.Name = "Pranav";
            oUser.ID = 123456;
            oUser.ContactNumber = 9820946019;
            return Ok(oUser);
        }

        [HttpGet]
        public IActionResult Output(string id)
        {
            ViewBag.Message = id;
            return View();
        }

        public class Result
        {
            public String username { get; set; }
            public String Status { get; set; }
        }

        public class LoginRequest
        {
            public String username { get; set; }
            public String password { get; set; }
        }

        public class LoginUser
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public long ContactNumber { get; set; }
        }
    }
}
