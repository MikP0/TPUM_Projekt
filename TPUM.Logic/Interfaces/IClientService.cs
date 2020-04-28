using System.Collections.Generic;
using TPUM.Logic.DTOs;

namespace TPUM.Logic.Interfaces
{
    public interface IClientService
    {
        ClientDTO GetClient(int id);
        IEnumerable<ClientDTO> GetClients();
        IEnumerable<ClientDTO> GetClientsByAge(int age);
    }
}
