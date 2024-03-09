﻿using System;
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
            //1. obtener los datos que ingresan
            Mascota mascota = (Mascota) comboBox1.SelectedItem;
            DateTime fechaConsulta = dateTimePicker1.Value;
            TipoUsuario Veterinario = (TipoUsuario)comboBox2.SelectedItem;
            float costoInsumos;
            
            if (float.TryParse(textBox2.Text, out costoInsumos)) { } else{ }
            float costo = costoInsumos + 300;
            
            string diagnostico = richTextBox1.Text;
            string tratamiento = richTextBox2.Text;
            bool hospitalizacion;
            
            if (radioButton1.Checked)
            {
                hospitalizacion = true;
            } else
            {
                hospitalizacion = false;
            }

            //2. creo la nueva consulta con mis datos
            Consulta nuevaConsulta = new Consulta(diagnostico, tratamiento, hospitalizacion);

            //3. esa consulta se lo paso a mi metodo agregarConsulta
            instanciaVeterinariaC.agregarConsulta(nuevaConsulta);

            //4. Mandar un mesaje de que la consulta se registro de forma correcta
            MessageBox.Show("Consulta registrada");
            //5. Limpiar los controladores
            comboBox1 = null;
            dateTimePicker1 = null;
            comboBox2 = null;
            textBox2.Text = " " ;
            richTextBox1.Text = " " ;
            richTextBox2.Text = " " ;
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }

        private void button2_Click(object sender, EventArgs e, float costo)
        {
            float costoInsumos;

            if (float.TryParse(textBox2.Text, out costoInsumos)) { } else { }
            float costoTotal = costoInsumos + 300;

            MessageBox.Show("El costo total de la consulta es de $ " + costoTotal + " pesos");
            
        }
    }
}
