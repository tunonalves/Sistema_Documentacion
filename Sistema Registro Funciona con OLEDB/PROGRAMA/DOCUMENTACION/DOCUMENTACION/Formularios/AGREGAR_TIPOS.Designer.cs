namespace DOCUMENTACION.Formularios
{
    partial class AGREGAR_TIPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AGREGAR_TIPOS));
            this.grp_tipos = new System.Windows.Forms.GroupBox();
            this.txt_tipo = new System.Windows.Forms.TextBox();
            this.lbl_tipos = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.grp_tipos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_tipos
            // 
            this.grp_tipos.Controls.Add(this.txt_tipo);
            this.grp_tipos.Controls.Add(this.lbl_tipos);
            this.grp_tipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_tipos.Location = new System.Drawing.Point(15, 15);
            this.grp_tipos.Margin = new System.Windows.Forms.Padding(6);
            this.grp_tipos.Name = "grp_tipos";
            this.grp_tipos.Padding = new System.Windows.Forms.Padding(6);
            this.grp_tipos.Size = new System.Drawing.Size(454, 90);
            this.grp_tipos.TabIndex = 0;
            this.grp_tipos.TabStop = false;
            this.grp_tipos.Text = "Tipos";
            // 
            // txt_tipo
            // 
            this.txt_tipo.Location = new System.Drawing.Point(178, 40);
            this.txt_tipo.Name = "txt_tipo";
            this.txt_tipo.Size = new System.Drawing.Size(267, 29);
            this.txt_tipo.TabIndex = 1;
            this.txt_tipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tipo_KeyPress);
            // 
            // lbl_tipos
            // 
            this.lbl_tipos.AutoSize = true;
            this.lbl_tipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipos.Location = new System.Drawing.Point(11, 43);
            this.lbl_tipos.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_tipos.Name = "lbl_tipos";
            this.lbl_tipos.Size = new System.Drawing.Size(153, 24);
            this.lbl_tipos.TabIndex = 0;
            this.lbl_tipos.Text = "Nombre del Tipo";
            // 
            // btn_ok
            // 
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(220, 117);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(6);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(120, 35);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "Confirmar";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.Location = new System.Drawing.Point(349, 117);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(6);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(120, 35);
            this.btn_salir.TabIndex = 3;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // Agregar_Tipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(484, 162);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.grp_tipos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Agregar_Tipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Tipos";
            this.grp_tipos.ResumeLayout(false);
            this.grp_tipos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_tipos;
        private System.Windows.Forms.Label lbl_tipos;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TextBox txt_tipo;
    }
}