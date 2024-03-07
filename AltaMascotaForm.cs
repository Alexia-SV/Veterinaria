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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string dueno = textBox2.Text;
            string especie = comboBox2.SelectedItem.ToString();

            
            //1.2 convertir la cadena que obtengo en tipoUsuario en un Enum para poder trabajarlo
            Especie especieEnum = (Especie)Enum.Parse(typeof(Especie), especie);
            
            //2. creo el nuevo usuario con mis datos 
            //Mascota nuevaMascota = new Mascota(nombre, dueno, especieEnum );

            //3. ese usuario se lo paso a mi metodo agregarUsuario
            //instanciaVeterinariaC.agregarMascota(nuevaMascota);

            //4. Mandar un mesaje de que el usuario se registro de forma correcta 
            MessageBox.Show("Mascota registrada con exito");
        }

        private void AltaMascotaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
