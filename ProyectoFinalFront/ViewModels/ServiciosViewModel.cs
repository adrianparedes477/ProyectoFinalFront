using ProyectoFinalFront.Datos.Dto;

namespace ProyectoFinalFront.ViewModels
{
    public class ServiciosViewModel
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public bool Estado { get; set; }
        public decimal ValorHora { get; set; }

        public static implicit operator ServiciosViewModel(Serviciodto servicio)
        {
            var serviciosViewModel = new ServiciosViewModel();
            serviciosViewModel.Id = servicio.Id;
            serviciosViewModel.Descr = servicio.Descr;
            serviciosViewModel.Estado = servicio.Estado;
            serviciosViewModel.ValorHora = servicio.ValorHora;
            return serviciosViewModel;
        }
    }
}
