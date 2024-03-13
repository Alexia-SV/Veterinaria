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

namespace VeterinariaS
{
    public partial class AltaDuenoForm : Form
    {
        //Definicion de instanciaVeterinariaC
        static VeterinariaC instanciaVeterinariaC;

        public AltaDuenoForm()
        {
            InitializeComponent();
            //Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
                textBox3.Text = "";

                return;
            }

            string Nombre = datosValidos["Nombre"];
            string Direccion = datosValidos["Direccion"];
            string Telefono = datosValidos["Telefono"];

            Dueno nuevoDueno = new Dueno (Nombre, Direccion, Telefono);
            // ese usuario se lo paso a mi metodo agregarUsuario
            instanciaVeterinariaC.agregarDueno(nuevoDueno);

            // Mandar un mesaje de que el usuario se registro de forma correcta 
            MessageBox.Show("Propietario fue registrado correctamente");
            textBox1.Text = "";
            textBox2 .Text = "";
            textBox3 .Text = "";

        }

        //metodo para validar datos 
        private Dictionary<string, string> ValidarDatos()
        {
            if(textBox1.Text == null || textBox1.Text.Trim() == "")
            {
                return null;
            }

            if (textBox2.Text == null || textBox2.Text.Trim() == "" ) 
            { 
                return null; 
            }

            if(textBox3.Text == null || textBox3.Text.Trim() == "")
            {
                return null;
            }

            //retorno un diccionario con los datos 
            Dictionary<string, string> datosValidos = new Dictionary<string, string>();

            //agrego datos al diccionario
            datosValidos.Add("Nombre", textBox1 .Text);
            datosValidos.Add("Direccion", textBox2.Text);
            datosValidos.Add("Telefono", textBox3 .Text);
            
            return datosValidos;
        }
    }
}
