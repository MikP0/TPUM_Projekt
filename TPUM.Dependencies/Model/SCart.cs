using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TPUM.Dependencies.Model
{
    [DataContract]
    public class SCart
    {
        [DataMember]
        public List<SProduct> Products { get; set; }
    }
}