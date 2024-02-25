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

namespace VeterinariaS
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            //1. Buscar usuario y contraseña 
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
        }

        private Usuario iniciarSesion(string Nombre, string Contrasena)
        {
            //1. comprar el usuario con "Administrador"
            //2. comparar la contraseña con "Administrador"
            if (Nombre == "Administrador" && Contrasena == "Administrador") 
            {
                //3. si ambos son igual entonces retornar un usuario
                return new Usuario(Nombre, TipoUsuario.administrador, Contrasena);
            }

            //3. si no se returna null 
            return null;          
        }
    }
}
