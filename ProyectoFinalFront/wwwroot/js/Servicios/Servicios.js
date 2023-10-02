var token = getCookie("Token");
let table = new DataTable('#servicios', {
    ajax: {
        url: `https://localhost:7284/api/Servicios?pageNumber=1&pageSize=10`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'id', visible: false },
        { data: 'descr', title: 'descr' },
        { data: 'estado', title: 'estado' },
        { data: 'valorHora', title: 'valorHora' },
        {
            data: function (data) {
                var botones =
                    `<td><a href='javascript:EditarServicio(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarServicio"></i></td>` +
                    `<td><a href='javascript:EliminarServicio(${data.id})'class='eliminarServicio'><i class="fa-solid fa-trash eliminarServicio" data-id='${data.id}'></i></td>`
                return botones;
            }
        }

    ]
});

function AgregarServicio() {
    $.ajax({
        type: "GET",
        url: "/Servicios/ServiciosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#serviciosAddPartial').html(resultado);
            $('#servicioModal').modal('show');
        }

    });
}



function EditarServicio(data) {
    $.ajax({
        type: "PUT",
        url: "/Servicios/ServicioAddPartial",
        data: JSON.stringify(data),
        headers: { "Authorization": "Bearer " + token },
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#servicioAddPartial').html(resultado);
            $('#servicioModal').modal('show');
        }

    });
}

function EliminarServicio(id) {
    swal({
        title: "¿Está seguro de eliminar el Servicio?",
        text: "Este registro no se podrá recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            debugger
            $.ajax({
                type: "DELETE",  
                url: `https://localhost:7284/api/Servicios/${id}`, 
                dataType: 'json',
                headers: { "Authorization": "Bearer " + token },
                success: function (resultado) {
                    if (resultado.status === 200) {
                        // La eliminación fue exitosa
                        toastr.success('Servicio eliminado correctamente');
                        
                    } else {
                        // Hubo un error al eliminar
                        toastr.error('Error al eliminar el servicio');
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
