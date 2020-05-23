using System;
using System.Collections.Generic;
using System.Text;
using TPUM.ClientData.Interfaces;
using TPUM.ClientData.Model;

namespace TPUM.ClientData
{
    public class DataContext
    {
        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }
    }
}
