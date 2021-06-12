using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STOCK_BD = DOCUMENTACION.BD.STOCK_BD;

namespace DOCUMENTACION.Formularios
{
    public partial class LISTAR_STOCK : Form
    {
        public LISTAR_STOCK()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LISTAR_STOCK_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Desea Finalizar la Aplicacion??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (x == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void LISTAR_STOCK_Load(object sender, EventArgs e)
        {
            STOCK_BD stock_bd = new STOCK_BD();
            dataGridView1.DataSource = stock_bd.devolver_todo();
            label1.Text = "LA CANTIDAD DE DOCUMENTACION ENCONTRADA ES: " + dataGridView1.Rows.Count.ToString();
        }
    }
}
