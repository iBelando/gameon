namespace SistemaPlataforma
{
    partial class GestionarRoles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarRoles));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelBuscarRol = new System.Windows.Forms.Panel();
            this.btnBuscador = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtBuscarRol = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dgvRoles = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.colIdRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panelGestionarRoles = new System.Windows.Forms.Panel();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnModificar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnNuevo = new Bunifu.Framework.UI.BunifuThinButton2();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtVerRol = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnGestionarRoles = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnVerRoles = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panelBuscarRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.panelGestionarRoles.SuspendLayout();
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
            // panelBuscarRol
            // 
            this.panelBuscarRol.Controls.Add(this.btnBuscador);
            this.panelBuscarRol.Controls.Add(this.txtBuscarRol);
            this.panelBuscarRol.Controls.Add(this.dgvRoles);
            this.panelBuscarRol.Location = new System.Drawing.Point(12, 82);
            this.panelBuscarRol.Name = "panelBuscarRol";
            this.panelBuscarRol.Size = new System.Drawing.Size(816, 504);
            this.panelBuscarRol.TabIndex = 34;
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
            // txtBuscarRol
            // 
            this.txtBuscarRol.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtBuscarRol.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtBuscarRol.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtBuscarRol.BorderThickness = 3;
            this.txtBuscarRol.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarRol.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBuscarRol.ForeColor = System.Drawing.Color.White;
            this.txtBuscarRol.isPassword = false;
            this.txtBuscarRol.Location = new System.Drawing.Point(18, 29);
            this.txtBuscarRol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscarRol.Name = "txtBuscarRol";
            this.txtBuscarRol.Size = new System.Drawing.Size(531, 40);
            this.txtBuscarRol.TabIndex = 3;
            this.txtBuscarRol.Text = "BUSCAR ROL...";
            this.txtBuscarRol.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarRol.Enter += new System.EventHandler(this.txtBuscarRol_Enter);
            this.txtBuscarRol.Leave += new System.EventHandler(this.txtBuscarRol_Leave);
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRoles.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRoles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdRol,
            this.colNombre,
            this.colAccede});
            this.dgvRoles.DoubleBuffered = true;
            this.dgvRoles.EnableHeadersVisualStyles = false;
            this.dgvRoles.HeaderBgColor = System.Drawing.Color.Black;
            this.dgvRoles.HeaderForeColor = System.Drawing.Color.White;
            this.dgvRoles.Location = new System.Drawing.Point(18, 76);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRoles.Size = new System.Drawing.Size(783, 420);
            this.dgvRoles.TabIndex = 0;
            this.dgvRoles.DoubleClick += new System.EventHandler(this.dgvRoles_DoubleClick);
            // 
            // colIdRol
            // 
            this.colIdRol.DataPropertyName = "idRol";
            this.colIdRol.HeaderText = "ID ROL";
            this.colIdRol.Name = "colIdRol";
            this.colIdRol.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "nombreRol";
            this.colNombre.HeaderText = "NOMBRE";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colAccede
            // 
            this.colAccede.DataPropertyName = "frmRoles";
            this.colAccede.HeaderText = "ACCEDE";
            this.colAccede.Name = "colAccede";
            this.colAccede.ReadOnly = true;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.bunifuSeparator1.LineThickness = 5;
            this.bunifuSeparator1.Location = new System.Drawing.Point(279, 72);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(121, 10);
            this.bunifuSeparator1.TabIndex = 44;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // panelGestionarRoles
            // 
            this.panelGestionarRoles.Controls.Add(this.btnEliminar);
            this.panelGestionarRoles.Controls.Add(this.btnModificar);
            this.panelGestionarRoles.Controls.Add(this.btnNuevo);
            this.panelGestionarRoles.Controls.Add(this.listBox1);
            this.panelGestionarRoles.Controls.Add(this.txtVerRol);
            this.panelGestionarRoles.Location = new System.Drawing.Point(856, 82);
            this.panelGestionarRoles.Name = "panelGestionarRoles";
            this.panelGestionarRoles.Size = new System.Drawing.Size(816, 504);
            this.panelGestionarRoles.TabIndex = 48;
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
            this.btnEliminar.ButtonText = "Eliminar";
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Honeydew;
            this.btnEliminar.IdleBorderThickness = 1;
            this.btnEliminar.IdleCornerRadius = 1;
            this.btnEliminar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnEliminar.IdleForecolor = System.Drawing.Color.White;
            this.btnEliminar.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnEliminar.Location = new System.Drawing.Point(567, 435);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(155, 44);
            this.btnEliminar.TabIndex = 44;
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
            this.btnModificar.ButtonText = "Modificar";
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.Honeydew;
            this.btnModificar.IdleBorderThickness = 1;
            this.btnModificar.IdleCornerRadius = 1;
            this.btnModificar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnModificar.IdleForecolor = System.Drawing.Color.White;
            this.btnModificar.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnModificar.Location = new System.Drawing.Point(346, 435);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(155, 44);
            this.btnModificar.TabIndex = 43;
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
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
            this.btnNuevo.ButtonText = "Nuevo";
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.Honeydew;
            this.btnNuevo.IdleBorderThickness = 1;
            this.btnNuevo.IdleCornerRadius = 1;
            this.btnNuevo.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnNuevo.IdleForecolor = System.Drawing.Color.White;
            this.btnNuevo.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.Location = new System.Drawing.Point(100, 435);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(155, 44);
            this.btnNuevo.TabIndex = 42;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(100, 165);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(622, 225);
            this.listBox1.TabIndex = 41;
            // 
            // txtVerRol
            // 
            this.txtVerRol.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtVerRol.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtVerRol.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtVerRol.BorderThickness = 3;
            this.txtVerRol.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVerRol.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtVerRol.ForeColor = System.Drawing.Color.White;
            this.txtVerRol.isPassword = false;
            this.txtVerRol.Location = new System.Drawing.Point(100, 90);
            this.txtVerRol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVerRol.Name = "txtVerRol";
            this.txtVerRol.Size = new System.Drawing.Size(622, 40);
            this.txtVerRol.TabIndex = 4;
            this.txtVerRol.Text = "NOMBRE del ROL...";
            this.txtVerRol.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVerRol.Enter += new System.EventHandler(this.txtVerRol_Enter);
            this.txtVerRol.Leave += new System.EventHandler(this.txtVerRol_Leave);
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
            this.bunifuImageButton1.TabIndex = 47;
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
            this.btnCerrar.TabIndex = 46;
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
            this.btnMinimizar.TabIndex = 45;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Zoom = 10;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnGestionarRoles
            // 
            this.btnGestionarRoles.ActiveBorderThickness = 1;
            this.btnGestionarRoles.ActiveCornerRadius = 1;
            this.btnGestionarRoles.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnGestionarRoles.ActiveForecolor = System.Drawing.Color.White;
            this.btnGestionarRoles.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnGestionarRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnGestionarRoles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGestionarRoles.BackgroundImage")));
            this.btnGestionarRoles.ButtonText = "Gestionar";
            this.btnGestionarRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionarRoles.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarRoles.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnGestionarRoles.IdleBorderThickness = 1;
            this.btnGestionarRoles.IdleCornerRadius = 1;
            this.btnGestionarRoles.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnGestionarRoles.IdleForecolor = System.Drawing.Color.White;
            this.btnGestionarRoles.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnGestionarRoles.Location = new System.Drawing.Point(404, 14);
            this.btnGestionarRoles.Margin = new System.Windows.Forms.Padding(5);
            this.btnGestionarRoles.Name = "btnGestionarRoles";
            this.btnGestionarRoles.Size = new System.Drawing.Size(123, 63);
            this.btnGestionarRoles.TabIndex = 43;
            this.btnGestionarRoles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGestionarRoles.Click += new System.EventHandler(this.btnGestionarRoles_Click);
            // 
            // btnVerRoles
            // 
            this.btnVerRoles.ActiveBorderThickness = 1;
            this.btnVerRoles.ActiveCornerRadius = 1;
            this.btnVerRoles.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerRoles.ActiveForecolor = System.Drawing.Color.White;
            this.btnVerRoles.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerRoles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerRoles.BackgroundImage")));
            this.btnVerRoles.ButtonText = "Ver Roles";
            this.btnVerRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerRoles.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerRoles.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnVerRoles.IdleBorderThickness = 1;
            this.btnVerRoles.IdleCornerRadius = 1;
            this.btnVerRoles.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerRoles.IdleForecolor = System.Drawing.Color.White;
            this.btnVerRoles.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerRoles.Location = new System.Drawing.Point(279, 14);
            this.btnVerRoles.Margin = new System.Windows.Forms.Padding(5);
            this.btnVerRoles.Name = "btnVerRoles";
            this.btnVerRoles.Size = new System.Drawing.Size(123, 63);
            this.btnVerRoles.TabIndex = 42;
            this.btnVerRoles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerRoles.Click += new System.EventHandler(this.btnVerRoles_Click);
            // 
            // GestionarRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(857, 598);
            this.Controls.Add(this.panelGestionarRoles);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btnGestionarRoles);
            this.Controls.Add(this.btnVerRoles);
            this.Controls.Add(this.panelBuscarRol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionarRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionarRoles";
            this.Load += new System.EventHandler(this.GestionarRoles_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GestionarRoles_MouseDown);
            this.panelBuscarRol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.panelGestionarRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelBuscarRol;
        private Bunifu.Framework.UI.BunifuThinButton2 btnBuscador;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscarRol;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvRoles;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnGestionarRoles;
        private Bunifu.Framework.UI.BunifuThinButton2 btnVerRoles;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizar;
        private System.Windows.Forms.Panel panelGestionarRoles;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtVerRol;
        private System.Windows.Forms.ListBox listBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnEliminar;
        private Bunifu.Framework.UI.BunifuThinButton2 btnModificar;
        private Bunifu.Framework.UI.BunifuThinButton2 btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccede;
    }
}