using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VeterinariaS.Forms
{
    public partial class ModificarCnsultaForm : Form
    {
        public ModificarCnsultaForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. Validar datos 
            //1.1 Metodo validar datos 
            Dictionary<string, object> datosValidos = ValidarDatos();
            if (datosValidos == null)
            {
                MessageBox.Show("Ingreso de datos incorrectos");

                textBox2.Text = "";
                comboBox3.SelectedItem = null;
                richTextBox2.text = "";
                return;
            }

            //2. Obtener datos 
            //2.1 debe de mostrar solo las consultas del veterinario que se selecciono     

            //3. implementar la parte de que se seleccione la consulta que se va a modificar 
            //3.1 se guarde los datos 

            //4. Aparezca el mensaje de consulta registrada 


            float costoInsumos;
            float costo = 0;

             if (float.TryParse(textBox2.Text, out costoInsumos)) 
        {
            costo = costoInsumos + 300;
             } else{ MessageBox.Show("El valor que esta ingresando en costo insumos no es un numero, por favor ingrese un numero");  }


            string diagnostico = richTextBox1.Text;
            string tratamiento = richTextBox2.Text;
            bool hospitalizacion;

            if (radioButton1.Checked)
            {
            hospitalizacion = true;
            }
            else
            {
           hospitalizacion = false;
            }

            //Si el radioButton 1 esta selelccionado entonces voy a abrir el formulario de hospitalizacion 
                if (radioButton1.Checked == true)
                {
                    AltaHospitalizacionForm instancia = new AltaHospitalizacionForm();
            instancia.Show();

                }
            //Si el radioButton 1 no esta seleccionado o el radioButton 2 esta seleccionado entonces no hace nada*/

                if (float.TryParse(textBox2.Text, out costoInsumos))
                {
                    costo = costoInsumos + 300;
                    label9.Text = "$ " + costo.ToString();
                }
                else { MessageBox.Show("El valor que esta ingresando en costo insumos no es un numero, por favor ingrese un numero"); }
            


        }

        private Dictionary<string, object> ValidarDatos()
        {
            if (comboBox3.SelectedItem == null)
            {
                return null;
            }

            if (textBox2.Text == null || textBox2.Text.Trim() == "")
            {
                return null;
            }

            if (richTextBox1.Text == null || richTextBox1.Text.Trim() == "")
            {
                return null;
            }
            if (richTextBox2.Text == null || richTextBox2.Text.Trim() == "")
            {
                return null;
            }

            //retorno un diccionario con los datos 
            Dictionary<string, object> datosValidos = new Dictionary<string, object>();

            //agrego datos al diccionario
            datosValidos.Add("Consulta", comboBox3.SelectedItem.ToString());
            datosValidos.Add("Disgnostico", richTextBox1.Text);
            datosValidos.Add("Tratamiento", richTextBox2.Text);
            datosValidos.Add("Costo Insumo", textBox2.Text);

            return datosValidos;
        }

    }

}
