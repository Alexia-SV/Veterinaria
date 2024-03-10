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
    public partial class AltaHospitalizacionForm1 : Form
    {
        //Definicion de instanciaVeterinariaC
        static VeterinariaC instanciaVeterinariaC;

        public AltaHospitalizacionForm1()
        {
            InitializeComponent();
           
            //Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();
        }

        private void AltaHospitalizacionForm1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Mascota = comboBox1.SelectedItem.ToString();
            String Veterinario = comboBox2.SelectedItem.ToString();
            int DiasHospital = textBox2.Text.Length;
            int NumeroCama = textBox2.Text.Length;
            float CostoInsumos = textBox3.Text.Length;
            float Costo = textBox4.Text.Length;
            DateTime  Fecha = DateTime.Now;
            string newDate = Fecha.ToString("yyyyMMdd");

            MessageBox.Show("Hospitalización registrada con exito");

        }
    }
}
