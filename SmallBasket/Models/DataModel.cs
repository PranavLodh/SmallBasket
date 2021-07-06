using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallBasket.Models
{
    public class DataModel
    {
        public List<ColumnKeyValuePair> ColumnKeyValue { get; set; }
    }
    public class ColumnKeyValuePair
    {
        public string ColumnKey { get; set; }
        public string ColumnValue { get; set; }
    }

    public class User
    {
        public string ID { get; set; }
        public string Password { get; set; }
    }
}
