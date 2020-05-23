using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPUM.Data;
using TPUM.Data.Interfaces;
using TPUM.Data.Model;
using TPUM.Data.Repositiories;
using TPUM.Dependencies.Model;

namespace TPUM.Logic.Services
{
    public class ClientService
    {
        private readonly IRepository<Client> _clientRepository;
        public ClientService()
        {
            _clientRepository = new ClientRepository(DbContext.Instance);
        }
        public ClientService(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<SClient> GetUser(int id)
        {
            return Mappings.MapClient(_clientRepository.Get(id));
        }

        public async Task<IEnumerable<SClient>> GetUsers()
        {
            IEnumerable<Client> clients = _clientRepository.Get();

            return clients.Select(c => Mappings.MapClient(c)).ToList();
        }

        public async Task<IEnumerable<SClient>> GetUsersByAge(int age)
        {
            IEnumerable<Client> clients = _clientRepository.Get(c => c.DateOfBirth.Year == DateTime.Now.Year - age);

            return clients.Select(c => Mappings.MapClient(c)).ToList();
        }
    }
}
