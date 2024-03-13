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
            // 1. Lo que me retorna ValidarDatos() lo guardo en algun lugar
            Dictionary<string, string> datosValidos = ValidarDatos();
            
            // 2. Si datosValido es nulo 
            if (datosValidos == null)
            {
                // 2.1 entonces no sigue
                MessageBox.Show("No ingreso ningun dato");
                return;
            }

            // 3. Obtener los datos que ingresan
            string nombre = datosValidos["Nombre"];
            string tipoUsuario = datosValidos["TipoUsuario"];
            string contrasena = datosValidos["Contraseña"];

            // 3.1 Convertir la cadena que obtengo en tipoUsuario en un Enum para poder trabajarlo
            TipoUsuario tipoUsuarioEnum = (TipoUsuario)Enum.Parse(typeof(TipoUsuario), tipoUsuario);
            
            // 4. Creo el nuevo usuario con mis datos 
            Usuario nuevoUsuario = new Usuario(nombre, tipoUsuarioEnum, contrasena);

            // 5. Ese usuario se lo paso a mi metodo agregarUsuario
            instanciaVeterinariaC.agregarUsuario(nuevoUsuario);

            // 6. Mandar un mesaje de que el usuario se registro de forma correcta 
            MessageBox.Show("Usuario registrado de forma correcta");

            // 7. Limpiar los controladores 
            textBox1.Text = "";
            textBox2.Text = "";
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

                           
        private Dictionary<string, string> ValidarDatos()
        {
            // 1. Verificar que texbox1 no sea nulo o sea un string vacio
            if (textBox1.Text == null || textBox1.Text.Trim() == "")
            {
                // 1.1 si texbox1 es nulo entonces me retorna nulo
                return null;
            }

            // 2. Verificar que texbox2 no sea nulo o sea un string vacio
            if (textBox2.Text == null || textBox2.Text.Trim() == "")
            {
                // 2.1 si texbox2 es nulo entonces me retorna nulo
                return null;
            }
            

            // 3. Verificar que el combox1 no este seleccionado el valor por default
            if (comboBox1.SelectedItem == null)
            {
                // 3.1 Si el combox1 esta seleccionado el valor por default entonces retorno nulo
                return null;
            }
            
            // 4. Retorno los datos validados en un diccionario
            Dictionary<string, string> datosValidos = new Dictionary<string, string>();

            // 5. Pasarle los datos
            datosValidos.Add("Nombre", textBox1.Text);
            datosValidos.Add("Contraseña", textBox2.Text);
            datosValidos.Add("TipoUsuario", comboBox1.SelectedItem.ToString());
            
            return datosValidos;
        }

        

    }
}
