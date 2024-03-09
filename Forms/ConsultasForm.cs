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

namespace VeterinariaS.Forms
{
    public partial class ConsultasForm : Form
    {
        //Definicion de instanciaVeterinariaC
        VeterinariaC instanciaVeterinariaC;
        public ConsultasForm()
        {
            InitializeComponent();
            //1. Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();

            //2. Traer todos las consultas de la instancia de Veterinaria C 
            Consulta[] listaConsulta = instanciaVeterinariaC.obtenerConsultas();

            //3. Asigna el arreglo de propietarios al DataGridView
            dataGridView1.DataSource = listaConsulta;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConsultasForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaConsultaForm instanciaFormConsulta = new AltaConsultaForm();
            instanciaFormConsulta.Show();
        }
    }
}
