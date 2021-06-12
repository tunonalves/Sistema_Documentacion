using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using ENTREGA_BD = DOCUMENTACION.BD.ENTREGA_BD;
using PERSONA = DOCUMENTACION.Clases.Persona;
using DOCUMENTO = DOCUMENTACION.Clases.Documentos;
using PROVINCIAS = DOCUMENTACION.BD.PROVINCIAS_BD;
using STOCK_BD = DOCUMENTACION.BD.STOCK_BD;

namespace DOCUMENTACION.Formularios
{
    public partial class ENTREGAR : Form
    {
        public ENTREGAR()
        {
            InitializeComponent();
        }
        
        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ENTREGAR_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Desea Salir del Formulario??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (x == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            busca();
        }

        private void ENTREGAR_Load(object sender, EventArgs e)
        {
           PROVINCIAS PROVINCIA = new PROVINCIAS();
           comboBox_provincia.DataSource = PROVINCIA.lista_provincia();
           comboBox_provincia.DisplayMember = "Provincias";
           comboBox_provincia.ValueMember = "Id_provincia";
           Limpiar();
        }

        private void Limpiar()
        {
            groupBox2.Enabled = false;
            dataGridView1.Enabled = false;
            groupBox1.Enabled = true;
            textBox_codigo.Clear();
            textBox_matricula.Clear();
            textBox_direccion.Clear();
            textBox_telefono.Clear();
            textBox_cod_area.Clear();
            textBox_dir_nro.Clear();
            textBox_codigo.Focus();
            dataGridView1.DataSource = false;
            textBox_codigo.Text.Trim();
            textBox_direccion.Text.Trim();
            textBox_matricula.Text.Trim();
            textBox_telefono.Text.Trim();
            textBox_cod_area.Text.Trim();
            textBox_dir_nro.Text.Trim();
            textBox_localidad.Text = "Mar del Plata";
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

        private void textBox_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText_num(e);
            enter(sender, e);
        }

        private void textBox_matricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText_num(e);
        }
        
        private void textBox_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText_num(e);
        }

        private void textBox_direccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText_dir(e);
        }

        private void textBox_localidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText_letra(e);
        }

        private void textBox_provincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText_letra(e);
        }

        private void textBox_cod_area_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText_num(e);
        }

        private void textBox_dir_nro_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText_num(e);
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button_select_Click(sender, e);
            }
        }

        private void validarText_letra(KeyPressEventArgs e)
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

        private void validarText_dir(KeyPressEventArgs e)
        {
            if ((((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57))
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
        }

        private void validarText_num(KeyPressEventArgs e)
        {
            if ((((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57))
            {
                //MessageBox.Show("SOLO SE PERMITEN NUMEROS");
                e.Handled = true;
            }
        }

        private void iNICIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void button_entregar_Click(object sender, EventArgs e)
        {
            entrega();
        }

        private void entrega()
        {
            ENTREGA_BD ENTREGA = new ENTREGA_BD();
            string aux_tel = " ";
            string aux_dir = " ";
            aux_tel = textBox_cod_area.Text.Trim() + textBox_telefono.Text.Trim();
            aux_dir = textBox_direccion.Text.Trim() + "  N° " + textBox_dir_nro.Text.Trim();
            try
            {
                verifica_txt();
                PERSONA PER = new PERSONA(Convert.ToInt32(textBox_matricula.Text.Trim()),convertir(aux_dir.Trim()),convertir(textBox_localidad.Text.Trim()),Convert.ToInt16(comboBox_provincia.SelectedValue), Convert.ToInt64(aux_tel));
                DialogResult x = MessageBox.Show("¿Confirmar Entrega?", "Aceptar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (x == DialogResult.Yes)
                {

                    ENTREGA.entregar(textBox_codigo.Text.Trim(), PER);
                    Limpiar();
                }
                else
                {
                    Limpiar();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException)
            {
                MessageBox.Show("Error SQL SERVER");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void verifica_txt()
        {
            if (textBox_matricula.Text == "")
            {
                textBox_matricula.Focus();
                throw new ArgumentException("Complete la Matricula");
            }
            else
            {
                if (textBox_direccion.Text == "")
                {
                    textBox_direccion.Focus();
                    throw new ArgumentException("Complete el Domicilio");
                }
                else
                {
                    if (textBox_dir_nro.Text == "")
                    {
                        textBox_dir_nro.Focus();
                        throw new ArgumentException("Complete la numeracion del Domicilio");
                    }
                    else
                    {
                        if (textBox_localidad.Text == "")
                        {
                            textBox_localidad.Focus();
                            throw new ArgumentException("Complete la Localidad");
                        }
                    }
                }
            }
        }

        private void busca()
        {
            STOCK_BD stock_bd = new STOCK_BD();
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            dataGridView1.Enabled = true;
            dataGridView1.DataSource = stock_bd.buscar_entrega_codigo(textBox_codigo.Text.Trim());
            textBox_matricula.Focus();
        }
    }
}
