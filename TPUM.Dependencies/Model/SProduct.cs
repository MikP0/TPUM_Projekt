using System;
using System.Collections.Generic;
using System.Text;

namespace TPUM.Dependencies.Model
{
    public class SProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public int MinimalAge { get; set; }

        public override string ToString()
        {
            return "P" + Id + ":" + Name + ":" + Author + ":" + Price + ":" + MinimalAge;
        }
    }
}
