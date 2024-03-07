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
        public string Nombre { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Contrasena { get; set; }
        //metodo constructor sin parametros
        public Usuario() { }
        //metodo constructor parametros 
        public Usuario(string elNombre, TipoUsuario elTipoUsuario, string laContrasena)
        {
            Nombre = elNombre;
            TipoUsuario = elTipoUsuario;
            Contrasena = laContrasena;
        }
    }


}
