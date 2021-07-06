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

        //[HttpPost]
        //[Route("/User/Login")]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login( User user)
        {
            string TableName = "Users";
            LowLevelSample.ExecuteAsync().Wait();
            LowLevelSample.GetOutputFromTable(TableName, new string[] { "id", "password" }, new string[] { user.ID, user.Password }).Wait();
            return RedirectToAction("Index");
        }
    }
}
