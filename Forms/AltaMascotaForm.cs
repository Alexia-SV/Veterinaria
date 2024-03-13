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
            
            // validar que en la listaDuenos no sea nula
            if (listaDuenos == null)
            {
                return;
            }

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
            Dictionary<string, object> datosValidos = ValidarDatos();
            if(datosValidos == null)
            {
                MessageBox.Show("Ingreso de datos incorrectos");

                textBox1.Text = "";
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
                return;
            }


            string nombre = datosValidos["Nombre"].ToString();
            Dueno dueno = (Dueno)datosValidos["Dueno"];
            string especie = datosValidos["Especie"].ToString();

            
            //1.2 convertir la cadena que obtengo en especia en un Enum para poder trabajarlo
            Especie especieEnum = (Especie)Enum.Parse(typeof(Especie), especie);
            
            
            //2. creo a la nueva mascota con mis datos 
            Mascota nuevaMascota = new Mascota(nombre, dueno, especieEnum );

            //3. Esa mascota se lo paso a mi metodo agregarMascota
            instanciaVeterinariaC.agregarMascota(nuevaMascota);

            //4. Mandar un mesaje de que el usuario se registro de forma correcta 
            MessageBox.Show("Mascota registrada con exito");

            textBox1.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
        }

        private void AltaMascotaForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //metodo para validar datos 
        private Dictionary<string, object> ValidarDatos()
        {
            if(textBox1.Text == null || textBox1.Text.Trim() == "")
            {
                return null;
            }

            if (comboBox1.SelectedItem == null)
            {
                return null;
            }

            if(comboBox2.SelectedItem == null)
            {
                return null;
            }

            //4. retorno los datos validados en un diccionario/tipo lista
            Dictionary<string, object> datosValidos = new Dictionary<string, object>();

            //5. Pasarle los datos a mi diccionario 
            datosValidos.Add("Nombre", textBox1.Text);
            datosValidos.Add("Dueno", (Dueno)comboBox1.SelectedItem);
            datosValidos.Add("Especie", comboBox2.SelectedItem.ToString());

            return datosValidos;

        }
    }
}
