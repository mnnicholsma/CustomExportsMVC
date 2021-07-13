using CustomExports.Data;
using System.Collections.Generic;

namespace CustomExports.Repositories.Accounts
{
    public interface IAccountsRepository
    {
        IList<Account> GetAccountDataByClient(int clientId);
        public int GetAccountRecordCountByClient(int clientId);
        public decimal GetAccountTotalsByClient(int clientId);
    }
}





