import {cardBarraLateral}  from "../BarraLateral/BarraLateral.js";
import {CardAlq}  from "./FilaAlquilerCard.js";
import {CardRes}  from "./FilaReservaCard.js";
import AlqYRes from "./AlqYResFetch.js";
import {cardFooter} from "../BarraLateral/Footer.js";

window.onload=async()=>{
    document.getElementById("BarraLateralAlquileres").innerHTML += cardBarraLateral();
    document.getElementById("FooterAlquileres").innerHTML += cardFooter();

    const Respuesta = await AlqYRes.TraerAlqYRes(1);
    const Res = Respuesta.lista[0].map(res=>CardRes(res.idAlquiler,res.isbn,res.titulo,res.autor,res.edicion,res.editorial,res.fechaReserva)).join('');
    document.getElementById("tablaReservas").innerHTML+=Res;

    const Alq = Respuesta.lista[1].map(alq=>CardAlq(alq.isbn,alq.titulo,alq.autor,alq.edicion,alq.editorial,alq.fechaAlquiler,alq.fechaDevolucion)).join('');
    document.getElementById("tablaAlquileres").innerHTML+=Alq;
}