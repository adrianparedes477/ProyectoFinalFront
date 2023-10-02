using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalFront.Datos.Dto
{
    public class TrabajoDto
    {
        public int Id { get; set; }
        public string Fecha { get; set; } // Usamos DateTime? para permitir valores nulos
        public ProyectoDto Proyecto { get; set; }
        public Serviciodto Servicio{ get; set; }
        public int CantHoras { get; set; }
        public decimal ValorHora { get; set; }
        public decimal Costo { get; set; }
    }
}
