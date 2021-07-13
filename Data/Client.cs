using System.Collections.Generic;

namespace CustomExports.Data
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExportFormatId { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<ExportConfig> ExportConfigs { get; set; }
    }
}