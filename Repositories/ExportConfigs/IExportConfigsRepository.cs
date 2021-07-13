using CustomExports.Data;
using System.Collections.Generic;

namespace CustomExports.Repositories.ExportConfigs
{
    public interface IExportConfigsRepository
    {
        IList<ExportConfig> GetAllExports();
        int GetClientExportFormat(int clientId);
        string GetClientExportDelimeter(int clientId);
    }
}




