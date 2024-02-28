using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Veterinaria.Clases;
using System.IO;

namespace Veterinaria.Clases
{
    public class VeterinariaC
    {
        //atributos 
        Consulta[] consultas;
        Hospitalizacion[] hospitalizaciones;
        Mascota[] mascotas;
        Dueno[] duenos;
        public Usuario[] usuarios;
        //metodo constructor sin parametros 
        public VeterinariaC() { }
        //metodo constructor con parametros 
        public VeterinariaC(
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

        public static VeterinariaC obtenerVeterinaria()
        {
            //1. Determinar donde esta guardado el archivo VeterinariaC
            string rutaArchivo = @"VeterinariaC/RegistroVeterinaria.json";
            
            try
            {
                //2. Obtener el archivo serializado
                string contenido = File.ReadAllText(rutaArchivo);

                //3. Deserilizar el archivo y lo retorno 
                VeterinariaC deserializacionContenido = JsonConvert.DeserializeObject<VeterinariaC>(contenido);
                return deserializacionContenido;

            }
            catch (IOException e)
            {
                //2. Creo un nueva instancia del obj/Clase VeterinariaC
                VeterinariaC instanciaVeterinariaC = new VeterinariaC();

                //3. Serializo el obj instanciaVeterinariaC y me retorna una cadena
                string conversionJson = JsonConvert.SerializeObject(instanciaVeterinariaC);

                //4. Creo el archivo
                File.WriteAllText(rutaArchivo, conversionJson);

                //5. Retorno una la instancia que ya cree de VeterinariaC
                return instanciaVeterinariaC;
            }                 
        }

        //serializar el obj, crear el archivo, necesito una instancia que ya exista que ya es la instancia que tengo
        //en el programa 
    }
}
