using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPUM.ClientData;
using TPUM.ClientData.Interfaces;
using TPUM.ClientData.Model;
using TPUM.ClientData.Repositiories;
using TPUM.ClientLogic.DTOs;


namespace TPUM.ClientLogic.Services
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

        public async Task<ClientDTO> GetUser(int id)
        {
            return Mappings.MapClient(_clientRepository.Get(id));
        }

        public async Task<IEnumerable<ClientDTO>> GetUsers()
        {
            IEnumerable<Client> clients = _clientRepository.Get();

            return clients.Select(c => Mappings.MapClient(c)).ToList();
        }

        public async Task<IEnumerable<ClientDTO>> GetUsersByAge(int age)
        {
            IEnumerable<Client> clients = _clientRepository.Get(c => c.DateOfBirth.Year == DateTime.Now.Year - age);

            return clients.Select(c => Mappings.MapClient(c)).ToList();
        }
    }
}
