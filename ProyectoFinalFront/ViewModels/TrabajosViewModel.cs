using ProyectoFinalFront.Datos.Dto;

namespace ProyectoFinalFront.ViewModels
{
    public class TrabajosViewModel
    {
        public int Id { get; set; }
        public string Fecha { get; set; } // Usamos DateTime? para permitir valores nulos
        public ProyectoDto Proyecto { get; set; }
        public Serviciodto Servicio { get; set; }
        public int CantHoras { get; set; }
        public decimal ValorHora { get; set; }
        public decimal Costo { get; set; }

        public static implicit operator TrabajosViewModel(TrabajoDto trabajo)
        {
            var trabajosViewModel = new TrabajosViewModel();
            trabajosViewModel.Id = trabajo.Id;
            trabajosViewModel.Fecha = trabajo.Fecha;
            trabajosViewModel.Proyecto = trabajo.Proyecto;
            trabajosViewModel.Servicio = trabajo.Servicio;
            trabajosViewModel.CantHoras = trabajo.CantHoras;
            trabajosViewModel.ValorHora = trabajo.ValorHora;
            trabajosViewModel.Costo = trabajo.Costo;
            return trabajosViewModel;
        }
    }
}
