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
    public partial class AltaMascota : Form
    {
        public AltaMascota()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //obtener nombre de label 1
            string nombre = textBox1.Text;
            //obtener dueno del label 2
            //relacionar la informacion, que por el nombre obtenga los otros tipos de datos 
            Dueno dueno = new Dueno(textBox2.Text);
            //obtener especie del label 3
            Especie especie = new Especie (textBox3.Text);
            //duda de porque nos da un error 
            //crear una instancia de la clase mascota, pasar nombre, dueño y respecie
            Mascota mascota = new Mascota(nombre, dueno, especie);
        }
    }
}
