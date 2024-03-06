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
        [JsonProperty]//--->se usa para guardar atributos que son de visibilidad privada
        Consulta[] consultas;

        [JsonProperty]
        Hospitalizacion[] hospitalizaciones;

        [JsonProperty]
        Mascota[] mascotas;
        
        [JsonProperty]
        Dueno[] duenos;
        
        [JsonProperty]
        Usuario[] usuarios;

        static string rutaArchivo = @"VeterinariaC/RegistroVeterinaria.json";
        
        

        // Estatica (no necesito que la clase este instanciada)
        //      new VeterinariaC() <--- Esto no es necesario
        //      VeterinariaC.obtenerVeterinaria() <--- Así mandamos a llamar un métodó est.
        //      VeterianariaC.atributo <--- Así mandamos a llamar un attr.
        //
        // Instancia (necesito tener una instancia)
        //      var instanciaC = new VeterinariaC() <-- Esto es necesario
        //      instanciaC.miMetodo()
        //      instanciaC.miAtributo

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
            try
            {
                //2. Obtener el archivo serializado
                string contenido = File.ReadAllText(VeterinariaC.rutaArchivo);

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
        // [x] Necesitamos cambiar la visibilidad de los atributos
        // [x] Necesitamos verificar que se serialize bien todo aunque los attr sean privados
        // [x] Crear el nuevo formulario y abrirlo desde el inicio de sesión, necesitar
        // recibir el nuevo form la instancia con la que estamos trabajando ----> solo le paso las primeras lines del form1
        // [x] Mostrar el formulario correcto dependiendo del tipo de usuario ---> se hace un switch
        // [ ] En la clase usuario hacer el metodo para que se calcule los ingresos
        // [x] Arreglar el formulario que se le va a mostrar al admin
        // [x] En el form de administrador necesito que agregue un usuario ---> instancia de agregar usuario
        // y que cuando se cree un veterinario o un asistente el tipo de usuario debe de cambiar segun le corresponda
        // [ ] Hacer un metodo para que lo que tengo en evento clic del boton sea entendible
        // [ ] Revisar el codigo de Roger y subir el codigo de Roger a github y ver porque no puede subir sus cambios a gitbuh
        // 

        public void agregarUsuario(Usuario usuario)
        {
            // 0.1. Si this.usuarios es nulo, entonces le ponemos un valor
            if (this.usuarios == null)
            {
                // this.usuarios es nulo, por ende va a fallar más adelante
                // por que queremos llamar .Concat sobre un nulo.
                this.usuarios = new Usuario[0];
            }//acumulador-nota care
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

        public Usuario[] obtenerUsuarios() 
        {
            return this.usuarios; 
            //Clase.atributo
            //this.atributo
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

            //1. Serializo el obj this el cual contiene todo lo que contiene Veterianaria y me retorna una cadena
            string conversionJson = JsonConvert.SerializeObject(this);

            //2. Creo el archivo
            File.WriteAllText(VeterinariaC.rutaArchivo, conversionJson);
        }
    }

}
;