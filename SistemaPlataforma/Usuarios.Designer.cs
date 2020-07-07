namespace SistemaPlataforma
{
    partial class Usuarios
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuarios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelBuscarEquipo = new System.Windows.Forms.Panel();
            this.btnBuscador = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtBuscaruUsuario = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dgvUsuarios = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.colImagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.colNickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBuscarEquipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 7;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panelBuscarEquipo
            // 
            this.panelBuscarEquipo.Controls.Add(this.btnBuscador);
            this.panelBuscarEquipo.Controls.Add(this.txtBuscaruUsuario);
            this.panelBuscarEquipo.Controls.Add(this.dgvUsuarios);
            this.panelBuscarEquipo.Location = new System.Drawing.Point(12, 82);
            this.panelBuscarEquipo.Name = "panelBuscarEquipo";
            this.panelBuscarEquipo.Size = new System.Drawing.Size(816, 504);
            this.panelBuscarEquipo.TabIndex = 25;
            // 
            // btnBuscador
            // 
            this.btnBuscador.ActiveBorderThickness = 1;
            this.btnBuscador.ActiveCornerRadius = 1;
            this.btnBuscador.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnBuscador.ActiveForecolor = System.Drawing.Color.White;
            this.btnBuscador.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnBuscador.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscador.BackgroundImage")));
            this.btnBuscador.ButtonText = "Buscar!";
            this.btnBuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscador.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscador.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnBuscador.IdleBorderThickness = 1;
            this.btnBuscador.IdleCornerRadius = 1;
            this.btnBuscador.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnBuscador.IdleForecolor = System.Drawing.Color.White;
            this.btnBuscador.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnBuscador.Location = new System.Drawing.Point(558, 29);
            this.btnBuscador.Margin = new System.Windows.Forms.Padding(5);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(243, 44);
            this.btnBuscador.TabIndex = 4;
            this.btnBuscador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscador.Click += new System.EventHandler(this.btnBuscador_Click);
            // 
            // txtBuscaruUsuario
            // 
            this.txtBuscaruUsuario.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtBuscaruUsuario.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtBuscaruUsuario.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtBuscaruUsuario.BorderThickness = 3;
            this.txtBuscaruUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscaruUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBuscaruUsuario.ForeColor = System.Drawing.Color.White;
            this.txtBuscaruUsuario.isPassword = false;
            this.txtBuscaruUsuario.Location = new System.Drawing.Point(18, 29);
            this.txtBuscaruUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscaruUsuario.Name = "txtBuscaruUsuario";
            this.txtBuscaruUsuario.Size = new System.Drawing.Size(531, 40);
            this.txtBuscaruUsuario.TabIndex = 3;
            this.txtBuscaruUsuario.Text = "BUSCAR USUARIO...";
            this.txtBuscaruUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscaruUsuario.Enter += new System.EventHandler(this.txtBuscaruUsuario_Enter);
            this.txtBuscaruUsuario.Leave += new System.EventHandler(this.txtBuscaruUsuario_Leave);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImagen,
            this.colNickname,
            this.colPais,
            this.colEquipos});
            this.dgvUsuarios.DoubleBuffered = true;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.HeaderBgColor = System.Drawing.Color.Black;
            this.dgvUsuarios.HeaderForeColor = System.Drawing.Color.White;
            this.dgvUsuarios.Location = new System.Drawing.Point(18, 76);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUsuarios.Size = new System.Drawing.Size(783, 420);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.DoubleClick += new System.EventHandler(this.dgvUsuarios_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(281, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 33);
            this.label1.TabIndex = 26;
            this.label1.Text = "BUSCAR USUARIOS";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Image = global::SistemaPlataforma.Properties.Resources.Cerrar;
            this.btnCerrar.ImageActive = null;
            this.btnCerrar.Location = new System.Drawing.Point(809, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(39, 34);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 28;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Zoom = 10;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizar.Image = global::SistemaPlataforma.Properties.Resources.icons8_minimizar_la_ventana_100;
            this.btnMinimizar.ImageActive = null;
            this.btnMinimizar.Location = new System.Drawing.Point(774, 5);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(39, 34);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 27;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Zoom = 10;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Image = global::SistemaPlataforma.Properties.Resources.icons8_chevron_izquierda_en_círculo_64;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(10, 3);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(39, 34);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 29;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // colImagen
            // 
            this.colImagen.DataPropertyName = "imagenPerfil";
            this.colImagen.HeaderText = "IMAGEN";
            this.colImagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImagen.Name = "colImagen";
            this.colImagen.ReadOnly = true;
            // 
            // colNickname
            // 
            this.colNickname.DataPropertyName = "nickname";
            this.colNickname.HeaderText = "NICKNAME";
            this.colNickname.Name = "colNickname";
            this.colNickname.ReadOnly = true;
            // 
            // colPais
            // 
            this.colPais.DataPropertyName = "pais";
            this.colPais.HeaderText = "PAIS";
            this.colPais.Name = "colPais";
            this.colPais.ReadOnly = true;
            // 
            // colEquipos
            // 
            this.colEquipos.DataPropertyName = "equipos";
            this.colEquipos.HeaderText = "EQUIPOS";
            this.colEquipos.Name = "colEquipos";
            this.colEquipos.ReadOnly = true;
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(860, 598);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelBuscarEquipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Usuarios_MouseDown);
            this.panelBuscarEquipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelBuscarEquipo;
        private Bunifu.Framework.UI.BunifuThinButton2 btnBuscador;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscaruUsuario;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvUsuarios;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizar;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.DataGridViewImageColumn colImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNickname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipos;
    }
}