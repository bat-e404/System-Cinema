using System;
using System.Collections.Generic;
using System.Text;
using System_Cinema.Interface;
using System.Linq;

namespace System_Cinema.Class
{
    /// <summary>
    /// Clase de los usuarios con permisos para cargar peliculas al sistema
    /// </summary>
    class EncargadoPeliculas : IUsuario
    {
        public string nombreUsuario { get; set; }
        public string password { get; set; }
        public static List<EncargadoPeliculas> encargados = new List<EncargadoPeliculas>();

        public EncargadoPeliculas(string nombreUsuario, string password)
        {
            this.nombreUsuario = nombreUsuario;
            this.password = password;
        }

        public static void AgregarEncargado(EncargadoPeliculas ep)
        {
            encargados.Add(ep);
        }

        /// <summary>
        /// Busca un encargado en la lista en base a los parámetros del nómbre de usuario y su contraseña.
        /// </summary>
        /// <param name="nombre">Nombre de usuario en el sistema.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>Verdadero si encuentra por lo menos una coincidencia dentro de la lista encargados; de otra manera, retorna falso</returns>
        public static bool BuscarEncargado(string nombre, string password)
        {
            //Consulta de LINQ en donde busco en la lista de encargado si hay algun registro con el nombre de usuario y el password que me pasaron
            bool resultado = (from e in encargados where e.nombreUsuario.Equals(nombre) && e.password.Equals(password) select e).Any();
            return resultado;
        }
    }
}
