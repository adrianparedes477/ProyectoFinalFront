var token = getCookie("Token");
let table = new DataTable('#usuarios', {
    ajax: {
        url: `https://localhost:7284/api/Usuarios?pageNumber=1&pageSize=20`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'id', visible: false },
        { data: 'nombreCompleto', title: 'nombreCompleto' },
        { data: 'dni', title: 'dni' },
        { data: 'tipo', title: 'tipo' },
        { data: 'correo', title: 'correo' },
        {
            data: function (data) {
                var botones =
                    `<td><a href='javascript:EditarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarUsuario"></i></td>` +
                    `<td><a href='javascript:EliminarUsuario(${data.id})'class='eliminarUsuario'><i class="fa-solid fa-trash eliminarUsuario" data-id='${data.id}'></i></td>`
                return botones;
            }
        }

    ]
});

function AgregarUsuario() {
    $.ajax({
        type: "GET",
        url: "/Usuarios/UsuariosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}



function EditarUsuario(data) {
    $.ajax({
        type: "PUT",
        url: "/Usuarios/UsuariosAddPartial",
        data: JSON.stringify(data),
        headers: { "Authorization": "Bearer " + token },
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}

function EliminarUsuario(id) {
    swal({
        title: "¿Está seguro de eliminar el Usuario?",
        text: "Este registro no se podrá recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            debugger
            $.ajax({
                type: "DELETE",  
                url: `https://localhost:7284/api/Usuarios/${id}`, 
                dataType: 'json',
                headers: { "Authorization": "Bearer " + token },
                success: function (resultado) {
                    if (resultado.status === 200) {
                        // La eliminación fue exitosa
                        toastr.success('Usuario eliminado correctamente');
                        
                    } else {
                        // Hubo un error al eliminar
                        toastr.error('Error al eliminar el usuario');
                    }
                },
                error: function () {
                    // Manejo de errores de la solicitud
                    toastr.error('Error en la solicitud');
                }
            });
        }
    });
}
