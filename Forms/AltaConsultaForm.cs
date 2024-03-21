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
using VeterinariaS.Forms;

namespace VeterinariaS
{
    public partial class AltaConsultaForm : Form
    {
        //Definicion de instanciaVeterinariaC
        VeterinariaC instanciaVeterinariaC;
        public AltaConsultaForm()
        {
            InitializeComponent();
            //Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();
            
            //1. Traer todos los usuarios de la instancia de Veterinaria C 
            Usuario[] listaUsuarios = instanciaVeterinariaC.obtenerUsuarios();
            
            //1.1 El comboBox va a usar la propiedad de Nombre dentro del usuario
            comboBox2.DisplayMember = "Nombre";

            //2. Filtro que por cada usuario 
            foreach (Usuario usuario in listaUsuarios)
            {
                //si el usuario es de tipo veterinario
                if (usuario.TipoUsuario == TipoUsuario.veterinario)
                {
                    //3. Entonces que aparezca en el comboBox
                    comboBox2.Items.Add(usuario); 
                }
            }

            //4. Traer todas las macotas de la instancia de Veterinaria C
            Mascota[ ] listaMascotas = instanciaVeterinariaC.obtenerMascotas();

            //Validar que listaMascotas no sea nula
            if (listaMascotas == null)
            {
                return;
            }

            //4.1 El comboBox va a usar la propiedad de Nombre dentro de la mascota
            comboBox1.DisplayMember = "Nombre";

            //5. Por cada mascota dentro de la listaMascotas
            foreach (Mascota mascota in listaMascotas)
            {
                //6. Escribirla en el comboBox
                comboBox1.Items.Add(mascota);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AltaConsultaForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> datosValidos = ValidarDatos();
            if (datosValidos == null)
            {
                MessageBox.Show("No ingreso ningun dato");
                //Limpiar los controladores
                comboBox1 = null;
                dateTimePicker1 = null;
                comboBox2 = null;
                textBox2.Text = " ";
                richTextBox1.Text = " ";
                richTextBox2.Text = " ";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                return;
            }

            //1. obtener los datos que ingresan
            Mascota mascota = (Mascota)datosValidos["Mascota"];
            DateTime fechaConsulta = dateTimePicker1.Value;
            Usuario veterinario = (Usuario)datosValidos["Veterinario"];
            float costo = 300;
            string diagnostico = (string)datosValidos["Diagnostico"];
            string tratamiento = (string)datosValidos["Tratamiento"];
            bool hospitalizacion;
            float costoInsumos;

            if (float.TryParse((string)datosValidos["CostoInsumo"], out costoInsumos))
            {
                costo = costoInsumos + costo;
            }
            else { MessageBox.Show("El valor que esta ingresando en costo insumos no es un numero, por favor ingrese un numero"); }

            if (radioButton1.Checked)
            {
                hospitalizacion = true;
            }

            hospitalizacion = false;


                //2. creo la nueva consulta con mis datos
                Consulta nuevaConsulta = new Consulta
                    (mascota,
                    veterinario, 
                    diagnostico, 
                    tratamiento, 
                    hospitalizacion, 
                    costo, 
                    costoInsumos, 
                    fechaConsulta);

            //3. esa consulta se lo paso a mi metodo agregarConsulta
            instanciaVeterinariaC.agregarConsulta(nuevaConsulta);

            //4. Mandar un mesaje de que la consulta se registro de forma correcta
            MessageBox.Show("Consulta registrada");

            //5. Limpiar los controladores
            comboBox1 = null;
            dateTimePicker1 = null;
            comboBox2 = null;
            textBox2.Text = " ";
            richTextBox1.Text = " ";
            richTextBox2.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            return;
        }

        private void button2_Click(object sender, EventArgs e, float costo)
        {

        }

        //Validar datos 
        private Dictionary<string, object> ValidarDatos()
        {
            if (comboBox1.SelectedItem == null)
            {
                return null;
            }

            if(comboBox2.SelectedItem == null)
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

            if (textBox2.Text == null || textBox2.Text.Trim() == "")
            {
                return null;
            }



            //4. retorno los datos validados en un diccionario/tipo lista
            Dictionary<string, object> datosValidos = new Dictionary<string, object>();
            //datosValidos.Add("Dueno", (Dueno)comboBox1.SelectedItem);

            datosValidos.Add("Mascota", (Mascota)comboBox1.SelectedItem);
            datosValidos.Add("Veterinario", (Usuario)comboBox2.SelectedItem);
            datosValidos.Add("Diagnostico", richTextBox1.Text);
            datosValidos.Add("Tratamiento", richTextBox2.Text);
            datosValidos.Add("CostoInsumo", textBox2.Text);

            return datosValidos;

        }
    }
}
