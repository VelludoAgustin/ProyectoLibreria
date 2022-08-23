function ConcretarAlquiler(id){
    ConcretarReserva(id)
}
async function ConcretarReserva(id){
    const config={
        method:'PUT',
        headers:{
            'Content-Type':'application/json'
        }
    }
    try {
        const response=await fetch(`https://localhost:7113/api/alquiler/${id}`,config)
        const result=await response.json()
        window.location.reload();
        return result;
    }    
    catch (error) {
        console.log(error)
    }
}