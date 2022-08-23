const ArrayLibros = {}

ArrayLibros.Libro=async(stock,titulo,autor)=>{
    const config={
        method : 'GET',
        headers :{
        accept:'application/json'}
    };
    try {
        const respuesta = await fetch(`https://localhost:7113/api/libros?stock=${stock}&titulo=${titulo}&autor=${autor}`,config);
        const finalizado= await respuesta.json();
        return finalizado;
    } catch (error) {
        console.log(error);
    }
}
export default ArrayLibros;