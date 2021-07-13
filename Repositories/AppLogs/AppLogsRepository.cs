using System;
using CustomExports.Data;
using CustomExports.Repositories.AppLogs;
using CustomExports.Repositories.Accounts;

namespace CustomExports.Repositories.Clients
{
    public class AppLogsRepository : IAppLogsRepository
    {

        private readonly CustomExportContext _context;
        private readonly IAccountsRepository _accountRepository;

        public AppLogsRepository(CustomExportContext context, IAccountsRepository accountRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
        }

        public void InsertAppLogWithClientId(string logType, int clientId, string clientName)
        {

            // TODO: REFACTOR TO USE LESS DATABASE CALLS
            decimal totalClientBalance = _accountRepository.GetAccountTotalsByClient(clientId);
            int totalClientRecords = _accountRepository.GetAccountRecordCountByClient(clientId);

            var applog = new AppLog
            {
                UserId = "",
                FirstName = "",
                LastName = "",
                LogTime = DateTime.Now,
                LogType = logType,
                ClientId = clientId,
                TotalAmount = totalClientBalance,
                NumberOfAccounts = totalClientRecords,
                ClientName = clientName
            };

            _context.Add(applog);
            _context.SaveChanges();
        }


    }
}
