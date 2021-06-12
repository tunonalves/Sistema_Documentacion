using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LISTAR_BD = DOCUMENTACION.BD.LISTAR_BD;

namespace DOCUMENTACION.Formularios
{
    public partial class LISTADO_COMPLETO : Form
    {
        public LISTADO_COMPLETO()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LISTADO_COMPLETO_Load(object sender, EventArgs e)
        {
            LISTAR_BD listar = new LISTAR_BD();
            dataGridView1.DataSource = listar.devolver_todo();
            label1.Text = "LA CANTIDAD DE DOCUMENTACION ENCONTRADA ES: " + dataGridView1.Rows.Count.ToString();
        }

        private void LISTADO_COMPLETO_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Desea Finalizar la Aplicacion??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (x == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }
    }
}
