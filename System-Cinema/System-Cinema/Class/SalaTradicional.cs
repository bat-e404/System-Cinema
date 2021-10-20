using System;
using System.Collections.Generic;
using System.Text;
using System_Cinema.Interface;

namespace System_Cinema.Class
{
    class SalaTradicional : ISalas
    {
        //Precio de las salas
        public int precioSala { get; set; }
        //Numero de asientos disponibles
        public int asientosDisp { get; set; }
        //Peliculas que se van a exhibir en la sala
        List<Pelicula> peliculas = new List<Pelicula>();


        public SalaTradicional()
        {
            precioSala = 50;
            asientosDisp = 50;
        }

        public void AgregarPelicula(Pelicula pelicula)
        {

        }
    }
}
