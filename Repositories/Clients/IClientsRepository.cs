using CustomExports.Data;
using System.Collections.Generic;

namespace CustomExports.Repositories.Clients
{
    public interface IClientsRepository
    {
        IList<Client> GetAllClients();
        public string GetClientName(int clientId);
    }
}




