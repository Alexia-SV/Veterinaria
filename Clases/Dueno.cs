using System;


namespace Veterinaria.Clases
{
    public class Dueno
    {
        //atributos
        string Nombre { get; set; }
        string Direccion { get; set; }
        string Telefono { get; set; }
        //metodo constructor
        public Dueno() { }
        //metodo constructor parametros 
        public Dueno(string elNombre, string laDireccion, string elTelefono)
        {
            Nombre = elNombre;
            Direccion = laDireccion;
            Telefono = elTelefono;
        }
    }
}

