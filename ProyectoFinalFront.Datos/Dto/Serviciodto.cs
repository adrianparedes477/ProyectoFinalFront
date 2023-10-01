using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalFront.Datos.Dto
{
    public class Serviciodto
    {
        public int Id { get; set; }
        
        public string Descr { get; set; }
       
        public bool Estado { get; set; }
        
        public decimal ValorHora { get; set; }
    }
}
