using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinariaS.Forms
{
    public partial class MenuVeterinarioForm : Form
    {
        public MenuVeterinarioForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ConsultasForm instancia = new ConsultasForm();
            AltaConsultaForm instancia = new AltaConsultaForm();    
            instancia.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //HospitalizacionForm instancia = new HospitalizacionForm();
            AltaHospitalizacionForm instancia = new AltaHospitalizacionForm();
            instancia.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InicioDeSesionForm instancia = new InicioDeSesionForm();
            instancia.Show();
            this.Hide();
        }
    }
}
