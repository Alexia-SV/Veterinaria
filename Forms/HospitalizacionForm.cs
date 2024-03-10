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
    public partial class HospitalizacionForm : Form
    {
        //Definicion de instanciaVeterinariaC
        VeterinariaC instanciaVeterinariaC;
        public HospitalizacionForm()
        {
            InitializeComponent();
            //1. Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();

            //2. Traer todos las consultas de la instancia de Veterinaria C 
            Hospitalizacion[] listaHospitalizacion = instanciaVeterinariaC.obtenerHospitalizaciones();

            //3. Asigna el arreglo de propietarios al DataGridView
            dataGridView1.DataSource = listaHospitalizacion;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Refresh();
        }

        private void HospitalizacionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
