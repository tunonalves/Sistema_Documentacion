using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENTREGA_BD = DOCUMENTACION.BD.ENTREGA_BD;
using DOCUMENTO = DOCUMENTACION.Clases.Documentos;
using PERSONA = DOCUMENTACION.Clases.Persona;

namespace DOCUMENTACION.Formularios
{
    public partial class MODIFICAR_ENTREGA : Form
    {
        public MODIFICAR_ENTREGA()
        {
            InitializeComponent();
        }

        ENTREGA_BD ENTREGA = new ENTREGA_BD();

        private void MODIFICAR_ENTREGA_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        private void MODIFICAR_ENTREGA_FormClosing(object sender, FormClosingEventArgs e)
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
            dgv_lista.DataSource = null;
        }

        private void textBox_matricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_num(e);
            this.enter2(sender, e);
        }

        private void textBox_nom_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_text(e);
            this.enter(sender, e);
        }

        private void textBox_ape_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_text(e);
            this.enter(sender, e);
        }

        private void textBox_filtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_num(e);
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

        private void limpiar()
        {
            textBox_ape.Clear();
            textBox_nom.Clear();
            textBox_matricula.Clear();
            datetimepiker_fecha.Value = DateTime.Today.Date;
            datetimepiker_fecha.MaxDate = DateTime.Today.Date;
            radiobutton_codigo.Checked = true;
            radiobutton_nombre_y_apellido.Checked = false;
            textBox_ape.Clear();
            textBox_filtro.Clear();
            textBox_nom.Clear();
            grupbox_modifica.Enabled = false;
            textBox_filtro.Focus();
            textBox_ape.Text.Trim();
            textBox_filtro.Text.Trim();
            textBox_matricula.Text.Trim();
            textBox_nom.Text.Trim();
            grupbox_busca.Enabled = true;
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
                lbl_filtro.Text = "Codigo";
                textBox_ape.Clear();
                textBox_nom.Clear();
            }
        }

        private void dgv_lista_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_lista.SelectedRows.Count > 0)
            {
                grupbox_modifica.Enabled = true;
                textBox_matricula.Text = dgv_lista.SelectedRows[0].Cells["MATRICULA"].Value.ToString();
                datetimepiker_fecha.Value = Convert.ToDateTime(dgv_lista.SelectedRows[0].Cells["FECHA_ENTREGA"].Value);
                datetimepiker_fecha.MinDate =  Convert.ToDateTime(dgv_lista.SelectedRows[0].Cells["FECHA"].Value);
                grupbox_busca.Enabled = false;
            }
        }

        private void update_datagrid()
        {
            dgv_lista.DataSource = ENTREGA.listar_entrega();
            dgv_lista.ClearSelection();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            buscar();
            grupbox_busca.Enabled = false;
        }

        private void button_todos_Click(object sender, EventArgs e)
        {
            update_datagrid();
            grupbox_modifica.Enabled = false;
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            modifica();
        }
                
        private void modifica()
        {
            if (textBox_matricula.Text != "")
            {
                if (datetimepiker_fecha.Value >= Convert.ToDateTime(dgv_lista.SelectedRows[0].Cells["FECHA"].Value))
                {
                    if (datetimepiker_fecha.Value <= DateTime.Today.Date)
                    {
                        ENTREGA.actualiza(Convert.ToString(dgv_lista.SelectedRows[0].Cells["CODIGO"].Value), Convert.ToInt32(textBox_matricula.Text.Trim()), datetimepiker_fecha.Value);
                        update_datagrid();
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("La Fecha no puede ser posterior a:  " + Convert.ToString(DateTime.Today.Date.Day) + "/" + Convert.ToString(DateTime.Today.Date.Month) + "/" + Convert.ToString(DateTime.Today.Date.Year), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La Fecha no puede ser posterior a:  " + dgv_lista.SelectedRows[0].Cells["FECHA"].Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese la Matricula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buscar()
        {
            string fechaReco = "01/01/1900 12:00:00";
            DateTime aux = new DateTime();
            aux = DateTime.Parse(fechaReco);
            int aux2 = 0;
            PERSONA PER = new PERSONA(aux2, convertir(textBox_nom.Text.Trim()), convertir(textBox_ape.Text.Trim()), " ", " ", aux2);
            DOCUMENTO DOC = new DOCUMENTO(textBox_filtro.Text.Trim(), PER, aux, aux, aux2);
            if (textBox_filtro.Text != "")
            {
                if (radiobutton_codigo.Checked == true)
                {
                    dgv_lista.DataSource = ENTREGA.buscar(DOC);
                }
            }
            else
            {
                if (radiobutton_nombre_y_apellido.Checked == true)
                {
                    if ((textBox_ape.Text != "") && (textBox_nom.Text != ""))
                    {
                        dgv_lista.DataSource = ENTREGA.buscar(DOC);
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
    }
}
