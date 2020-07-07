namespace SistemaPlataforma
{
    partial class GestionarInscripciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarInscripciones));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelVerInscripciones = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dropdownBuscarTipoCompetencia = new Bunifu.Framework.UI.BunifuDropdown();
            this.txtBuscarJuego = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtBuscarEquipo = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnEliminarInscripcion = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnVerInscripción = new Bunifu.Framework.UI.BunifuThinButton2();
            this.dgvInscripciones = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.colFechaInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreCompetencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoCompetencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJuego = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVerInscripciones = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegresar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEquipo = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJuego = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTipoCompetencia = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreCompetencia = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dtpFechaInscripcion = new Bunifu.Framework.UI.BunifuDatepicker();
            this.panelVerInscripciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 7;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panelVerInscripciones
            // 
            this.panelVerInscripciones.Controls.Add(this.label6);
            this.panelVerInscripciones.Controls.Add(this.dropdownBuscarTipoCompetencia);
            this.panelVerInscripciones.Controls.Add(this.txtBuscarJuego);
            this.panelVerInscripciones.Controls.Add(this.txtBuscarEquipo);
            this.panelVerInscripciones.Controls.Add(this.btnEliminarInscripcion);
            this.panelVerInscripciones.Controls.Add(this.btnVerInscripción);
            this.panelVerInscripciones.Controls.Add(this.dgvInscripciones);
            this.panelVerInscripciones.Location = new System.Drawing.Point(12, 82);
            this.panelVerInscripciones.Name = "panelVerInscripciones";
            this.panelVerInscripciones.Size = new System.Drawing.Size(816, 504);
            this.panelVerInscripciones.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(487, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Tipo de Competencia";
            // 
            // dropdownBuscarTipoCompetencia
            // 
            this.dropdownBuscarTipoCompetencia.BackColor = System.Drawing.Color.Transparent;
            this.dropdownBuscarTipoCompetencia.BorderRadius = 3;
            this.dropdownBuscarTipoCompetencia.ForeColor = System.Drawing.Color.White;
            this.dropdownBuscarTipoCompetencia.Items = new string[0];
            this.dropdownBuscarTipoCompetencia.Location = new System.Drawing.Point(614, 33);
            this.dropdownBuscarTipoCompetencia.Name = "dropdownBuscarTipoCompetencia";
            this.dropdownBuscarTipoCompetencia.NomalColor = System.Drawing.Color.SeaGreen;
            this.dropdownBuscarTipoCompetencia.onHoverColor = System.Drawing.Color.SeaGreen;
            this.dropdownBuscarTipoCompetencia.selectedIndex = -1;
            this.dropdownBuscarTipoCompetencia.Size = new System.Drawing.Size(184, 36);
            this.dropdownBuscarTipoCompetencia.TabIndex = 28;
            this.dropdownBuscarTipoCompetencia.onItemSelected += new System.EventHandler(this.dropdownBuscarTipoCompetencia_onItemSelected);
            // 
            // txtBuscarJuego
            // 
            this.txtBuscarJuego.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtBuscarJuego.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtBuscarJuego.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtBuscarJuego.BorderThickness = 3;
            this.txtBuscarJuego.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarJuego.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBuscarJuego.ForeColor = System.Drawing.Color.White;
            this.txtBuscarJuego.isPassword = false;
            this.txtBuscarJuego.Location = new System.Drawing.Point(251, 29);
            this.txtBuscarJuego.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscarJuego.Name = "txtBuscarJuego";
            this.txtBuscarJuego.Size = new System.Drawing.Size(234, 40);
            this.txtBuscarJuego.TabIndex = 27;
            this.txtBuscarJuego.Text = "Juego...";
            this.txtBuscarJuego.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarJuego.OnValueChanged += new System.EventHandler(this.txtBuscarJuego_OnValueChanged);
            this.txtBuscarJuego.Enter += new System.EventHandler(this.txtBuscarJuego_Enter);
            this.txtBuscarJuego.Leave += new System.EventHandler(this.txtBuscarJuego_Leave);
            // 
            // txtBuscarEquipo
            // 
            this.txtBuscarEquipo.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtBuscarEquipo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtBuscarEquipo.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtBuscarEquipo.BorderThickness = 3;
            this.txtBuscarEquipo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarEquipo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBuscarEquipo.ForeColor = System.Drawing.Color.White;
            this.txtBuscarEquipo.isPassword = false;
            this.txtBuscarEquipo.Location = new System.Drawing.Point(18, 29);
            this.txtBuscarEquipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscarEquipo.Name = "txtBuscarEquipo";
            this.txtBuscarEquipo.Size = new System.Drawing.Size(230, 40);
            this.txtBuscarEquipo.TabIndex = 26;
            this.txtBuscarEquipo.Text = "Equipo..";
            this.txtBuscarEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarEquipo.OnValueChanged += new System.EventHandler(this.txtBuscarEquipo_OnValueChanged);
            this.txtBuscarEquipo.Enter += new System.EventHandler(this.txtBuscarEquipo_Enter);
            this.txtBuscarEquipo.Leave += new System.EventHandler(this.txtBuscarEquipo_Leave);
            // 
            // btnEliminarInscripcion
            // 
            this.btnEliminarInscripcion.ActiveBorderThickness = 1;
            this.btnEliminarInscripcion.ActiveCornerRadius = 1;
            this.btnEliminarInscripcion.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnEliminarInscripcion.ActiveForecolor = System.Drawing.Color.White;
            this.btnEliminarInscripcion.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnEliminarInscripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnEliminarInscripcion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarInscripcion.BackgroundImage")));
            this.btnEliminarInscripcion.ButtonText = "Eliminar Inscripción";
            this.btnEliminarInscripcion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarInscripcion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarInscripcion.ForeColor = System.Drawing.Color.Honeydew;
            this.btnEliminarInscripcion.IdleBorderThickness = 1;
            this.btnEliminarInscripcion.IdleCornerRadius = 1;
            this.btnEliminarInscripcion.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnEliminarInscripcion.IdleForecolor = System.Drawing.Color.White;
            this.btnEliminarInscripcion.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnEliminarInscripcion.Location = new System.Drawing.Point(555, 455);
            this.btnEliminarInscripcion.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminarInscripcion.Name = "btnEliminarInscripcion";
            this.btnEliminarInscripcion.Size = new System.Drawing.Size(243, 44);
            this.btnEliminarInscripcion.TabIndex = 5;
            this.btnEliminarInscripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminarInscripcion.Click += new System.EventHandler(this.btnEliminarInscripcion_Click);
            // 
            // btnVerInscripción
            // 
            this.btnVerInscripción.ActiveBorderThickness = 1;
            this.btnVerInscripción.ActiveCornerRadius = 1;
            this.btnVerInscripción.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnVerInscripción.ActiveForecolor = System.Drawing.Color.White;
            this.btnVerInscripción.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnVerInscripción.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerInscripción.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerInscripción.BackgroundImage")));
            this.btnVerInscripción.ButtonText = "Ver Inscripción";
            this.btnVerInscripción.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerInscripción.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerInscripción.ForeColor = System.Drawing.Color.Honeydew;
            this.btnVerInscripción.IdleBorderThickness = 1;
            this.btnVerInscripción.IdleCornerRadius = 1;
            this.btnVerInscripción.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.btnVerInscripción.IdleForecolor = System.Drawing.Color.White;
            this.btnVerInscripción.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnVerInscripción.Location = new System.Drawing.Point(15, 455);
            this.btnVerInscripción.Margin = new System.Windows.Forms.Padding(5);
            this.btnVerInscripción.Name = "btnVerInscripción";
            this.btnVerInscripción.Size = new System.Drawing.Size(243, 44);
            this.btnVerInscripción.TabIndex = 4;
            this.btnVerInscripción.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerInscripción.Click += new System.EventHandler(this.btnVerInscripción_Click);
            // 
            // dgvInscripciones
            // 
            this.dgvInscripciones.AllowUserToAddRows = false;
            this.dgvInscripciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvInscripciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInscripciones.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvInscripciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInscripciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInscripciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInscripciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFechaInscripcion,
            this.colNombreCompetencia,
            this.colTipoCompetencia,
            this.colJuego,
            this.colEquipo});
            this.dgvInscripciones.DoubleBuffered = true;
            this.dgvInscripciones.EnableHeadersVisualStyles = false;
            this.dgvInscripciones.HeaderBgColor = System.Drawing.Color.Black;
            this.dgvInscripciones.HeaderForeColor = System.Drawing.Color.White;
            this.dgvInscripciones.Location = new System.Drawing.Point(15, 75);
            this.dgvInscripciones.Name = "dgvInscripciones";
            this.dgvInscripciones.ReadOnly = true;
            this.dgvInscripciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInscripciones.Size = new System.Drawing.Size(783, 372);
            this.dgvInscripciones.TabIndex = 0;
            this.dgvInscripciones.Click += new System.EventHandler(this.dgvInscripciones_Click);
            // 
            // colFechaInscripcion
            // 
            this.colFechaInscripcion.DataPropertyName = "fechaInscripcion";
            this.colFechaInscripcion.HeaderText = "FECHA INSCRIPCIÓN";
            this.colFechaInscripcion.Name = "colFechaInscripcion";
            this.colFechaInscripcion.ReadOnly = true;
            // 
            // colNombreCompetencia
            // 
            this.colNombreCompetencia.DataPropertyName = "nombreCompetencia";
            this.colNombreCompetencia.HeaderText = "COMPETENCIA";
            this.colNombreCompetencia.Name = "colNombreCompetencia";
            this.colNombreCompetencia.ReadOnly = true;
            // 
            // colTipoCompetencia
            // 
            this.colTipoCompetencia.DataPropertyName = "tipoCompetencia";
            this.colTipoCompetencia.HeaderText = "TIPO";
            this.colTipoCompetencia.Name = "colTipoCompetencia";
            this.colTipoCompetencia.ReadOnly = true;
            // 
            // colJuego
            // 
            this.colJuego.DataPropertyName = "juego";
            this.colJuego.HeaderText = "JUEGO";
            this.colJuego.Name = "colJuego";
            this.colJuego.ReadOnly = true;
            // 
            // colEquipo
            // 
            this.colEquipo.DataPropertyName = "nombre";
            this.colEquipo.HeaderText = "EQUIPO";
            this.colEquipo.Name = "colEquipo";
            this.colEquipo.ReadOnly = true;
            // 
            // btnVerInscripciones
            // 
            this.btnVerInscripciones.ActiveBorderThickness = 1;
            this.btnVerInscripciones.ActiveCornerRadius = 1;
            this.btnVerInscripciones.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerInscripciones.ActiveForecolor = System.Drawing.Color.White;
            this.btnVerInscripciones.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(81)))), ((int)(((byte)(89)))));
            this.btnVerInscripciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerInscripciones.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerInscripciones.BackgroundImage")));
            this.btnVerInscripciones.ButtonText = "Ver Inscripciones";
            this.btnVerInscripciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerInscripciones.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerInscripciones.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnVerInscripciones.IdleBorderThickness = 1;
            this.btnVerInscripciones.IdleCornerRadius = 1;
            this.btnVerInscripciones.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerInscripciones.IdleForecolor = System.Drawing.Color.White;
            this.btnVerInscripciones.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.btnVerInscripciones.Location = new System.Drawing.Point(333, 14);
            this.btnVerInscripciones.Margin = new System.Windows.Forms.Padding(5);
            this.btnVerInscripciones.Name = "btnVerInscripciones";
            this.btnVerInscripciones.Size = new System.Drawing.Size(146, 63);
            this.btnVerInscripciones.TabIndex = 35;
            this.btnVerInscripciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.bunifuSeparator1.LineThickness = 5;
            this.bunifuSeparator1.Location = new System.Drawing.Point(333, 67);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(146, 10);
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
            this.bunifuImageButton1.TabIndex = 45;
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
            this.btnCerrar.TabIndex = 44;
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
            this.btnMinimizar.TabIndex = 43;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Zoom = 10;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtEquipo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtJuego);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTipoCompetencia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNombreCompetencia);
            this.panel1.Controls.Add(this.dtpFechaInscripcion);
            this.panel1.Location = new System.Drawing.Point(856, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 504);
            this.panel1.TabIndex = 46;
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
            this.btnRegresar.Location = new System.Drawing.Point(175, 416);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(5);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(625, 44);
            this.btnRegresar.TabIndex = 16;
            this.btnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(108, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "EQUIPO:";
            // 
            // txtEquipo
            // 
            this.txtEquipo.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtEquipo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtEquipo.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtEquipo.BorderThickness = 3;
            this.txtEquipo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEquipo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEquipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEquipo.isPassword = false;
            this.txtEquipo.Location = new System.Drawing.Point(175, 307);
            this.txtEquipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEquipo.Name = "txtEquipo";
            this.txtEquipo.Size = new System.Drawing.Size(625, 40);
            this.txtEquipo.TabIndex = 14;
            this.txtEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(113, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "JUEGO:";
            // 
            // txtJuego
            // 
            this.txtJuego.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtJuego.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtJuego.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtJuego.BorderThickness = 3;
            this.txtJuego.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJuego.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtJuego.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtJuego.isPassword = false;
            this.txtJuego.Location = new System.Drawing.Point(175, 240);
            this.txtJuego.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJuego.Name = "txtJuego";
            this.txtJuego.Size = new System.Drawing.Size(625, 40);
            this.txtJuego.TabIndex = 12;
            this.txtJuego.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(5, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "FECHA DE INSCRIPCION:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(102, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "NOMBRE:";
            // 
            // txtTipoCompetencia
            // 
            this.txtTipoCompetencia.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtTipoCompetencia.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtTipoCompetencia.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtTipoCompetencia.BorderThickness = 3;
            this.txtTipoCompetencia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTipoCompetencia.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTipoCompetencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTipoCompetencia.isPassword = false;
            this.txtTipoCompetencia.Location = new System.Drawing.Point(175, 109);
            this.txtTipoCompetencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTipoCompetencia.Name = "txtTipoCompetencia";
            this.txtTipoCompetencia.Size = new System.Drawing.Size(625, 40);
            this.txtTipoCompetencia.TabIndex = 9;
            this.txtTipoCompetencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(11, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "TIPO DE COMPETENCIA:";
            // 
            // txtNombreCompetencia
            // 
            this.txtNombreCompetencia.BorderColorFocused = System.Drawing.Color.Gainsboro;
            this.txtNombreCompetencia.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(177)))), ((int)(((byte)(136)))));
            this.txtNombreCompetencia.BorderColorMouseHover = System.Drawing.Color.Gainsboro;
            this.txtNombreCompetencia.BorderThickness = 3;
            this.txtNombreCompetencia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombreCompetencia.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtNombreCompetencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNombreCompetencia.isPassword = false;
            this.txtNombreCompetencia.Location = new System.Drawing.Point(175, 42);
            this.txtNombreCompetencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombreCompetencia.Name = "txtNombreCompetencia";
            this.txtNombreCompetencia.Size = new System.Drawing.Size(625, 40);
            this.txtNombreCompetencia.TabIndex = 7;
            this.txtNombreCompetencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // dtpFechaInscripcion
            // 
            this.dtpFechaInscripcion.BackColor = System.Drawing.Color.SeaGreen;
            this.dtpFechaInscripcion.BorderRadius = 0;
            this.dtpFechaInscripcion.ForeColor = System.Drawing.Color.White;
            this.dtpFechaInscripcion.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaInscripcion.FormatCustom = null;
            this.dtpFechaInscripcion.Location = new System.Drawing.Point(175, 178);
            this.dtpFechaInscripcion.Name = "dtpFechaInscripcion";
            this.dtpFechaInscripcion.Size = new System.Drawing.Size(625, 36);
            this.dtpFechaInscripcion.TabIndex = 6;
            this.dtpFechaInscripcion.Value = new System.DateTime(2019, 2, 14, 18, 38, 14, 748);
            // 
            // GestionarInscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(860, 598);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btnVerInscripciones);
            this.Controls.Add(this.panelVerInscripciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionarInscripciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionarInscripciones";
            this.Load += new System.EventHandler(this.GestionarInscripciones_Load);
            this.Click += new System.EventHandler(this.GestionarInscripciones_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GestionarInscripciones_MouseDown);
            this.panelVerInscripciones.ResumeLayout(false);
            this.panelVerInscripciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelVerInscripciones;
        private Bunifu.Framework.UI.BunifuThinButton2 btnVerInscripción;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvInscripciones;
        private Bunifu.Framework.UI.BunifuThinButton2 btnVerInscripciones;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnEliminarInscripcion;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizar;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuDatepicker dtpFechaInscripcion;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtEquipo;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtJuego;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtTipoCompetencia;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtNombreCompetencia;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuDropdown dropdownBuscarTipoCompetencia;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscarJuego;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBuscarEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCompetencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoCompetencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJuego;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipo;
        private Bunifu.Framework.UI.BunifuThinButton2 btnRegresar;
    }
}