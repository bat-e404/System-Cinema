using System;
using System.Collections.Generic;
using System.Text;
using System_Cinema.Interface;
using System_Cinema.Class;

namespace System_Cinema.Class 
{
    class SalaVIP : ISalas
    {
        //Precio de las salas
        public int precioSala { get; set; }
        //Peliculas que se van a exhibir en la sala
        List<Pelicula> peliculas = new List<Pelicula>();


        public SalaVIP()
        {
            precioSala = 100;
        }

        /// <summary>
        /// Verifica que el horario de la película no colisione con alguna otra
        /// película dentro de la sala a la que voy a agregar.
        /// </summary>
        /// <param name="pelicula">Objeto Pelicula la cual voy a meter a la sala.</param>
        /// <returns>True si la película puede ser agregada a la sala; falso </returns>
        public bool AgregarPelicula(Pelicula pelicula)
        {
            //Variable para saber si hay alguna colisión con el horario de otra pelicula
            bool colision = true;
            //La horaFin1 es para la hora de finalización de la pelicula que voy a ingresar, la segunda es para la pelicula que ya esta dentro del sistema
            string horaFin1 = CalcularHoraFin(pelicula), horaFin2;
            //En estos arrays voy a tener las horas y minutos de finalización e inicio de la pelicula a meter
            string[] hInicio1 = pelicula.horaInicio.Split(':');
            string[] hFin1 = horaFin1.Split(':');

            //Por último, voy a convertir a concatenar las horas y los minutos de inicio y fin de la película y convertirlas a cantidades númericas para la validación.
            int I1 = int.Parse(hInicio1[0] + hInicio1[1]);
            int F1 = int.Parse(hFin1[0] + hFin1[1]);

            //Foreach para comparar los horarios de todas las películas.
            foreach (Pelicula peli in peliculas)
            {
                //Obtenemos la hora de finalización de la pelicula ya agregada en la lista
                string[] hInicio2 = peli.horaInicio.Split(':');
                horaFin2 = CalcularHoraFin(peli);
                string[] hFin2 = horaFin2.Split(':');

                //Hacemos el mismo proceso para obtener una cantidad númerica através de la hora y minutos de inicio y fin de la película
                int I2 = int.Parse(hInicio2[0] + hInicio2[1]);
                int F2 = int.Parse(hFin2[0] + hInicio2[1]);

                /*If para validar que la hora de inicio no se encuentre dentro de una hora de inicio o una hora de fin de alguna pelicula:
                 * Me voy a basar en I1 y F1 (hora y fin de la pelicula a ingresar a la sala), van a tener alguna cantidad númerica como 800 (8:00) o 1130 (11:30)
                    al igual que I2 y F2, primero tengo que comprobar que la hora de inicio de la pelicula que voy a meter NO este dentro del rango de la película que esta
                    ya agregada en la sala. EJ: Yo tengo una pelicula ya agregada que inica a las 9:15 y termina a las 10:45, I2 va a tener 915 y F2 va a tener el valor de 1045,
                    si yo agrego una pelicula que empieza a las 9:30 en esa sala I1 va a tener un valor de 930, obviamente va a haber una colisión en el horario de esa sala, por lo
                    que hago una validación preguntando si I1 esta dentro de I2 y F2, en este caso 915<=930<=1045, como en este caso, se cumple, voy a cambiar la variable colision
                    como false.
                 */
                if (I2 <= I1 && I1 <= F2)
                {
                    colision = false;
                }
                //De igual manera, voy a validar el mismo rango pero con la hora de finalización a la pelicula para registrar
                if (I2 <= F1 && F1 <= F2)
                {
                    colision = false;
                }
            }
            //Si el horario de la pelicula que voy a meter, no colisona con ningún horario de las peliculas que ya estan dentro de la sala, entonces colisiones permanecerá con true
            //pero con que colisone con un solo horario tendrá false, el resultado lo regreso.
            return colision;
        }

        /// <summary>
        /// Calcula la hora a la que se acaba una película.
        /// </summary>
        /// <param name="peli">Objeto Pelicula con el cuál con la cual se va a calcular su hora de finalización.</param>
        /// <returns>Un string en formato XX:XX con la hora en la que se acaba la película.</returns>
        private static string CalcularHoraFin(Pelicula peli)
        {
            //Variables para guardar la hora y fin de la pelicula, también un acarreo por si la suma de los minutos llega a una hora
            int horaFin, minFin, acarreo = 0;
            //Se espera que al dividir la string de pelicula por el separador ':' me de un array de 2 string, una con la hora y la otra con los minutos
            string[] horaInicio = peli.horaInicio.Split(':');
            //Convertimos a entero los dos elementos del arreglo de horaInicio con la hora y minutos
            int hora = int.Parse(horaInicio[0]);
            int minutos = int.Parse(horaInicio[1]);
            int duraMinutos = peli.duracion / 60; //Conversión de segundos a minutos
            int duraHora = duraMinutos / 60; //Conversión de los minutos de duración a horas

            //duraMinutos hasta ahora tiene toda la duración total de la pelicula, ahora vamos a restar las horas totales x 60 minutos para restar todas las horas
            //asi ya tenemos el formato de horas y minutos totales de la pelicula separados
            duraMinutos = duraMinutos - (duraHora * 60);

            //Calculamos los minutos que va a abarcar la pelicula, si la suma de minutos de duración mas los minutos de cuándo inicia la pelicula rebasan los 60 minutos
            //entonces haremos una operación para que se haga el acarreo de una hora, si no es asi, simplemente sumamos tal cual los minutos.
            if (minutos + duraMinutos >= 60)
            {
                minFin = minutos + duraMinutos - 60;
                acarreo = 1;
            }
            else
            {
                minFin = minutos + duraMinutos;
            }

            //Sumamos las hora de inicio con la duración en horas con el acarreo de horas (si es que hay)
            horaFin = hora + duraHora + acarreo;

            //Concatenamos la hora de finalización y los min para finalizar la película para obtener la hora a la que se termina y la retornamos
            string horaFinalizacion = horaFin.ToString() + ":" + minFin.ToString();
            return horaFinalizacion;

        }
    }
}
