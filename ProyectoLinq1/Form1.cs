using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoLinq1
{
    public partial class Form1 : Form
    {
        NegocioCls.ClsPersona obj = new NegocioCls.ClsPersona();
        int id = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 obj.insert(textBox1.Text, textBox2.Text);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
            finally {
                recargar();
                recargarTexto();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            obj.update(textBox1.Text, textBox2.Text, id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                recargar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj.selectAll(listBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            recargarTexto();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'proyectonetDataSet.sp_persona_select_all' table. You can move, or remove it, as needed.
            obj.selectAll(comboBox1);
            obj.selectAll(listBox1);
            recargarTexto();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getId(listBox1.SelectedItem.ToString());
            obj.loadform(id.ToString(), textBox1, textBox2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           getId(comboBox1.SelectedItem.ToString());
           obj.loadform(id.ToString(), textBox1, textBox2);
        }
        private void recargarTexto() {
            textBox1.Text = "";
            textBox2.Text = "";
            id = 0;
        }
        private void recargar() {
            textBox1.Text = "";
            textBox2.Text = "";
            obj.selectAll(comboBox1);
            obj.selectAll(listBox1);
            id = 0;
        }

        private void getId(String idSplit)
        {
            string texto = idSplit;
            string[] dividir = texto.Split('-');
            id = Int32.Parse(dividir[0]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Deseas eleminar esta persona?",
                      "Eliminar personas", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    obj.delete(id);
                    recargar();
                    recargarTexto();
                    break;
                case DialogResult.No:

                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            VentanaModificar ventana = new VentanaModificar();
            ventana.ShowDialog();
        }
    }
}
