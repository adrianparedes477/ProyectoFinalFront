using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalFront.Datos.Base;
using ProyectoFinalFront.Datos.Dto;
using ProyectoFinalFront.ViewModels;

namespace ProyectoFinalFront.Controllers
{
    [Authorize]
    public class ProyectosController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public ProyectosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Proyectos()
        {
            return View();
        }

        public async Task<IActionResult> ProyectosAddPartial([FromBody] ProyectoDto proyecto)
        {
            var proyectosViewModel = new ProyectosViewModel();
            if (proyecto != null)
            {
                proyectosViewModel = proyecto;
            }

            return PartialView("~/Views/Proyectos/Partial/ProyectosAddPartial.cshtml", proyectosViewModel);
        }

        public IActionResult GuardarServicio(ProyectoDto proyecto)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var proyectos = baseApi.PostToApi("Proyecto", proyecto, token);
            return View("~/Views/Proyectos/Proyectos.cshtml");
        }

        public async Task<IActionResult> EliminarProyecto(int id)
        {
            try
            {
                var token = HttpContext.Session.GetString("Token");
                var baseApi = new BaseApi(_httpClient);

                await baseApi.DeleteFromApi("Proyectos", id.ToString(), token);
                return Ok(); // Si se eliminó correctamente
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return BadRequest($"Error al eliminar el proyecto: {ex.Message}");
            }
        }


    }
}
