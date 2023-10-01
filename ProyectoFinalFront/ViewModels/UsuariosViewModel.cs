using ProyectoFinalFront.Datos.Dto;

namespace ProyectoFinalFront.ViewModels
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public int Dni { get; set; }
        public string Contrasenia { get; set; }
        public string Tipo { get; set; }

        public string correo { get; set; }

        public static implicit operator UsuariosViewModel(UsuarioDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            usuariosViewModel.Id = usuario.Id;
            usuariosViewModel.NombreCompleto = usuario.NombreCompleto;
            usuariosViewModel.Dni = usuario.Dni;
            usuariosViewModel.Contrasenia = usuario.Contrasenia;
            usuariosViewModel.Tipo = usuario.Tipo;
            usuariosViewModel.correo = usuario.correo;
            return usuariosViewModel;
        }
    }
}
