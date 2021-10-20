using System;
using System.Collections.Generic;
using System.Text;
using System_Cinema.Interface;
using System.Linq;

namespace System_Cinema.Class
{
    /// <summary>
    /// Clase de los usuarios que van a realizar la transacción de la compra de boletos y dulcería
    /// </summary>
    class Cajero : IUsuario
    {
        public string nombreUsuario { get; set; }
        public string password { get; set; }
        public static List<Cajero> cajeros = new List<Cajero>();
        public Cajero(string nombreUsuario, string password)
        {
            this.nombreUsuario = nombreUsuario;
            this.password = password;
        }

        public static void AgregarCajero(Cajero ca)
        {
            cajeros.Add(ca);
        }

        /// <summary>
        /// Busca un cajero en la lista en base a los parámetros del nómbre de usuario y su contraseña.
        /// </summary>
        /// <param name="nombre">Nombre de usuario en el sistema.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>Verdadero si encuentra por lo menos una coincidencia dentro de la lista cajeros; de otra manera, retorna falso</returns>
        public static bool BuscarCajero(string nombre, string password)
        {
            //Consulta de LINQ en donde busco en la lista de encargado si hay algun registro con el nombre de usuario y el password que me pasaron
            bool resultado = (from c in cajeros where c.nombreUsuario.Equals(nombre) && c.password.Equals(password) select c).Any();
            return resultado;
        }
    }
}
