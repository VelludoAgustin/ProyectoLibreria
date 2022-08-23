const AlqYRes = {}
AlqYRes.TraerAlqYRes=async(id)=>{
    const config={
        method:'GET',
        headers :{
            accept:'application/json'
        }
    };
    try{
        const respuesta = await fetch(`https://localhost:7113/api/alquiler/cliente/${id}`,config);
        const finalizado= await respuesta.json();
        return finalizado;
    }
    catch(error){
        console.log(error);
    }
}
export default AlqYRes;