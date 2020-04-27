using System;
using System.Collections.Generic;
using System.Text;

namespace TPUM.Data.Model
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public DateTime AllowedFromDate { get; set; }
    }
}
