using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalFront.Datos.Base;
using ProyectoFinalFront.Datos.Dto;
using ProyectoFinalFront.ViewModels;

namespace ProyectoFinalFront.Controllers
{
    [Authorize]
    public class TrabajosController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public TrabajosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Trabajos()
        {
            return View();
        }

        public async Task<IActionResult> TrabajosAddPartial([FromBody] TrabajoDto trabajo)
        {
            var trabajosViewModel = new TrabajosViewModel();
            if (trabajo != null)
            {
                trabajosViewModel = trabajo;
            }

            return PartialView("~/Views/Trabajos/Partial/TrabajosAddPartial.cshtml", trabajosViewModel);
        }

        public IActionResult GuardarTrabajo(TrabajoDto trabajo)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var trabajos = baseApi.PostToApi("Trabajos", trabajo, token);
            return View("~/Views/Trabajos/Trabajos.cshtml");
        }

        public async Task<IActionResult> EliminarTrabajo(int id)
        {
            try
            {
                var token = HttpContext.Session.GetString("Token");
                var baseApi = new BaseApi(_httpClient);

                await baseApi.DeleteFromApi("Trabajos", id.ToString(), token);
                return Ok(); // Si se eliminó correctamente
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return BadRequest($"Error al eliminar el trabajo: {ex.Message}");
            }
        }


    }
}
