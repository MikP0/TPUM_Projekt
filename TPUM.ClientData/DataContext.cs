using System;
using System.Collections.Generic;
using System.Text;
using TPUM.ClientData.Model;
using TPUM.Dependencies.Model;

namespace TPUM.ClientData
{
    public class DataContext
    {
        public List<SClient> SClients { get; set; }
        public List<SProduct> SProducts { get; set; }
    }
}
