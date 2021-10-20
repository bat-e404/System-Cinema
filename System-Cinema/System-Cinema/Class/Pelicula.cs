using System;
using System.Collections.Generic;
using System.Text;

namespace System_Cinema.Class
{
    class Pelicula
    {
        private string nombre { get; set; }
        private int duracion { get; set; }
        private string horaInicio { get; set; }

        public Pelicula(string nombre, int duracion, string horaInicio)
        {
            this.nombre = nombre;
            this.duracion = duracion;
            this.horaInicio = horaInicio;
        }

    }
}
