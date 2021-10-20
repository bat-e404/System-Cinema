using System;
using System_Cinema.Class;
using System_Cinema.Interface;

namespace System_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            IUsuario cajero = new Cajero("Prueba123", "12345");
            IUsuario encargado = new EncargadoPeliculas("Prueba456", "67890");

            //Agregamos nuestros usuarios a las listas de las clases
            Cajero.AgregarCajero((Cajero)cajero);
            EncargadoPeliculas.AgregarEncargado((EncargadoPeliculas)encargado);
            int user = Login();
            Console.WriteLine("Ha entrado al sistema");

            //Menú del encargado
            if (user == 1)
            {
                Console.WriteLine("Ha ingresado como un encargado");
                Menu.NameHader();
            }
            //Menú del cajero
            else
            {
                Console.WriteLine("Ha ingresado como un cajero");
                Menu.NameHader();
            }

        }

        /// <summary>
        /// Valida las credenciales de inicio de sesión, mediante un nombre de usuario y su contraseña, rectifica si 
        /// el usuario es un encargado o un cajero.
        /// </summary>
        /// <returns>Devuelve 1 si el usuario ingresado es un encargado; 2 en caso contrario de ser un cajero.</returns>
        private static int Login()
        {
            bool busqueda = false;
            string nom, pass; //Variables de inicio de sesión
            do
            {
                Console.Write("\nIngrese su nombre de usuario: ");
                nom = Console.ReadLine();
                Console.Write("\nIngrese su contraseña: ");
                pass = Console.ReadLine();
                //Realizamos una búsqueda dentro de las lsitas del encargado o los cajeros, con que me de un verdadero significa que los datos de login son correctos y búsqueda va a tener "true"
                busqueda = EncargadoPeliculas.BuscarEncargado(nom, pass) || Cajero.BuscarCajero(nom, pass);

                if (!busqueda)
                {
                    Console.WriteLine("Error: contraseña o usuarios inválidos, intente de nuevo");
                }
            } while (!busqueda);
            /*Si sale del do-while, significa que el usuario ingresado si esta dentro de nuestra lista de registros, por lo que solo falta preguntar si es un encargado o un
             * cajero, para esto utilizamos el operador ternario, si buscamos la información de inicio de sesión dentro de nuestra lista de encargados con la función BuscarEncargado y
             * nos devuelve un "True", significa que es un encargado y retornamos un 1,  si nos regresa "False" es por que inicio sesión como un cajero y retornamos 2 en todo caso.
             */
            return (EncargadoPeliculas.BuscarEncargado(nom, pass)) ? 1 : 2;
        }
    }
}
