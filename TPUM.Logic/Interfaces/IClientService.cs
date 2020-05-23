using System.Collections.Generic;
using System.Threading.Tasks;
using TPUM.Dependencies.Model;

namespace TPUM.Logic.Interfaces
{
    public interface IClientService
    {
        Task<SClient> GetClient(int id);
        Task<IEnumerable<SClient>> GetClients();
        Task<IEnumerable<SClient>> GetClientsByAge(int age);
    }
}
