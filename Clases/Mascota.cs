using System;
using Veterinaria.Enums;



namespace Veterinaria.Clases 
{
    public class Mascota
    {
        //atributos
        string nombre { get; set; }
        Dueno dueno { get; set; }
        Especie especie { get; set; }
        //metodo constructor sin parametros
        public Mascota() { }
        //metodo constructor parametros 
        public Mascota(string elNombre, Dueno elDueno, Especie laEspecieM)
        {
            nombre = elNombre;
            dueno = elDueno;
            especie = laEspecieM;
        }
    }
}
