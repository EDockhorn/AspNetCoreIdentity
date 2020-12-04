using KissLog;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentity.Controllers
{
    public class TesteController : Controller
    {
        private readonly ILogger _logger;

        public TesteController(ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.Debug(".: This is a test from KissLog implementation Debug log.: ");
            _logger.Critical(".: This is a test from KissLog implementation Critical log.: ");

            return View();
        }
    }
}
