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
        int DiasHospital { get; set; }
        int NumeroCama { get; set; }
        //metodo constructor sin parametros 
        public Hospitalizacion() { }
        //metodo constructor con parametros 
        public Hospitalizacion(
            Mascota laMascota,
            Usuario elVeterinario,
            float elCosto,
            float elCostoInsumo,
            DateTime laFecha,
            int diasH, 
            int numeroCama)
        {
            Mascota = laMascota;
            Veterinario = elVeterinario;
            Costo = elCosto;
            CostoInsumo = elCostoInsumo;
            DiasHospital = diasH;
            NumeroCama = numeroCama;
            Fecha = laFecha;
        }

    }
}
