using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPUM.ClientData;
using TPUM.ClientData.Repositiories;
using TPUM.ClientLogic.DTOs;
using TPUM.Dependencies.Model;

namespace TPUM.ClientLogic.Services
{
    public class ClientService
    {
        private readonly SClientRepository _sclientRepository;
        public ClientService()
        {
            _sclientRepository = new SClientRepository(DbContext.Instance);
        }
        public ClientService(SClientRepository clientRepository)
        {
            _sclientRepository = clientRepository;
        }

        public async Task<ClientDTO> GetUser(int id)
        {
            return Mappings.MapClient(_sclientRepository.Get(id));
        }

        public async Task<IEnumerable<ClientDTO>> GetUsers()
        {
            IEnumerable<SClient> clients = _sclientRepository.Get();

            return clients.Select(c => Mappings.MapClient(c)).ToList();
        }

        public async Task<IEnumerable<ClientDTO>> GetUsersByAge(int age)
        {
            IEnumerable<SClient> clients = _sclientRepository.Get(c => c.Age == age);

            return clients.Select(c => Mappings.MapClient(c)).ToList();
        }
    }
}
