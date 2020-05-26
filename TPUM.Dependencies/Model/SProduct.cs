using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TPUM.Dependencies.Model
{
    [DataContract]
    public class SProduct
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public int MinimalAge { get; set; }

        public override string ToString()
        {
            return "P" + Id + ":" + Name + ":" + Author + ":" + Price + ":" + MinimalAge;
        }
    }
}