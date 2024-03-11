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
    public partial class MascotaForm : Form
    {
        //Definicion de instanciaVeterinariaC
        VeterinariaC instanciaVeterinariaC;

        public MascotaForm()
        {
            InitializeComponent();
            //1. Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();

            //2. Traer todas las mascotas de la instancia de Veterinaria C 
            Mascota[] listaMascota = instanciaVeterinariaC.obtenerMascotas();

            //2.1 si lista mascota es nulo entonces que no se ejecute lo de dataGrid
            if (listaMascota != null)
            {

                
                dataGridView1.AutoGenerateColumns = true;
                //4. Asigna el arreglo de mascotas al DataGridView
                dataGridView1.DataSource = listaMascota;

                //5. Refresco el dataGrid por cada columna
                dataGridView1.Refresh();
            }
            
        }

        private void MascotaForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaMascotaForm instancia = new AltaMascotaForm();
            instancia.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1. Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();

            //2. Traer todas las mascotas de la instancia de Veterinaria C 
            Mascota[] listaMascota = instanciaVeterinariaC.obtenerMascotas();

            //3. Cancelo el autogenerador de columnas 
            dataGridView1.AutoGenerateColumns = true;
            //4. Asigna el arreglo de mascotas al DataGridView
            dataGridView1.DataSource = listaMascota;

            //5. Refresco el dataGrid por cada columna
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
