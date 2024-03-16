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
using System.Linq.Expressions;
using VeterinariaS.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VeterinariaS
{
    public partial class InicioDeSesionForm : Form
    {
        //Definicion de instanciaVeterinariaC
        VeterinariaC instanciaVeterinariaC;
        
        
        public InicioDeSesionForm()
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
            Dictionary<string, string> datosValidos = ValidarDatos();
            if (datosValidos == null)
            {
                MessageBox.Show("Los datos ingresados fueron incorrectos");
                textBox1.Text = "";
                textBox2.Text = "";

                return;
            }

            //1. Obtengo los datos que ingrese el usuario
            string usuario = textBox1.Text;
            string contrasena = textBox2.Text;
            Usuario UsuarioQueInicioSesion = iniciarSesion(usuario, contrasena);//----> almacena el resultado del metodo

            //2. Si existe determinar que formulario se va a mostrar 
            if (UsuarioQueInicioSesion  != null) 
            {
                //3. Notificar al usuario con un mensaje
                MessageBox.Show("Bienvenido " + UsuarioQueInicioSesion.Nombre);

                //4.Mostrar el form correcto dependiento del tipo de usuario
                switch (UsuarioQueInicioSesion.TipoUsuario)
                {
                    case TipoUsuario.asistente:
                        //Se muestra formAsistente, es un menu con las opciones:
                        //dar de alta mascota, dar de alta propietario, dar de alta consulta, dar de alta hospitalizacion
                        MenuAsistenteForm instanciaFormAsistente = new MenuAsistenteForm();
                        instanciaFormAsistente.Show();
                        this.Hide();

                        break;
                    case TipoUsuario.veterinario:
                        MenuVeterinarioForm instanciaFormVet = new MenuVeterinarioForm();
                        instanciaFormVet.Show();
                        this.Hide();

                        break;
                    case TipoUsuario.administrador:
                        MenuAdministradorForm instanciaFormAdmin = new MenuAdministradorForm();
                        instanciaFormAdmin.Show();
                        this.Hide();
                        break;
                    default:

                        break; 
                }
                return;
            }

            //4. Si no existe, retornar un mensaje
            MessageBox.Show("Datos incorrectos");
            textBox1.Text = " ";
            textBox2.Text = " ";
        }

        //visibilidad  estatico/no estatico   retorna    nombre    propiedades 
        private Usuario iniciarSesion(string Nombre, string Contrasena)
        {
            //1.Extraigo toda lista de usuarios de VeterinariaC 
                //1.1. Verificar que la variable donde guarde la instancia de Veterinaria y usuarios no sean nulos

            if (instanciaVeterinariaC.obtenerUsuarios() != null)
            {
                foreach (Usuario usuario in instanciaVeterinariaC.obtenerUsuarios() )
                {
                //2.Por cada usuario dentro de la lista de usuarios debe coincidir el nombre y la contraseña
                //Comparo el nombre y la contraseña que me estan escribiendo con el nombre y la contraseña que ya tengo guardada del usuario
                    if (usuario.Nombre == Nombre && usuario.Contrasena == Contrasena)
                    {
                        //3.Si el nombre y la contraseña coinciden Inicia Sesion
                        MessageBox.Show("Datos correctos ");
                        return usuario;
                    }
                }
            }
             
            //5.Si no tengo nada dentro de la lista de usuarios, entonces creo al administrador
            if (instanciaVeterinariaC.obtenerUsuarios() == null || instanciaVeterinariaC.obtenerUsuarios().Length == 0)
            {
                Usuario admnistrador = new Usuario(Nombre, TipoUsuario.administrador, Contrasena);
                instanciaVeterinariaC.agregarUsuario(admnistrador);
                
                return admnistrador;
                
            }

            MessageBox.Show("No se encontro ninguna cuenta");
            return null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Validar datos 
        private Dictionary<string, string> ValidarDatos()
        {
            if (textBox1.Text == null || textBox1.Text.Trim() == "")
            {
                return null;
            }

            if (textBox2.Text == null || textBox2.Text.Trim() == "")
            {
                return null;
            }

            //4. retorno los datos validados en un diccionario/tipo lista
            Dictionary<string, string> datosValidos = new Dictionary<string, string>();
            //datosValidos.Add("Dueno", (Dueno)comboBox1.SelectedItem);

            datosValidos.Add("Nombre", textBox1.Text);
            datosValidos.Add("Contrasena", textBox2.Text);

            return datosValidos;

        }
    }
}
