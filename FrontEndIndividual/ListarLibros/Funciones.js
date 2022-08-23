function MostrarModal(imagen,titulo,autor,isbn,edicion,editorial,stock){
    document.getElementById("ModalLibro").innerHTML = `
    <div class="Modal">
        <img src=${imagen} alt="Libro">  
        <ul> 
            <span class="ModalTitulo">${titulo}</span>
            <span class="ModalAutor">Autor: ${autor}</span>            
            <span class="ModalISBN">ISBN: ${isbn}</span>
            <span class="ModalEdicion">Edición: ${edicion}</span>
            <div class="datosSecundarios">
                <span class="ModalEditorial">Editorial: ${editorial}</span>
                <span class="ModalStock">Stock: ${stock}</span>
            </div>
        </ul>
        <button id="CerrarModal" name="CerrarModal" onclick="OcultarModal()"> 
            <span>
                X
            </span> 
        </button>
        <button id="Reservar" class="BotonesModal" onclick="Reservar(${isbn})"> 
            <span>
                Reservar
            </span> 
        </button>
        <button id="Alquilar" class="BotonesModal" onclick="Alquilar(${isbn})"> 
            <span>
                Alquilar
            </span> 
        </button>            
    </div>`
    document.getElementById("ModalLibro").style.display = "flex";  
}
function OcultarModal(){
    document.getElementById("ModalLibro").style.display = "none";
}