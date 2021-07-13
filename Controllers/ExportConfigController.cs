using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CustomExports.Data;

namespace CustomExports.Controllers
{
    public class ExportConfigController : Controller
    {
        private readonly CustomExportContext _context;

        public ExportConfigController(CustomExportContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var exportConfigData = await _context.ExportConfigs
                .Join(_context.Clients, e => e.ClientId, c => c.Id, (e, c) =>
                new Models.ExportConfig { ExportType= e.ExportType, Delimiter = e.Delimiter, ClientName = c.Name })
                .ToListAsync();

            ViewBag.ExportConfigData = exportConfigData;

            return View();
        }

    }
}
