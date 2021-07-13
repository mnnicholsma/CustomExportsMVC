namespace CustomExports.Repositories.AppLogs
{
    public interface IAppLogsRepository
    {
        public void InsertAppLogWithClientId(string logType, int clientId, string clientName);
    }
}




