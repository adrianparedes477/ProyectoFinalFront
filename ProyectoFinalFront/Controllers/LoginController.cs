using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoFinalFront.Datos.Base;
using ProyectoFinalFront.Datos.Dto;

namespace ProyectoFinalFront.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public LoginController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Ingresar(LoginDto login)
        {
            var baseApi = new BaseApi(_httpClient);
            var token = await baseApi.PostToApi("Login", login);
            var resultadoLogin = token as OkObjectResult;
            var resultadoObjeto = JsonConvert.DeserializeObject<Models.Login>(resultadoLogin.Value.ToString());
            ViewBag.Nombre = resultadoObjeto.NombreCompleto;
            return View("~/Views/Home/Index.cshtml", resultadoObjeto);
        }


    }
}
