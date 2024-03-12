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
            string valorSeleccionado;

            if (itemSeleccionado != null)
            {
               //1.2 Realizar acciones con el elemento seleccionado
                valorSeleccionado = itemSeleccionado.ToString();
            }
            else
            {
                //1.2 No hay ningún elemento seleccionado
                MessageBox.Show("Ningún elemento seleccionado, por favor seleccione uno");
                return;
            }

            //2. Obtengo todos los servicios, Qué contiene? consultas y hospitalizaciones
            //   no filtrados.
            Servicio[] listaServicios = instanciaVeterinariaC.obtenerServicios();
            List<Servicio> serviciosVet = new List<Servicio>();

            // 3. Tenemos que filtrarlos, en base al nombre del Veterinario de listaServicios
            // 3.1. Por cada servicio en la lista de servicios
            foreach (Servicio servicio in listaServicios)
            {
                // 3.2. Comparar el nombre del veterinario (servicio.vet.nombre) con valorSeleccionado    
                //error en que cuando selecciona al veterinario y busca los servicios lo rompe
                if (servicio.Veterinario.Nombre == valorSeleccionado)
                {
                    // 3.3. Si son iguales:
                    // 3.4. A la lista serviciosVet le agrego servicio
                    serviciosVet.Add(servicio);
                }
            }

            // 4. Pasar esos datos a mi dataGrid
            dataGridView1.DataSource = serviciosVet;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Refresh();


            // ...

            // Final. Que tenga una tabla con todos los servicios que sean del Veteriano que
            //    se seleccionó





















            //foreach (Servicio servicio in listaServicios)
            //{
            //    if (valorSeleccionado == servicio.Veterinario.Nombre)
            //    {
            //                    
            //    }
            //}

            //4. Escribo en el dataGrid 
        }
    }
}
