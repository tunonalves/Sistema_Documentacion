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
    public partial class REPORTE_ENTREGA : Form
    {
        public REPORTE_ENTREGA()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void REPORTE_ENTREGA_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'registro2.Pro_Historico_Listar' Puede moverla o quitarla según sea necesario.
            this.pro_Historico_ListarTableAdapter.Fill(this.registro2.Pro_Historico_Listar);

            this.reportViewer1.RefreshReport();
        }

        private void REPORTE_ENTREGA_FormClosing(object sender, FormClosingEventArgs e)
        {
            Listas_Close(sender, e);
        }

        private void Listas_Close(System.Object sender, System.EventArgs e)
        {
            this.Dispose();
        }
    }
}
