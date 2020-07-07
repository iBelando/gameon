namespace SistemaPlataforma
{
    partial class GestionarUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarUsuarios));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelBuscarUsuario = new System.Windows.Forms.Panel();
            this.btnBuscador = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtBuscarUsuario = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dgvUsuarios = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.colNickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRolUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelGestionarUsuario = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEstadoUsuario = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.label4 = new System.Windows.Forms.Label();
            this.dropdownRol = new Bunifu.Framework.UI.BunifuDropdown();
            this.txtContraseña = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtEmail = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnModificar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new Bunifu.Framework.UI.BunifuDatepicker();
            this.dropdownEquipo = new Bunifu.Framework.UI.BunifuDropdown();
            this.dropdownPais = new Bunifu.Framework.UI.BunifuDropdown();
            this.btnSubirImagen = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnNuevo = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtNombreUsuario = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnGestionarUsuarios = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnVerUsuarios = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panelBuscarUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelGestionarUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 7;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panelBuscarUsuario
            // 
            this.panelBuscarUsuario.Controls.Add(this.btnBuscador);
            this.panelBuscarUsuario.Controls.Add(this.txtBuscarUsuario);
            this.panelBuscarUsuario.Controls.Add(this.dgvUsuarios);
            this.panelBuscarUsuario.Location = new System.Drawing.Point(12, 82);
            this.panelBuscarUsuario.Name = "panelBuscarUsuario";
            this.panelBuscarUsuario.Size = new System.Drawing.Size(816, 504);
            this.panelBuscarUsuario.TabIndex = 32;
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
            this.btnBuscador.Location = new System.Drawing.Point(558, 29);
            this.btnBuscador.Margin = new System.Windows.Forms.Padding(5);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(243, 44);
            this.btnBuscador.TabIndex = 4;
            this.btnBuscador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscador.Click += new System.EventHandler(this.btnBuscador_Click);
            // 
            // txtBuscarUsuario
            // 
            this.txtBuscarUsuario.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtBuscarUsuario.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtBuscarUsuario.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtBuscarUsuario.BorderThickness = 3;
            this.txtBuscarUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBuscarUsuario.ForeColor = System.Drawing.Color.White;
            this.txtBuscarUsuario.isPassword = false;
            this.txtBuscarUsuario.Location = new System.Drawing.Point(18, 29);
            this.txtBuscarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscarUsuario.Name = "txtBuscarUsuario";
            this.txtBuscarUsuario.Size = new System.Drawing.Size(531, 40);
            this.txtBuscarUsuario.TabIndex = 3;
            this.txtBuscarUsuario.Text = "BUSCAR USUARIO...";
            this.txtBuscarUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarUsuario.Enter += new System.EventHandler(this.txtBuscarUsuario_Enter);
            this.txtBuscarUsuario.Leave += new System.EventHandler(this.txtBuscarUsuario_Leave);
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
            this.colNickname,
            this.colPais,
            this.colFechaNacimiento,
            this.colEmail,
            this.colRolUsuario,
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
            // colRolUsuario
            // 
            this.colRolUsuario.DataPropertyName = "rolUsuario";
            this.colRolUsuario.HeaderText = "ROL";
            this.colRolUsuario.Name = "colRolUsuario";
            this.colRolUsuario.ReadOnly = true;
            // 
            // colEquipos
            // 
            this.colEquipos.DataPropertyName = "equipos";
            this.colEquipos.HeaderText = "EQUIPOS";
            this.colEquipos.Name = "colEquipos";
            this.colEquipos.ReadOnly = true;
            // 
            // panelGestionarUsuario
            // 
            this.panelGestionarUsuario.Controls.Add(this.label6);
            this.panelGestionarUsuario.Controls.Add(this.btnEstadoUsuario);
            this.panelGestionarUsuario.Controls.Add(this.label4);
            this.panelGestionarUsuario.Controls.Add(this.dropdownRol);
            this.panelGestionarUsuario.Controls.Add(this.txtContraseña);
            this.panelGestionarUsuario.Controls.Add(this.txtEmail);
            this.panelGestionarUsuario.Controls.Add(this.btnEliminar);
            this.panelGestionarUsuario.Controls.Add(this.btnModificar);
            this.panelGestionarUsuario.Controls.Add(this.label3);
            this.panelGestionarUsuario.Controls.Add(this.label2);
            this.panelGestionarUsuario.Controls.Add(this.label1);
            this.panelGestionarUsuario.Controls.Add(this.dtpFechaNacimiento);
            this.panelGestionarUsuario.Controls.Add(this.dropdownEquipo);
            this.panelGestionarUsuario.Controls.Add(this.dropdownPais);
            this.panelGestionarUsuario.Controls.Add(this.btnSubirImagen);
            this.panelGestionarUsuario.Controls.Add(this.pictureBox2);
            this.panelGestionarUsuario.Controls.Add(this.btnNuevo);
            this.panelGestionarUsuario.Controls.Add(this.txtNombreUsuario);
            this.panelGestionarUsuario.Location = new System.Drawing.Point(856, 82);
            this.panelGestionarUsuario.Name = "panelGestionarUsuario";
            this.panelGestionarUsuario.Size = new System.Drawing.Size(816, 504);
            this.panelGestionarUsuario.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(590, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 22);
            this.label6.TabIndex = 38;
            this.label6.Text = "ESTADO:";
            // 
            // btnEstadoUsuario
            // 
            this.btnEstadoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnEstadoUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEstadoUsuario.BackgroundImage")));
            this.btnEstadoUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEstadoUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadoUsuario.Location = new System.Drawing.Point(682, 88);
            this.btnEstadoUsuario.Name = "btnEstadoUsuario";
            this.btnEstadoUsuario.OffColor = System.Drawing.Color.Red;
            this.btnEstadoUsuario.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.btnEstadoUsuario.Size = new System.Drawing.Size(43, 25);
            this.btnEstadoUsuario.TabIndex = 37;
            this.btnEstadoUsuario.Value = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(189, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = "ROL:";
            // 
            // dropdownRol
            // 
            this.dropdownRol.BackColor = System.Drawing.Color.Transparent;
            this.dropdownRol.BorderRadius = 3;
            this.dropdownRol.ForeColor = System.Drawing.Color.White;
            this.dropdownRol.Items = new string[0];
            this.dropdownRol.Location = new System.Drawing.Point(235, 411);
            this.dropdownRol.Name = "dropdownRol";
            this.dropdownRol.NomalColor = System.Drawing.Color.SeaGreen;
            this.dropdownRol.onHoverColor = System.Drawing.Color.SeaGreen;
            this.dropdownRol.selectedIndex = -1;
            this.dropdownRol.Size = new System.Drawing.Size(490, 34);
            this.dropdownRol.TabIndex = 35;
            // 
            // txtContraseña
            // 
            this.txtContraseña.BorderColorFocused = System.Drawing.Color.White;
            this.txtContraseña.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtContraseña.BorderColorMouseHover = System.Drawing.Color.White;
            this.txtContraseña.BorderThickness = 3;
            this.txtContraseña.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContraseña.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtContraseña.ForeColor = System.Drawing.Color.White;
            this.txtContraseña.isPassword = false;
            this.txtContraseña.Location = new System.Drawing.Point(95, 228);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(630, 40);
            this.txtContraseña.TabIndex = 34;
            this.txtContraseña.Text = "Contraseña..";
            this.txtContraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtContraseña.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtContraseña.Leave += new System.EventHandler(this.txtContraseña_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderColorFocused = System.Drawing.Color.White;
            this.txtEmail.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtEmail.BorderColorMouseHover = System.Drawing.Color.White;
            this.txtEmail.BorderThickness = 3;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.isPassword = false;
            this.txtEmail.Location = new System.Drawing.Point(95, 182);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(630, 40);
            this.txtEmail.TabIndex = 33;
            this.txtEmail.Text = "Email..";
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ActiveBorderThickness = 1;
            this.btnEliminar.ActiveCornerRadius = 1;
            this.btnEliminar.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnEliminar.ActiveForecolor = System.Drawing.Color.White;
            this.btnEliminar.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.ButtonText = "ELIMINAR";
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnEliminar.IdleBorderThickness = 1;
            this.btnEliminar.IdleCornerRadius = 1;
            this.btnEliminar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnEliminar.IdleForecolor = System.Drawing.Color.White;
            this.btnEliminar.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnEliminar.Location = new System.Drawing.Point(527, 451);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(198, 44);
            this.btnEliminar.TabIndex = 32;
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.ActiveBorderThickness = 1;
            this.btnModificar.ActiveCornerRadius = 1;
            this.btnModificar.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnModificar.ActiveForecolor = System.Drawing.Color.White;
            this.btnModificar.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnModificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModificar.BackgroundImage")));
            this.btnModificar.ButtonText = "MODIFICAR";
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnModificar.IdleBorderThickness = 1;
            this.btnModificar.IdleCornerRadius = 1;
            this.btnModificar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnModificar.IdleForecolor = System.Drawing.Color.White;
            this.btnModificar.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnModificar.Location = new System.Drawing.Point(308, 451);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(198, 44);
            this.btnModificar.TabIndex = 31;
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(134, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "NACIMIENTO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(166, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "EQUIPO:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(188, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "PAIS:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.BackColor = System.Drawing.Color.SeaGreen;
            this.dtpFechaNacimiento.BorderRadius = 0;
            this.dtpFechaNacimiento.ForeColor = System.Drawing.Color.White;
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaNacimiento.FormatCustom = null;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(235, 365);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(490, 36);
            this.dtpFechaNacimiento.TabIndex = 27;
            this.dtpFechaNacimiento.Value = new System.DateTime(2019, 2, 12, 16, 49, 41, 988);
            // 
            // dropdownEquipo
            // 
            this.dropdownEquipo.BackColor = System.Drawing.Color.Transparent;
            this.dropdownEquipo.BorderRadius = 3;
            this.dropdownEquipo.ForeColor = System.Drawing.Color.White;
            this.dropdownEquipo.Items = new string[0];
            this.dropdownEquipo.Location = new System.Drawing.Point(235, 320);
            this.dropdownEquipo.Name = "dropdownEquipo";
            this.dropdownEquipo.NomalColor = System.Drawing.Color.SeaGreen;
            this.dropdownEquipo.onHoverColor = System.Drawing.Color.SeaGreen;
            this.dropdownEquipo.selectedIndex = -1;
            this.dropdownEquipo.Size = new System.Drawing.Size(490, 34);
            this.dropdownEquipo.TabIndex = 25;
            // 
            // dropdownPais
            // 
            this.dropdownPais.BackColor = System.Drawing.Color.Transparent;
            this.dropdownPais.BorderRadius = 3;
            this.dropdownPais.ForeColor = System.Drawing.Color.White;
            this.dropdownPais.Items = new string[0];
            this.dropdownPais.Location = new System.Drawing.Point(235, 276);
            this.dropdownPais.Name = "dropdownPais";
            this.dropdownPais.NomalColor = System.Drawing.Color.SeaGreen;
            this.dropdownPais.onHoverColor = System.Drawing.Color.SeaGreen;
            this.dropdownPais.selectedIndex = -1;
            this.dropdownPais.Size = new System.Drawing.Size(490, 34);
            this.dropdownPais.TabIndex = 24;
            // 
            // btnSubirImagen
            // 
            this.btnSubirImagen.ActiveBorderThickness = 1;
            this.btnSubirImagen.ActiveCornerRadius = 1;
            this.btnSubirImagen.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnSubirImagen.ActiveForecolor = System.Drawing.Color.White;
            this.btnSubirImagen.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnSubirImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnSubirImagen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubirImagen.BackgroundImage")));
            this.btnSubirImagen.ButtonText = "Subir Imágen";
            this.btnSubirImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubirImagen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirImagen.ForeColor = System.Drawing.Color.Honeydew;
            this.btnSubirImagen.IdleBorderThickness = 1;
            this.btnSubirImagen.IdleCornerRadius = 1;
            this.btnSubirImagen.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnSubirImagen.IdleForecolor = System.Drawing.Color.White;
            this.btnSubirImagen.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnSubirImagen.Location = new System.Drawing.Point(259, 79);
            this.btnSubirImagen.Margin = new System.Windows.Forms.Padding(5);
            this.btnSubirImagen.Name = "btnSubirImagen";
            this.btnSubirImagen.Size = new System.Drawing.Size(180, 44);
            this.btnSubirImagen.TabIndex = 10;
            this.btnSubirImagen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSubirImagen.Click += new System.EventHandler(this.btnSubirImagen_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SistemaPlataforma.Properties.Resources.equipo;
            this.pictureBox2.Location = new System.Drawing.Point(95, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(141, 112);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.ActiveBorderThickness = 1;
            this.btnNuevo.ActiveCornerRadius = 1;
            this.btnNuevo.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.ActiveForecolor = System.Drawing.Color.White;
            this.btnNuevo.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.ButtonText = "NUEVO";
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.IdleBorderThickness = 1;
            this.btnNuevo.IdleCornerRadius = 1;
            this.btnNuevo.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnNuevo.IdleForecolor = System.Drawing.Color.White;
            this.btnNuevo.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.Location = new System.Drawing.Point(95, 451);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(198, 44);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            this.txtNombreUsuario.Location = new System.Drawing.Point(95, 137);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(630, 40);
            this.txtNombreUsuario.TabIndex = 4;
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
            this.bunifuSeparator1.Location = new System.Drawing.Point(279, 72);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(123, 5);
            this.bunifuSeparator1.TabIndex = 42;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
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
            this.bunifuImageButton1.TabIndex = 35;
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
            this.btnCerrar.TabIndex = 34;
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
            this.btnMinimizar.TabIndex = 33;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Zoom = 10;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnGestionarUsuarios
            // 
            this.btnGestionarUsuarios.ActiveBorderThickness = 1;
            this.btnGestionarUsuarios.ActiveCornerRadius = 1;
            this.btnGestionarUsuarios.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnGestionarUsuarios.ActiveForecolor = System.Drawing.Color.White;
            this.btnGestionarUsuarios.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnGestionarUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnGestionarUsuarios.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGestionarUsuarios.BackgroundImage")));
            this.btnGestionarUsuarios.ButtonText = "Gestionar";
            this.btnGestionarUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionarUsuarios.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarUsuarios.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnGestionarUsuarios.IdleBorderThickness = 1;
            this.btnGestionarUsuarios.IdleCornerRadius = 1;
            this.btnGestionarUsuarios.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnGestionarUsuarios.IdleForecolor = System.Drawing.Color.White;
            this.btnGestionarUsuarios.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnGestionarUsuarios.Location = new System.Drawing.Point(404, 14);
            this.btnGestionarUsuarios.Margin = new System.Windows.Forms.Padding(5);
            this.btnGestionarUsuarios.Name = "btnGestionarUsuarios";
            this.btnGestionarUsuarios.Size = new System.Drawing.Size(123, 63);
            this.btnGestionarUsuarios.TabIndex = 31;
            this.btnGestionarUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGestionarUsuarios.Click += new System.EventHandler(this.btnGestionarUsuarios_Click);
            // 
            // btnVerUsuarios
            // 
            this.btnVerUsuarios.ActiveBorderThickness = 1;
            this.btnVerUsuarios.ActiveCornerRadius = 1;
            this.btnVerUsuarios.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerUsuarios.ActiveForecolor = System.Drawing.Color.White;
            this.btnVerUsuarios.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerUsuarios.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerUsuarios.BackgroundImage")));
            this.btnVerUsuarios.ButtonText = "Ver Usuarios";
            this.btnVerUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerUsuarios.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerUsuarios.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnVerUsuarios.IdleBorderThickness = 1;
            this.btnVerUsuarios.IdleCornerRadius = 1;
            this.btnVerUsuarios.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerUsuarios.IdleForecolor = System.Drawing.Color.White;
            this.btnVerUsuarios.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerUsuarios.Location = new System.Drawing.Point(279, 14);
            this.btnVerUsuarios.Margin = new System.Windows.Forms.Padding(5);
            this.btnVerUsuarios.Name = "btnVerUsuarios";
            this.btnVerUsuarios.Size = new System.Drawing.Size(122, 63);
            this.btnVerUsuarios.TabIndex = 28;
            this.btnVerUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerUsuarios.Click += new System.EventHandler(this.btnVerUsuarios_Click);
            // 
            // GestionarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(857, 598);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.panelGestionarUsuario);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.panelBuscarUsuario);
            this.Controls.Add(this.btnGestionarUsuarios);
            this.Controls.Add(this.btnVerUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionarUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionarUsuarios";
            this.Load += new System.EventHandler(this.GestionarUsuarios_Load);
            this.Click += new System.EventHandler(this.GestionarUsuarios_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GestionarUsuarios_MouseDown);
            this.panelBuscarUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panelGestionarUsuario.ResumeLayout(false);
            this.panelGestionarUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnVerUsuarios;
        private Bunifu.Framework.UI.BunifuThinButton2 btnGestionarUsuarios;
        private System.Windows.Forms.Panel panelBuscarUsuario;
        private Bunifu.Framework.UI.BunifuThinButton2 btnBuscador;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscarUsuario;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvUsuarios;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizar;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel panelGestionarUsuario;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSubirImagen;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuThinButton2 btnNuevo;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtNombreUsuario;
        private Bunifu.Framework.UI.BunifuDropdown dropdownEquipo;
        private Bunifu.Framework.UI.BunifuDropdown dropdownPais;
        private Bunifu.Framework.UI.BunifuThinButton2 btnEliminar;
        private Bunifu.Framework.UI.BunifuThinButton2 btnModificar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuDatepicker dtpFechaNacimiento;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtEmail;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtContraseña;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuiOSSwitch btnEstadoUsuario;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuDropdown dropdownRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNickname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRolUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipos;
    }
}