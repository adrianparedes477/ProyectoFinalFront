using Microsoft.AspNetCore.Mvc;
using ProyectoFinalFront.Datos.Dto;

namespace ProyectoFinalFront.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Ingresar(LoginDto login)
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
