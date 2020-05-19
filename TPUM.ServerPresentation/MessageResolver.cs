using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPUM.Logic.Services;

namespace TPUM.ServerPresentation
{
    public class MessageResolver
    {
        public MessageResolver(Action<string> log) 
        {
            Log = log;
            ClientService = new ClientService();
            ProductService = new ProductService();
        }

        public string Resolve(string message)
        {
            if (message.Contains("GetUser"))
            {
                Log("[Server]: Resolving GetUser request");
                string[] parameters = message.Split(':');
                var user = ClientService.GetUser(Int32.Parse(parameters[1]));
                return user.Result.ToString();
            }
            else if (message.Contains("GetProduct"))
            {
                Log("[Server]: Resolving GetProduct request");
                string[] parameters = message.Split(':');
                var product = ProductService.GetProduct(Int32.Parse(parameters[1]));
                return product.ToString();
            }
            else if (message.Contains("GetAllProducts"))
            {
                Log("[Server]: Resolving GetAllProducts request");
                var products = ProductService.GetProducts();
                String result = "";
                foreach(var prod in products)
                {
                    result += prod.ToString() + "\n";
                }
                return result;
            }
            else
            {
                return "Can't process given message";
            }
        }

        private Action<string> Log { get; }
        private ClientService ClientService { get; }
        private ProductService ProductService { get; }
    }
}
