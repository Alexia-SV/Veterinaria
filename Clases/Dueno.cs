using System;


namespace Veterinaria.Clases
{
    public class Dueno
    {
        //atributos
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        //metodo constructor
        public Dueno() { }
        //metodo constructor parametros 
        public Dueno(string elNombre, string laDireccion, string elTelefono)
        {
            Nombre = elNombre;
            Direccion = laDireccion;
            Telefono = elTelefono;
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}

