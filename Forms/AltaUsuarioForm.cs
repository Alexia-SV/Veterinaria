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
    }
}
