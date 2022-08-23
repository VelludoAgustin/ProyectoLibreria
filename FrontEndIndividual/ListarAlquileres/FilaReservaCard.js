export const CardRes=(id,ISBN,titulo,autor,edicion,editorial,fechaReserva)=>{
    return`
        <tr>
            <td>${ISBN}</td>
            <td>${titulo}</td>
            <td>${autor}</td>
            <td>${editorial}</td>
            <td>${edicion}</td>
            <td>${fechaReserva}</td>
            <td><button class="botonConcretar" onclick="ConcretarAlquiler(${id})">Concretar</button></td>
        </tr>
    `
}