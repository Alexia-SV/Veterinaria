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
            
            //3. Por cada elemento dentro de listaMascota
            foreach (Mascota mascota  in listaMascota)
            {
                //En la clase Mascota agrego una propiedad NombreDueno que es igual a
                //la variable mascota propiedad instancia de dueno propiedad nombre
                mascota.NombreDueno = mascota.Dueno.Nombre; 
            }

            //3. Cancelo el autogenerador de columnas 
            dataGridView1.AutoGenerateColumns = false;
            //4. Asigna el arreglo de mascotas al DataGridView
            dataGridView1.DataSource = listaMascota;

            //5. Refresco el dataGrid por cada columna
            dataGridView1.Refresh();
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

            //3. Por cada elemento dentro de listaMascota
            foreach (Mascota mascota in listaMascota)
            {
                //En la clase Mascota agrego una propiedad NombreDueno que es igual a
                //la variable mascota propiedad instancia de dueno propiedad nombre
                mascota.NombreDueno = mascota.Dueno.Nombre;
            }

            //3. Cancelo el autogenerador de columnas 
            dataGridView1.AutoGenerateColumns = false;
            //4. Asigna el arreglo de mascotas al DataGridView
            dataGridView1.DataSource = listaMascota;

            //5. Refresco el dataGrid por cada columna
            dataGridView1.Refresh();
        }
    }
}
