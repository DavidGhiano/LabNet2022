$( document ).ready(() => {
    $("#formulario").submit((e) => {
        e.preventDefault();
        $("#validar-nombre").html("");
        $("#validar-apellido").html("");
        $("#datos").html("");
        var nombre = $("#nombre").val();
        var apellido = $("#apellido").val();
        var fecha = $("#fecha").val();
        var color = $("#color").val().split(",");
        if(nombre != "" && apellido != ""){
            var datos;
            datos = `
            <p><strong>Nombre: </strong> ${nombre}</p>
            <p><strong>Apellido: </strong> ${apellido}</p>`
            if(fecha != ""){
                datos += `
                    <p><strong>Fecha de Nacimiento: </strong> ${fecha}</p>
                    <p><strong>Edad: </strong> ${Edad(fecha)}</p>`;
            }
            if(color != ""){
                datos += `
                    <p><strong>Color: </strong> <span style="color: ${color[0]}" >${color[1]}</span></p>`;
            }
            $("#datos").html(datos);
            $("#formulario").trigger("reset");
        }else if(nombre == "" && apellido != ""){
            $("#validar-nombre").html("campo obligatorio");
        }else if(apellido == "" && nombre != ""){
            $("#validar-apellido").html("campo obligatorio");
        }else{
            $("#validar-nombre").html("campo obligatorio");
            $("#validar-apellido").html("campo obligatorio");
        }
    });
});

function Edad(fecha){
    var hoy = new Date();
    var cumpleanos = new Date(fecha);
    var edad = hoy.getFullYear() - cumpleanos.getFullYear();
    var m = hoy.getMonth() - cumpleanos.getMonth();

    if(m < 0 || (m === 0 && hoy.getDate() < cumpleanos.getDate())){
        edad--;
    }
    return edad;
}