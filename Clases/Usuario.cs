using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Enums;

namespace Veterinaria.Clases
{
    public class Usuarion
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
    }
}
