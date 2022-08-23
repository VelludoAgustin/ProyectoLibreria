import  ArrayLibros  from "./LibrosFetch.js";
import {cardBook}  from "./CardLibro.js";
import {cardModal}  from "./CardModal.js";
import {cardBarraLateral}  from "../BarraLateral/BarraLateral.js";
import {cardFooter} from "../BarraLateral/Footer.js";

window.onload=async()=>{
    document.getElementById("BarraLateral").innerHTML += cardBarraLateral();
    document.getElementById("FooterLibros").innerHTML += cardFooter();

    const libro = await ArrayLibros.Libro(false,"","");
    let aux=libro.lista.map(lib=>cardBook(lib.imagen,lib.titulo,lib.autor,lib.isbn,lib.edicion,lib.editorial,lib.stock)).join('');
    document.getElementById("Listado").innerHTML += aux;

    document.getElementById("FiltarLibros").onclick=async(e)=>{
        e.preventDefault();
        const stock=document.BusquedaLibros.Stock;
        const titulo=document.BusquedaLibros.BuscarTitulo.value;
        const autor=document.BusquedaLibros.BuscarAutor.value;
        if(stock.checked)
        {
            const libros=await ArrayLibros.Libro(true,titulo,autor);
            let refresh=libros.lista.map(lib=>cardBook(lib.imagen,lib.titulo,lib.autor,lib.isbn,lib.edicion,lib.editorial,lib.stock)).join('');
            document.getElementById("Listado").innerHTML = refresh;
        }
        else
        {
            const libros=await ArrayLibros.Libro(false,titulo,autor);
            let refresh=libros.lista.map(lib=>cardBook(lib.imagen,lib.titulo,lib.autor,lib.isbn,lib.edicion,lib.editorial,lib.stock)).join('');
            document.getElementById("Listado").innerHTML = refresh;
        }
    }
}