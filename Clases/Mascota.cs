using System;
using Veterinaria.Enums;



namespace Veterinaria.Clases 
{
    public class Mascota
    {
        //atributos
        public string Nombre { get; set; }
        public Dueno Dueno { get; set; }
        public Especie Especie { get; set; }
        //metodo constructor sin parametros
        public Mascota() { }
        //metodo constructor parametros 
        public Mascota(string elNombre, Dueno elDueno, Especie laEspecieM)
        {
            Nombre = elNombre;
            Dueno = elDueno;
            Especie = laEspecieM;
        }
    }
}
