using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomExports.Data;

namespace CustomExports.Controllers
{
    public class AppLogsController : Controller
    {
        private readonly CustomExportContext _context;

        public AppLogsController(CustomExportContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appLogData = await _context.AppLogs.ToListAsync();
            ViewBag.AppLogData = appLogData;

            return View();
        }

    }
}
