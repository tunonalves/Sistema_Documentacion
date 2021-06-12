namespace DOCUMENTACION.Formularios
{
    partial class MODIFICAR_TIPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MODIFICAR_TIPOS));
            this.grp_tipos = new System.Windows.Forms.GroupBox();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.txt_nuevo = new System.Windows.Forms.TextBox();
            this.lbl_nuevo = new System.Windows.Forms.Label();
            this.lbl_tipos = new System.Windows.Forms.Label();
            this.cmb_tipos = new System.Windows.Forms.ComboBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.grp_tipos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_tipos
            // 
            this.grp_tipos.Controls.Add(this.btn_modificar);
            this.grp_tipos.Controls.Add(this.txt_nuevo);
            this.grp_tipos.Controls.Add(this.lbl_nuevo);
            this.grp_tipos.Controls.Add(this.lbl_tipos);
            this.grp_tipos.Controls.Add(this.cmb_tipos);
            this.grp_tipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_tipos.Location = new System.Drawing.Point(15, 15);
            this.grp_tipos.Margin = new System.Windows.Forms.Padding(6);
            this.grp_tipos.Name = "grp_tipos";
            this.grp_tipos.Padding = new System.Windows.Forms.Padding(6);
            this.grp_tipos.Size = new System.Drawing.Size(504, 174);
            this.grp_tipos.TabIndex = 0;
            this.grp_tipos.TabStop = false;
            this.grp_tipos.Text = "Tipos";
            // 
            // btn_modificar
            // 
            this.btn_modificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_modificar.Location = new System.Drawing.Point(387, 133);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(108, 32);
            this.btn_modificar.TabIndex = 4;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // txt_nuevo
            // 
            this.txt_nuevo.Enabled = false;
            this.txt_nuevo.Location = new System.Drawing.Point(218, 82);
            this.txt_nuevo.Name = "txt_nuevo";
            this.txt_nuevo.Size = new System.Drawing.Size(277, 29);
            this.txt_nuevo.TabIndex = 3;
            this.txt_nuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nuevo_KeyPress);
            // 
            // lbl_nuevo
            // 
            this.lbl_nuevo.AutoSize = true;
            this.lbl_nuevo.Location = new System.Drawing.Point(12, 87);
            this.lbl_nuevo.Name = "lbl_nuevo";
            this.lbl_nuevo.Size = new System.Drawing.Size(140, 24);
            this.lbl_nuevo.TabIndex = 2;
            this.lbl_nuevo.Text = "Nuevo Nombre";
            // 
            // lbl_tipos
            // 
            this.lbl_tipos.AutoSize = true;
            this.lbl_tipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipos.Location = new System.Drawing.Point(12, 35);
            this.lbl_tipos.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_tipos.Name = "lbl_tipos";
            this.lbl_tipos.Size = new System.Drawing.Size(148, 24);
            this.lbl_tipos.TabIndex = 1;
            this.lbl_tipos.Text = "Seleccione Tipo";
            // 
            // cmb_tipos
            // 
            this.cmb_tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_tipos.FormattingEnabled = true;
            this.cmb_tipos.Location = new System.Drawing.Point(218, 35);
            this.cmb_tipos.Margin = new System.Windows.Forms.Padding(6);
            this.cmb_tipos.Name = "cmb_tipos";
            this.cmb_tipos.Size = new System.Drawing.Size(274, 32);
            this.cmb_tipos.TabIndex = 0;
            this.cmb_tipos.SelectedIndexChanged += new System.EventHandler(this.cmb_tipos_SelectedIndexChanged);
            // 
            // btn_salir
            // 
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.Location = new System.Drawing.Point(402, 219);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(108, 31);
            this.btn_salir.TabIndex = 1;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // Modificar_Tipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(534, 262);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.grp_tipos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Modificar_Tipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Tipos";
            this.Load += new System.EventHandler(this.Modificar_Tipos_Load);
            this.grp_tipos.ResumeLayout(false);
            this.grp_tipos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_tipos;
        private System.Windows.Forms.Label lbl_tipos;
        private System.Windows.Forms.ComboBox cmb_tipos;
        private System.Windows.Forms.TextBox txt_nuevo;
        private System.Windows.Forms.Label lbl_nuevo;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.Button btn_salir;

    }
}