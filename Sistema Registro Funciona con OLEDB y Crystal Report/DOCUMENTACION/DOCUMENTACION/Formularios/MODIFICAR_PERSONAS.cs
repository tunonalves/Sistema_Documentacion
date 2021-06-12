using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PERSONA = DOCUMENTACION.Clases.Persona;
using PERSONAS_BD = DOCUMENTACION.BD.PERSONA_BD;
using PROVINCIAS = DOCUMENTACION.BD.PROVINCIAS_BD;

namespace DOCUMENTACION.Formularios
{
    public partial class MODIFICAR_PERSONAS : Form
    {
        public MODIFICAR_PERSONAS()
        {
            InitializeComponent();
        }

        PERSONAS_BD PERSONAS = new PERSONAS_BD();
        PROVINCIAS PROVINCIA = new PROVINCIAS();

        private void MODIFICAR_PERSONAS_Load(object sender, EventArgs e)
        {
            comboBox_provincia.DataSource = PROVINCIA.lista_provincia();
            comboBox_provincia.DisplayMember = "Provincias";
            comboBox_provincia.ValueMember = "Id_provincia";
            limpiar();
        }

        private void MODIFICAR_PERSONAS_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Desea Salir del Formulario??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (x == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nUEVAMODIFICACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button_todos_Click(object sender, EventArgs e)
        {
            update_datagrid();
            grupbox_modifica.Enabled = false;
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            buscar();
            grupbox_busca.Enabled = false;
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            modifica();
        }

        private void textBox_nom_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_text(e);
            enter(sender, e);
        }

        private void textBox_ape_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_text(e);
            enter(sender, e);
        }

        private void textBox_filtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_num(e);
            enter(sender, e);
        }

        private void textBox_nombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_text(e);
            enter2(sender, e);
        }

        private void textBox_apellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_text(e);
            enter2(sender, e);
        }

        private void textBox_domicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_text(e);
            enter2(sender, e);
        }

        private void textBox_dir_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_num(e);
            enter2(sender, e);
        }

        private void textBox_localidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_text(e);
            enter2(sender, e);
        }

        private void textBox_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_num(e);
            enter2(sender, e);
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
                lbl_filtro.Text = "Nombre";
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
                lbl_filtro.Text = "Matricula";
                textBox_ape.Clear();
                textBox_nom.Clear();
            }
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

        private void validar_text(KeyPressEventArgs e)
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

        private void validar_num(KeyPressEventArgs e)
        {
            if ((((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57))
            {
                //MessageBox.Show("SOLO SE PERMITEN NUMEROS");
                e.Handled = true;
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

        private string[] verifica_domicilio(string dato)
        {
            string[] devolucion = new string[2];
            char[] aux = dato.ToCharArray();
            string dom = "";
            string num = "";
            char flag = '0';
            for (int i = aux.Length - 1; i >= 0; i--)
            {
                if ((aux[i] != 'N') && (aux[i] != '°'))
                {
                    if ((flag == '0') && (aux[i] != ' '))
                    {
                        num = aux[i] + num;
                    }
                    else
                    {
                        if (flag == '1')
                        {
                            dom = aux[i] + dom;
                        }
                    }
                }
                else
                {
                    if (aux[i] == '°')
                    {
                        flag = '1';
                    }
                }
            }
            devolucion[0] = dom;
            devolucion[1] = num;
            return devolucion;
        }

        private void limpiar()
        {
            textBox_ape.Clear();
            textBox_nom.Clear();
            textBox_filtro.Clear();
            textBox_apellidos.Clear();
            textBox_domicilio.Clear();
            textBox_dir_num.Clear();
            textBox_localidad.Clear();
            textBox_nombres.Clear();
            textBox_telefono.Clear();
            radiobutton_codigo.Checked = true;
            radiobutton_nombre_y_apellido.Checked = false;
            dgv_lista.DataSource = null;
            comboBox_provincia.SelectedItem = null;
            grupbox_modifica.Enabled = false;
            textBox_filtro.Focus();
            grupbox_busca.Enabled = true;
        }

        private void dgv_lista_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_lista.SelectedRows.Count > 0)
            {
                grupbox_modifica.Enabled = true;
                textBox_apellidos.Text = dgv_lista.SelectedRows[0].Cells["APELLIDOS"].Value.ToString();
                textBox_nombres.Text = dgv_lista.SelectedRows[0].Cells["NOMBRES"].Value.ToString();
                string[] aux = this.verifica_domicilio(dgv_lista.SelectedRows[0].Cells["DIRECCION"].Value.ToString());
                textBox_domicilio.Text = aux[0];
                textBox_dir_num.Text = aux[1];
                comboBox_provincia.SelectedValue = PROVINCIA.get_idProvincia(dgv_lista.SelectedRows[0].Cells["PROVINCIAS"].Value.ToString());
                textBox_localidad.Text = dgv_lista.SelectedRows[0].Cells["LOCALIDAD"].Value.ToString();
                textBox_telefono.Text = dgv_lista.SelectedRows[0].Cells["TELEFONO"].Value.ToString();
                grupbox_busca.Enabled = false;

            }
        }

        private void update_datagrid()
        {
            dgv_lista.DataSource = PERSONAS.devolver_persona();
            dgv_lista.ClearSelection();
        }

        private void buscar()
        {
            if (textBox_filtro.Text != "")
            {
                if (radiobutton_codigo.Checked == true)
                {
                    PERSONA PER = new PERSONA(Convert.ToInt32(textBox_filtro.Text.Trim()));
                    dgv_lista.DataSource = PERSONAS.buscar(PER);
                }
            }
            else
            {
                if (radiobutton_nombre_y_apellido.Checked == true)
                {
                    if ((textBox_ape.Text != "") && (textBox_nom.Text != ""))
                    {
                        PERSONA PER = new PERSONA(textBox_nom.Text.Trim(), textBox_ape.Text.Trim());
                        dgv_lista.DataSource = PERSONAS.buscar(PER);
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

        private void modifica()
        {
            if (textBox_nombres.Text != "")
            {
                if (textBox_apellidos.Text != "")
                {
                    if ((textBox_domicilio.Text != "") && (textBox_dir_num.Text != ""))
                    {
                        if (textBox_localidad.Text != "")
                        {
                            if (textBox_telefono.Text != "")
                            {
                                if (comboBox_provincia.SelectedItem != null)
                                {
                                    string aux = textBox_domicilio.Text.Trim() + "  N° " + textBox_dir_num.Text.Trim();
                                    PERSONA PER = new PERSONA(Convert.ToInt32(dgv_lista.SelectedRows[0].Cells["DNI"].Value), convertir(textBox_nombres.Text.Trim()), convertir(textBox_apellidos.Text.Trim()), convertir(aux), convertir(textBox_localidad.Text.Trim()), Convert.ToInt16(comboBox_provincia.SelectedValue), Convert.ToInt64(textBox_telefono.Text.Trim()));
                                    PERSONAS.actualiza(PER);
                                    update_datagrid();
                                    limpiar();
                                }
                                else
                                {
                                    MessageBox.Show("Ingrese la Provincia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ingrese el Telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese la Localidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese el Domicilio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese el Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
