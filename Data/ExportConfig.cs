namespace CustomExports.Data
{
    public class ExportConfig
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ExportType { get; set; }
        public string Delimiter { get; set; }
        public Client Client { get; set; }
    }
}