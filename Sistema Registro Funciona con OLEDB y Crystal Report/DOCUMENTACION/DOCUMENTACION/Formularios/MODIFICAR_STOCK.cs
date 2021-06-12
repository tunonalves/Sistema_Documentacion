using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STOCK_BD = DOCUMENTACION.BD.STOCK_BD;
using DOCUMENTO = DOCUMENTACION.Clases.Documentos;
using PERSONA = DOCUMENTACION.Clases.Persona;
using TIPO_BD = DOCUMENTACION.BD.TIPO_BD;

namespace DOCUMENTACION.Formularios
{
    public partial class MODIFICAR_STOCK : Form
    {
        STOCK_BD stock_bd = new STOCK_BD();
        TIPO_BD Tipos_BD = new TIPO_BD();

        public MODIFICAR_STOCK()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MODIFICAR_STOCK_Load(object sender, EventArgs e)
        {
            comboBox_tipo.DataSource = Tipos_BD.listar();
            comboBox_tipo.DisplayMember = "Tipo";
            comboBox_tipo.ValueMember = "Id_Tipo";
            limpiar();
        }

        private void MODIFICAR_STOCK_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Desea Salir del Formulario??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (x == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }
        private void limpiar()
        {
            textBox_ape.Clear();
            textBox_apellido.Clear();
            textBox_nom.Clear();
            textBox_nombre.Clear();
            datetimepiker_fecha.Value = DateTime.Today.Date;
            datetimepiker_fecha.MaxDate = DateTime.Today.Date;
            radiobutton_codigo.Checked = true;
            radiobutton_nombre_y_apellido.Checked = false;
            textBox_ape.Clear();
            textBox_filtro.Clear();
            textBox_nom.Clear();
            grupbox_modifica.Enabled = false;
            comboBox_tipo.SelectedItem = null;
            textBox_filtro.Focus();
            textBox_ape.Text.Trim();
            textBox_apellido.Text.Trim();
            textBox_filtro.Text.Trim();
            textBox_nom.Text.Trim();
            textBox_nombre.Text.Trim();
            limpiar_datetime();
            grupbox_busca.Enabled = true;
        }

        private void nUEVAMODIFICACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            dgv_lista.DataSource = null;
        }

        private void textBox_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText(e);
            this.enter2(sender, e);
        }

        private void textBox_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText(e);
            this.enter2(sender, e);
        }

        private void textBox_filtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57))
            {
                //MessageBox.Show("SOLO SE PERMITEN NUMEROS");
                e.Handled = true;
            }
            this.enter(sender, e);
        }

        private void textBox_nom_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText(e);
            this.enter(sender, e);
        }

        private void textBox_ape_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarText(e);
            this.enter(sender, e);
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button_buscar_Click(sender, e);
            }
        }

        private void enter2(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button_modificar_Click(sender, e);
            }
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

        private void dgv_lista_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgv_lista.SelectedRows.Count > 0)
            {
                grupbox_modifica.Enabled = true;
                textBox_apellido.Text = dgv_lista.SelectedRows[0].Cells["APELLIDOS"].Value.ToString();
                textBox_nombre.Text = dgv_lista.SelectedRows[0].Cells["NOMBRES"].Value.ToString();
                datetimepiker_fecha.Value = Convert.ToDateTime(dgv_lista.SelectedRows[0].Cells["FECHA"].Value);
                comboBox_tipo.SelectedValue = Tipos_BD.get_idTipos(dgv_lista.SelectedRows[0].Cells["TIPO"].Value.ToString());
                grupbox_busca.Enabled = false;
            }

        }

        private void radiobutton_nombre_y_apellido_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_nombre_y_apellido.Checked == true)
            {
                lbl_ape.Visible = true;
                textBox_ape.Visible = true;
                textBox_ape.Enabled = true;
                textBox_nom.Visible = true;
                textBox_nom.Enabled = true;
                textBox_filtro.Visible = false;
                textBox_filtro.Enabled = false;
                lbl_filtro.Text = "Nombres";
                textBox_filtro.Clear();
            }
            else
            {
                lbl_ape.Visible = false;
                textBox_ape.Visible = false;
                textBox_ape.Enabled = false;
                textBox_nom.Visible = false;
                textBox_nom.Enabled = false;
                textBox_filtro.Visible = true;
                textBox_filtro.Enabled = true;
                lbl_filtro.Text = "Codigo";
                textBox_ape.Clear();
                textBox_nom.Clear();
            }
        }

        private void update_datagrid()
        {
            dgv_lista.DataSource = stock_bd.devolver_todo();
            dgv_lista.ClearSelection();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            busca();
            grupbox_busca.Enabled = false;
        }

        private void button_todos_Click(object sender, EventArgs e)
        {
            update_datagrid();
            grupbox_modifica.Enabled = false;
            textBox_nom.Text = "";
            textBox_ape.Text = "";
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            modificar();
        }

        private void limpiar_datetime()
        {
            datetimepiker_fecha.Format = DateTimePickerFormat.Custom;
            datetimepiker_fecha.CustomFormat = " ";
        }

        private void datetimepiker_fecha_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepiker_fecha.Format == DateTimePickerFormat.Custom)
            {
                datetimepiker_fecha.Format = DateTimePickerFormat.Long;
            }
        }

        private void busca()
        {
            string fechaReco = "01/01/1900 12:00:00";
            DateTime aux = new DateTime();
            aux = DateTime.Parse(fechaReco);
            PERSONA PER = new PERSONA(convertir(textBox_nom.Text.Trim()), convertir(textBox_ape.Text.Trim()));
            DOCUMENTO DOC = new DOCUMENTO(textBox_filtro.Text.Trim(), PER, aux, Convert.ToInt16(comboBox_tipo.SelectedValue));
            if (textBox_filtro.Text != "")
            {
                if (radiobutton_codigo.Checked == true)
                {
                    dgv_lista.DataSource = stock_bd.buscar(DOC);
                }
            }
            else
            {
                if (radiobutton_nombre_y_apellido.Checked == true)
                {
                    if ((textBox_ape.Text != "") && (textBox_nom.Text != ""))
                    {
                        dgv_lista.DataSource = stock_bd.buscar(DOC);
                        grupbox_modifica.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese el Nombre y el Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el Codigo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void modificar()
        {
            if ((textBox_apellido.Text != "") && (textBox_nombre.Text != ""))
            {
                if (datetimepiker_fecha.Value <= DateTime.Today.Date)
                {
                    if (comboBox_tipo.SelectedItem != null)
                    {
                        PERSONA PER = new PERSONA(textBox_nombre.Text.Trim(), textBox_apellido.Text.Trim());
                        DOCUMENTO DOC = new DOCUMENTO(Convert.ToString(dgv_lista.SelectedRows[0].Cells["CODIGO"].Value), PER, datetimepiker_fecha.Value, Convert.ToInt16(comboBox_tipo.SelectedValue));
                        stock_bd.actualiza(DOC);
                        update_datagrid();
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione el Tipo de Documentación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La Fecha no puede ser posterior a:  " + Convert.ToString(DateTime.Today.Date.Day) + "/" + Convert.ToString(DateTime.Today.Date.Month) + "/" + Convert.ToString(DateTime.Today.Date.Year), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
