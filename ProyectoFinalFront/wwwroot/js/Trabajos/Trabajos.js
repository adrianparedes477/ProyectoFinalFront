var token = getCookie("Token");
let table = new DataTable('#trabajos', {
    ajax: {
        url: `https://localhost:7284/api/Trabajos?pageNumber=1&pageSize=10`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'ID' },
        { data: 'fecha', title: 'Fecha' },
        { data: 'cantHoras', title: 'Cantidad de Horas' },
        { data: 'proyecto.nombre', title: 'Nombre del Proyecto' }, // Aquí se accede al nombre del proyecto
        { data: 'servicio.descr', title: 'Descripción del Servicio' }, // Similarmente, accediendo a la descripción del servicio
        { data: 'servicio.estado', title: 'Estado del Servicio' }, // Y así sucesivamente
        { data: 'servicio.valorHora', title: 'Valor Hora del Servicio' },
        { data: 'valorHora', title: 'Valor Hora' },
        { data: 'costo', title: 'Costo' },
        {
            data: function (data) {
                var botones =
                    `<td><a href='javascript:EditarTrabajo(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarTrabajo"></i></td>` +
                    `<td><a href='javascript:EliminarTrabajo(${data.id})'class='eliminarTrabajo'><i class="fa-solid fa-trash eliminarTrabajo" data-id='${data.id}'></i></td>`
                return botones;
            }
        }

    ]
});

function AgregarTrabajo() {
    $.ajax({
        type: "GET",
        url: "/Trabajos/TrabajosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#trabajosAddPartial').html(resultado);
            $('#trabajoModal').modal('show');
        }

    });
}



function EditarTrabajo(data) {
    $.ajax({
        type: "PUT",
        url: "/Trabajos/TrabajosAddPartial",
        data: JSON.stringify(data),
        headers: { "Authorization": "Bearer " + token },
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#trabajosAddPartial').html(resultado);
            $('#trabajoModal').modal('show');
        }

    });
}

function EliminarTrabajo(id) {
    swal({
        title: "¿Está seguro de eliminar el Trabajo?",
        text: "Este registro no se podrá recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            debugger
            $.ajax({
                type: "DELETE",  
                url: `https://localhost:7284/api/Trabajos/${id}`, 
                dataType: 'json',
                headers: { "Authorization": "Bearer " + token },
                success: function (resultado) {
                    if (resultado.status === 200) {
                        // La eliminación fue exitosa
                        toastr.success('Trabajo eliminado correctamente');
                        
                    } else {
                        // Hubo un error al eliminar
                        toastr.error('Error al eliminar el trabajo');
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
