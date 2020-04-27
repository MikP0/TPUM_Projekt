using System;
using System.Collections.Generic;
using System.Text;
using TPUM.Data.Model;

namespace TPUM.Data
{
    public class DbContext
    {
        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }

    }
}
