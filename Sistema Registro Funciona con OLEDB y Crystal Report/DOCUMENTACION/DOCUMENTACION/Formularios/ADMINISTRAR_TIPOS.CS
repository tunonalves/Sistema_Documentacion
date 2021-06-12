using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tipo_BD = DOCUMENTACION.BD.TIPO_BD;

namespace DOCUMENTACION.Formularios
{
    public partial class ADMINISTRAR_TIPOS : Form
    {
        public ADMINISTRAR_TIPOS()
        {
            InitializeComponent();
        }

        Tipo_BD bd = new Tipo_BD();

        private void Administrar_Tipos_Load(object sender, EventArgs e)
        {
            refrescar();
        }

        private void refrescar()
        {
            lst_habilitados.DataSource = bd.listar();
            lst_habilitados.DisplayMember = "Tipo";
            lst_habilitados.ValueMember = "Id_tipo";
            lst_deshabilitados.DataSource = bd.listar_bajas();
            lst_deshabilitados.DisplayMember = "Tipo";
            lst_deshabilitados.ValueMember = "Id_tipo";
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lst_habilitados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_habilitados.SelectedItem != null)
            {
                btn_deshabilitar.Enabled = true;
            }
            else
            {
                btn_deshabilitar.Enabled = false;
            }
        }

        private void lst_deshabilitados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_deshabilitados.SelectedItem != null)
            {
                btn_habilitar.Enabled = true;
            }
            else
            {
                btn_habilitar.Enabled = false;
            }
        }

        private void btn_deshabilitar_Click(object sender, EventArgs e)
        {
            if (lst_habilitados.SelectedItem != null)
            {
                bd.deshabilitar_tipo(Convert.ToInt32(lst_habilitados.SelectedValue));
                refrescar();
            }
            else
            {
                MessageBox.Show("Seleccione un tipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_habilitar_Click(object sender, EventArgs e)
        {
            if (lst_deshabilitados.SelectedItem != null)
            {
                bd.habilitar_tipo(Convert.ToInt32(lst_deshabilitados.SelectedValue));
                refrescar();
            }
            else
            {
                MessageBox.Show("Seleccione un tipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
