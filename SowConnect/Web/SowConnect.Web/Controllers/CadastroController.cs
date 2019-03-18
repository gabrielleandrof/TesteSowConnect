using Microsoft.AspNetCore.Mvc;

namespace SowConnect.Web.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Banco()
        {
            return View();
        }
        public IActionResult Cliente()
        {
            return View();
        }
        public IActionResult ContaTransferencia()
        {
            return View();
        }
    }
}