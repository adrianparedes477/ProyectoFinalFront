using ProyectoFinalFront.Datos.Dto;

namespace ProyectoFinalFront.ViewModels
{
    public class ProyectosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; } // Cambio de enum a string

        public static implicit operator ProyectosViewModel(ProyectoDto proyecto)
        {
            var proyectosViewModel = new ProyectosViewModel();
            proyectosViewModel.Id = proyecto.Id;
            proyectosViewModel.Nombre = proyecto.Nombre;
            proyectosViewModel.Direccion = proyecto.Direccion;
            proyectosViewModel.Estado = proyecto.Estado;
            return proyectosViewModel;
        }
    }
}
