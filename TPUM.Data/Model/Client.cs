using System;
using System.Collections.Generic;
using System.Text;

namespace TPUM.Data.Model
{
    public class Client : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
