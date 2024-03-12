using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.Clases;
using Veterinaria.Enums;

namespace VeterinariaS
{
    public partial class AltaUsuarioForm : Form
    {
        //Definicion de instanciaVeterinariaC
        static VeterinariaC instanciaVeterinariaC;
        
        public AltaUsuarioForm()
        {
            InitializeComponent();
            //Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();
        }

        private void AdministradorForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //0.1 Validar que el textbox 1 no sea nulo
            //0.2 Validar que el textbox 2 no sea nulo
            //0.3 Validar que el comboBox no tenga el valor por defecto
            //1. obtener los datos que ingresan
            string nombre = textBox1.Text;
            string tipoUsuario = comboBox1.SelectedItem.ToString();
            string contrasena = textBox2.Text;

            //1.2 convertir la cadena que obtengo en tipoUsuario en un Enum para poder trabajarlo
            TipoUsuario tipoUsuarioEnum = (TipoUsuario)Enum.Parse(typeof(TipoUsuario), tipoUsuario);
            
            //2. creo el nuevo usuario con mis datos 
            Usuario nuevoUsuario = new Usuario(nombre, tipoUsuarioEnum, contrasena);

            //3. ese usuario se lo paso a mi metodo agregarUsuario
            instanciaVeterinariaC.agregarUsuario(nuevoUsuario);

            //4. Mandar un mesaje de que el usuario se registro de forma correcta 
            MessageBox.Show("Usuario registrado de forma correcta");

            //5. Limpiar los controladores 
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.SelectedItem = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InicioDeSesionForm instanciaFormInicio = new InicioDeSesionForm();
            instanciaFormInicio.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

                           
        private string[] ValidarDatos()
        {
            //normalmente usar else es una mala practica y normalmente
            //todo el codigo que usa else se puede refactorizar/cambiar para que no use el else 

            //1.verificar que texbox1 no sea nulo
            if (textBox1 == null)
            {
                //1.1 si texbox1 no es nulo entonces sigo
                //1.2 si texbox1 es nulo entonces me retorna nulo
                return null;
            }

            //2.verificar que texbox2 no sea nulo
            if (textBox2 == null)
            {
                //2.1 si texbox2 no es nulo entonces sig
                //2.2 si texbox2 es nulo entonces me retorna nulo
                return null;
            }
            
                

            //3.verificar que el combox1 no este seleccionado el valor por default
            if (comboBox1 == null)
            {
                //3.1 si el combox1 no esta seleccionado el valor por default entonces sigo
                //3.2 si el combox1 esta seleccionado el valor por default entonces retorno nulo
                return null;
            }


            //4. retorno los datos validados en una lista de tipo cadena de tamaño 3
            List<string> datosValidos = new List<string>();

            //4.1 Pasarle los datos
            datosValidos.Add(textBox1.Text);
            datosValidos.Add(textBox2.Text);
            datosValidos.Add(comboBox1.SelectedItem.ToString());
             return datosValidos.ToArray();
        }
    }
}
