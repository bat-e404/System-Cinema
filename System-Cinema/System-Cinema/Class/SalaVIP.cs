using System;
using System.Collections.Generic;
using System.Text;

namespace System_Cinema.Class
{
    class SalaVIP
    {
        //Precio de las salas
        public int precioSala { get; set; }
        //Numero de asientos disponibles
        public int asientosDisp { get; set; }
        //Peliculas que se van a exhibir en la sala
        List<Pelicula> peliculas = new List<Pelicula>();


        public SalaVIP()
        {
            precioSala = 100;
            asientosDisp = 20;
        }
    }
}
