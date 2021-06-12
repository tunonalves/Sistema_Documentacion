using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENTREGA_BD = DOCUMENTACION.BD.ENTREGA_BD;

namespace DOCUMENTACION.Formularios
{
    public partial class LISTAR_ENTREGA : Form
    {
        public LISTAR_ENTREGA()
        {
            InitializeComponent();
        }

        private void LISTAR_ENTREGA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Desea Salir del Formulario??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (x == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LISTAR_ENTREGA_Load(object sender, EventArgs e)
        {
            ENTREGA_BD entrega = new ENTREGA_BD();
            dataGridView1.DataSource = entrega.listar_entrega();
            label1.Text = "LA CANTIDAD DE DOCUMENTACION ENTREGADA ES: " + dataGridView1.Rows.Count.ToString();
        }
    }
}
