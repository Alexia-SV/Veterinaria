using System;


namespace Veterinaria.Clases
{
    public class Dueno
    {
        //atributos
        string nombre { get; set; }
        string direccion { get; set; }
        string telefono { get; set; }
        //metodo constructor
        public Dueno() { }
        //metodo constructor parametros 
        public Dueno(string elNombre, string laDireccion, string elTelefono)
        {
            nombre = elNombre;
            direccion = laDireccion;
            telefono = elTelefono;
        }
    }
}

