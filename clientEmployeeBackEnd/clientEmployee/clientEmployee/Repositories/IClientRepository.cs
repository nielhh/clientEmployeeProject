using skeleton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skeleton.Repositories
{

    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientByID(int ID);
        Task<Client> InsertClient(Client objClient);
        Task<Client> UpdateClient(Client objClient);
        bool DeleteClient(int ID);
    }
}