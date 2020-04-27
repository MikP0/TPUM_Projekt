using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPUM.Data.Interfaces;
using TPUM.Data.Model;
using TPUM.Logic.DTOs;


namespace TPUM.Logic.Services
{
    public class ClientService
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientService(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public ClientDTO GetUser(int id)
        {
            Client client = _clientRepository.Get(id);

            return Mappings.MapClient(client);
        }

        public IEnumerable<ClientDTO> GetUsers()
        {
            IEnumerable<Client> clients = _clientRepository.Get();

            return clients.Select(c => Mappings.MapClient(c)).ToList();
        }

        public IEnumerable<ClientDTO> GetUsersByAge(int age)
        {
            IEnumerable<Client> clients = _clientRepository.Get(c => c.DateOfBirth.Year == DateTime.Now.Year - age);

            return clients.Select(c => Mappings.MapClient(c)).ToList();
        }
    }
}
