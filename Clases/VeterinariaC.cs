using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Veterinaria.Clases;
using System.IO;
using System.Drawing;
using VeterinariaS.Forms;

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
        public VeterinariaC() { }

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
        // [x] Hacer le menu para el tipo de acceso de asistente 

        // Hoy
        // [ ] En el form de Admin hacer la funcion de servicios veterinario 
        // [ ] En el form de Admin hacer la funcion de servicios mascota
        // [ ] En el form de Admin hacer la funcion de ingresos mensuales
        // [ ] En el form de Admin hacer la funcion de ingresos anuales
        // [x] En el form de Alta consulta hacer que el boton calcular costo total funcione 
        // [x] En el form de Alta consulta que funcione la parte de la hospitalizacion 
        // [x] En el form de Alta consulta arreglar la linea 86 que es que se seleccione al veterinario en el evento click
        // [x] En el form de Menu Asistente hacer la funcion de hospitalizacion 
        // [ ] En el form de Hospitalizacion checar si se pueden ordenar por fecha 

        public Servicio[] obtenerServicios()
        {
            //1. obtener las consultas
            if (this.consultas == null)
            {
                this.consultas = new Consulta[0];
            }

            //1.1 Hospitalizaciones
            if (this.hospitalizaciones == null)
            {
                this.hospitalizaciones = new Hospitalizacion[0];
            }

            //1.1 hospitalizaciones 
            //2. conbinarlas en un solo arreglo 
            Servicio[] servicios = this.consultas.Cast<Servicio>().Concat(this.hospitalizaciones.Cast<Servicio>()).ToArray();
            //3. retornarlas 
            return servicios;
        }
        public void agregarConsulta(Consulta consulta)
        {
            if (this.consultas == null)
            {
                this.consultas = new Consulta[0];
            }

            Consulta[] nuevaConsulta = new Consulta[1] { consulta };

            Consulta[] combiArregloConsulta = this.consultas.Concat(nuevaConsulta).ToArray();

            consultas = combiArregloConsulta;

            this.guardarAtributosVeterinaria();
        }

        public void registroHospitalizacion(Hospitalizacion hospitalizacion)
        {
            if(this.hospitalizaciones == null)
            {
                this.hospitalizaciones = new Hospitalizacion[0];
            }
            Hospitalizacion[] nuevaHospitalizacion = new Hospitalizacion[1] { hospitalizacion };

            Hospitalizacion[] combiArregloHospitalizacion = this.hospitalizaciones.Concat(nuevaHospitalizacion).ToArray();

            hospitalizaciones = combiArregloHospitalizacion;

            this.guardarAtributosVeterinaria();
        }



        public void agregarMascota(Mascota mascota)
        {
            if (this.mascotas == null)
            {
                this.mascotas = new Mascota[0];
            }

            Mascota[] nuevaMascota = new Mascota[1] { mascota };
            Mascota[] combiArregloMascota = this.mascotas.Concat(nuevaMascota).ToArray();
            mascotas = combiArregloMascota;

            this.guardarAtributosVeterinaria();
        }

        public void agregarDueno(Dueno dueno)
        {
            if (this.duenos == null)
            {
                this.duenos = new Dueno[0];
            }

            Dueno[] nuevoDueno = new Dueno[1] { dueno };

            Dueno[] combiArregloDueno = this.duenos.Concat(nuevoDueno).ToArray();

            duenos = combiArregloDueno;

            this.guardarAtributosVeterinaria();
        }

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

        public Dueno[] obtenerDuenos()
        {
            return this.duenos;
        }

        public Mascota[] obtenerMascotas()
        {
            return this.mascotas;
        }

        public Consulta[] obtenerConsultas()
        {
            return this.consultas;
        }

        public Hospitalizacion[] obtenerHospitalizaciones()
        {
            return this.hospitalizaciones;
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