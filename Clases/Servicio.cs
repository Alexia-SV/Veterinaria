using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Clases;
using Veterinaria.Enums;

namespace Veterinaria.Clases
{
    public class Servicio
    {
        //atributos 
        float Costo { get; set; }
        float CostoInsumo { get; set; }
        TipoUsuario Veterinario { get; set; }
        Mascota Mascota { get; set; }
        DateTime Fecha { get; set; }
        //metodo constructor sin parametros
        public Servicio() { }
        //metodo constructor parametros 
        public Servicio(float elCosto, float elCostoInsumo, TipoUsuario elVeterinario, Mascota laMascota, DateTime laFecha)
        {
            Costo = elCosto;
            CostoInsumo = elCostoInsumo;
            Veterinario = elVeterinario;
            Mascota = laMascota;
            Fecha = laFecha;
        }
    }
}
