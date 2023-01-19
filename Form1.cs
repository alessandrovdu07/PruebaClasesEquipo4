using PruebaClases.MetodosAlgoritmos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PruebaClases
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Paso 1: Condicíon de vacío
                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
                {
                    MessageBox.Show("Los números tienen que ser MAYOR que cero, NO VACÍOS");
                    return;
                }
                int numeroDatos = Convert.ToInt32(textBox1.Text);
                int limiteInferior = Convert.ToInt32(textBox2.Text);
                int limiteSuperior = Convert.ToInt32(textBox3.Text);
                double stdDev = 0, media = 0;
                List<double> lista = new List<double>();
                // Paso 2: Condicíon de Mayor y Menor
                if (limiteInferior >= limiteSuperior)
                {
                    MessageBox.Show("Los límites tienen error");
                    return;
                }
                if (limiteInferior > 0 && limiteSuperior > 0 && numeroDatos > 0)
                {
                    AlgoritmoInicio algoritmo = new AlgoritmoInicio();
                    media = algoritmo.AlgoritmoGenerarAleatoriosMedia(numeroDatos, limiteInferior, limiteSuperior, lista);
                    llenarGrid(numeroDatos, algoritmo);
                    textBox4.Text = lista[0].ToString();
                    //stdDev = algoritmo.AlgoritmoGenerarAleatoriosStdDev(numeroDatos, limiteInferior, limiteSuperior);
                    textBox5.Text = lista[1].ToString();
                    //textBox5.Text=stdDev.ToString(); 
                }
                else
                {
                    MessageBox.Show("Vuelve a intentar (Núnca te rindas)");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vuelve a intentar");
            }
        }

        public void llenarGrid(int numeroDatos, AlgoritmoInicio algoritmo)
        {
            string numeroColumna1 = "1";
            string numeroColumna2 = "2";

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(numeroColumna1, "Algoritmo 1");
            dataGridView1.Columns.Add(numeroColumna2, "ID");
            for (int i = 0; i < numeroDatos; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = algoritmo.listaDemandas[i].CantidadRequerida.ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna2) - 1].Value = algoritmo.listaDemandas[i].IdDemanda.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DescargaExcel(dataGridView1);
        }
        public void DescargaExcel(DataGridView data)
        {
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indiceColumna = 0;
            // Llenar (construir) encabezados
            foreach (DataGridViewColumn columna in data.Columns)
            {
                indiceColumna = indiceColumna + 1;
                exportarExcel.Cells[1, indiceColumna] = columna.HeaderText;
            }
            // Llenar filas
            int indiceFila = 0;
            foreach (DataGridViewRow fila in data.Rows)
            {
                indiceFila++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in data.Columns)
                {
                    indiceColumna++;
                    exportarExcel.Cells[indiceFila + 1, indiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            exportarExcel.Visible = true;
        }

       
    }
}
