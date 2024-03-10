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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VeterinariaS.Forms
{
    public partial class ServiciosVeterinarioForm : Form
    {
        //Definicion de instanciaVeterinariaC
        VeterinariaC instanciaVeterinariaC;
        public ServiciosVeterinarioForm()
        {
            InitializeComponent();
            //Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();

            //1. Traer todos los usuarios de la instancia de Veterinaria C 
            Usuario[] listaUsuarios = instanciaVeterinariaC.obtenerUsuarios();
            //1.1 El comboBox va a usar la propiedad de Nombre dentro del usuario
            comboBox1.DisplayMember = "Nombre";
            //2. Filtro que por cada usuario 
            foreach (Usuario usuario in listaUsuarios)
            {
                //si el usuario es de tipo veterinario
                if (usuario.TipoUsuario == TipoUsuario.veterinario)
                {
                    //3. Entonces que aparezca en el comboBox
                    comboBox1.Items.Add(usuario);
                }
            }
        }

        private void ServiciosVeterinarioForm_Load(object sender, EventArgs e)
        {

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
            //Servicio[ ] listaServicios = instanciaVeterinariaC.obtenerServicios();

            //3. Filtro los servicios dependiendo del vet
            //por cada 
            //foreach ( )
            //Servicio[ ] serviciosNombreVeterinario = listaServicios 
            //4. Escribo en el dataGrid 
        }
    }
}
