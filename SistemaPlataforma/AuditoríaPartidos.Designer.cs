namespace SistemaPlataforma
{
    partial class AuditoríaPartidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditoríaPartidos));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnVolver = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelBuscarGrupo = new System.Windows.Forms.Panel();
            this.btnBuscador = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtBuscarPartido = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dgvAuditoríaPartidos = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnVerGrupos = new Bunifu.Framework.UI.BunifuThinButton2();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panelBuscarGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoríaPartidos)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Transparent;
            this.btnVolver.Image = global::SistemaPlataforma.Properties.Resources.icons8_chevron_izquierda_en_círculo_64;
            this.btnVolver.ImageActive = null;
            this.btnVolver.Location = new System.Drawing.Point(10, 3);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(39, 34);
            this.btnVolver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnVolver.TabIndex = 57;
            this.btnVolver.TabStop = false;
            this.btnVolver.Zoom = 10;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
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
            this.btnMinimizar.TabIndex = 58;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Zoom = 10;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
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
            this.btnCerrar.TabIndex = 59;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Zoom = 10;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelBuscarGrupo
            // 
            this.panelBuscarGrupo.Controls.Add(this.btnBuscador);
            this.panelBuscarGrupo.Controls.Add(this.txtBuscarPartido);
            this.panelBuscarGrupo.Controls.Add(this.dgvAuditoríaPartidos);
            this.panelBuscarGrupo.Location = new System.Drawing.Point(12, 82);
            this.panelBuscarGrupo.Name = "panelBuscarGrupo";
            this.panelBuscarGrupo.Size = new System.Drawing.Size(816, 504);
            this.panelBuscarGrupo.TabIndex = 60;
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
            this.btnBuscador.ForeColor = System.Drawing.Color.Honeydew;
            this.btnBuscador.IdleBorderThickness = 1;
            this.btnBuscador.IdleCornerRadius = 1;
            this.btnBuscador.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnBuscador.IdleForecolor = System.Drawing.Color.White;
            this.btnBuscador.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnBuscador.Location = new System.Drawing.Point(558, 24);
            this.btnBuscador.Margin = new System.Windows.Forms.Padding(5);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(243, 44);
            this.btnBuscador.TabIndex = 4;
            this.btnBuscador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscador.Click += new System.EventHandler(this.btnBuscador_Click);
            // 
            // txtBuscarPartido
            // 
            this.txtBuscarPartido.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtBuscarPartido.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtBuscarPartido.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtBuscarPartido.BorderThickness = 3;
            this.txtBuscarPartido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarPartido.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBuscarPartido.ForeColor = System.Drawing.Color.White;
            this.txtBuscarPartido.isPassword = false;
            this.txtBuscarPartido.Location = new System.Drawing.Point(18, 29);
            this.txtBuscarPartido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscarPartido.Name = "txtBuscarPartido";
            this.txtBuscarPartido.Size = new System.Drawing.Size(531, 40);
            this.txtBuscarPartido.TabIndex = 3;
            this.txtBuscarPartido.Text = "BUSCAR PARTIDO...";
            this.txtBuscarPartido.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarPartido.Enter += new System.EventHandler(this.txtBuscarPartido_Enter);
            this.txtBuscarPartido.Leave += new System.EventHandler(this.txtBuscarPartido_Leave);
            // 
            // dgvAuditoríaPartidos
            // 
            this.dgvAuditoríaPartidos.AllowUserToAddRows = false;
            this.dgvAuditoríaPartidos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvAuditoríaPartidos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvAuditoríaPartidos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvAuditoríaPartidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAuditoríaPartidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditoríaPartidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvAuditoríaPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoríaPartidos.DoubleBuffered = true;
            this.dgvAuditoríaPartidos.EnableHeadersVisualStyles = false;
            this.dgvAuditoríaPartidos.HeaderBgColor = System.Drawing.Color.Black;
            this.dgvAuditoríaPartidos.HeaderForeColor = System.Drawing.Color.White;
            this.dgvAuditoríaPartidos.Location = new System.Drawing.Point(18, 76);
            this.dgvAuditoríaPartidos.Name = "dgvAuditoríaPartidos";
            this.dgvAuditoríaPartidos.ReadOnly = true;
            this.dgvAuditoríaPartidos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAuditoríaPartidos.Size = new System.Drawing.Size(783, 420);
            this.dgvAuditoríaPartidos.TabIndex = 0;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.bunifuSeparator1.LineThickness = 5;
            this.bunifuSeparator1.Location = new System.Drawing.Point(343, 72);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(121, 10);
            this.bunifuSeparator1.TabIndex = 62;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btnVerGrupos
            // 
            this.btnVerGrupos.ActiveBorderThickness = 1;
            this.btnVerGrupos.ActiveCornerRadius = 1;
            this.btnVerGrupos.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerGrupos.ActiveForecolor = System.Drawing.Color.White;
            this.btnVerGrupos.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerGrupos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerGrupos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerGrupos.BackgroundImage")));
            this.btnVerGrupos.ButtonText = "Auditoría Partidos";
            this.btnVerGrupos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerGrupos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerGrupos.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnVerGrupos.IdleBorderThickness = 1;
            this.btnVerGrupos.IdleCornerRadius = 1;
            this.btnVerGrupos.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerGrupos.IdleForecolor = System.Drawing.Color.White;
            this.btnVerGrupos.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerGrupos.Location = new System.Drawing.Point(343, 14);
            this.btnVerGrupos.Margin = new System.Windows.Forms.Padding(5);
            this.btnVerGrupos.Name = "btnVerGrupos";
            this.btnVerGrupos.Size = new System.Drawing.Size(123, 63);
            this.btnVerGrupos.TabIndex = 61;
            this.btnVerGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AuditoríaPartidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(857, 598);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btnVerGrupos);
            this.Controls.Add(this.panelBuscarGrupo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuditoríaPartidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuditoríaPartidos";
            this.Load += new System.EventHandler(this.AuditoríaPartidos_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AuditoríaPartidos_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panelBuscarGrupo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoríaPartidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton btnVolver;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizar;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private System.Windows.Forms.Panel panelBuscarGrupo;
        private Bunifu.Framework.UI.BunifuThinButton2 btnBuscador;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscarPartido;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvAuditoríaPartidos;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnVerGrupos;
    }
}