﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalFront.Datos.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public int Dni { get; set; }
        public string Contrasenia { get; set; }
        public string Tipo { get; set; }

        public string correo { get; set; }
    }
}
