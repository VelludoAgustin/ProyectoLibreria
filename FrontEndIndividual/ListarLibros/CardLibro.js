export const cardBook = (imagen,titulo,autor,isbn,edicion,editorial,stock) => {
    return`
        <button id="BotonCard" onclick="MostrarModal('${imagen}','${titulo}','${autor}','${isbn}','${edicion}','${editorial}','${stock}')"> 
            <div class="card">            
                <img src=${imagen} alt="Libro">  
                <ul> 
                    <span class="cardTitulo">${titulo}</span>
                    <span class="cardAutor">Autor: ${autor}</span>
                </ul>                       
            </div>
        </button> `   
    }