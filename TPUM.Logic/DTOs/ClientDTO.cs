﻿namespace TPUM.Logic.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public CartDTO Cart { get; set; }

        public override string ToString() 
        {
            return Id + ":" + Name + ":" + LastName + ":" + Age;
        }
    }
}
