using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODIFICAR_STOCK = DOCUMENTACION.Formularios.MODIFICAR_STOCK;
using CANCELAR_ENTREGA = DOCUMENTACION.Formularios.CANCELAR_ENTREGA;
using MODIFICA_ENTREGA = DOCUMENTACION.Formularios.MODIFICAR_ENTREGA;
using Agregar_Tipos = DOCUMENTACION.Formularios.AGREGAR_TIPOS;
using Modificar_Tipos = DOCUMENTACION.Formularios.MODIFICAR_TIPOS;
using Administrar_Tipos = DOCUMENTACION.Formularios.ADMINISTRAR_TIPOS;
using MODIFICAR_PERSONA = DOCUMENTACION.Formularios.MODIFICAR_PERSONAS;

namespace DOCUMENTACION.Formularios
{
    public partial class MENU_ADMIN : Form
    {
        public MENU_ADMIN()
        {
            InitializeComponent();
        }

        private void modificarEntregaToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            MODIFICA_ENTREGA fmodifica = new MODIFICA_ENTREGA();
            fmodifica.ShowDialog();
        }

        private void cancelarEntregaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CANCELAR_ENTREGA Fcancelar = new CANCELAR_ENTREGA();
            Fcancelar.ShowDialog();
        }

        private void modificarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MODIFICAR_STOCK Fmodificar = new MODIFICAR_STOCK();
            Fmodificar.ShowDialog();
        }

        private void Menu_Admin_Load(object sender, EventArgs e)
        {

        }

        private void agregarTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AGREGAR_TIPOS fAgregar = new AGREGAR_TIPOS();
            fAgregar.ShowDialog();
        }

        private void modificarTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MODIFICAR_TIPOS fModificar = new MODIFICAR_TIPOS();
            fModificar.ShowDialog();
        }

        private void administrarTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADMINISTRAR_TIPOS fAdmin = new ADMINISTRAR_TIPOS();
            fAdmin.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MODIFICAR_PERSONAS fmodificar = new MODIFICAR_PERSONA();
            fmodificar.ShowDialog();
        }
    }
}
