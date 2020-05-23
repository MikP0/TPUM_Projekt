using System;
using System.Collections.Generic;
using System.Text;

namespace TPUM.Dependencies.Model
{
    public class SClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public SCart Cart { get; set; }

        public override string ToString()
        {
            return "C" + Id + ":" + Name + ":" + LastName + ":" + Age;
        }
    }
}
