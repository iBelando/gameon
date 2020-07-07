namespace SistemaPlataforma
{
    partial class GestionarArbitros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarArbitros));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelBuscarArbitro = new System.Windows.Forms.Panel();
            this.btnBuscador = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtBuscadorArbitro = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dgvVerArbitros = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.colNickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelConsultarArbitro = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEstadoUsuario = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.label4 = new System.Windows.Forms.Label();
            this.dropdownRol = new Bunifu.Framework.UI.BunifuDropdown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new Bunifu.Framework.UI.BunifuDatepicker();
            this.dropdownPais = new Bunifu.Framework.UI.BunifuDropdown();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtNombreUsuario = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnConsultarArbitro = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnVerArbitros = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panelBuscarArbitro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerArbitros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.panelConsultarArbitro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 7;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panelBuscarArbitro
            // 
            this.panelBuscarArbitro.Controls.Add(this.btnBuscador);
            this.panelBuscarArbitro.Controls.Add(this.txtBuscadorArbitro);
            this.panelBuscarArbitro.Controls.Add(this.dgvVerArbitros);
            this.panelBuscarArbitro.Location = new System.Drawing.Point(12, 82);
            this.panelBuscarArbitro.Name = "panelBuscarArbitro";
            this.panelBuscarArbitro.Size = new System.Drawing.Size(816, 504);
            this.panelBuscarArbitro.TabIndex = 34;
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
            this.btnBuscador.TabIndex = 30;
            this.btnBuscador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscador.Click += new System.EventHandler(this.btnBuscador_Click);
            // 
            // txtBuscadorArbitro
            // 
            this.txtBuscadorArbitro.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtBuscadorArbitro.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtBuscadorArbitro.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtBuscadorArbitro.BorderThickness = 3;
            this.txtBuscadorArbitro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscadorArbitro.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBuscadorArbitro.ForeColor = System.Drawing.Color.White;
            this.txtBuscadorArbitro.isPassword = false;
            this.txtBuscadorArbitro.Location = new System.Drawing.Point(18, 29);
            this.txtBuscadorArbitro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscadorArbitro.Name = "txtBuscadorArbitro";
            this.txtBuscadorArbitro.Size = new System.Drawing.Size(531, 40);
            this.txtBuscadorArbitro.TabIndex = 29;
            this.txtBuscadorArbitro.Text = "BUSCAR ARBITRO...";
            this.txtBuscadorArbitro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscadorArbitro.Enter += new System.EventHandler(this.txtBuscadorArbitro_Enter);
            this.txtBuscadorArbitro.Leave += new System.EventHandler(this.txtBuscadorArbitro_Leave);
            // 
            // dgvVerArbitros
            // 
            this.dgvVerArbitros.AllowUserToAddRows = false;
            this.dgvVerArbitros.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvVerArbitros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVerArbitros.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvVerArbitros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVerArbitros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVerArbitros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVerArbitros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerArbitros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNickname,
            this.colPais,
            this.colFechaNacimiento,
            this.colEmail});
            this.dgvVerArbitros.DoubleBuffered = true;
            this.dgvVerArbitros.EnableHeadersVisualStyles = false;
            this.dgvVerArbitros.HeaderBgColor = System.Drawing.Color.Black;
            this.dgvVerArbitros.HeaderForeColor = System.Drawing.Color.White;
            this.dgvVerArbitros.Location = new System.Drawing.Point(18, 76);
            this.dgvVerArbitros.Name = "dgvVerArbitros";
            this.dgvVerArbitros.ReadOnly = true;
            this.dgvVerArbitros.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVerArbitros.Size = new System.Drawing.Size(783, 420);
            this.dgvVerArbitros.TabIndex = 0;
            this.dgvVerArbitros.DoubleClick += new System.EventHandler(this.dgvVerArbitros_DoubleClick);
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
            // colFechaNacimiento
            // 
            this.colFechaNacimiento.DataPropertyName = "fechaNacimiento";
            this.colFechaNacimiento.HeaderText = "FECHA de NACIMIENTO";
            this.colFechaNacimiento.Name = "colFechaNacimiento";
            this.colFechaNacimiento.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "email";
            this.colEmail.HeaderText = "EMAIL";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
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
            this.bunifuImageButton1.TabIndex = 51;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
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
            this.btnCerrar.TabIndex = 50;
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
            this.btnMinimizar.TabIndex = 49;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Zoom = 10;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // panelConsultarArbitro
            // 
            this.panelConsultarArbitro.Controls.Add(this.label6);
            this.panelConsultarArbitro.Controls.Add(this.btnEstadoUsuario);
            this.panelConsultarArbitro.Controls.Add(this.label4);
            this.panelConsultarArbitro.Controls.Add(this.dropdownRol);
            this.panelConsultarArbitro.Controls.Add(this.label3);
            this.panelConsultarArbitro.Controls.Add(this.txtEmail);
            this.panelConsultarArbitro.Controls.Add(this.label1);
            this.panelConsultarArbitro.Controls.Add(this.dtpFechaNacimiento);
            this.panelConsultarArbitro.Controls.Add(this.dropdownPais);
            this.panelConsultarArbitro.Controls.Add(this.pictureBox2);
            this.panelConsultarArbitro.Controls.Add(this.txtNombreUsuario);
            this.panelConsultarArbitro.Location = new System.Drawing.Point(856, 82);
            this.panelConsultarArbitro.Name = "panelConsultarArbitro";
            this.panelConsultarArbitro.Size = new System.Drawing.Size(816, 504);
            this.panelConsultarArbitro.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(559, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 22);
            this.label6.TabIndex = 54;
            this.label6.Text = "ESTADO:";
            // 
            // btnEstadoUsuario
            // 
            this.btnEstadoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnEstadoUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEstadoUsuario.BackgroundImage")));
            this.btnEstadoUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEstadoUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadoUsuario.Location = new System.Drawing.Point(651, 122);
            this.btnEstadoUsuario.Name = "btnEstadoUsuario";
            this.btnEstadoUsuario.OffColor = System.Drawing.Color.Red;
            this.btnEstadoUsuario.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.btnEstadoUsuario.Size = new System.Drawing.Size(43, 25);
            this.btnEstadoUsuario.TabIndex = 53;
            this.btnEstadoUsuario.Value = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(59, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 22);
            this.label4.TabIndex = 52;
            this.label4.Text = "GRUPO:";
            // 
            // dropdownRol
            // 
            this.dropdownRol.BackColor = System.Drawing.Color.Transparent;
            this.dropdownRol.BorderRadius = 3;
            this.dropdownRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownRol.ForeColor = System.Drawing.Color.White;
            this.dropdownRol.Items = new string[0];
            this.dropdownRol.Location = new System.Drawing.Point(150, 397);
            this.dropdownRol.Margin = new System.Windows.Forms.Padding(0);
            this.dropdownRol.Name = "dropdownRol";
            this.dropdownRol.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.dropdownRol.onHoverColor = System.Drawing.Color.MediumSeaGreen;
            this.dropdownRol.selectedIndex = -1;
            this.dropdownRol.Size = new System.Drawing.Size(550, 34);
            this.dropdownRol.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(8, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 22);
            this.label3.TabIndex = 46;
            this.label3.Text = "NACIMIENTO:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtEmail.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtEmail.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtEmail.BorderThickness = 3;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.isPassword = false;
            this.txtEmail.Location = new System.Drawing.Point(150, 232);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(550, 40);
            this.txtEmail.TabIndex = 29;
            this.txtEmail.Text = "Email..";
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(88, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 22);
            this.label1.TabIndex = 45;
            this.label1.Text = "PAIS:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.dtpFechaNacimiento.BorderRadius = 0;
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaNacimiento.ForeColor = System.Drawing.Color.White;
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaNacimiento.FormatCustom = null;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(150, 346);
            this.dtpFechaNacimiento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(550, 36);
            this.dtpFechaNacimiento.TabIndex = 44;
            this.dtpFechaNacimiento.Value = new System.DateTime(2019, 2, 12, 16, 49, 41, 988);
            // 
            // dropdownPais
            // 
            this.dropdownPais.BackColor = System.Drawing.Color.Transparent;
            this.dropdownPais.BorderRadius = 3;
            this.dropdownPais.ForeColor = System.Drawing.Color.White;
            this.dropdownPais.Items = new string[0];
            this.dropdownPais.Location = new System.Drawing.Point(150, 292);
            this.dropdownPais.Name = "dropdownPais";
            this.dropdownPais.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.dropdownPais.onHoverColor = System.Drawing.Color.MediumSeaGreen;
            this.dropdownPais.selectedIndex = -1;
            this.dropdownPais.Size = new System.Drawing.Size(550, 34);
            this.dropdownPais.TabIndex = 43;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SistemaPlataforma.Properties.Resources.equipo;
            this.pictureBox2.Location = new System.Drawing.Point(150, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(144, 113);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.BorderColorFocused = System.Drawing.Color.White;
            this.txtNombreUsuario.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtNombreUsuario.BorderColorMouseHover = System.Drawing.Color.White;
            this.txtNombreUsuario.BorderThickness = 3;
            this.txtNombreUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombreUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.txtNombreUsuario.isPassword = false;
            this.txtNombreUsuario.Location = new System.Drawing.Point(150, 173);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(550, 40);
            this.txtNombreUsuario.TabIndex = 39;
            this.txtNombreUsuario.Text = "Nombre del Usuario..";
            this.txtNombreUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNombreUsuario.Enter += new System.EventHandler(this.txtNombreUsuario_Enter);
            this.txtNombreUsuario.Leave += new System.EventHandler(this.txtNombreUsuario_Leave);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.bunifuSeparator1.LineThickness = 5;
            this.bunifuSeparator1.Location = new System.Drawing.Point(278, 72);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(123, 5);
            this.bunifuSeparator1.TabIndex = 56;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btnConsultarArbitro
            // 
            this.btnConsultarArbitro.ActiveBorderThickness = 1;
            this.btnConsultarArbitro.ActiveCornerRadius = 1;
            this.btnConsultarArbitro.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnConsultarArbitro.ActiveForecolor = System.Drawing.Color.White;
            this.btnConsultarArbitro.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnConsultarArbitro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnConsultarArbitro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultarArbitro.BackgroundImage")));
            this.btnConsultarArbitro.ButtonText = "Consultar";
            this.btnConsultarArbitro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultarArbitro.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarArbitro.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnConsultarArbitro.IdleBorderThickness = 1;
            this.btnConsultarArbitro.IdleCornerRadius = 1;
            this.btnConsultarArbitro.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnConsultarArbitro.IdleForecolor = System.Drawing.Color.White;
            this.btnConsultarArbitro.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnConsultarArbitro.Location = new System.Drawing.Point(403, 14);
            this.btnConsultarArbitro.Margin = new System.Windows.Forms.Padding(5);
            this.btnConsultarArbitro.Name = "btnConsultarArbitro";
            this.btnConsultarArbitro.Size = new System.Drawing.Size(123, 63);
            this.btnConsultarArbitro.TabIndex = 55;
            this.btnConsultarArbitro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConsultarArbitro.Click += new System.EventHandler(this.btnConsultarArbitro_Click);
            // 
            // btnVerArbitros
            // 
            this.btnVerArbitros.ActiveBorderThickness = 1;
            this.btnVerArbitros.ActiveCornerRadius = 1;
            this.btnVerArbitros.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerArbitros.ActiveForecolor = System.Drawing.Color.White;
            this.btnVerArbitros.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerArbitros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerArbitros.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerArbitros.BackgroundImage")));
            this.btnVerArbitros.ButtonText = "Ver Arbitros";
            this.btnVerArbitros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerArbitros.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerArbitros.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnVerArbitros.IdleBorderThickness = 1;
            this.btnVerArbitros.IdleCornerRadius = 1;
            this.btnVerArbitros.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerArbitros.IdleForecolor = System.Drawing.Color.White;
            this.btnVerArbitros.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerArbitros.Location = new System.Drawing.Point(277, 14);
            this.btnVerArbitros.Margin = new System.Windows.Forms.Padding(5);
            this.btnVerArbitros.Name = "btnVerArbitros";
            this.btnVerArbitros.Size = new System.Drawing.Size(122, 63);
            this.btnVerArbitros.TabIndex = 54;
            this.btnVerArbitros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerArbitros.Click += new System.EventHandler(this.btnVerArbitros_Click);
            // 
            // GestionarArbitros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(854, 598);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btnConsultarArbitro);
            this.Controls.Add(this.btnVerArbitros);
            this.Controls.Add(this.panelConsultarArbitro);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.panelBuscarArbitro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionarArbitros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionarArbitros";
            this.Load += new System.EventHandler(this.GestionarArbitros_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GestionarArbitros_MouseDown);
            this.panelBuscarArbitro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerArbitros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.panelConsultarArbitro.ResumeLayout(false);
            this.panelConsultarArbitro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelBuscarArbitro;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscadorArbitro;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvVerArbitros;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizar;
        private Bunifu.Framework.UI.BunifuThinButton2 btnBuscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNickname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.Panel panelConsultarArbitro;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtEmail;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuiOSSwitch btnEstadoUsuario;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuDropdown dropdownRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuDatepicker dtpFechaNacimiento;
        private Bunifu.Framework.UI.BunifuDropdown dropdownPais;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtNombreUsuario;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnConsultarArbitro;
        private Bunifu.Framework.UI.BunifuThinButton2 btnVerArbitros;
    }
}