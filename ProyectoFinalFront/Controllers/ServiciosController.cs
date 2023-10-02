using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalFront.Datos.Base;
using ProyectoFinalFront.Datos.Dto;
using ProyectoFinalFront.ViewModels;

namespace ProyectoFinalFront.Controllers
{
    [Authorize]
    public class ServiciosController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public ServiciosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Servicios()
        {
            return View();
        }

        public async Task<IActionResult> ServiciosAddPartial([FromBody] Serviciodto servicio)
        {
            var serviciosViewModel = new ServiciosViewModel();
            if (servicio != null)
            {
                serviciosViewModel = servicio;
            }

            return PartialView("~/Views/Servicios/Partial/ServiciosAddPartial.cshtml", serviciosViewModel);
        }

        public IActionResult GuardarServicio(Serviciodto servicio)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var servicios = baseApi.PostToApi("Servicios", servicio, token);
            return View("~/Views/Servicios/Servicios.cshtml");
        }

        public async Task<IActionResult> EliminarServicio(int id)
        {
            try
            {
                var token = HttpContext.Session.GetString("Token");
                var baseApi = new BaseApi(_httpClient);

                await baseApi.DeleteFromApi("Servicios", id.ToString(), token);
                return Ok(); // Si se eliminó correctamente
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return BadRequest($"Error al eliminar el servicio: {ex.Message}");
            }
        }


    }
}
