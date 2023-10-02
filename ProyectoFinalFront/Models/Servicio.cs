using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalFront.Models
{
    public class Servicio 
    {
        [Column("codServicio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "La Descripcion es Requerido")]
        [MaxLength(60, ErrorMessage = "La Descripcion debe tener un maximo de 60 caracteres")]
        public string Descr { get; set; }
        [Required(ErrorMessage = "El Estado es Requerido")]
        [MaxLength(100, ErrorMessage = "El Estado debe tener un maximo de 100 caracteres")]
        public bool Estado { get; set; }
        [Required(ErrorMessage = "El ValorHora es Requerido")]
        [MaxLength(60, ErrorMessage = "El ValorHora debe tener un maximo de 60 caracteres")]
        public decimal ValorHora { get; set; }

        
    }
}
