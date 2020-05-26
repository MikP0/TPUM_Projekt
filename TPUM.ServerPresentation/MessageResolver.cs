using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using TPUM.Dependencies.Model;
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
                SClient user = ClientService.GetUser(Int32.Parse(parameters[1])).Result;

                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SClient));
                serializer.WriteObject(stream, user);

                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);
                string output = sr.ReadToEnd();

                return output;
            }
            else if (message.Contains("GetProduct"))
            {
                Log("[Server]: Resolving GetProduct request");
                string[] parameters = message.Split(':');
                SProduct product = ProductService.GetProduct(Int32.Parse(parameters[1]));

                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SProduct));
                serializer.WriteObject(stream, product);

                byte[] json = stream.ToArray();
                stream.Close();
                string result = Encoding.UTF8.GetString(json, 0, json.Length);
                return Encoding.UTF8.GetString(json, 0, json.Length);
            }
            else if (message.Contains("GetAllProducts"))
            {
                Log("[Server]: Resolving GetAllProducts request");
                IEnumerable<SProduct> products = ProductService.GetProducts();

                List<SProduct> serializationList = new List<SProduct>();

                foreach (SProduct prod in products)
                {
                    serializationList.Add(prod);
                }

                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<SProduct>));
                serializer.WriteObject(stream, serializationList);

                byte[] json = stream.ToArray();
                stream.Close();
                string result = Encoding.UTF8.GetString(json, 0, json.Length);

                return Encoding.UTF8.GetString(json, 0, json.Length);
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
