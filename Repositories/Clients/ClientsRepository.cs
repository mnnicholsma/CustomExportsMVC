using System.Collections.Generic;
using System.Linq;
using CustomExports.Data;

namespace CustomExports.Repositories.Clients
{
    public class ClientsRepository : IClientsRepository
    {

        private readonly CustomExportContext _context;

        public ClientsRepository(CustomExportContext context)
        {
            _context = context;
        }

        public IList<Client> GetAllClients()
        {
            List<Client> allClients = null;

            allClients = _context.Clients
                .ToList();

            return allClients;
        }

        public string GetClientName(int clientId)
        {
            var clientRecord = _context.Clients
           .Where(a => a.Id == clientId)
               .First();

            string clientName = clientRecord.Name;
            return clientName;

        }


    }
}
