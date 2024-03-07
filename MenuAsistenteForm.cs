using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinariaS
{
    public partial class MenuAsistenteForm : Form
    {
        public MenuAsistenteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaMascotaForm instanciaFormMascota = new AltaMascotaForm();
            instanciaFormMascota.Show();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaDuenoForm instanciaFormDueno = new AltaDuenoForm();
            instanciaFormDueno.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AltaConsultaForm instanciaFormConsulta = new AltaConsultaForm();
            instanciaFormConsulta.Show();
        }
    }
}
