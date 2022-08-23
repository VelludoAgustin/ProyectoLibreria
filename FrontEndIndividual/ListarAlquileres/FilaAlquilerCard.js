export const CardAlq=(ISBN,titulo,autor,edicion,editorial,fechaAlquiler,fechaDevolucion)=>{
    return`
        <tr>
            <td>${ISBN}</td>
            <td>${titulo}</td>
            <td>${autor}</td>
            <td>${editorial}</td>
            <td>${edicion}</td>
            <td>${fechaAlquiler}</td>
            <td>${fechaDevolucion}</td>
        </tr>
    `
}