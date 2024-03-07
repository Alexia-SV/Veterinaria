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
            string Nombre = textBox1.Text;
            string Direccion = textBox2.Text;
            string Telefono = textBox3.Text;

            Dueno nuevoDueno = new Dueno (Nombre, Direccion, Telefono);
            //3. ese usuario se lo paso a mi metodo agregarUsuario
            instanciaVeterinariaC.agregarDueno(nuevoDueno);

            //4. Mandar un mesaje de que el usuario se registro de forma correcta 
            MessageBox.Show("Propietario fue registrado correctamente");
        }
    }
}
