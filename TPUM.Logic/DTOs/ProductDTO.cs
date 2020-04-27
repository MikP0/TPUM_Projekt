using System;
using System.Collections.Generic;
using System.Text;

namespace TPUM.Logic.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public int MinimalAge { get; set; }
    }
}
