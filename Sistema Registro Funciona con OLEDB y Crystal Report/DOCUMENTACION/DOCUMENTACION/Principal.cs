using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CARGAR = DOCUMENTACION.Formularios.CARGAR;
using ENTREGAR = DOCUMENTACION.Formularios.ENTREGAR;
using LISTAR_STOCK = DOCUMENTACION.Formularios.LISTAR_STOCK;
using LISTAR_ENTREGA = DOCUMENTACION.Formularios.LISTAR_ENTREGA;
using BUSCAR_STOCK = DOCUMENTACION.Formularios.BUSCAR_STOCK;
using BUSCAR_ENTREGA = DOCUMENTACION.Formularios.BUSCAR_ENTREGA;
using ADMINISTRADOR = DOCUMENTACION.Formularios.ADMIN_VERIFICAR;
using REPORTE_STOCK = DOCUMENTACION.Formularios.REPORTE_STOCK;
using REPORTE_ENTREGA = DOCUMENTACION.Formularios.REPORTE_ENTREGA;
using CONTROLADORA = DOCUMENTACION.BD.Controladora;
using LISTAR_TODO = DOCUMENTACION.Formularios.LISTADO_COMPLETO;
using System.Data.OleDb;

namespace DOCUMENTACION
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult x = MessageBox.Show("Desea Finalizar la Aplicacion??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void cARGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CARGAR Fcargar = new CARGAR();
            Fcargar.ShowDialog();
        }

        private void bUSCARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BUSCAR_STOCK Fbuscar = new BUSCAR_STOCK();
            Fbuscar.ShowDialog();
        }

        private void lISTADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LISTAR_STOCK Flistar_stock = new LISTAR_STOCK();
            Flistar_stock.ShowDialog();
        }

        private void eNTREGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ENTREGAR Fentregar = new ENTREGAR();
            Fentregar.ShowDialog();
        }

        private void bUSCARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BUSCAR_ENTREGA fbuscar = new BUSCAR_ENTREGA();
            fbuscar.ShowDialog();
        }

        private void lISTADOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LISTAR_ENTREGA Flistar_entrega = new LISTAR_ENTREGA();
            Flistar_entrega.ShowDialog();
        }

        private void mENUADMINISTRADORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADMINISTRADOR fadmin = new ADMINISTRADOR();
            fadmin.ShowDialog();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTE_STOCK freporte = new REPORTE_STOCK();
            freporte.ShowDialog();
        }

        private void reporteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            REPORTE_ENTREGA freporte = new REPORTE_ENTREGA();
            freporte.ShowDialog();
        }

        private void lISTADOlStripMenuItem1_Click(object sender, EventArgs e)
        {
            LISTAR_TODO flistar = new LISTAR_TODO();
            flistar.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            CONTROLADORA contro = new CONTROLADORA();
            try
            {
                contro.conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void crystalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Reporte_Crystal_Stock Reporte = new Formularios.Reporte_Crystal_Stock();
            Reporte.ShowDialog();
        }

        private void crystalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Formularios.Reporte_Crystal_Entrega Reporte = new Formularios.Reporte_Crystal_Entrega();
            Reporte.ShowDialog();
        }
    }
}
