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
        public float Costo { get; set; }
        public float CostoInsumo { get; set; }
        public Usuario Veterinario { get; set; }
        public Mascota Mascota { get; set; }
        public DateTime Fecha { get; set; }
        //metodo constructor sin parametros
        public Servicio() { }
        //metodo constructor parametros 
        public Servicio(float elCosto, float elCostoInsumo, Usuario elVeterinario, Mascota laMascota, DateTime laFecha)
        {
            Costo = elCosto;
            CostoInsumo = elCostoInsumo;
            Veterinario = elVeterinario;
            Mascota = laMascota;
            Fecha = laFecha;
        }
    }
}
