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
    public partial class MODIFICAR_TIPOS : Form
    {
        public MODIFICAR_TIPOS()
        {
            InitializeComponent();
        }

        Tipo_BD bd = new Tipo_BD();

        private void Modificar_Tipos_Load(object sender, EventArgs e)
        {
            refrescar();
        }

        private void cmb_tipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_nuevo.Enabled = true;
        }

        public string convertir(string texto)
        {
            string aux = "";
            char[] car = texto.ToCharArray();
            for (int i = 0; i < car.Length; i++)
            {
                if (i == 0 || (car[i - 1].ToString() == " "))
                    car[i] = car[i].ToString().ToUpper()[0];
                else
                    car[i] = car[i].ToString().ToLower()[0];
                aux = aux + car[i].ToString();
            }
            return aux;
        }

        private void validarText(KeyPressEventArgs e)
        {
            if ((e.KeyChar < 65) || (e.KeyChar > 90))
            {
                if ((e.KeyChar < 97) || (e.KeyChar > 122))
                {
                    if ((e.KeyChar != 8) && (e.KeyChar != 32))
                    {
                        if ((e.KeyChar != 'Ñ') && (e.KeyChar != 'ñ'))
                        {
                            //MessageBox.Show("SOLO SE PERMITEN LETRAS");
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void refrescar()
        {
            txt_nuevo.Clear();
            cmb_tipos.DataSource = bd.listar_todo();
            cmb_tipos.DisplayMember = "Tipo";
            cmb_tipos.ValueMember = "Id_tipo";
            cmb_tipos.SelectedItem = null;
        }

        private void txt_nuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText(e);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (txt_nuevo.Text != "")
            {
                if (bd.verifica_tipo(txt_nuevo.Text) == 1)
                {
                     DialogResult x = MessageBox.Show("¿Confirmar Modificacion?", "Aceptar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                     if (x == DialogResult.Yes)
                     {
                         bd.modificar_tipo(Convert.ToInt32(cmb_tipos.SelectedValue), convertir(txt_nuevo.Text.Trim()));
                         refrescar();
                     }
                     else
                     {
                         this.Close();
                     }
                }
                else 
                {
                    MessageBox.Show("El tipo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("Ingrese nuevo nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
