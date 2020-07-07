using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace SistemaPlataforma
{
    public partial class GestionarCompetencias : Form
    {

        #region Almacenar Credenciales de la Competencia
        public static string idCompetenciaSeleccionada = "";
        public static string idInscripcionCompetenciaSeleccionada = "";
        #endregion

        #region Inicializar Componentes
        public GestionarCompetencias()
        {
            InitializeComponent();

            #region Carga Dropdown Fecha Inicio Competencia
            dtpFechaInicio.Value = DateTime.Today;
            #endregion

            #region Carga Dropdown Fecha Fin Competencia
            dtpFechaFin.Value = DateTime.Today;
            #endregion

            #region Carga Dropdown Tipo Competencia
            //Carga Buscar Tipo Competencia
            dropdownBuscarTipoCompetencia.AddItem("Todos");
            dropdownBuscarTipoCompetencia.AddItem("Torneo");
            dropdownBuscarTipoCompetencia.AddItem("Liga");
            #endregion

            #region Carga Tipo Competencia en Panel de Gestionar
            //Carga Tipo Torneo
            dropdownTipoCompetencia.AddItem("Torneo");
            dropdownTipoCompetencia.AddItem("Liga");
            #endregion

            #region Carga de Juegos Existentes en el sistema a DropdownJuego

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando = new SqlCommand("Select nombreJuego from juegos", SqlCon);
                SqlCon.Open();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    dropdownJuego.AddItem(registro["nombreJuego"].ToString());
                }
                SqlCon.Close();
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }

            #endregion

            #region Carga Dropdown Cantidad Equipos Competencia
            //Carga de Cantidad de Equipos
            dropdownCantidadEquipos.AddItem("8");
            dropdownCantidadEquipos.AddItem("16");
            dropdownCantidadEquipos.AddItem("32");
            #endregion

            ModoNuevo();
            ListarCompetencias();
        }
        #endregion

        #region Modo Nuevo
        private void ModoNuevo()
        {
            this.btnNuevo.Visible = true;
            this.btnModificar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnGestionarEquipos.Visible = false;
            this.btnNuevo.Width = 778; //598
            this.txtBuscarNombre.Text = "Nombre de la Competencia...";
            this.txtBuscarJuego.Text = "Juego...";
            this.txtNombreCompetencia.Text = "Nombre de la Competencia...";
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            dropdownBuscarTipoCompetencia.selectedIndex = 0;
            dropdownJuego.selectedIndex = 0;
            dropdownTipoCompetencia.selectedIndex = 0;
            dropdownCantidadEquipos.selectedIndex = 0;
            dropdownBuscarTipoCompetencia.selectedIndex = 0;
        }
        #endregion

        #region Listar Competencias
        private void ListarCompetencias()
        {
            this.dgvCompetencias.DataSource = CCompetencia.Mostrar();
            this.dgvCompetencias.Columns["idCompetencia"].Visible = false;
            this.dgvCompetencias.Columns["equiposInscriptos"].Visible = false;
            this.dgvCompetencias.RowHeadersVisible = false;
            this.dgvCompetencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompetencias.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCompetencias.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvCompetencias.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region Cerrar Formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Desplazar al Panel de Ver Competencias
        private void btnVerCompetencias_Click(object sender, EventArgs e)
        {
            if (panelBuscarCompetencia.Left == 705 || panelBuscarCompetencia.Left == 1344)
            {
                panelGestionarCompetencias.Visible = false;
                panelGestionarCompetencias.Left = 705;
                panelGestionarEquiposInscriptos.Visible = false;

                panelBuscarCompetencia.Visible = false;
                panelBuscarCompetencia.Left = 10;
                panelBuscarCompetencia.Visible = true;


                bunifuSeparator1.Left = btnVerCompetencias.Left;
                bunifuSeparator1.Width = btnVerCompetencias.Width;

                #region Resetear Campos Panel Gestionar Competencia
                ModoNuevo();
                #endregion

            }
        }
        #endregion

        #region Desplazar al Panel de Gestionar Competencias
        private void btnGestionarCompetencias_Click(object sender, EventArgs e)
        {
            if (panelGestionarCompetencias.Left == 859 || panelGestionarCompetencias.Left == 705)
            {
                panelBuscarCompetencia.Visible = false;
                panelBuscarCompetencia.Left = 705;
                panelGestionarEquiposInscriptos.Visible = false;
                panelGestionarEquiposInscriptos.Left = 705;

                panelGestionarCompetencias.Visible = false;
                panelGestionarCompetencias.Left = 15;
                panelGestionarCompetencias.Visible = true;

                bunifuSeparator1.Left = btnGestionarCompetencias.Left;
                bunifuSeparator1.Width = btnGestionarCompetencias.Width;
            }
        }
        #endregion

        #region Minimizar Formulario
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Configuracion Campos Gestionar

        #region Limpiar Campo Nombre Competencia al hacer click
        private void txtNombreCompetencia_Enter(object sender, EventArgs e)
        {
            if (txtNombreCompetencia.Text == "Nombre de la Competencia...")
            {
                txtNombreCompetencia.Text = "";
            }
        }

        private void txtNombreCompetencia_Leave(object sender, EventArgs e)
        {
            if (txtNombreCompetencia.Text == "")
            {
                txtNombreCompetencia.Text = "Nombre de la Competencia...";
            }
        }
        #endregion

        #region Limpiar Campo Buscar Juego Competencia al hacer click
        private void txtBuscarJuego_Enter(object sender, EventArgs e)
        {
            if (txtBuscarJuego.Text == "Juego...")
            {
                txtBuscarJuego.Text = "";
            }
        }

        private void txtBuscarJuego_Leave(object sender, EventArgs e)
        {
            if (txtBuscarJuego.Text != "Juego...")
            {
                txtBuscarJuego.Text = "Juego...";
            }
        }
        #endregion

        #region Limpiar Campo Buscar Nombre Competencia al hacer click
        private void txtBuscarNombre_Enter(object sender, EventArgs e)
        {
            if (txtBuscarNombre.Text == "Nombre de la Competencia...")
            {
                txtBuscarNombre.Text = "";
            }
        }

        private void txtBuscarNombre_Leave(object sender, EventArgs e)
        {
            if (txtBuscarNombre.Text != "Nombre de la Competencia...")
            {
                txtBuscarNombre.Text = "Nombre de la Competencia...";
            }
        }
        #endregion

        #region Click en el Formulario
        private void GestionarCompetencias_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreCompetencia.Text))
            {
                txtNombreCompetencia.Text = "Nombre de la Competencia...";
            }
            if (String.IsNullOrEmpty(txtBuscarNombre.Text))
            {
                txtBuscarNombre.Text = "Nombre de la Competencia...";
            }
            if (String.IsNullOrEmpty(txtBuscarJuego.Text))
            {
                txtBuscarJuego.Text = "Juego...";
            }
        }

        #endregion

        #endregion

        #region Mensaje de Error
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Boton Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                rpta = CCompetencia.Insertar(this.txtNombreCompetencia.Text, this.dtpFechaInicio.Value, this.dtpFechaFin.Value, this.dropdownJuego.selectedValue, this.dropdownTipoCompetencia.selectedValue, int.Parse(this.dropdownCantidadEquipos.selectedValue));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "La competencia se ha creado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarCompetencias.Visible = false;
                    panelGestionarCompetencias.Left = 705;
                    panelBuscarCompetencia.Visible = false;
                    panelBuscarCompetencia.Left = 15;
                    panelBuscarCompetencia.Visible = true;
                    bunifuSeparator1.Left = btnVerCompetencias.Left;
                    bunifuSeparator1.Width = btnVerCompetencias.Width;
                    ModoNuevo();
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "La creación de la competencia no ha sido exitosa!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                this.ListarCompetencias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Boton Volver
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            PanelDeAdmin frmPanelGestion = new PanelDeAdmin();
            frmPanelGestion.Show();
            this.Hide();
        }
        #endregion

        #region Validar Juego Competencia
        private static int ValidarJuegoCompetencia(string juegoCompetencia)
        {
            int index = 0;

            switch (juegoCompetencia)
            {
                case "Brawlhalla":
                    index = 0;
                    break;
                case "Clash Royale":
                    index = 1;
                    break;
                case "HearthStone":
                    index = 2;
                    break;
                case "League of Legends":
                    index = 3;
                    break;
                case "Rocket League":
                    index = 4;
                    break;
                case "Vainglory":
                    index = 5;
                    break;
            }
            return index;
        }
        #endregion

        #region Validar Tipo Competencia
        private static int ValidarTipoCompetencia(string tipoCompetencia)
        {
            int index = 0;

            switch (tipoCompetencia)
            {
                case "Torneo":
                    index = 0;
                    break;
                case "Liga":
                    index = 1;
                    break;
            }
            return index;
        }
        #endregion

        #region Validar Cantidad Competencia
        private static int ValidarCantidadCompetencia(string cantCompetencia)
        {
            int index = 0;

            switch (cantCompetencia)
            {
                case "8":
                    index = 0;
                    break;
                case "16":
                    index = 1;
                    break;
                case "32":
                    index = 2;
                    break;
            }
            return index;
        }
        #endregion

        #region Modo Modificar y Eliminar
        private void dgvCompetencias_DoubleClick(object sender, EventArgs e)
        {
            #region Configuracion Visibilidad Botones
            this.btnNuevo.Visible = false;
            this.btnModificar.Visible = true;
            this.btnEliminar.Visible = true;
            this.btnGestionarEquipos.Visible = true;
            #endregion

            #region Carga el ID de la Competencia Seleccionada
            idCompetenciaSeleccionada = Convert.ToString(this.dgvCompetencias.CurrentRow.Cells["idCompetencia"].Value);
            #endregion

            #region Carga el Nombre de la Competencia Seleccionada
            this.txtNombreCompetencia.Text = Convert.ToString(this.dgvCompetencias.CurrentRow.Cells["colNombreCompetencia"].Value);
            #endregion

            #region Carga la Fecha de Inicio de la Competencia Seleccionada
            this.dtpFechaInicio.Value = Convert.ToDateTime(this.dgvCompetencias.CurrentRow.Cells["colFechaInicio"].Value);
            #endregion

            #region Carga la Fecha Fin de la Competencia Seleccionada
            this.dtpFechaFin.Value = Convert.ToDateTime(this.dgvCompetencias.CurrentRow.Cells["colFechaFin"].Value);
            #endregion

            #region Carga el Juego de la Competencia Seleccionada
            int Selected = -1;
            int count = 1000000000;
            for (int i = 0; (i <= (count - 1)); i++)
            {
                dropdownJuego.selectedIndex = i;
                if ((string)(dropdownJuego.selectedValue) == Convert.ToString(this.dgvCompetencias.CurrentRow.Cells["colJuego"].Value))
                {
                    Selected = i;
                    break;
                }

            }

            dropdownJuego.selectedIndex = Selected;
            #endregion

            #region Carga el Tipo de la Competencia Seleccionada
            this.dropdownTipoCompetencia.selectedIndex = ValidarTipoCompetencia(Convert.ToString(this.dgvCompetencias.CurrentRow.Cells["colTipoCompetencia"].Value));
            #endregion

            #region Carga la Cantidad de Cupos de la Competencia Seleccionada
            this.dropdownCantidadEquipos.selectedIndex = ValidarCantidadCompetencia(Convert.ToString(this.dgvCompetencias.CurrentRow.Cells["colCupos"].Value));
            #endregion

            panelBuscarCompetencia.Visible = false;
            panelBuscarCompetencia.Left = 705;
            panelGestionarEquiposInscriptos.Visible = false;
            panelGestionarEquiposInscriptos.Left = 705;

            panelGestionarCompetencias.Visible = false;
            panelGestionarCompetencias.Left = 15;
            panelGestionarCompetencias.Visible = true;


            bunifuSeparator1.Left = btnGestionarCompetencias.Left;
            bunifuSeparator1.Width = btnGestionarCompetencias.Width;
        }

        #endregion

        #region Boton Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                rpta = CCompetencia.Editar(int.Parse(idCompetenciaSeleccionada),this.txtNombreCompetencia.Text, this.dtpFechaInicio.Value, this.dtpFechaFin.Value, this.dropdownJuego.selectedValue, this.dropdownTipoCompetencia.selectedValue, int.Parse(this.dropdownCantidadEquipos.selectedValue));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "La competencia se ha modificado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarCompetencias.Visible = false;
                    panelGestionarCompetencias.Left = 705;
                    panelBuscarCompetencia.Visible = false;
                    panelBuscarCompetencia.Left = 15;
                    panelBuscarCompetencia.Visible = true;
                    bunifuSeparator1.Left = btnVerCompetencias.Left;
                    bunifuSeparator1.Width = btnVerCompetencias.Width;
                    ModoNuevo();
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido modificar la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                this.ListarCompetencias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        #endregion

        #region Boton Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                DialogResult VentanaEmergente;
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere eliminar el usuario?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {
                    rpta = CCompetencia.Eliminar(Convert.ToInt32(idCompetenciaSeleccionada));

                    if (rpta.Equals("OK"))
                    {
                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "La competencia se ha eliminado exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                        //MessageBox.Show("Se eliminó correctamente!");
                        panelGestionarCompetencias.Visible = false;
                        panelGestionarCompetencias.Left = 705;
                        panelBuscarCompetencia.Visible = false;
                        panelBuscarCompetencia.Left = 15;
                        panelBuscarCompetencia.Visible = true;
                        bunifuSeparator1.Left = btnVerCompetencias.Left;
                        bunifuSeparator1.Width = btnVerCompetencias.Width;
                        ModoNuevo();
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "No se ha podido eliminar la competencia correctamente!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }

                    this.ListarCompetencias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Desplazar al Panel de Equipos Inscriptos
        private void btnGestionarEquipos_Click(object sender, EventArgs e)
        {
            if (panelGestionarEquiposInscriptos.Left == 1344 || panelGestionarEquiposInscriptos.Left == 705)
            {
                panelGestionarCompetencias.Visible = false;
                panelGestionarCompetencias.Left = 1344;
                panelBuscarCompetencia.Visible = false;
                panelBuscarCompetencia.Left = 1344;

                panelGestionarEquiposInscriptos.Visible = false;
                panelGestionarEquiposInscriptos.Left = 15;
                panelGestionarEquiposInscriptos.Visible = true;

                bunifuSeparator1.Left = btnGestionarCompetencias.Left;
                bunifuSeparator1.Width = btnGestionarCompetencias.Width;

                BuscarInscripcionesCompetencia();

                if (dgvEquiposInscriptos.Rows.Count == 0)
                {
                    this.btnEliminarInscripcion.Visible = false;
                }
                else
                {
                    this.btnEliminarInscripcion.Visible = true;
                }
            }
        }
        #endregion

        #region Buscar Competencia Por Nombre
        private void BuscarCompetenciaPorNombre()
        {
            if (String.IsNullOrEmpty(txtBuscarNombre.Text) || txtBuscarNombre.Text == "Nombre de la Competencia...")
            {
                ListarCompetencias();
                //this.txtBuscarUsuario.Text = "BUSCAR USUARIO...";
            }
            else
            {
                this.dgvCompetencias.DataSource = CCompetencia.BuscarCompetenciaPorNombre(txtBuscarNombre.Text);
                //this.txt.Text = "BUSCAR USUARIO...";
            }

        }
        #endregion

        #region Buscar Competencia Por Juego
        private void BuscarCompetenciaPorJuego()
        {
            if (String.IsNullOrEmpty(txtBuscarJuego.Text) || txtBuscarJuego.Text == "Juego...")
            {
                ListarCompetencias();
                //this.txtBuscarUsuario.Text = "BUSCAR USUARIO...";
            }
            else
            {
                this.dgvCompetencias.DataSource = CCompetencia.BuscarCompetenciaPorJuego(txtBuscarJuego.Text);
                //this.txt.Text = "BUSCAR USUARIO...";
            }

        }
        #endregion

        #region Buscar Competencia Por Tipo
        private void BuscarCompetenciaPorTipo()
        {
            if (dropdownBuscarTipoCompetencia.selectedValue == "Todos")
            {
                ListarCompetencias();
                //this.txtBuscarUsuario.Text = "BUSCAR USUARIO...";
            }
            else
            {
                this.dgvCompetencias.DataSource = CCompetencia.BuscarCompetenciaPorTipo(dropdownBuscarTipoCompetencia.selectedValue);
                //this.txt.Text = "BUSCAR USUARIO...";
            }

        }
        #endregion

        #region Buscar Inscripciones de la Competencia Seleccionada
        private void BuscarInscripcionesCompetencia()
        {
            this.dgvEquiposInscriptos.DataSource = CCompetencia.BuscarInscripcionesCompetencia(idCompetenciaSeleccionada);
            this.dgvEquiposInscriptos.Columns["idInscripcion"].Visible = false;
            this.dgvEquiposInscriptos.Columns["idCompetencia"].Visible = false;
            this.dgvEquiposInscriptos.RowHeadersVisible = false;
            foreach (DataGridViewColumn col in dgvCompetencias.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region Filtro Buscar Nombre Competencia
        private void txtBuscarNombre_OnValueChanged(object sender, EventArgs e)
        {
            BuscarCompetenciaPorNombre();
        }

        #endregion

        #region Filtro Buscar Juego Competencia
        private void txtBuscarJuego_OnValueChanged(object sender, EventArgs e)
        {
            BuscarCompetenciaPorJuego();
        }


        #endregion

        #region Filtro Buscar Tipo Competencia
        private void dropdownBuscarTipoCompetencia_onItemSelected(object sender, EventArgs e)
        {
            BuscarCompetenciaPorTipo();
        }

        #endregion

        #region Listar Inscripciones en Competencias
        private void ListarInscripcionesCompetencias()
        {
            this.dgvEquiposInscriptos.DataSource = CCompetencia.MostrarInscripcionesEnCompetencias();
            this.dgvEquiposInscriptos.Columns["idInscripcion"].Visible = false;
            this.dgvEquiposInscriptos.Columns["idCompetencia"].Visible = false;
            this.dgvEquiposInscriptos.RowHeadersVisible = false;
            foreach (DataGridViewColumn col in dgvCompetencias.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region Boton Eliminar Inscripcion
        private void btnEliminarInscripcion_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                DialogResult VentanaEmergente;
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere eliminar la inscripción?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {
                    rpta = CInscripcion.Eliminar(Convert.ToInt32(idInscripcionCompetenciaSeleccionada));

                    if (rpta.Equals("OK"))
                    {
                        MessageBox.Show("Se eliminó correctamente!");
                    }
                    else
                    {
                        MensajeError(rpta);
                    }

                    this.BuscarInscripcionesCompetencia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Seleccionar Inscripcion
        private void dgvEquiposInscriptos_Click(object sender, EventArgs e)
        {
            idInscripcionCompetenciaSeleccionada = Convert.ToString(this.dgvCompetencias.CurrentRow.Cells["idInscripcion"].Value);
        }
        #endregion

        #region Pantalla Arrastrable
        private void GestionarCompetencias_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void GestionarCompetencias_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        #endregion

    }
}
