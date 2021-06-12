namespace DOCUMENTACION.Formularios
{
    partial class ADMINISTRAR_TIPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADMINISTRAR_TIPOS));
            this.grp_habilitados = new System.Windows.Forms.GroupBox();
            this.lst_habilitados = new System.Windows.Forms.ListBox();
            this.btn_deshabilitar = new System.Windows.Forms.Button();
            this.grp_deshabilitados = new System.Windows.Forms.GroupBox();
            this.lst_deshabilitados = new System.Windows.Forms.ListBox();
            this.btn_habilitar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.grp_habilitados.SuspendLayout();
            this.grp_deshabilitados.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_habilitados
            // 
            this.grp_habilitados.Controls.Add(this.lst_habilitados);
            this.grp_habilitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_habilitados.Location = new System.Drawing.Point(22, 22);
            this.grp_habilitados.Margin = new System.Windows.Forms.Padding(6);
            this.grp_habilitados.Name = "grp_habilitados";
            this.grp_habilitados.Padding = new System.Windows.Forms.Padding(6);
            this.grp_habilitados.Size = new System.Drawing.Size(324, 305);
            this.grp_habilitados.TabIndex = 0;
            this.grp_habilitados.TabStop = false;
            this.grp_habilitados.Text = "Habilitados";
            // 
            // lst_habilitados
            // 
            this.lst_habilitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_habilitados.FormattingEnabled = true;
            this.lst_habilitados.ItemHeight = 24;
            this.lst_habilitados.Location = new System.Drawing.Point(39, 35);
            this.lst_habilitados.Margin = new System.Windows.Forms.Padding(6);
            this.lst_habilitados.Name = "lst_habilitados";
            this.lst_habilitados.Size = new System.Drawing.Size(248, 244);
            this.lst_habilitados.TabIndex = 0;
            this.lst_habilitados.SelectedIndexChanged += new System.EventHandler(this.lst_habilitados_SelectedIndexChanged);
            // 
            // btn_deshabilitar
            // 
            this.btn_deshabilitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_deshabilitar.Enabled = false;
            this.btn_deshabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deshabilitar.Location = new System.Drawing.Point(358, 127);
            this.btn_deshabilitar.Margin = new System.Windows.Forms.Padding(6);
            this.btn_deshabilitar.Name = "btn_deshabilitar";
            this.btn_deshabilitar.Size = new System.Drawing.Size(70, 42);
            this.btn_deshabilitar.TabIndex = 2;
            this.btn_deshabilitar.Text = ">>";
            this.btn_deshabilitar.UseVisualStyleBackColor = true;
            this.btn_deshabilitar.Click += new System.EventHandler(this.btn_deshabilitar_Click);
            // 
            // grp_deshabilitados
            // 
            this.grp_deshabilitados.Controls.Add(this.lst_deshabilitados);
            this.grp_deshabilitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_deshabilitados.Location = new System.Drawing.Point(440, 22);
            this.grp_deshabilitados.Margin = new System.Windows.Forms.Padding(6);
            this.grp_deshabilitados.Name = "grp_deshabilitados";
            this.grp_deshabilitados.Padding = new System.Windows.Forms.Padding(6);
            this.grp_deshabilitados.Size = new System.Drawing.Size(319, 305);
            this.grp_deshabilitados.TabIndex = 1;
            this.grp_deshabilitados.TabStop = false;
            this.grp_deshabilitados.Text = "Deshabilitados";
            // 
            // lst_deshabilitados
            // 
            this.lst_deshabilitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_deshabilitados.FormattingEnabled = true;
            this.lst_deshabilitados.ItemHeight = 24;
            this.lst_deshabilitados.Location = new System.Drawing.Point(41, 35);
            this.lst_deshabilitados.Margin = new System.Windows.Forms.Padding(6);
            this.lst_deshabilitados.Name = "lst_deshabilitados";
            this.lst_deshabilitados.Size = new System.Drawing.Size(248, 244);
            this.lst_deshabilitados.TabIndex = 0;
            this.lst_deshabilitados.SelectedIndexChanged += new System.EventHandler(this.lst_deshabilitados_SelectedIndexChanged);
            // 
            // btn_habilitar
            // 
            this.btn_habilitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_habilitar.Enabled = false;
            this.btn_habilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_habilitar.Location = new System.Drawing.Point(358, 181);
            this.btn_habilitar.Margin = new System.Windows.Forms.Padding(6);
            this.btn_habilitar.Name = "btn_habilitar";
            this.btn_habilitar.Size = new System.Drawing.Size(70, 42);
            this.btn_habilitar.TabIndex = 3;
            this.btn_habilitar.Text = "<<";
            this.btn_habilitar.UseVisualStyleBackColor = true;
            this.btn_habilitar.Click += new System.EventHandler(this.btn_habilitar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.Location = new System.Drawing.Point(622, 367);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(6);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(138, 42);
            this.btn_salir.TabIndex = 2;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // Administrar_Tipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.btn_habilitar);
            this.Controls.Add(this.btn_deshabilitar);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.grp_deshabilitados);
            this.Controls.Add(this.grp_habilitados);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Administrar_Tipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Tipos";
            this.Load += new System.EventHandler(this.Administrar_Tipos_Load);
            this.grp_habilitados.ResumeLayout(false);
            this.grp_deshabilitados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_habilitados;
        private System.Windows.Forms.Button btn_deshabilitar;
        private System.Windows.Forms.ListBox lst_habilitados;
        private System.Windows.Forms.GroupBox grp_deshabilitados;
        private System.Windows.Forms.Button btn_habilitar;
        private System.Windows.Forms.ListBox lst_deshabilitados;
        private System.Windows.Forms.Button btn_salir;
    }
}