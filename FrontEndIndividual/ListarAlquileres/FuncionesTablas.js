function AbrirAlquileres(){
    document.getElementById("tablaAlquileres").style.display = "table";
    document.getElementById("AbrirAlquileres").style.display = "none";
    document.getElementById("CerrarAlquileres").style.display = "inline-block";
}
function CerrarAlquileres(){
    document.getElementById("tablaAlquileres").style.display = "none";
    document.getElementById("AbrirAlquileres").style.display = "inline-block";
    document.getElementById("CerrarAlquileres").style.display = "none";
}


function AbrirReservas(){
    document.getElementById("tablaReservas").style.display = "table";
    document.getElementById("AbrirReservas").style.display = "none";
    document.getElementById("CerrarReservas").style.display = "inline-block";
}
function CerrarReservas(){
    document.getElementById("tablaReservas").style.display = "none";
    document.getElementById("AbrirReservas").style.display = "inline-block";
    document.getElementById("CerrarReservas").style.display = "none";
}