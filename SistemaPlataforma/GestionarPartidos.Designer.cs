namespace SistemaPlataforma
{
    partial class GestionarPartidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarPartidos));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelBuscarPartido = new System.Windows.Forms.Panel();
            this.txtBuscadorEquipo = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dtpFecha = new Bunifu.Framework.UI.BunifuDatepicker();
            this.txtBuscadorJuego = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dgvVerPartidos = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnGestionarPartidos = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnVerPartidos = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelGestionarPartido = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArbitro = new Bunifu.Framework.UI.BunifuDropdown();
            this.txtResultado2 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnModificar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResultado1 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dtpFechaPartido = new Bunifu.Framework.UI.BunifuDatepicker();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompetencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipoA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJuego = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBuscarPartido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerPartidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.panelGestionarPartido.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 7;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panelBuscarPartido
            // 
            this.panelBuscarPartido.Controls.Add(this.txtBuscadorEquipo);
            this.panelBuscarPartido.Controls.Add(this.dtpFecha);
            this.panelBuscarPartido.Controls.Add(this.txtBuscadorJuego);
            this.panelBuscarPartido.Controls.Add(this.dgvVerPartidos);
            this.panelBuscarPartido.Location = new System.Drawing.Point(12, 82);
            this.panelBuscarPartido.Name = "panelBuscarPartido";
            this.panelBuscarPartido.Size = new System.Drawing.Size(816, 504);
            this.panelBuscarPartido.TabIndex = 33;
            // 
            // txtBuscadorEquipo
            // 
            this.txtBuscadorEquipo.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtBuscadorEquipo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtBuscadorEquipo.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtBuscadorEquipo.BorderThickness = 3;
            this.txtBuscadorEquipo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscadorEquipo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBuscadorEquipo.ForeColor = System.Drawing.Color.White;
            this.txtBuscadorEquipo.isPassword = false;
            this.txtBuscadorEquipo.Location = new System.Drawing.Point(291, 28);
            this.txtBuscadorEquipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscadorEquipo.Name = "txtBuscadorEquipo";
            this.txtBuscadorEquipo.Size = new System.Drawing.Size(249, 40);
            this.txtBuscadorEquipo.TabIndex = 29;
            this.txtBuscadorEquipo.Text = "BUSCAR EQUIPO...";
            this.txtBuscadorEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscadorEquipo.OnValueChanged += new System.EventHandler(this.txtBuscadorEquipo_OnValueChanged);
            this.txtBuscadorEquipo.Enter += new System.EventHandler(this.txtBuscadorEquipo_Enter);
            this.txtBuscadorEquipo.Leave += new System.EventHandler(this.txtBuscadorEquipo_Leave);
            // 
            // dtpFecha
            // 
            this.dtpFecha.BackColor = System.Drawing.Color.SeaGreen;
            this.dtpFecha.BorderRadius = 0;
            this.dtpFecha.ForeColor = System.Drawing.Color.White;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFecha.FormatCustom = null;
            this.dtpFecha.Location = new System.Drawing.Point(18, 28);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(257, 40);
            this.dtpFecha.TabIndex = 28;
            this.dtpFecha.Tag = "";
            this.dtpFecha.Value = new System.DateTime(2019, 2, 12, 16, 49, 41, 988);
            this.dtpFecha.onValueChanged += new System.EventHandler(this.dtpFecha_onValueChanged);
            // 
            // txtBuscadorJuego
            // 
            this.txtBuscadorJuego.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtBuscadorJuego.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtBuscadorJuego.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtBuscadorJuego.BorderThickness = 3;
            this.txtBuscadorJuego.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscadorJuego.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBuscadorJuego.ForeColor = System.Drawing.Color.White;
            this.txtBuscadorJuego.isPassword = false;
            this.txtBuscadorJuego.Location = new System.Drawing.Point(555, 28);
            this.txtBuscadorJuego.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscadorJuego.Name = "txtBuscadorJuego";
            this.txtBuscadorJuego.Size = new System.Drawing.Size(246, 40);
            this.txtBuscadorJuego.TabIndex = 3;
            this.txtBuscadorJuego.Text = "BUSCAR JUEGO...";
            this.txtBuscadorJuego.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscadorJuego.OnValueChanged += new System.EventHandler(this.txtBuscadorJuego_OnValueChanged);
            this.txtBuscadorJuego.Enter += new System.EventHandler(this.txtBuscadorJuego_Enter);
            this.txtBuscadorJuego.Leave += new System.EventHandler(this.txtBuscadorJuego_Leave);
            // 
            // dgvVerPartidos
            // 
            this.dgvVerPartidos.AllowUserToAddRows = false;
            this.dgvVerPartidos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvVerPartidos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVerPartidos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvVerPartidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVerPartidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVerPartidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVerPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerPartidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colCompetencia,
            this.colEquipoA,
            this.colEquipoB,
            this.colResultado,
            this.colJuego});
            this.dgvVerPartidos.DoubleBuffered = true;
            this.dgvVerPartidos.EnableHeadersVisualStyles = false;
            this.dgvVerPartidos.HeaderBgColor = System.Drawing.Color.Black;
            this.dgvVerPartidos.HeaderForeColor = System.Drawing.Color.White;
            this.dgvVerPartidos.Location = new System.Drawing.Point(18, 76);
            this.dgvVerPartidos.Name = "dgvVerPartidos";
            this.dgvVerPartidos.ReadOnly = true;
            this.dgvVerPartidos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVerPartidos.Size = new System.Drawing.Size(783, 372);
            this.dgvVerPartidos.TabIndex = 0;
            this.dgvVerPartidos.DoubleClick += new System.EventHandler(this.dgvVerPartidos_DoubleClick);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.bunifuSeparator1.LineThickness = 5;
            this.bunifuSeparator1.Location = new System.Drawing.Point(279, 72);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(123, 5);
            this.bunifuSeparator1.TabIndex = 45;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btnGestionarPartidos
            // 
            this.btnGestionarPartidos.ActiveBorderThickness = 1;
            this.btnGestionarPartidos.ActiveCornerRadius = 1;
            this.btnGestionarPartidos.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnGestionarPartidos.ActiveForecolor = System.Drawing.Color.White;
            this.btnGestionarPartidos.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnGestionarPartidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnGestionarPartidos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGestionarPartidos.BackgroundImage")));
            this.btnGestionarPartidos.ButtonText = "Gestionar";
            this.btnGestionarPartidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionarPartidos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarPartidos.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnGestionarPartidos.IdleBorderThickness = 1;
            this.btnGestionarPartidos.IdleCornerRadius = 1;
            this.btnGestionarPartidos.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnGestionarPartidos.IdleForecolor = System.Drawing.Color.White;
            this.btnGestionarPartidos.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnGestionarPartidos.Location = new System.Drawing.Point(404, 14);
            this.btnGestionarPartidos.Margin = new System.Windows.Forms.Padding(5);
            this.btnGestionarPartidos.Name = "btnGestionarPartidos";
            this.btnGestionarPartidos.Size = new System.Drawing.Size(123, 63);
            this.btnGestionarPartidos.TabIndex = 44;
            this.btnGestionarPartidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGestionarPartidos.Click += new System.EventHandler(this.btnGestionarPartidos_Click);
            // 
            // btnVerPartidos
            // 
            this.btnVerPartidos.ActiveBorderThickness = 1;
            this.btnVerPartidos.ActiveCornerRadius = 1;
            this.btnVerPartidos.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerPartidos.ActiveForecolor = System.Drawing.Color.White;
            this.btnVerPartidos.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerPartidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerPartidos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerPartidos.BackgroundImage")));
            this.btnVerPartidos.ButtonText = "Ver Partidos";
            this.btnVerPartidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerPartidos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerPartidos.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnVerPartidos.IdleBorderThickness = 1;
            this.btnVerPartidos.IdleCornerRadius = 1;
            this.btnVerPartidos.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerPartidos.IdleForecolor = System.Drawing.Color.White;
            this.btnVerPartidos.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerPartidos.Location = new System.Drawing.Point(279, 14);
            this.btnVerPartidos.Margin = new System.Windows.Forms.Padding(5);
            this.btnVerPartidos.Name = "btnVerPartidos";
            this.btnVerPartidos.Size = new System.Drawing.Size(123, 63);
            this.btnVerPartidos.TabIndex = 43;
            this.btnVerPartidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerPartidos.Click += new System.EventHandler(this.btnVerPartidos_Click);
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
            this.bunifuImageButton1.TabIndex = 48;
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
            this.btnCerrar.TabIndex = 47;
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
            this.btnMinimizar.TabIndex = 46;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Zoom = 10;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // panelGestionarPartido
            // 
            this.panelGestionarPartido.Controls.Add(this.label7);
            this.panelGestionarPartido.Controls.Add(this.label6);
            this.panelGestionarPartido.Controls.Add(this.label2);
            this.panelGestionarPartido.Controls.Add(this.label1);
            this.panelGestionarPartido.Controls.Add(this.label5);
            this.panelGestionarPartido.Controls.Add(this.label4);
            this.panelGestionarPartido.Controls.Add(this.txtArbitro);
            this.panelGestionarPartido.Controls.Add(this.txtResultado2);
            this.panelGestionarPartido.Controls.Add(this.btnEliminar);
            this.panelGestionarPartido.Controls.Add(this.btnModificar);
            this.panelGestionarPartido.Controls.Add(this.label3);
            this.panelGestionarPartido.Controls.Add(this.txtResultado1);
            this.panelGestionarPartido.Controls.Add(this.dtpFechaPartido);
            this.panelGestionarPartido.Location = new System.Drawing.Point(856, 82);
            this.panelGestionarPartido.Name = "panelGestionarPartido";
            this.panelGestionarPartido.Size = new System.Drawing.Size(816, 504);
            this.panelGestionarPartido.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.label7.Location = new System.Drawing.Point(666, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 36);
            this.label7.TabIndex = 43;
            this.label7.Text = "TIPO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.label6.Location = new System.Drawing.Point(49, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(347, 36);
            this.label6.TabIndex = 42;
            this.label6.Text = "NOMBRE COMPETENCIA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(409, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 28);
            this.label2.TabIndex = 41;
            this.label2.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(643, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 40;
            this.label1.Text = "EQUIPO B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(92, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 22);
            this.label5.TabIndex = 39;
            this.label5.Text = "EQUIPO A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(49, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 22);
            this.label4.TabIndex = 38;
            this.label4.Text = "ARBITRO:";
            // 
            // txtArbitro
            // 
            this.txtArbitro.BackColor = System.Drawing.Color.Transparent;
            this.txtArbitro.BorderRadius = 3;
            this.txtArbitro.ForeColor = System.Drawing.Color.White;
            this.txtArbitro.Items = new string[0];
            this.txtArbitro.Location = new System.Drawing.Point(155, 197);
            this.txtArbitro.Name = "txtArbitro";
            this.txtArbitro.NomalColor = System.Drawing.Color.SeaGreen;
            this.txtArbitro.onHoverColor = System.Drawing.Color.SeaGreen;
            this.txtArbitro.selectedIndex = -1;
            this.txtArbitro.Size = new System.Drawing.Size(586, 34);
            this.txtArbitro.TabIndex = 37;
            // 
            // txtResultado2
            // 
            this.txtResultado2.BorderColorFocused = System.Drawing.Color.White;
            this.txtResultado2.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtResultado2.BorderColorMouseHover = System.Drawing.Color.White;
            this.txtResultado2.BorderThickness = 3;
            this.txtResultado2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtResultado2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtResultado2.ForeColor = System.Drawing.Color.White;
            this.txtResultado2.isPassword = false;
            this.txtResultado2.Location = new System.Drawing.Point(451, 307);
            this.txtResultado2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtResultado2.Name = "txtResultado2";
            this.txtResultado2.Size = new System.Drawing.Size(105, 40);
            this.txtResultado2.TabIndex = 34;
            this.txtResultado2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.btnEliminar.ForeColor = System.Drawing.Color.Honeydew;
            this.btnEliminar.IdleBorderThickness = 1;
            this.btnEliminar.IdleCornerRadius = 1;
            this.btnEliminar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnEliminar.IdleForecolor = System.Drawing.Color.White;
            this.btnEliminar.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnEliminar.Location = new System.Drawing.Point(451, 419);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(217, 44);
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
            this.btnModificar.ForeColor = System.Drawing.Color.Honeydew;
            this.btnModificar.IdleBorderThickness = 1;
            this.btnModificar.IdleCornerRadius = 1;
            this.btnModificar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnModificar.IdleForecolor = System.Drawing.Color.White;
            this.btnModificar.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnModificar.Location = new System.Drawing.Point(164, 419);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(220, 44);
            this.btnModificar.TabIndex = 31;
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(67, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 22);
            this.label3.TabIndex = 30;
            this.label3.Text = "FECHA:";
            // 
            // txtResultado1
            // 
            this.txtResultado1.BorderColorFocused = System.Drawing.Color.White;
            this.txtResultado1.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtResultado1.BorderColorMouseHover = System.Drawing.Color.White;
            this.txtResultado1.BorderThickness = 3;
            this.txtResultado1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtResultado1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtResultado1.ForeColor = System.Drawing.Color.White;
            this.txtResultado1.isPassword = false;
            this.txtResultado1.Location = new System.Drawing.Point(279, 307);
            this.txtResultado1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtResultado1.Name = "txtResultado1";
            this.txtResultado1.Size = new System.Drawing.Size(105, 40);
            this.txtResultado1.TabIndex = 4;
            this.txtResultado1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // dtpFechaPartido
            // 
            this.dtpFechaPartido.BackColor = System.Drawing.Color.SeaGreen;
            this.dtpFechaPartido.BorderRadius = 0;
            this.dtpFechaPartido.ForeColor = System.Drawing.Color.White;
            this.dtpFechaPartido.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaPartido.FormatCustom = null;
            this.dtpFechaPartido.Location = new System.Drawing.Point(155, 136);
            this.dtpFechaPartido.Name = "dtpFechaPartido";
            this.dtpFechaPartido.Size = new System.Drawing.Size(586, 36);
            this.dtpFechaPartido.TabIndex = 27;
            this.dtpFechaPartido.Value = new System.DateTime(2019, 2, 12, 16, 49, 41, 988);
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "fecha";
            this.colFecha.HeaderText = "FECHA";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colCompetencia
            // 
            this.colCompetencia.DataPropertyName = "nombreCompetencia";
            this.colCompetencia.HeaderText = "COMPETENCIA";
            this.colCompetencia.Name = "colCompetencia";
            this.colCompetencia.ReadOnly = true;
            // 
            // colEquipoA
            // 
            this.colEquipoA.DataPropertyName = "equipoA";
            this.colEquipoA.HeaderText = "EQUIPO A";
            this.colEquipoA.Name = "colEquipoA";
            this.colEquipoA.ReadOnly = true;
            // 
            // colEquipoB
            // 
            this.colEquipoB.DataPropertyName = "equipoB";
            this.colEquipoB.HeaderText = "EQUIPO B";
            this.colEquipoB.Name = "colEquipoB";
            this.colEquipoB.ReadOnly = true;
            // 
            // colResultado
            // 
            this.colResultado.DataPropertyName = "resultado";
            this.colResultado.HeaderText = "RESULTADO";
            this.colResultado.Name = "colResultado";
            this.colResultado.ReadOnly = true;
            // 
            // colJuego
            // 
            this.colJuego.DataPropertyName = "juego";
            this.colJuego.HeaderText = "JUEGO";
            this.colJuego.Name = "colJuego";
            this.colJuego.ReadOnly = true;
            // 
            // GestionarPartidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(857, 598);
            this.Controls.Add(this.panelGestionarPartido);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btnGestionarPartidos);
            this.Controls.Add(this.btnVerPartidos);
            this.Controls.Add(this.panelBuscarPartido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionarPartidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionarPartidos";
            this.Load += new System.EventHandler(this.GestionarPartidos_Load);
            this.Click += new System.EventHandler(this.GestionarPartidos_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GestionarPartidos_MouseDown);
            this.panelBuscarPartido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerPartidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.panelGestionarPartido.ResumeLayout(false);
            this.panelGestionarPartido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelBuscarPartido;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscadorJuego;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvVerPartidos;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnGestionarPartidos;
        private Bunifu.Framework.UI.BunifuThinButton2 btnVerPartidos;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizar;
        private System.Windows.Forms.Panel panelGestionarPartido;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtResultado2;
        private Bunifu.Framework.UI.BunifuThinButton2 btnEliminar;
        private Bunifu.Framework.UI.BunifuThinButton2 btnModificar;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuDatepicker dtpFechaPartido;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtResultado1;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscadorEquipo;
        private Bunifu.Framework.UI.BunifuDatepicker dtpFecha;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuDropdown txtArbitro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompetencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipoA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJuego;
    }
}