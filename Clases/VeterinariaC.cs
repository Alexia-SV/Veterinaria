using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Veterinaria.Clases;
using System.IO;
using System.Drawing;

namespace Veterinaria.Clases
{
    public class VeterinariaC
    {
        // Atributos 
        Consulta[] consultas;
        Hospitalizacion[] hospitalizaciones;
        Mascota[] mascotas;
        Dueno[] duenos;
        public Usuario[] usuarios; 

        // Metodo constructor sin parametros 
        public VeterinariaC() {}

        // Metodo constructor con parametros
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
            // 1. Determinar donde esta guardado el archivo VeterinariaC
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

        // Hoy

        // [x] Necesitamos un método para agregar un usuario a la clase Vet
        // [x] Necesitamos un método que guarde (serialize) Veteriania junto con todos sus atributos
        // [ ] Necesitamos cambiar la visibilidad de los atributos
        // [ ] Necesitamos verificar que se serialize bien todo aunque los attr sean privados
        // [ ] Crear el nuevo formulario y abrirlo desde el inicio de sesión, necesitar recibir el nuevo form la instancia con la que estamos trabajando

        public void agregarUsuario(Usuario usuario)
        {
            // 0.1. Si this.usuarios es nulo, entonces le ponemos un valor
            if (this.usuarios == null)
            {
                // this.usuarios es nulo, por ende va a fallar más adelante
                // por que queremos llamar .Concat sobre un nulo.
                this.usuarios = new Usuario[0];
            }


            // 1. Definiendo nuevoUsuario es de tipo Usuario[] es igual a un
            // nuevo arreglo de tipo Usuario de tamaño 1 el cual contiene el
            // elemento usuario
            Usuario[] nuevoUsuario = new Usuario[1] {usuario};

            // 2. Definiendo combinacionArreglosUsario es de tipo Usuario[]
            // es igual a combinacion de usuarios[] y nuevoUsuario[]
            Usuario[] combinacionArreglosUsuario = this.usuarios.Concat(nuevoUsuario).ToArray();

            // 3. usuarios[] es igual a la combinacionArreglosUsuarios
            usuarios = combinacionArreglosUsuario;

            // 4. Guardo a todo
            this.guardarAtributosVeterinaria();
        }

        /// <summary>
        ///     Cada que modifique algo en esta clase y lo quiera guardar 
        ///     entonces debo de agregar una linea al final del metodo 
        ///     para que se guarde entonces debo agregar
        ///     
        ///     this.guardarAtributosVeterinaria();
        /// </summary>
        private void guardarAtributosVeterinaria()
        {
            // 1. Determinar donde esta guardado el archivo VeterinariaC
            string rutaArchivo = @"VeterinariaC/RegistroVeterinaria.json";

            //2. Serializo el obj this el cual contiene todo lo que contiene Veterianaria y me retorna una cadena
            string conversionJson = JsonConvert.SerializeObject(this);

            //3. Creo el archivo
            File.WriteAllText(rutaArchivo, conversionJson);
        }
    }
}
;