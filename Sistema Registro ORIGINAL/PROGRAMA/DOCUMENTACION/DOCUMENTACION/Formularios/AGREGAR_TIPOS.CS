using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TIPO_BD = DOCUMENTACION.BD.TIPO_BD;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DOCUMENTACION.Formularios
{
    public partial class AGREGAR_TIPOS : Form
    {
        public AGREGAR_TIPOS()
        {
            InitializeComponent();
        }

        TIPO_BD bd = new TIPO_BD();

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_tipo.Text != "")
            {
                try
                {
                    if (bd.verifica_tipo(txt_tipo.Text) == 1)
                    {
                        DialogResult x = MessageBox.Show("¿Confirmar Ingreso?", "Aceptar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (x == DialogResult.Yes)
                        {
                            bd.agregar_tipo(convertir(txt_tipo.Text.Trim()));
                            txt_tipo.Clear();
                            txt_tipo.Focus();
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
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txt_tipo.Text = "";
            }
            else
            {
                MessageBox.Show("Complete el nombre del Tipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txt_tipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText(e);
        }
        
    }
}
