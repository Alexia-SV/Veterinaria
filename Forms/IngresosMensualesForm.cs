using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.Clases;

namespace VeterinariaS.Forms
{
    public partial class IngresosMensualesForm : Form
    {
        //Definicion de instanciaVeterinariaC
        VeterinariaC instanciaVeterinariaC;
        public IngresosMensualesForm()
        {
            InitializeComponent();
            //Llamar al metodo obtenerVeterinaria
            instanciaVeterinariaC = VeterinariaC.obtenerVeterinaria();
            //1. Me traigo todos los sevicios existentes en instancia veterinariaC
            Servicio[] listaServicios = instanciaVeterinariaC.obtenerServicios();            
            //2. Añado series al chart 
            chart1.Series.Clear();
            chart1.Series.Add("Total");
            


            int anoActual = DateTime.Now.Year;
            float ingresosEnero = 0;
            float ingresosFebrero = 0;
            float ingresosMarzo = 0;
            float ingresosAbril = 0;
            float ingresosMayo = 0;
            float ingresosJunio = 0;
            float ingresosJulio = 0;
            float ingresosAgosto = 0;
            float ingresosSeptiembre = 0;
            float ingresosOctubre = 0;
            float ingresosNoviembre = 0;
            float ingresosDiciembre = 0;

            //3. Filtro los servicios por el año en curso
            //por cada Servicio servicio in listaServicios
            foreach (Servicio servicio in listaServicios)
            {
                //si servicio.fecha != año actual
                if (servicio.Fecha.Year != anoActual)
                {
                    //entonces no nos interesa
                    continue; //me salto a la siguiente ejecucion
                }

                //pero si es igual 

                //sumamos al total del mes correspondiente su costo
                //el costo acumulado de todos los servicios de ese mes
                switch (servicio.Fecha.Month)
                {
                    
                    case 1:
                        ingresosEnero = ingresosEnero + servicio.Costo; 
                        break;

                    case 2:
                        ingresosFebrero += servicio.Costo;
                        break;

                    case 3:
                        ingresosMarzo += servicio.Costo;
                        break;

                    case 4:
                        ingresosAbril += servicio.Costo;
                        break;

                    case 5:
                        ingresosMayo += servicio.Costo;
                        break;

                    case 6:
                        ingresosJunio += servicio.Costo;
                        break;

                    case 7:
                        ingresosJulio += servicio.Costo;
                        break;

                    case 8:
                        ingresosAgosto += servicio.Costo;
                        break;

                    case 9:
                        ingresosSeptiembre += servicio.Costo;
                        break;

                    case 10:
                        ingresosOctubre += servicio.Costo;
                        break;

                    case 11:
                        ingresosNoviembre += servicio.Costo;
                        break;

                    case 12:
                        ingresosDiciembre += servicio.Costo;
                        break;
                    
                    default:
                        break;
                }
                

            }

            //4. Añado los servicios al mes correspondiente 
            chart1.Series["Total"].Points.AddXY("Enero", ingresosEnero);
            chart1.Series["Total"].Points.Last().Label = ingresosEnero.ToString();

            chart1.Series["Total"].Points.AddXY("Febrero", ingresosFebrero);
            chart1.Series["Total"].Points.Last().Label = ingresosFebrero.ToString();

            chart1.Series["Total"].Points.AddXY("Marzo", ingresosMarzo);
            chart1.Series["Total"].Points.Last().Label = ingresosMarzo.ToString();

            chart1.Series["Total"].Points.AddXY("Abril", ingresosAbril);
            chart1.Series["Total"].Points.Last().Label = ingresosAbril.ToString();

            chart1.Series["Total"].Points.AddXY("Mayo", ingresosMayo);
            chart1.Series["Total"].Points.Last().Label = ingresosMayo.ToString();

            chart1.Series["Total"].Points.AddXY("Junio", ingresosJunio);
            chart1.Series["Total"].Points.Last().Label = ingresosJunio.ToString();

            chart1.Series["Total"].Points.AddXY("Julio", ingresosJulio);
            chart1.Series["Total"].Points.Last().Label = ingresosJulio.ToString();

            chart1.Series["Total"].Points.AddXY("Agosto", ingresosAgosto);
            chart1.Series["Total"].Points.Last().Label = ingresosAgosto.ToString();

            chart1.Series["Total"].Points.AddXY("Septiembre", ingresosSeptiembre);
            chart1.Series["Total"].Points.Last().Label = ingresosSeptiembre.ToString();

            chart1.Series["Total"].Points.AddXY("Octubre", ingresosOctubre);
            chart1.Series["Total"].Points.Last().Label = ingresosOctubre.ToString();

            chart1.Series["Total"].Points.AddXY("Noviembre", ingresosNoviembre);
            chart1.Series["Total"].Points.Last().Label = ingresosNoviembre.ToString();

            chart1.Series["Total"].Points.AddXY("Diciembre", ingresosDiciembre);
            chart1.Series["Total"].Points.Last().Label = ingresosDiciembre.ToString();


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void IngresosMensualesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
