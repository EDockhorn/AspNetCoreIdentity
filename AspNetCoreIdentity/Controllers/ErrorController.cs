using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentity.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Message = "Ooops! Ocorreu um erro! Tente novamente mais tarde.";
                modelErro.Title = "Ocorreu um erro!";
                modelErro.ErrorCode = id;
            }

            else if (id == 404)
            {
                modelErro.Message =
                    "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com o nosso time de suporte";
                modelErro.Title = "Ops! Página não encontrada";
                modelErro.ErrorCode = id;
            }

            else if (id == 403)
            {
                modelErro.Message = "Você não tem permissão para fazer isto.";
                modelErro.Title = "Acesso negado.";
                modelErro.ErrorCode = id;
            }

            else return StatusCode(404);

            return View("Error", modelErro);
        }
    }
}
