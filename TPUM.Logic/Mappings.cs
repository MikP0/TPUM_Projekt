using System;
using System.Linq;
using System.Threading.Tasks;
using TPUM.Data.Model;
using TPUM.Dependencies.Model;

namespace TPUM.Logic
{
    public static class Mappings
    {
        public static SClient MapClient(Client client)
        {
            SClient sclient = new SClient
            {
                Id = client.Id,
                Name = client.Name,
                LastName = client.LastName,
                Age = DateTime.Now.Year - client.DateOfBirth.Year,
                Cart = MapCart(client.Cart)
            };

            return sclient;
        }

        public static SProduct MapProduct(Product product)
        {
            SProduct sproduct = new SProduct
            {
                Id = product.Id,
                Author = product.Author,
                Name = product.Name,
                MinimalAge = DateTime.Now.Year - product.AllowedFromDate.Year,
                Price = product.Price
            };

            return sproduct;
        }

        public static SCart MapCart(Cart cart)
        {
            SCart scart = new SCart
            {
                Products = cart.Products.Select(MapProduct).ToList()
            };
            return scart;
        }
    }
}
