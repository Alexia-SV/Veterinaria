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
        /*float costoInsumos;
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
}*/

/*//Si el radioButton 1 esta selelccionado entonces voy a abrir el formulario de hospitalizacion 
    if (radioButton1.Checked == true)
    {
        AltaHospitalizacionForm instancia = new AltaHospitalizacionForm();
instancia.Show();

    }
//Si el radioButton 1 no esta seleccionado o el radioButton 2 esta seleccionado entonces no hace nada*/

/*float costoInsumos;
    float costo = 0;

    if (float.TryParse(textBox2.Text, out costoInsumos))
    {
        costo = costoInsumos + 300;
        label9.Text = "$ " + costo.ToString();
    }
    else { MessageBox.Show("El valor que esta ingresando en costo insumos no es un numero, por favor ingrese un numero"); }
*/

}

}
