using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Clases;

namespace Veterinaria.Clases
{
    public class Veterinaria
    {
        //atributos 
        Consulta[] consultas;
        Hospitalizacion[] hospitalizaciones;
        Mascota[] mascotas;
        Dueno[] duenos;
        Usuario[] usuarios;
        //metodo constructor sin parametros 
        public Veterinaria() { }
        //metodo constructor con parametros 
        public Veterinaria(
            Consulta[] lasConsultas,
            Hospitalizacion[] lasHospitalizaciones,
            Mascota[] lasMascotas,
            Dueno[] losDuenos,
            Usuario[] losUsuarios
        )
        {
            consultas = lasConsultas;
            hospitalizaciones = lasHospitalizaciones;
            mascotas = lasMascotas;
            duenos = losDuenos;
            usuarios = losUsuarios;
        }

    }
}
