using System;
using System.Collections.Generic;
using System.Text;
using TPUM.Data.Model;

namespace TPUM.Data
{
    public sealed class DbContext
    {
        private static DbContext instance = null;
        private static readonly object lockobj = new object();
        DbContext()
        {
            Clients = new List<Client>();
            Products = new List<Product>();
            GenerateData();
        }
        public static DbContext Instance {
            get {
                lock (lockobj)
                {
                    if (instance == null)
                    {
                        instance = new DbContext();
                    }
                }
                return instance;
            }
        }

        private void GenerateData()
        {
            Clients.Add(new Client {
                Id = 1,
                DateOfBirth = new DateTime(1997, 06, 25),
                Cart = new Cart(),
                Name = "Jan",
                LastName = "Naj"
            });

            Products.Add(new Product
            {
                Id = 1,
                Author = "DVD Project Blue",
                Name = "Super gra",
                Price = 31.50f,
                AllowedFromDate = new DateTime(1999, 01, 01),
                IsLocked = false
            });
        }

        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }

    }
}
