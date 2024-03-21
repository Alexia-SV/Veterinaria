using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaS.Forms;

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
            MascotaForm instancia = new MascotaForm();
            instancia.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PropietarioForm instanciaPropietarioForm = new PropietarioForm();
            instanciaPropietarioForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ConsultasForm instancia = new ConsultasForm();
            AltaConsultaForm instancia = new AltaConsultaForm();
            instancia.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InicioDeSesionForm instancia = new InicioDeSesionForm();
            instancia.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //HospitalizacionForm instancia = new HospitalizacionForm();
            AltaHospitalizacionForm instancia = new AltaHospitalizacionForm();
            instancia.Show();
        }

        private void MenuAsistenteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
