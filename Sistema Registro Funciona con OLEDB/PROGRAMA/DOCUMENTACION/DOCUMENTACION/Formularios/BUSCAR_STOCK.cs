using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STOCK = DOCUMENTACION.BD.STOCK_BD;
using DOCUMENTO = DOCUMENTACION.Clases.Documentos;
using PERSONA = DOCUMENTACION.Clases.Persona;
using TIPO_BD = DOCUMENTACION.BD.TIPO_BD;
using System.Data.OleDb;

namespace DOCUMENTACION.Formularios
{
    public partial class BUSCAR_STOCK : Form
    {
        public BUSCAR_STOCK()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LISTADO_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Desea Salir del Formulario??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (x == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            dataGridView1.DataSource = busca();
            label_cant.Visible = true;
            label_cant.Text = "LA CANTIDAD ENCONTRADA ES: " + dataGridView1.Rows.Count.ToString();
            groupBox2.Enabled = false;
        }

        private void BUSCAR_STOCK_Load(object sender, EventArgs e)
        {
            TIPO_BD BD = new TIPO_BD();
            comboBox_tipo.DataSource = BD.listar();
            comboBox_tipo.DisplayMember = "Tipo";
            comboBox_tipo.ValueMember = "Id_Tipo";
            limpiar();
        }

        private void nUEVABUSQUEDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            dataGridView1.DataSource = null;
        }

        private void limpiar()
        {
            textBox_apellido.Clear();
            textBox_nombre.Clear();
            textBox_codigo.Clear();
            dataGridView1.Enabled = false;
            comboBox_tipo.SelectedItem = null;
            dataGridView1.DataSource = false;
            dateTime_fecha.Value = DateTime.Today.Date;
            dateTime_fecha.MaxDate = DateTime.Today.Date;
            label_cant.Text = "";
            label_cant.Visible = false;
            textBox_apellido.Text.Trim();
            textBox_codigo.Text.Trim();
            textBox_nombre.Text.Trim();
            dateTime_fecha.Format = DateTimePickerFormat.Custom;
            dateTime_fecha.CustomFormat = " ";
            groupBox2.Enabled = true;
        }

        private DataTable busca()
        {
            string fechaReco = "01/01/1900 12:00:00"; 
            DateTime aux = new DateTime(); 
            if (dateTime_fecha.Format == DateTimePickerFormat.Custom)
            {
                aux = DateTime.Parse(fechaReco);              
            }
            else
            {
                aux = dateTime_fecha.Value;
            }
            STOCK STOCK = new STOCK();
            DataTable DT = new DataTable();
            try
            {
                PERSONA PER = new PERSONA(textBox_nombre.Text.Trim(), textBox_apellido.Text.Trim());
                DOCUMENTO DOC = new DOCUMENTO(textBox_codigo.Text.Trim(), PER, aux, Convert.ToInt16(comboBox_tipo.SelectedValue));
                DT = STOCK.buscar(DOC);
            }
            catch (OleDbException)
            {
                MessageBox.Show("Error SQL SERVER");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            return DT;
        }

        private void textBox_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validarText(e);
            this.enter(sender, e);
        }

        private void textBox_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validarText(e);
            this.enter(sender, e);
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button_buscar_Click(sender, e);
            }
        }

        private void validarText(KeyPressEventArgs e)
        {
            if ((e.KeyChar < 65) || (e.KeyChar > 90))
            {
                if ((e.KeyChar < 97) || (e.KeyChar > 122))
                {
                    if ((e.KeyChar != 8) && (e.KeyChar != 32))
                    {
                        if ((e.KeyChar != 'Ñ') && (e.KeyChar != 'ñ'))
                        {
                            //MessageBox.Show("SOLO SE PERMITEN LETRAS");
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void textBox_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57))
            {
                //MessageBox.Show("SOLO SE PERMITEN NUMEROS");
                e.Handled = true;
            }
            this.enter(sender, e);
        }

        private void dateTime_fecha_ValueChanged(object sender, EventArgs e)
        {
            if (dateTime_fecha.Format == DateTimePickerFormat.Custom)
            {
                dateTime_fecha.Format = DateTimePickerFormat.Long;
            }
        }
    }
}
