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
using STOCK = DOCUMENTACION.BD.STOCK_BD;
using DOCUMENTOS = DOCUMENTACION.Clases.Documentos;
using CONTROLADORA = DOCUMENTACION.BD.Controladora;
using PERSONA = DOCUMENTACION.Clases.Persona;
using TIPO_BD = DOCUMENTACION.BD.TIPO_BD;

namespace DOCUMENTACION.Formularios
{
    public partial class CARGAR : Form
    {
        public CARGAR()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CARGAR_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Desea Salir del Formulario??", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (x == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void CARGAR_Load(object sender, EventArgs e)
        {
            TIPO_BD BD = new TIPO_BD();
            comboBox_tipo.DataSource = BD.listar();
            comboBox_tipo.DisplayMember = "Tipo";
            comboBox_tipo.ValueMember = "Id_Tipo";
            limpiar();
        }

        private void limpiar()
        {
            textBox_nombre.Clear();
            textBox_apellido.Clear();
            textBox_codigo.Clear();
            comboBox_tipo.SelectedItem = null;
            dateTime_fecha.Value = DateTime.Today.Date;
            dateTime_fecha.MaxDate = DateTime.Today.Date;
            textBox_nombre.Focus();
            textBox_apellido.Text.Trim();
            textBox_codigo.Text.Trim();
            textBox_nombre.Text.Trim();
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

        private void verifica_casilleros()
        {
            if (textBox_nombre.Text == "")
            {
                textBox_nombre.Focus();
                throw new ArgumentException("Ingrese el Nombre");
            }
            else
            {
                if (textBox_apellido.Text == "")
                {
                    textBox_apellido.Focus();
                    throw new ArgumentException("Ingrese el Apellido");
                }
                else
                {
                    if (textBox_codigo.Text == "")
                    {
                        textBox_codigo.Focus();
                        throw new ArgumentException("Ingrese el Codigo");
                    }
                    else
                    {
                        if (comboBox_tipo.SelectedItem == null)
                        {
                            comboBox_tipo.Focus();
                            throw new ArgumentException("Ingrese el Tipo de Documentacion");
                        }
                    }
                }
            }
        }

        private void textBox_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validarText(e);
            this.enter(sender, e);
        }

        private void textBox_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validarText(e);
            this.enter(sender, e);
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

        private void enter(object sender , KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button_guardar_Click(sender,e);
            }
        }

        private void textBox_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57))
            {
                //MessageBox.Show("SOLO SE PERMITEN NUMEROS");
                e.Handled = true;
            }
            this.enter(sender, e);
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void nUEVACARGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void cargar()
        {
            CONTROLADORA CONECT = new CONTROLADORA();
            STOCK STOCK_BD = new STOCK();
            if (STOCK_BD.verifica_codigo(textBox_codigo.Text) == 1)
            {
                try
                {
                    verifica_casilleros();
                    PERSONA persona = new PERSONA(convertir(textBox_nombre.Text.Trim()), convertir(textBox_apellido.Text.Trim()));
                    DOCUMENTOS doc = new DOCUMENTOS(textBox_codigo.Text.Trim(), persona, dateTime_fecha.Value, Convert.ToInt16(comboBox_tipo.SelectedValue));
                    STOCK_BD.grabar_informacion(doc);
                    limpiar();

                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Error SQL SERVER");
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("El Codigo ingresado ya existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_codigo.Text = "";
                textBox_codigo.Focus();
            }
        }
    }
}
