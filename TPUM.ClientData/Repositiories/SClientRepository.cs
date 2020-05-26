using System;
using System.Collections.Generic;
using System.Linq;
using TPUM.Dependencies.Model;

namespace TPUM.ClientData.Repositiories
{
    public class SClientRepository
    {
        private readonly DataContext _dataContext;

        public SClientRepository()
        {
            _dataContext = DbContext.Instance;
        }
        public SClientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public SClient Add(SClient entity)
        {
            _dataContext.SClients.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            SClient client = _dataContext.SClients.FirstOrDefault(c => c.Id == id);
            _dataContext.SClients.Remove(client);
        }

        public IEnumerable<SClient> Get()
        {
            return _dataContext.SClients;
        }

        public SClient Get(int id)
        {
            return _dataContext.SClients.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<SClient> Get(Func<SClient, bool> filter)
        {
            return _dataContext.SClients.Where(filter).ToList();
        }

        public SClient Update(int id, SClient entity)
        {
            SClient client = _dataContext.SClients.FirstOrDefault(c => c.Id == id);

            client.LastName = entity.LastName;
            client.Name = entity.Name;
            client.Age = entity.Age;
            client.Cart = entity.Cart;

            return client;
        }
    }
}
