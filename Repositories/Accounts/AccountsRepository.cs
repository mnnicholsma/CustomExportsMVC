using System.Collections.Generic;
using System.Linq;
using CustomExports.Data;

namespace CustomExports.Repositories.Accounts
{
    public class AccountsRepository : IAccountsRepository
    {

        private readonly CustomExportContext _context;

        public AccountsRepository(CustomExportContext context)
        {
            _context = context;
        }

        public IList<Account> GetAccountDataByClient(int clientId)
        {
            List<Account> AllAccounts = null;

            AllAccounts = _context.Accounts
            .Where(a => a.ClientId == clientId)
                .ToList();

            return AllAccounts;
        }

        public decimal GetAccountTotalsByClient(int clientId)
        {

            var totalBalanceOfExport = _context.Accounts
            .Where(a => a.ClientId == clientId)
                .Sum(x => x.Balance);

            return (decimal)totalBalanceOfExport;
        }


        public int GetAccountRecordCountByClient(int clientId)
        {

            var totalNumberOfAccountRecords = _context.Accounts
            .Where(a => a.ClientId == clientId)
                .Count();

            return totalNumberOfAccountRecords;
        }








    }
}
