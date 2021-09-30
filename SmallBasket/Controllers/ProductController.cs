using Logger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmallBasket.BL;
using SmallBasket.Generic;
using SmallBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallBasket.Controllers
{
    [Filters]
    public class ProductController : Controller
    {
        private IConfiguration _config;
        private ILog log;

        public ProductController(IConfiguration config)
        {
            _config = config;
            log = Log.GetInstance;
        }

        [HttpGet]
        public IActionResult GetFruits()
        {
            List<Fruit> oFruit = new List<Fruit>();
            oFruit=ProductBL.GetFruitsList();
            return Ok(oFruit);
        }
    }
}
