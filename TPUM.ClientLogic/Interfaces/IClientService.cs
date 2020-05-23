using System.Collections.Generic;
using System.Threading.Tasks;
using TPUM.ClientLogic.DTOs;

namespace TPUM.ClientLogic.Interfaces
{
    public interface IClientService
    {
        Task<ClientDTO> GetClient(int id);
        Task<IEnumerable<ClientDTO>> GetClients();
        Task<IEnumerable<ClientDTO>> GetClientsByAge(int age);
    }
}
