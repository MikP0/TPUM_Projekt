using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TPUM.ClientData.Repositiories;
using TPUM.Dependencies.Model;

namespace TPUM.ClientData.UnitTests
{
    [TestClass]
    public class ClientRepositoryUnitTest
    {
        [TestMethod]
        public void CreateTest()
        {
            DataContext dataContext = new DataContext { SClients = new List<SClient>() };
            SClientRepository ClientRepository = new SClientRepository(dataContext);
            Assert.IsNotNull(ClientRepository);
        }

        [TestMethod]
        public void GetTest()
        {
            DataContext dataContext = new DataContext { SClients = new List<SClient>() };
            SClientRepository ClientRepository = new SClientRepository(dataContext);
            IEnumerable<SClient> Clients = ClientRepository.Get();
            Assert.IsNotNull(Clients);
        }
        [TestMethod]
        public void AddTest()
        {
            DataContext dataContext = new DataContext { SClients = new List<SClient>() };
            SClientRepository ClientRepository = new SClientRepository(dataContext);
            SClient client = new SClient
            {
                Id = -1,
                Age = 18,
                Cart = new SCart(),
                Name = "John",
                LastName = "Doe"
            };

            ClientRepository.Add(client);
            Assert.IsNotNull(ClientRepository.Get(-1));
        }
        [TestMethod]
        public void DeleteTest()
        {
            DataContext dataContext = new DataContext { SClients = new List<SClient>() };
            SClientRepository ClientRepository = new SClientRepository(dataContext);
            SClient client = new SClient
            {
                Id = -1,
                Age = 18,
                Cart = new SCart(),
                Name = "John",
                LastName = "Doe"
            };
            ClientRepository.Add(client);
            ClientRepository.Delete(-1);

            Assert.AreEqual(0, ClientRepository.Get().ToList().Count());
        }

        [TestMethod]
        public void FilterTest()
        {
            DataContext dataContext = new DataContext { SClients = new List<SClient>() };
            SClientRepository ClientRepository = new SClientRepository(dataContext);
            SClient client = new SClient
            {
                Id = -1,
                Age = 18,
                Cart = new SCart(),
                Name = "John",
                LastName = "Doe"
            };
            SClient client2 = new SClient
            {
                Id = -2,
                Age = 32,
                Cart = new SCart(),
                Name = "Jack",
                LastName = "Sparrow"
            };
            ClientRepository.Add(client);
            ClientRepository.Add(client2);

            List<SClient> clients = ClientRepository.Get(c => c.Age == 32).ToList();
            Assert.AreEqual(1, clients.Count());
            
        }
        [TestMethod]
        public void UpdateTest()
        {
            DataContext dataContext = new DataContext { SClients = new List<SClient>() };
            SClientRepository ClientRepository = new SClientRepository(dataContext);
            SClient client = new SClient
            {
                Id = -1,
                Age = 18,
                Cart = new SCart(),
                Name = "John",
                LastName = "Doe"
            };
            ClientRepository.Add(client);

            string newName = "Jack";
            SClient client2 = new SClient
            {
                Id = -1,
                Age = 32,
                Cart = new SCart(),
                Name = newName,
                LastName = "Doe"
            };
            ClientRepository.Update(-1, client2);
            Assert.AreEqual(newName, ClientRepository.Get(-1).Name);
        }
    }
}
