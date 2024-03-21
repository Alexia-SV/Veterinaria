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
         public string Diagnostico { get; set; }
         public string Tratamiento { get; set; }
         public bool Hospitalizacion { get; set; }
        //metodo constructor sin parametros
        public Consulta() { }
        //metodo constructor
        public Consulta(
            Mascota laMascota,
            Usuario elVeterinario,
            string elDiagnostico, 
            string elTratamiento, 
            bool laHospitalizacion, 
            float elCosto, 
            float elCostoInsumo, 
            DateTime laFecha
            )
        {
            Mascota = laMascota;
            Veterinario = elVeterinario;
            Diagnostico = elDiagnostico;
            Tratamiento = elTratamiento;
            Hospitalizacion = laHospitalizacion;
            Costo = elCosto;
            CostoInsumo = elCostoInsumo;
            Fecha = laFecha;
            TipoServicio = "Consulta";
        }
    }
}

