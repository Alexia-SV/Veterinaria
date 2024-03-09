using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Clases;
using Veterinaria.Enums;

namespace Veterinaria.Clases
{
    public class Consulta : Servicio
    {
        //atributos 
        string Diagnostico { get; set; }
        string Tratamiento { get; set; }
        bool AltaConsulta { get; set; }
        //metodo constructor sin parametros
        public Consulta() { }
        //metodo constructor
        public Consulta(string elDiagnostico, string elTratamiento, bool laAltaConsulta)
        {
            Diagnostico = elDiagnostico;
            Tratamiento = elTratamiento;
            AltaConsulta = laAltaConsulta;
            
        }
    }
}

