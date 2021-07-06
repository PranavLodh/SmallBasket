using Microsoft.AspNetCore.Mvc;
using SmallBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallBasket.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            string TableName = "Users";
            string value=await LowLevelSample.GetOutputFromTable(TableName, new string[] { "id", "password" }, new string[] { user.ID, user.Password }, new string[] { "Name" });
            if (value != "Failed")
                return RedirectToAction("Output",new { id=value});
            else 
                return RedirectToAction("Output", new { id = value });
        }

        [HttpGet]
        public IActionResult Output(string id)
        {
            ViewBag.Message = id;
            return View();
        }
    }
}
