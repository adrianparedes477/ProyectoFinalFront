var token = getCookie("Token");
let table = new DataTable('#proyectos', {
    ajax: {
        url: `https://localhost:7284/api/Proyectos?pageNumber=1&pageSize=10`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'id', visible: false },
        { data: 'nombre', title: 'nombre' },
        { data: 'direccion', title: 'direccion' },
        { data: 'estado', title: 'estado' },
        {
            data: function (data) {
                var botones =
                    `<td><a href='javascript:EditarProyecto(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarProyecto"></i></td>` +
                    `<td><a href='javascript:EliminarProyecto(${data.id})'class='eliminarProyecto'><i class="fa-solid fa-trash eliminarProyecto" data-id='${data.id}'></i></td>`
                return botones;
            }
        }

    ]
});

function AgregarProyecto() {
    $.ajax({
        type: "GET",
        url: "/Proyectos/ProyectosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#proyectosAddPartial').html(resultado);
            $('#proyectoModal').modal('show');
        }

    });
}



function EditarProyecto(data) {
    $.ajax({
        type: "PUT",
        url: "/Proyectos/ProyectosAddPartial",
        data: JSON.stringify(data),
        headers: { "Authorization": "Bearer " + token },
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#proyectosAddPartial').html(resultado);
            $('#proyectoModal').modal('show');
        }

    });
}

function EliminarProyecto(id) {
    swal({
        title: "¿Está seguro de eliminar el Proyecto?",
        text: "Este registro no se podrá recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            debugger
            $.ajax({
                type: "DELETE",  
                url: `https://localhost:7284/api/Proyectos/${id}`, 
                dataType: 'json',
                headers: { "Authorization": "Bearer " + token },
                success: function (resultado) {
                    if (resultado.status === 200) {
                        // La eliminación fue exitosa
                        toastr.success('Proyectos eliminado correctamente');
                        
                    } else {
                        // Hubo un error al eliminar
                        toastr.error('Error al eliminar el proyecto');
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
