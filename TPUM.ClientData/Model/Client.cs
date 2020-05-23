using System;

namespace TPUM.ClientData.Model
{
    public class Client : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Cart Cart { get; set; }
    }
}
