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
using Veterinaria.Clases;

namespace VeterinariaS.Forms
{
    public partial class ModificarCnsultaForm : Form
    {
        //Definicion de instanciaVeterinariaC
        static VeterinariaC instanciaVeterinariaC;
        public ModificarCnsultaForm()
        {
            InitializeComponent();
            //Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();

            // Cargar las consultas en el comboBox
            CargarConsultas();

        }
        private void CargarConsultas()
        {
            Consulta[] listaConsultas = instanciaVeterinariaC.obtenerConsultas();

            // Validar que la lista de consultas no sea nula
            if (listaConsultas == null)
            {
                return;
            }

            // Asignar la propiedad DisplayMember y cargar las consultas en el comboBox
            comboBox3.DisplayMember = "Mascota";
            foreach (Consulta consulta in listaConsultas)
            {
                comboBox3.Items.Add(consulta);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

            // Validar los datos ingresados por el usuario
            Dictionary<string, object> datosValidos = ValidarDatos();
            if (datosValidos == null)
            {
                MessageBox.Show("Por favor ingrese todos los datos correctamente");
                LimpiarCampos();
                return;
            }

            float costoInsumos = (float)datosValidos["CostoInsumos"];
            // Calcular el costo total
            float costoTotal = costoInsumos + 300;
            label9.Text = "$ " + costoTotal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar los datos ingresados por el usuario
            Dictionary<string, object> datosValidos = ValidarDatos();
            if (datosValidos == null)
            {
                MessageBox.Show("Por favor ingrese todos los datos correctamente");
                LimpiarCampos();
                return;
            }
            // Obtener los datos validados
            Consulta consulta = (Consulta)datosValidos["Consulta"];
            string diagnostico = (string)datosValidos["Diagnostico"];
            string tratamiento = (string)datosValidos["Tratamiento"];
            float costoInsumos = (float)datosValidos["CostoInsumos"];
            //creo la nueva hospitalizacion con mis datos 
            //Consulta nuevaConsulta = new Consulta(Diagnostico,Tratamiento,Hospitalizacion);

            //instanciaVeterinariaC.registroConsulta(nuevaConsulta);

            // Mostrar el mensaje de consulta registrada
            MessageBox.Show("Consulta registrada correctamente");

        }

        private Dictionary<string, object> ValidarDatos()
        {
            if (comboBox3.SelectedItem == null ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(richTextBox1.Text) ||
                string.IsNullOrWhiteSpace(richTextBox2.Text))
            {
                return null;
            }

            // Validar que el costo de insumos sea un número
            if (!float.TryParse(textBox2.Text, out float costoInsumos))
            {
                MessageBox.Show("El costo de insumos debe ser un número.");
                return null;
            }

            // Retornar un diccionario con los datos validados
            Dictionary<string, object> datosValidos = new Dictionary<string, object>();
            datosValidos.Add("Consulta", comboBox3.SelectedItem);
            datosValidos.Add("Diagnostico", richTextBox1.Text);
            datosValidos.Add("Tratamiento", richTextBox2.Text);
            datosValidos.Add("CostoInsumos", costoInsumos);

            return datosValidos;

        }
        private void LimpiarCampos()
        {
            textBox2.Text = "";
            comboBox3.SelectedItem = null;
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }


    }

}
