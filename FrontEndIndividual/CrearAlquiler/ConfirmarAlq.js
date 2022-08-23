function Reservar(isbnParam) {
    const fecha=new Date();
    const DTOReserva={
        cliente:"1",
        isbn:isbnParam.toString(),
        fechaAlquiler:null,
        fechaReserva: fecha.toJSON()
    }
    CrearAlquiler(DTOReserva)
}
function Alquilar(isbnParam) {
    const fecha=new Date();
    const DTOAlquiler={
        cliente:"1",
        isbn:isbnParam.toString(),
        fechaAlquiler: fecha.toJSON(),
        fechaReserva: null
    }
    CrearAlquiler(DTOAlquiler)
}
const url=`https://localhost:7113/api/alquiler`;
async function CrearAlquiler(cuerpo){
    const config={
        method:'POST',
        headers:{
            'Content-Type':'application/json'
        },
        body:JSON.stringify(cuerpo)
    }
    try {
        const response=await fetch(url,config)
        const result=await response.json()
        window.location.reload();
        return result;
    }    
    catch (error) {
        console.log(error)
    }
}