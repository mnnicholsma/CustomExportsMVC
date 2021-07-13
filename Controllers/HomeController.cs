using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CustomExports.Repositories.Accounts;
using CustomExports.Repositories.Clients;
using CustomExports.Repositories.ExportConfigs;
using CustomExports.Repositories.AppLogs;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;
using CustomExports.Data;

namespace CustomExports.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountsRepository _accountRepository;
        private readonly IClientsRepository _clientRepository;
        private readonly IExportConfigsRepository _exportConfigRepository;
        private readonly IAppLogsRepository _appLogsRepository;
        private readonly CustomExportContext _context;

        public HomeController(IAccountsRepository accountRepository, IClientsRepository clientRepository, IExportConfigsRepository exportConfigsRepository, IAppLogsRepository appLogsRepository, CustomExportContext context)
        {
            _accountRepository = accountRepository;
            _clientRepository = clientRepository;
            _exportConfigRepository = exportConfigsRepository;
            _appLogsRepository = appLogsRepository;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.AllClients=_clientRepository.GetAllClients();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExportFile(Client model)
        {
            int clientIdSelected = model.Id;
            var accountDataForExport = _accountRepository.GetAccountDataByClient(clientIdSelected);
            string accountDataForExportFormatted = FormatAccountDataForExportAsync(accountDataForExport, clientIdSelected);
            string filename = "DefaultExport_" + (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + ".csv";
            return File(new System.Text.UTF8Encoding().GetBytes(accountDataForExportFormatted), "text/csv", filename);
        }

        private string FormatAccountDataForExportAsync(IList<Data.Account> accountDataForExport, int clientIdSelected)
        {
            //***************************************************************************************
            // FORMAT THE EXPORTED ACCOUNT DATA
            // TODO: USE FIELDS FROM THE EXPORT CONFIG TABLE TO EXPAND LOGIC FOR DATE FORMATS
            // TODO: USE FIELDS FROM THE EXPORT CONFIG TO EXPAND LOGIC FOR FILENAMES
            //***************************************************************************************
            string clientName = _clientRepository.GetClientName(clientIdSelected);

            var accountDataForExportFormatted = accountDataForExport.Select(a => new
            {
                a.AccountNumber,
                a.AdmitDate,
                a.Balance,
                a.DischargeDate
            }).ToList();

            string csv = ListToCSV(accountDataForExportFormatted, clientIdSelected);
            _appLogsRepository.InsertAppLogWithClientId("File Export", clientIdSelected, clientName);
            return csv;
        }

        private string ListToCSV<T>(IEnumerable<T> list, int clientIdSelected)
        {
            //***************************************************************************************
            // GET THE DELIMETER FROM THE EXPORT CONFIG TABLE FOR THE CLIENT
            // RETURN THE FORMATTED LIST READY FOR EXPORT
            //***************************************************************************************

            string clientExportDelimeter = _exportConfigRepository.GetClientExportDelimeter(clientIdSelected);

            StringBuilder sList = new StringBuilder();

            Type type = typeof(T);
            var props = type.GetProperties();
            sList.Append("\"");
            sList.Append(string.Join("\"" + clientExportDelimeter + "\"", props.Select(p => p.Name)));
            sList.Append("\"" + Environment.NewLine);

            foreach (var element in list)
            {
                sList.Append("\"");
                sList.Append(string.Join("\"" + clientExportDelimeter + "\"", props.Select(p => p.GetValue(element, null))));
                sList.Append("\"" + Environment.NewLine);
            }

            return sList.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
