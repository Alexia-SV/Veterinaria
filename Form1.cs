using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.Clases;
using Veterinaria.Enums;
using System.IO;
using Newtonsoft.Json;

namespace VeterinariaS
{
    public partial class Form1 : Form
    {
        //Definicion de instanciaVeterinariaC
        static VeterinariaC instanciaVeterinariaC;
        
        public Form1()
        {
            InitializeComponent();

            //Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
            string usuario = textBox1.Text;
            string contrasena = textBox2.Text;
            Usuario UsuarioQueInicioSesion = iniciarSesion(usuario, contrasena);

            //2. Si existe determinar que formulario se va a mostrar 
            if (UsuarioQueInicioSesion  != null) 
            {
                //3. Mostrar el formulario
                MessageBox.Show ("Inicio de sesion exitoso");

                return;
            }

            //4. Si no existe, retornar un mensaje
            MessageBox.Show("Datos incorrectos");
            textBox1.Text = " ";
            textBox2.Text = " ";

        }

        private Usuario iniciarSesion(string Nombre, string Contrasena)
        {
            //1.Extraigo toda lista de usuarios de VeterinariaC 
                //1.1. Verificar que la variable donde guarde la instancia de Veterinaria y usuarios no sean nulos
            if (instanciaVeterinariaC.usuarios != null)
            {
                foreach (Usuario usuario in instanciaVeterinariaC.usuarios)
                {
                //2.Por cada usuario dentro de la lista de usuarios debe coincidir el nombre y la contraseña
                //Comparo el nombre y la contraseña que me estan escribiendo con el nombre y la contraseña que ya tengo guardada del usuario
                    if (usuario.Nombre == Nombre && usuario.Contrasena == Contrasena)
                    {
                        //3.Si el nombre y la contraseña coinciden Inicia Sesion
                        MessageBox.Show("Datos correctos");
                        return usuario;
                    }
                }
            }
             
            //5.Si no tengo nada dentro de la lista de usuarios, entonces creo al administrador
            if (instanciaVeterinariaC.usuarios == null || instanciaVeterinariaC.usuarios.Length == 0)
            {
                Usuario admnistrador = new Usuario(Nombre, TipoUsuario.administrador, Contrasena);
                return admnistrador;
            }

            MessageBox.Show("No se encontro ninguna cuenta");
            return null;
        }
    }
}
