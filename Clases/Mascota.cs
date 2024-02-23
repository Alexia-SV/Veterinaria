using System;
using Veterinaria.Enums;



namespace Veterinaria.Clases 
{
    public class Mascota
    {
        //atributos
        string Nombre { get; set; }
        Dueno Dueno { get; set; }
        Especie Especie { get; set; }
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
