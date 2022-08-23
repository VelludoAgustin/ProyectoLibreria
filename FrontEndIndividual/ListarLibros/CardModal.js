export const cardModal = (imagen,titulo,autor,isbn,edicion,editorial,stock) => {
    return`
        <div class="Modal">
            <img src=${imagen} alt="Libro">  
            <ul> 
                <span class="cardTitulo">${titulo}</span>
                <span class="cardAutor">Autor: ${autor}</span>
                <span class="cardTitulo">${edicion}</span>
                <span class="cardAutor">Autor: ${editorial}</span>
                <span class="cardTitulo">${stock}</span>
                <span class="cardAutor">Autor: ${isbn}</span>
            </ul>            
        </div>`   
    }