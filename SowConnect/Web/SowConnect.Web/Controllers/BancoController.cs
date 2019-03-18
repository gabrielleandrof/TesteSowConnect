using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SowConnect.Web.Controllers
{
    public class BancoController : Controller
    {
        public IActionResult Banco()
        {
            return View();
        }
    }
}