namespace SistemaPlataforma
{
    partial class Partidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Partidos));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelBuscarPartido = new System.Windows.Forms.Panel();
            this.txtBuscadorEquipo = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dtpFecha = new Bunifu.Framework.UI.BunifuDatepicker();
            this.txtBuscadorJuego = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dgvVerPartidos = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompetencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipoA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJuego = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelGestionarPartido = new System.Windows.Forms.Panel();
            this.btnRegresar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArbitro = new Bunifu.Framework.UI.BunifuDropdown();
            this.txtResultado2 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtResultado1 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dtpFechaPartido = new Bunifu.Framework.UI.BunifuDatepicker();
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
            this.bunifuElipse1.ElipseRadius = 5;
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
            this.panelBuscarPartido.TabIndex = 34;
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
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvVerPartidos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVerPartidos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvVerPartidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVerPartidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVerPartidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(375, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 33);
            this.label2.TabIndex = 37;
            this.label2.Text = "PARTIDOS";
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
            // panelGestionarPartido
            // 
            this.panelGestionarPartido.Controls.Add(this.btnRegresar);
            this.panelGestionarPartido.Controls.Add(this.label7);
            this.panelGestionarPartido.Controls.Add(this.label6);
            this.panelGestionarPartido.Controls.Add(this.label1);
            this.panelGestionarPartido.Controls.Add(this.label3);
            this.panelGestionarPartido.Controls.Add(this.label5);
            this.panelGestionarPartido.Controls.Add(this.label4);
            this.panelGestionarPartido.Controls.Add(this.txtArbitro);
            this.panelGestionarPartido.Controls.Add(this.txtResultado2);
            this.panelGestionarPartido.Controls.Add(this.label8);
            this.panelGestionarPartido.Controls.Add(this.txtResultado1);
            this.panelGestionarPartido.Controls.Add(this.dtpFechaPartido);
            this.panelGestionarPartido.Location = new System.Drawing.Point(856, 82);
            this.panelGestionarPartido.Name = "panelGestionarPartido";
            this.panelGestionarPartido.Size = new System.Drawing.Size(816, 504);
            this.panelGestionarPartido.TabIndex = 52;
            // 
            // btnRegresar
            // 
            this.btnRegresar.ActiveBorderThickness = 1;
            this.btnRegresar.ActiveCornerRadius = 1;
            this.btnRegresar.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnRegresar.ActiveForecolor = System.Drawing.Color.White;
            this.btnRegresar.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnRegresar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegresar.BackgroundImage")));
            this.btnRegresar.ButtonText = "Regresar";
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.Honeydew;
            this.btnRegresar.IdleBorderThickness = 1;
            this.btnRegresar.IdleCornerRadius = 1;
            this.btnRegresar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnRegresar.IdleForecolor = System.Drawing.Color.White;
            this.btnRegresar.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnRegresar.Location = new System.Drawing.Point(183, 439);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(5);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(466, 44);
            this.btnRegresar.TabIndex = 44;
            this.btnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(409, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 28);
            this.label1.TabIndex = 41;
            this.label1.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(643, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 40;
            this.label3.Text = "EQUIPO B";
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
            this.txtArbitro.Enabled = false;
            this.txtArbitro.ForeColor = System.Drawing.Color.White;
            this.txtArbitro.Items = new string[0];
            this.txtArbitro.Location = new System.Drawing.Point(155, 197);
            this.txtArbitro.Name = "txtArbitro";
            this.txtArbitro.NomalColor = System.Drawing.Color.SeaGreen;
            this.txtArbitro.onHoverColor = System.Drawing.Color.SeaGreen;
            this.txtArbitro.selectedIndex = -1;
            this.txtArbitro.Size = new System.Drawing.Size(586, 36);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(67, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 22);
            this.label8.TabIndex = 30;
            this.label8.Text = "FECHA:";
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
            this.dtpFechaPartido.Enabled = false;
            this.dtpFechaPartido.ForeColor = System.Drawing.Color.White;
            this.dtpFechaPartido.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaPartido.FormatCustom = null;
            this.dtpFechaPartido.Location = new System.Drawing.Point(155, 136);
            this.dtpFechaPartido.Name = "dtpFechaPartido";
            this.dtpFechaPartido.Size = new System.Drawing.Size(586, 36);
            this.dtpFechaPartido.TabIndex = 27;
            this.dtpFechaPartido.Value = new System.DateTime(2019, 2, 12, 16, 49, 41, 988);
            // 
            // Partidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(854, 598);
            this.Controls.Add(this.panelGestionarPartido);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelBuscarPartido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Partidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Partidos";
            this.Load += new System.EventHandler(this.Partidos_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Partidos_MouseDown);
            this.panelBuscarPartido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerPartidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.panelGestionarPartido.ResumeLayout(false);
            this.panelGestionarPartido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelBuscarPartido;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscadorEquipo;
        private Bunifu.Framework.UI.BunifuDatepicker dtpFecha;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscadorJuego;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompetencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipoA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJuego;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizar;
        private System.Windows.Forms.Panel panelGestionarPartido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuDropdown txtArbitro;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtResultado2;
        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtResultado1;
        private Bunifu.Framework.UI.BunifuDatepicker dtpFechaPartido;
        private Bunifu.Framework.UI.BunifuThinButton2 btnRegresar;
        public Bunifu.Framework.UI.BunifuCustomDataGrid dgvVerPartidos;
    }
}