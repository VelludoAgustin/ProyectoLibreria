export const cardBarraLateral = () => {
    return`
    <div class="LogoPrincipal">
        <img class="imagenLOGO" src="../Imagenes/LogoPrincipal.png" alt="imagenLOGO">
    </div>
    <nav class="OpcionesBarraLateral">
        <ul class="Opcion">
            <hr>
            <li>                        
                <a href="../ListarAlquileres/ListarAlquileres.html">
                    <img class="IconoTipo1" src="../Imagenes/AppConsultarAlquiler.png" alt=" Logo listar Alquileres">
                    <span>
                        LISTAR LOS ALQUILERES
                    </span>
                </a>
            </li>
            <li>                        
                <a href="../ListarLibros/ListarLibros.html">
                    <img class="IconoTipo2" src="../Imagenes/AppsListarLibros.png" alt="Logo Lista de Libros">
                    <span>
                        LISTAR LIBROS DISPONIBLES
                    </span>
                </a>
            </li>
            <li>                        
                <a>
                    <img class="IconoTipo2" src="../Imagenes/Envios.png" alt="Logo Lista de Libros">
                    <span>
                        ENVÍOS
                    </span>
                </a>
            </li>
            <li>                        
                <a>
                    <img class="IconoTipo2" src="../Imagenes/Locales.png" alt="Logo Lista de Libros">
                    <span>
                        LOCALES
                    </span>
                </a>
            </li>
            <li>                        
                <a>
                    <img class="IconoTipo3" src="../Imagenes/Usuario.png" alt="Logo Lista de Libros">
                    <span>
                        CUENTA
                    </span>
                </a>
            </li>
            <li class="Config">                        
                <a>
                    <img class="IconoTipo2" src="../Imagenes/Ajustes.png" alt="Logo Lista de Libros">
                    <span>
                        CONFIGURACIÓN
                    </span>
                </a>
            </li>
        </ul>
    </nav>`   
}