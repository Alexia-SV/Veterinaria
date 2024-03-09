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
    public partial class PropietarioForm : Form
    {
        //Definicion de instanciaVeterinariaC
        VeterinariaC instanciaVeterinariaC;
        public PropietarioForm()
        {
            InitializeComponent();
            //1. Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();

            //2. Traer todos los propietarios de la instancia de Veterinaria C 
            Dueno[] listaDueno = instanciaVeterinariaC.obtenerDuenos();

            //3. Asigna el arreglo de propietarios al DataGridView
            dataGridView1.DataSource = listaDueno;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Refresh();
        }

        private void PropietarioForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Llamar el form para dar de alta a un Propietario
            AltaDuenoForm instanciaFormDueno = new AltaDuenoForm();
            instanciaFormDueno.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Refresca la lista de los propietarios
            //1. Obtengo la instancia en la que estoy trabajando
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();

            //2. Traer todos los propietarios de la instancia de Veterinaria C 
            Dueno[] listaDueno = instanciaVeterinariaC.obtenerDuenos();

            //3. Asigna el arreglo de propietarios al DataGridView
            dataGridView1.DataSource = listaDueno;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Refresh();
        }

        
    }
}
