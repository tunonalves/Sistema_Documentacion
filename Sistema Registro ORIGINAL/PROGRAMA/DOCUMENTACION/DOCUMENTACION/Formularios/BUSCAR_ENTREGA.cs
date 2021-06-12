using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using ENTREGA_BD = DOCUMENTACION.BD.ENTREGA_BD;
using TIPO_BD = DOCUMENTACION.BD.TIPO_BD;
using PERSONA = DOCUMENTACION.Clases.Persona;
using DOCUMENTOS = DOCUMENTACION.Clases.Documentos;
using PROVINCIA = DOCUMENTACION.BD.PROVINCIAS_BD;

namespace DOCUMENTACION.Formularios
{
    public partial class BUSCAR_ENTREGA : Form
    {
        public BUSCAR_ENTREGA()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BUSCAR_ENTREGA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Desea Salir del Formulario??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (x == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void BUSCAR_ENTREGA_Load(object sender, EventArgs e)
        {
            TIPO_BD BD = new TIPO_BD();
            PROVINCIA PRO = new PROVINCIA();
            comboBox_tipo.DataSource = BD.listar();
            comboBox_tipo.DisplayMember = "Tipo";
            comboBox_tipo.ValueMember = "Id_Tipo";
            comboBox_provincia.DataSource = PRO.lista_provincia();
            comboBox_provincia.DisplayMember = "Provincias";
            comboBox_provincia.ValueMember = "Id_provincia";
            limpiar();
        }

        private void limpiar()
        {
            dataGridView1.DataSource = null;
            textBox_apellido.Clear();
            textBox_matricula.Clear();
            textBox_nombre.Clear();
            textBox_codigo.Clear();
            textBox_localidad.Clear();
            comboBox_tipo.SelectedItem = null;
            comboBox_provincia.SelectedItem = null;
            textBox_apellido.Text.Trim();
            textBox_matricula.Text.Trim();
            textBox_nombre.Text.Trim();
            textBox_codigo.Text.Trim();
            textBox_localidad.Text.Trim();
            dateTimePicker_fecha.Value = DateTime.Today.Date;
            dateTimePicker_fecha_entrega.Value = DateTime.Today.Date;
            dateTimePicker_fecha.MaxDate = DateTime.Today.Date;
            dateTimePicker_fecha_entrega.MaxDate = DateTime.Today.Date;
            dateTimePicker_fecha.Format = DateTimePickerFormat.Custom;
            dateTimePicker_fecha.CustomFormat = " ";
            dateTimePicker_fecha_entrega.Format = DateTimePickerFormat.Custom;
            dateTimePicker_fecha_entrega.CustomFormat = " ";
            groupBox2.Enabled = true;
        }

        private void nUEVABUSQUEDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void textBox_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText(e);
            this.enter(sender, e);
        }

        private void textBox_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText(e);
            this.enter(sender, e);
        }

        private void textBox_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validanum(e);
            this.enter(sender, e);
        }

        private void textBox_matricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            validanum(e);
            this.enter(sender, e);
        }

        private void textBox_localidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText(e);
            this.enter(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validanum(e);
            this.enter(sender, e);
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }

        private void validanum(KeyPressEventArgs e)
        {
            if ((((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57))
            {
                //MessageBox.Show("SOLO SE PERMITEN NUMEROS");
                e.Handled = true;
            }
        }

        private void validarText_dir(KeyPressEventArgs e)
        {
            if ((((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57))
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

        private void dateTimePicker_fecha_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_fecha.Format == DateTimePickerFormat.Custom)
            {
                dateTimePicker_fecha.Format = DateTimePickerFormat.Long;
            }
        }

        private void dateTimePicker_fecha_entrega_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_fecha_entrega.Format == DateTimePickerFormat.Custom)
            {
                dateTimePicker_fecha_entrega.Format = DateTimePickerFormat.Long;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = busca();
            dataGridView1.Enabled = true;
            label_cant.Visible = true;
            label_cant.Text = "LA CANTIDAD ENCONTRADA ES: " + dataGridView1.Rows.Count.ToString();
            groupBox2.Enabled = false;
        }

        private DataTable busca()
        {
            string fechaReco = "01/01/1900 12:00:00";
            DateTime aux = new DateTime();
            DateTime aux2 = new DateTime();
            int aux4 = 0;
            if (dateTimePicker_fecha.Format == DateTimePickerFormat.Custom)
            {
                aux = DateTime.Parse(fechaReco);
            }
            else
            {
                aux = dateTimePicker_fecha.Value;
            }
            if (dateTimePicker_fecha_entrega.Format == DateTimePickerFormat.Custom)
            {
                aux2 = DateTime.Parse(fechaReco);
            }
            else
            {
                aux2 = dateTimePicker_fecha_entrega.Value;
            }
            if (textBox_matricula.Text == "")
            {
                aux4 = 0;
            }
            else
            {
                aux4 = Convert.ToInt32(textBox_matricula.Text.Trim());
            }
            ENTREGA_BD entrega = new ENTREGA_BD();
            DataTable DT = new DataTable();
            try
            {
                PERSONA PER = new PERSONA(aux4, textBox_nombre.Text.Trim(), textBox_apellido.Text.Trim(), "" , textBox_localidad.Text.Trim(), Convert.ToInt16(comboBox_provincia.SelectedValue));
                DOCUMENTOS DOC = new DOCUMENTOS(textBox_codigo.Text.Trim(), PER, aux, aux2, Convert.ToInt16(comboBox_tipo.SelectedValue));
                DT = entrega.buscar(DOC);
            }
            catch (SqlException)
            {
                MessageBox.Show("Error SQL SERVER");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            return DT;
        }
    }
}
