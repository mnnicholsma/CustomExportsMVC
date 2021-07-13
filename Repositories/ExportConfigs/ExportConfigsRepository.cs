using System.Collections.Generic;
using System.Linq;
using CustomExports.Data;

namespace CustomExports.Repositories.ExportConfigs
{
    public class ExportConfigsRepository : IExportConfigsRepository
    {

        private readonly CustomExportContext _context;

        public ExportConfigsRepository(CustomExportContext context)
        {
            _context = context;
        }

        public IList<ExportConfig> GetAllExports()
        {
            List<ExportConfig> allExportFormats = null;

            allExportFormats = _context.ExportConfigs
                .ToList();

            return allExportFormats;
        }

        public int GetClientExportFormat(int clientId)
        {
            var clientExportRecord = _context.ExportConfigs
            .Where(c => c.ClientId == clientId)
            .First();

            var clientExportType = clientExportRecord.Id;

            return clientExportType;
        }

        public string GetClientExportDelimeter(int clientId)
        {
            var clientExportRecord = _context.ExportConfigs
            .Where(c => c.ClientId == clientId)
            .First();

            string clientExportType = clientExportRecord.Delimiter;

            return clientExportType;
        }


    }
}
