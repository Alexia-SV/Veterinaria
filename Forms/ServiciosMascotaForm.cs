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

namespace VeterinariaS.Forms
{
    public partial class ServiciosMascotaForm : Form
    {
        //Definicion de instanciaVeterinariaC
        VeterinariaC instanciaVeterinariaC;
        public ServiciosMascotaForm()
        {
            InitializeComponent();
            InitializeComponent();
            //Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();

            //1. Traer todos las mascotas de la instancia de Veterinaria C 
            Mascota[] listaMascotas = instanciaVeterinariaC.obtenerMascotas();
            //1.1 El comboBox va a usar la propiedad de Nombre dentro del usuario
            comboBox1.DisplayMember = "Nombre";
            //2. Filtro que por cada usuario 
            foreach (Mascota mascota in listaMascotas)
            {
                comboBox1.Items.Add(mascota);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. Obtengo lo que selecciono el usuario 
            //1.1 Obtener el elemento seleccionado como objeto
            object itemSeleccionado = comboBox1.SelectedItem;

            if (itemSeleccionado != null)
            {
                //1.2 Realizar acciones con el elemento seleccionado
                string valorSeleccionado = itemSeleccionado.ToString();
            }
            else
            {
                //1.2 No hay ningún elemento seleccionado
                MessageBox.Show("Ningún elemento seleccionado, por favor seleccione uno");
            }

            //2. Obtengo todos los servicios
            Mascota[] listaMascotas = instanciaVeterinariaC.obtenerMascotas();
            //3. Filtro los servicios dependiendo de la mascota
            // por cada mascota dentro de la lista de mascotas 
            //
            //4. Escribo en el dataGrid 
        }
    }
}
