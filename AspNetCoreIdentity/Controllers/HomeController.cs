using System;
using Microsoft.AspNetCore.Mvc;
using KissLog;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            _logger.Trace("O usuário acessou a Home!");
            
            return View();
        }

        public IActionResult Privacy()
        {
            try
            {
                throw new Exception("Algo deu errado!");
                return View();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
                //return RedirectToAction("Index", "Error", new { id = 500 });
            }

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {

            return View();
        }

        [Authorize(Policy = "PodeTestar")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeAcessar")]
        public IActionResult SecretClaimPodeAcessar()
        {
            return View("Secret");
        }

        public IActionResult ClaimAccess()
        {
            return View();
        }
    }
}
