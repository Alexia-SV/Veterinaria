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
    public partial class AltaDueno : Form
    {
        public AltaDueno()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AltaDueno_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. Obtener Nombre del label 1
            string nombre = textBox1.Text;
            //2. Obetener Direccion del label 2
            string direccion = textBox2.Text;
            //3. Obtener Telefono del label 3
            string telefono = textBox3.Text;
            //4. Crear una instancia de la clase, pasarle el nombre, la direccion, el telefono
             Dueno dueno = new Dueno( nombre, direccion, telefono);
             
        }
    }
}
