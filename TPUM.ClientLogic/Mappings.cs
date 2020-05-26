using System;
using System.Linq;
using TPUM.ClientLogic.DTOs;
using TPUM.Dependencies.Model;

namespace TPUM.ClientLogic
{
    public static class Mappings
    {
        public static ClientDTO MapClient(SClient client)
        {
            ClientDTO clientDTO = new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                LastName = client.LastName,
                Age = client.Age,
                Cart = MapCart(client.Cart)
            };

            return clientDTO;
        }

        public static ProductDTO MapProduct(SProduct product)
        {
            ProductDTO productDTO = new ProductDTO
            {
                Id = product.Id,
                Author = product.Author,
                Name = product.Name,
                MinimalAge = product.MinimalAge,
                Price = product.Price
            };

            return productDTO;
        }

        public static CartDTO MapCart(SCart cart)
        {
            CartDTO cartDTO = new CartDTO
            {
                Products = cart.Products.Select(MapProduct).ToList()
            };
            return cartDTO;
        }
    }
}
