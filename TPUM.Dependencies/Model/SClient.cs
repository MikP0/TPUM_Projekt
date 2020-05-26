using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TPUM.Dependencies.Model
{
    [DataContract]
    public class SClient
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public SCart Cart { get; set; }

        public override string ToString()
        {
            return "C" + Id + ":" + Name + ":" + LastName + ":" + Age;
        }
    }
}