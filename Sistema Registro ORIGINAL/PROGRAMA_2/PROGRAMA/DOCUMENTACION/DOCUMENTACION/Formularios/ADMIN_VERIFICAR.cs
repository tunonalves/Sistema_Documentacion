using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Usuario = DOCUMENTACION.BD.USUARIO_BD;
using MenuAdmin = DOCUMENTACION.Formularios.MENU_ADMIN;


namespace DOCUMENTACION.Formularios
{
    public partial class ADMIN_VERIFICAR : Form
    {
        public ADMIN_VERIFICAR()
        {
            InitializeComponent();
        }

        Usuario db = new Usuario();

        private void ADMIN_VERIFICAR_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            if ((txt_pass.Text != "") && (txt_user.Text != ""))
            {
                if (db.loguear_User(txt_user.Text, txt_pass.Text) == 1)
                {
                    MENU_ADMIN fMenu = new MenuAdmin();
                    txt_pass.Text = "";
                    txt_user.Text = "";
                    //this.Visible = false;
                    fMenu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (txt_user.Text == "")
                {
                    MessageBox.Show("Ingrese el Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_user.Focus();
                }
                else
                {
                    MessageBox.Show("Ingrese la Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_pass.Focus();
                }
            }
        }

        private void txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.enter(sender, e);
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_login_Click(sender, e);
            }
        }
    }
}
