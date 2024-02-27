using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Enums;
using System.IO;
using Newtonsoft.Json;

namespace Veterinaria.Clases
{
    public class Usuario
    {
        //atributos 
        string Nombre { get; set; }
        TipoUsuario TipoUsuario { get; set; }
        string Contrasena { get; set; }
        //metodo constructor sin parametros
        public Usuario() { }
        //metodo constructor parametros 
        public Usuario(string elNombre, TipoUsuario elTipoUsuario, string laContrasena)
        {
            Nombre = elNombre;
            TipoUsuario = elTipoUsuario;
            Contrasena = laContrasena;
        }

        //Obtener (deserializando) todos los usuarios que hay en el sistema
        public ObtenerTodos()
        {
            string directorio = @"usuarios";
            //1.Obtener todos los archivos de usuario que existan
            string[] archivos = Directory.GetFiles(directorio);
            //2.Deserializar todos los usuarios que existan 
            foreach (string archivo in archivos) 
            {
                //1.Leer el contenido del archivo
                string contenidoArchivo = File.ReadAllText(archivo);
                //2.Deserializar y crear una nueva instancia de la clase Usuario 
                Usuario usuarioDeserializado = JsonConvert.DeserializeObject<Usuario>(contenidoArchivo);
            }
            
        }


    }


}
