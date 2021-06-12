using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DOCUMENTACION.Formularios
{
    public partial class REPORTE_STOCK : Form
    {
        public REPORTE_STOCK()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void REPORTE_STOCK_FormClosing(object sender, FormClosingEventArgs e)
        {
            Listas_Close(sender, e);
        }

        private void REPORTE_STOCK_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'registro2.Pro_Pendiente_Listar' Puede moverla o quitarla según sea necesario.
            this.pro_Pendiente_ListarTableAdapter.Fill(this.registro2.Pro_Pendiente_Listar);

            this.reportViewer1.RefreshReport();
        }

        private void Listas_Close(System.Object sender, System.EventArgs e)
        {
            this.Dispose();
        }
    }
}
