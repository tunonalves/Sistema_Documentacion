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

namespace DOCUMENTACION.Formularios
{
    public partial class CANCELAR_ENTREGA : Form
    {
        ENTREGA_BD entrega = new ENTREGA_BD();

        public CANCELAR_ENTREGA()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CANCELAR_ENTREGA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Desea Salir del Formulario??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (x == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void cANCELARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            limpiar();
            if ((((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57))
            {
                //MessageBox.Show("SOLO SE PERMITEN NUMEROS");
                e.Handled = true;
            }
        }

        private void limpiar()
        {
            textBox_codigo.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Enabled = false;
            textBox_codigo.Text.Trim();
            dataGridView1.DataSource = null;
            groupBox2.Visible = false;
        }

        private void buscar()
        {
            dataGridView1.DataSource = entrega.buscar_entrega_codigo(textBox_codigo.Text.Trim());
            if (dataGridView1.Rows.Count != 0)
            {
                groupBox2.Visible = true;
            }
        }

        private void cancelar()
        {
            DialogResult x = MessageBox.Show("¿ Desea Cancelar la Entrega ?", "Aceptar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.Yes)
            {
                entrega.cancelar_entrega(textBox_codigo.Text.Trim());
                dataGridView1.Enabled = true;
                limpiar();
            }
        }

        private void button_entregar_Click(object sender, EventArgs e)
        {
            cancelar();
        }
    }
}
