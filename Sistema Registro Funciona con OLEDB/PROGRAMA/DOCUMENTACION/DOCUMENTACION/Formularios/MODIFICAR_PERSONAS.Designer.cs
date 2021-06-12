namespace DOCUMENTACION.Formularios
{
    partial class MODIFICAR_PERSONAS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MODIFICAR_PERSONAS));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nUEVAMODIFICACIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sALIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupbox_modifica = new System.Windows.Forms.GroupBox();
            this.textBox_dir_num = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_provincia = new System.Windows.Forms.ComboBox();
            this.textBox_localidad = new System.Windows.Forms.TextBox();
            this.textBox_telefono = new System.Windows.Forms.TextBox();
            this.textBox_domicilio = new System.Windows.Forms.TextBox();
            this.textBox_apellidos = new System.Windows.Forms.TextBox();
            this.textBox_nombres = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_modificar = new System.Windows.Forms.Button();
            this.grupbox_busca = new System.Windows.Forms.GroupBox();
            this.textBox_nom = new System.Windows.Forms.TextBox();
            this.lbl_ape = new System.Windows.Forms.Label();
            this.textBox_ape = new System.Windows.Forms.TextBox();
            this.radiobutton_nombre_y_apellido = new System.Windows.Forms.RadioButton();
            this.button_todos = new System.Windows.Forms.Button();
            this.button_buscar = new System.Windows.Forms.Button();
            this.lbl_filtro = new System.Windows.Forms.Label();
            this.textBox_filtro = new System.Windows.Forms.TextBox();
            this.lbl_buscar = new System.Windows.Forms.Label();
            this.radiobutton_codigo = new System.Windows.Forms.RadioButton();
            this.dgv_lista = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.grupbox_modifica.SuspendLayout();
            this.grupbox_busca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nUEVAMODIFICACIONToolStripMenuItem,
            this.sALIRToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 41);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nUEVAMODIFICACIONToolStripMenuItem
            // 
            this.nUEVAMODIFICACIONToolStripMenuItem.Name = "nUEVAMODIFICACIONToolStripMenuItem";
            this.nUEVAMODIFICACIONToolStripMenuItem.Size = new System.Drawing.Size(255, 37);
            this.nUEVAMODIFICACIONToolStripMenuItem.Text = "NUEVA MODIFICACION";
            this.nUEVAMODIFICACIONToolStripMenuItem.Click += new System.EventHandler(this.nUEVAMODIFICACIONToolStripMenuItem_Click);
            // 
            // sALIRToolStripMenuItem
            // 
            this.sALIRToolStripMenuItem.Name = "sALIRToolStripMenuItem";
            this.sALIRToolStripMenuItem.Size = new System.Drawing.Size(86, 37);
            this.sALIRToolStripMenuItem.Text = "SALIR";
            this.sALIRToolStripMenuItem.Click += new System.EventHandler(this.sALIRToolStripMenuItem_Click);
            // 
            // grupbox_modifica
            // 
            this.grupbox_modifica.Controls.Add(this.textBox_dir_num);
            this.grupbox_modifica.Controls.Add(this.label1);
            this.grupbox_modifica.Controls.Add(this.comboBox_provincia);
            this.grupbox_modifica.Controls.Add(this.textBox_localidad);
            this.grupbox_modifica.Controls.Add(this.textBox_telefono);
            this.grupbox_modifica.Controls.Add(this.textBox_domicilio);
            this.grupbox_modifica.Controls.Add(this.textBox_apellidos);
            this.grupbox_modifica.Controls.Add(this.textBox_nombres);
            this.grupbox_modifica.Controls.Add(this.label7);
            this.grupbox_modifica.Controls.Add(this.label6);
            this.grupbox_modifica.Controls.Add(this.label5);
            this.grupbox_modifica.Controls.Add(this.label4);
            this.grupbox_modifica.Controls.Add(this.label3);
            this.grupbox_modifica.Controls.Add(this.label2);
            this.grupbox_modifica.Controls.Add(this.button_modificar);
            this.grupbox_modifica.Enabled = false;
            this.grupbox_modifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupbox_modifica.Location = new System.Drawing.Point(13, 45);
            this.grupbox_modifica.Margin = new System.Windows.Forms.Padding(4);
            this.grupbox_modifica.Name = "grupbox_modifica";
            this.grupbox_modifica.Padding = new System.Windows.Forms.Padding(4);
            this.grupbox_modifica.Size = new System.Drawing.Size(556, 242);
            this.grupbox_modifica.TabIndex = 110;
            this.grupbox_modifica.TabStop = false;
            this.grupbox_modifica.Text = "MODIFICAR";
            // 
            // textBox_dir_num
            // 
            this.textBox_dir_num.Location = new System.Drawing.Point(470, 93);
            this.textBox_dir_num.Name = "textBox_dir_num";
            this.textBox_dir_num.Size = new System.Drawing.Size(78, 29);
            this.textBox_dir_num.TabIndex = 4;
            this.textBox_dir_num.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_dir_num_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "N°";
            // 
            // comboBox_provincia
            // 
            this.comboBox_provincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_provincia.FormattingEnabled = true;
            this.comboBox_provincia.Location = new System.Drawing.Point(130, 163);
            this.comboBox_provincia.Name = "comboBox_provincia";
            this.comboBox_provincia.Size = new System.Drawing.Size(298, 32);
            this.comboBox_provincia.TabIndex = 6;
            // 
            // textBox_localidad
            // 
            this.textBox_localidad.Location = new System.Drawing.Point(130, 128);
            this.textBox_localidad.Name = "textBox_localidad";
            this.textBox_localidad.Size = new System.Drawing.Size(298, 29);
            this.textBox_localidad.TabIndex = 5;
            this.textBox_localidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_localidad_KeyPress);
            // 
            // textBox_telefono
            // 
            this.textBox_telefono.Location = new System.Drawing.Point(130, 201);
            this.textBox_telefono.Name = "textBox_telefono";
            this.textBox_telefono.Size = new System.Drawing.Size(223, 29);
            this.textBox_telefono.TabIndex = 7;
            this.textBox_telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_telefono_KeyPress);
            // 
            // textBox_domicilio
            // 
            this.textBox_domicilio.Location = new System.Drawing.Point(130, 93);
            this.textBox_domicilio.Name = "textBox_domicilio";
            this.textBox_domicilio.Size = new System.Drawing.Size(298, 29);
            this.textBox_domicilio.TabIndex = 3;
            this.textBox_domicilio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_domicilio_KeyPress);
            // 
            // textBox_apellidos
            // 
            this.textBox_apellidos.Location = new System.Drawing.Point(130, 58);
            this.textBox_apellidos.Name = "textBox_apellidos";
            this.textBox_apellidos.Size = new System.Drawing.Size(298, 29);
            this.textBox_apellidos.TabIndex = 2;
            this.textBox_apellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_apellidos_KeyPress);
            // 
            // textBox_nombres
            // 
            this.textBox_nombres.Location = new System.Drawing.Point(130, 23);
            this.textBox_nombres.Name = "textBox_nombres";
            this.textBox_nombres.Size = new System.Drawing.Size(298, 29);
            this.textBox_nombres.TabIndex = 1;
            this.textBox_nombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_nombres_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Provincia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Localidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Domicilio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Apellidos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombres";
            // 
            // button_modificar
            // 
            this.button_modificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_modificar.Location = new System.Drawing.Point(422, 201);
            this.button_modificar.Margin = new System.Windows.Forms.Padding(4);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(126, 32);
            this.button_modificar.TabIndex = 8;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // grupbox_busca
            // 
            this.grupbox_busca.Controls.Add(this.textBox_nom);
            this.grupbox_busca.Controls.Add(this.lbl_ape);
            this.grupbox_busca.Controls.Add(this.textBox_ape);
            this.grupbox_busca.Controls.Add(this.radiobutton_nombre_y_apellido);
            this.grupbox_busca.Controls.Add(this.button_todos);
            this.grupbox_busca.Controls.Add(this.button_buscar);
            this.grupbox_busca.Controls.Add(this.lbl_filtro);
            this.grupbox_busca.Controls.Add(this.textBox_filtro);
            this.grupbox_busca.Controls.Add(this.lbl_buscar);
            this.grupbox_busca.Controls.Add(this.radiobutton_codigo);
            this.grupbox_busca.Location = new System.Drawing.Point(577, 45);
            this.grupbox_busca.Margin = new System.Windows.Forms.Padding(4);
            this.grupbox_busca.Name = "grupbox_busca";
            this.grupbox_busca.Padding = new System.Windows.Forms.Padding(4);
            this.grupbox_busca.Size = new System.Drawing.Size(424, 242);
            this.grupbox_busca.TabIndex = 109;
            this.grupbox_busca.TabStop = false;
            this.grupbox_busca.Text = "BUSCAR";
            // 
            // textBox_nom
            // 
            this.textBox_nom.Enabled = false;
            this.textBox_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nom.Location = new System.Drawing.Point(123, 115);
            this.textBox_nom.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_nom.Name = "textBox_nom";
            this.textBox_nom.Size = new System.Drawing.Size(293, 29);
            this.textBox_nom.TabIndex = 1;
            this.textBox_nom.Visible = false;
            this.textBox_nom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_nom_KeyPress);
            // 
            // lbl_ape
            // 
            this.lbl_ape.AutoSize = true;
            this.lbl_ape.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ape.Location = new System.Drawing.Point(21, 160);
            this.lbl_ape.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ape.Name = "lbl_ape";
            this.lbl_ape.Size = new System.Drawing.Size(79, 24);
            this.lbl_ape.TabIndex = 9;
            this.lbl_ape.Text = "Apellido";
            this.lbl_ape.Visible = false;
            // 
            // textBox_ape
            // 
            this.textBox_ape.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ape.Location = new System.Drawing.Point(123, 157);
            this.textBox_ape.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ape.Name = "textBox_ape";
            this.textBox_ape.Size = new System.Drawing.Size(293, 29);
            this.textBox_ape.TabIndex = 2;
            this.textBox_ape.Visible = false;
            this.textBox_ape.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ape_KeyPress);
            // 
            // radiobutton_nombre_y_apellido
            // 
            this.radiobutton_nombre_y_apellido.AutoSize = true;
            this.radiobutton_nombre_y_apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobutton_nombre_y_apellido.Location = new System.Drawing.Point(135, 72);
            this.radiobutton_nombre_y_apellido.Margin = new System.Windows.Forms.Padding(4);
            this.radiobutton_nombre_y_apellido.Name = "radiobutton_nombre_y_apellido";
            this.radiobutton_nombre_y_apellido.Size = new System.Drawing.Size(185, 28);
            this.radiobutton_nombre_y_apellido.TabIndex = 0;
            this.radiobutton_nombre_y_apellido.TabStop = true;
            this.radiobutton_nombre_y_apellido.Text = "Nombre y Apellido";
            this.radiobutton_nombre_y_apellido.UseVisualStyleBackColor = true;
            this.radiobutton_nombre_y_apellido.CheckedChanged += new System.EventHandler(this.radiobutton_nombre_y_apellido_CheckedChanged);
            // 
            // button_todos
            // 
            this.button_todos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_todos.Location = new System.Drawing.Point(261, 203);
            this.button_todos.Margin = new System.Windows.Forms.Padding(4);
            this.button_todos.Name = "button_todos";
            this.button_todos.Size = new System.Drawing.Size(92, 31);
            this.button_todos.TabIndex = 4;
            this.button_todos.Text = "Todos";
            this.button_todos.UseVisualStyleBackColor = true;
            this.button_todos.Click += new System.EventHandler(this.button_todos_Click);
            // 
            // button_buscar
            // 
            this.button_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_buscar.Location = new System.Drawing.Point(76, 203);
            this.button_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(112, 31);
            this.button_buscar.TabIndex = 3;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // lbl_filtro
            // 
            this.lbl_filtro.AutoSize = true;
            this.lbl_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_filtro.Location = new System.Drawing.Point(21, 119);
            this.lbl_filtro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_filtro.Name = "lbl_filtro";
            this.lbl_filtro.Size = new System.Drawing.Size(85, 24);
            this.lbl_filtro.TabIndex = 4;
            this.lbl_filtro.Text = "Matricula";
            // 
            // textBox_filtro
            // 
            this.textBox_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_filtro.Location = new System.Drawing.Point(123, 116);
            this.textBox_filtro.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_filtro.Name = "textBox_filtro";
            this.textBox_filtro.Size = new System.Drawing.Size(293, 29);
            this.textBox_filtro.TabIndex = 1;
            this.textBox_filtro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_filtro_KeyPress);
            // 
            // lbl_buscar
            // 
            this.lbl_buscar.AutoSize = true;
            this.lbl_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_buscar.Location = new System.Drawing.Point(82, 30);
            this.lbl_buscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_buscar.Name = "lbl_buscar";
            this.lbl_buscar.Size = new System.Drawing.Size(106, 24);
            this.lbl_buscar.TabIndex = 2;
            this.lbl_buscar.Text = "Buscar por:";
            // 
            // radiobutton_codigo
            // 
            this.radiobutton_codigo.AutoSize = true;
            this.radiobutton_codigo.Checked = true;
            this.radiobutton_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobutton_codigo.Location = new System.Drawing.Point(24, 72);
            this.radiobutton_codigo.Margin = new System.Windows.Forms.Padding(4);
            this.radiobutton_codigo.Name = "radiobutton_codigo";
            this.radiobutton_codigo.Size = new System.Drawing.Size(103, 28);
            this.radiobutton_codigo.TabIndex = 0;
            this.radiobutton_codigo.TabStop = true;
            this.radiobutton_codigo.Text = "Matricula";
            this.radiobutton_codigo.UseVisualStyleBackColor = true;
            // 
            // dgv_lista
            // 
            this.dgv_lista.AllowUserToAddRows = false;
            this.dgv_lista.AllowUserToDeleteRows = false;
            this.dgv_lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_lista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_lista.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgv_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_lista.Location = new System.Drawing.Point(13, 295);
            this.dgv_lista.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_lista.MultiSelect = false;
            this.dgv_lista.Name = "dgv_lista";
            this.dgv_lista.ReadOnly = true;
            this.dgv_lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_lista.Size = new System.Drawing.Size(988, 428);
            this.dgv_lista.TabIndex = 108;
            this.dgv_lista.SelectionChanged += new System.EventHandler(this.dgv_lista_SelectionChanged);
            // 
            // MODIFICAR_PERSONAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.grupbox_modifica);
            this.Controls.Add(this.grupbox_busca);
            this.Controls.Add(this.dgv_lista);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MODIFICAR_PERSONAS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Personas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MODIFICAR_PERSONAS_FormClosing);
            this.Load += new System.EventHandler(this.MODIFICAR_PERSONAS_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grupbox_modifica.ResumeLayout(false);
            this.grupbox_modifica.PerformLayout();
            this.grupbox_busca.ResumeLayout(false);
            this.grupbox_busca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nUEVAMODIFICACIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sALIRToolStripMenuItem;
        private System.Windows.Forms.GroupBox grupbox_modifica;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.GroupBox grupbox_busca;
        private System.Windows.Forms.TextBox textBox_nom;
        private System.Windows.Forms.Label lbl_ape;
        private System.Windows.Forms.TextBox textBox_ape;
        private System.Windows.Forms.RadioButton radiobutton_nombre_y_apellido;
        private System.Windows.Forms.Button button_todos;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Label lbl_filtro;
        private System.Windows.Forms.TextBox textBox_filtro;
        private System.Windows.Forms.Label lbl_buscar;
        private System.Windows.Forms.RadioButton radiobutton_codigo;
        private System.Windows.Forms.DataGridView dgv_lista;
        private System.Windows.Forms.ComboBox comboBox_provincia;
        private System.Windows.Forms.TextBox textBox_localidad;
        private System.Windows.Forms.TextBox textBox_telefono;
        private System.Windows.Forms.TextBox textBox_domicilio;
        private System.Windows.Forms.TextBox textBox_apellidos;
        private System.Windows.Forms.TextBox textBox_nombres;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_dir_num;
        private System.Windows.Forms.Label label1;
    }
}