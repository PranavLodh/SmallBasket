using Logger;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallBasket.Controllers
{
    public class ErrorController : Controller
    {
        private ILog log;
        public ErrorController()
        {
            log = Log.GetInstance;
        }

        [Route("/error")]
        public IActionResult Error()
        {
            return Ok();
        }


    }
}
