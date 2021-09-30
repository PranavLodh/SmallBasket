using Newtonsoft.Json;
using SmallBasket.Generic;
using SmallBasket.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallBasket.BL
{
    public class ProductBL
    {
        public static List<Fruit> GetFruitsList()
        {            
            ExecuteData oExecuteData = new ExecuteData();
            string result;
            List<Fruit> oFruit = new List<Fruit>();
            Fruit fruit = new Fruit();
            ArrayList fruits = new ArrayList();
            oExecuteData.ExecuteReader("Select FruitID,Name,Price,Quantity,Amount from Fruit", out result,out fruits);
            oFruit=JsonConvert.DeserializeObject<List<Fruit>>(result);
            return oFruit;
            
        }
    }
}
