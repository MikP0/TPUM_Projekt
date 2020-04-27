using System;
using System.Collections.Generic;
using System.Text;
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
