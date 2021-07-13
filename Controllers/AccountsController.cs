using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomExports.Models;
using System.Linq;
using System.Collections.Generic;
using CustomExports.Data;

namespace CustomExports.Controllers
{
    public class AccountsController : Controller
    {
        private readonly CustomExportContext _context;

        public AccountsController(CustomExportContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allAccountData = await _context.Accounts
                .Join(_context.Clients, a => a.ClientId, c => c.Id, (a, c) => 
                new Models.Account { AccountNumber = a.AccountNumber, Balance = a.Balance,  AdmitDate = a.AdmitDate,  DischargeDate = a.DischargeDate,  PatientId = a.PatientId, ClientName = c.Name })
                .ToListAsync();

            ViewBag.AllAccountData = allAccountData;

            return View();
        }

    }
}
