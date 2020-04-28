using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPUM.Data.Interfaces;
using TPUM.Data.Model;

namespace TPUM.Data.Repositiories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly DbContext _dbContext;
        public ClientRepository()
        {
            _dbContext = DbContext.Instance;
        }
        public ClientRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Client Add(Client entity)
        {
            _dbContext.Clients.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Client client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
            _dbContext.Clients.Remove(client);
        }

        public IEnumerable<Client> Get()
        {
            return _dbContext.Clients;
        }

        public Client Get(int id)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Client> Get(Func<Client, bool> filter)
        {
            return _dbContext.Clients.Where(filter).ToList();
        }

        public Client Update(int id, Client entity)
        {
            Client client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);

            client.LastName = entity.LastName;
            client.Name = entity.Name;
            client.DateOfBirth = entity.DateOfBirth;
            client.Cart = entity.Cart;

            return client;
        }
    }
}
