using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Clases;

namespace Veterinaria.Clases
{
    public class Hospitalizacion : Servicio
    {
        //atributos 
        float DiasHospital { get; set; }
        string NumeroCama { get; set; }
        //metodo constructor sin parametros 
        public Hospitalizacion() { }
        //metodo constructor con parametros 
        public Hospitalizacion(
            Mascota laMascota,
            Usuario elVeterinario,
            float elCosto,
            float elCostoInsumo,
            DateTime laFecha,
            float diasH, 
            string numeroCama
            )
        {
            Mascota = laMascota;
            Veterinario = elVeterinario;
            Costo = elCosto;
            CostoInsumo = elCostoInsumo;
            DiasHospital = diasH;
            NumeroCama = numeroCama;
            Fecha = laFecha;
            TipoServicio = "Hospitalización";
        }

    }
}
