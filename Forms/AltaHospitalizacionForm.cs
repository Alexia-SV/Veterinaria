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
    public partial class AltaHospitalizacionForm : Form
    {
        //Definicion de instanciaVeterinariaC
        static VeterinariaC instanciaVeterinariaC;

        public AltaHospitalizacionForm()
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
            Mascota[] listaMascotas = instanciaVeterinariaC.obtenerMascotas();

            //4.1 El comboBox va a usar la propiedad de Nombre dentro de la mascota
            comboBox1.DisplayMember = "Nombre";

            //5. Por cada mascota dentro de la listaMascotas
            foreach (Mascota mascota in listaMascotas)
            {
                //6. Escribirla en el comboBox
                comboBox1.Items.Add(mascota);
            }
        }

        private void AltaHospitalizacionForm1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mascota mascota = (Mascota)comboBox1.SelectedItem;
            Usuario Veterinario = (Usuario)comboBox2.SelectedItem;
            int DiasHospital = textBox2.Text.Length;
            int NumeroCama = textBox2.Text.Length;
            float CostoInsumos = textBox3.Text.Length;
            float Costo = textBox4.Text.Length;
            DateTime fecha = dateTimePicker1.Value;
            
            //creo la nueva hospitalizacion con mis datos 
            Hospitalizacion nuevaHospitalizacion = new Hospitalizacion
                (mascota, 
                Veterinario, 
                Costo, 
                CostoInsumos, 
                fecha, 
                DiasHospital, 
                NumeroCama);
            instanciaVeterinariaC.registroHospitalizacion(nuevaHospitalizacion);

            MessageBox.Show("Hospitalización registrada con exito");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float costoInsumos;

            if (float.TryParse(textBox2.Text, out costoInsumos)) { } else { }
            float costoTotal = costoInsumos + 600;
            label8.Text =  "$ " + costoTotal.ToString();
        }
    }
}
