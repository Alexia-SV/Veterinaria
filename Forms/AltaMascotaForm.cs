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
    public partial class AltaMascotaForm : Form
    {
        //Definicion de instanciaVeterinariaC
        static VeterinariaC instanciaVeterinariaC;
        public AltaMascotaForm()
        {
            InitializeComponent();
            //Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();
            //1. Traer todos los dueños de la instancia de Veterinaria C 
            Dueno[] listaDuenos = instanciaVeterinariaC.obtenerDuenos();
            //1.1 El comboBox1 va a usar la propiedad de Nombre dentro del dueno
            comboBox1.DisplayMember = "Nombre";
            //2. Filtro que por cada dueno 
            foreach (Dueno dueno in listaDuenos)
            {
                comboBox1.Items.Add(dueno);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            Dueno dueno = (Dueno)comboBox1.SelectedItem;
            string especie = comboBox2.SelectedItem.ToString();

            
            //1.2 convertir la cadena que obtengo en especia en un Enum para poder trabajarlo
            Especie especieEnum = (Especie)Enum.Parse(typeof(Especie), especie);
            
            
            //2. creo a la nueva mascota con mis datos 
            Mascota nuevaMascota = new Mascota(nombre, dueno, especieEnum );

            //3. Esa mascota se lo paso a mi metodo agregarMascota
            instanciaVeterinariaC.agregarMascota(nuevaMascota);

            //4. Mandar un mesaje de que el usuario se registro de forma correcta 
            MessageBox.Show("Mascota registrada con exito");

            textBox1.Text = " ";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
        }

        private void AltaMascotaForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
