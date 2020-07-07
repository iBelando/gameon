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

namespace SistemaPlataforma
{
    public partial class GestionarInscripciones : Form
    {

        #region Almacenar Credenciales de la Inscripcion
        public static string idInscripcionSeleccionada = "";
        #endregion

        #region Inicializar Componentes
        public GestionarInscripciones()
        {
            InitializeComponent();
            //Carga Buscar Tipo Competencia
            dropdownBuscarTipoCompetencia.AddItem("Todos");
            dropdownBuscarTipoCompetencia.AddItem("Torneo");
            dropdownBuscarTipoCompetencia.AddItem("Liga");
            dropdownBuscarTipoCompetencia.selectedIndex = 0;
            ListarInscripciones();
        }
        #endregion

        #region Cerrar Formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Minimizar Formulario
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Listar Inscripciones
        private void ListarInscripciones()
        {
            this.dgvInscripciones.DataSource = CInscripcion.Mostrar();
            this.dgvInscripciones.Columns["idInscripcion"].Visible = false;
            this.dgvInscripciones.RowHeadersVisible = false;
            this.dgvInscripciones.RowHeadersVisible = false;
            this.dgvInscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInscripciones.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvInscripciones.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvInscripciones.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region Mensaje de Error
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Boton VerInscripcion
        private void btnVerInscripción_Click(object sender, EventArgs e)
        {
            this.txtNombreCompetencia.Text = Convert.ToString(this.dgvInscripciones.CurrentRow.Cells["colNombreCompetencia"].Value);
            this.txtTipoCompetencia.Text = Convert.ToString(this.dgvInscripciones.CurrentRow.Cells["colTipoCompetencia"].Value);
            this.dtpFechaInscripcion.Value = Convert.ToDateTime(this.dgvInscripciones.CurrentRow.Cells["colFechaInscripcion"].Value);
            this.txtJuego.Text = Convert.ToString(this.dgvInscripciones.CurrentRow.Cells["colJuego"].Value);
            this.txtEquipo.Text = Convert.ToString(this.dgvInscripciones.CurrentRow.Cells["colEquipo"].Value);
            this.txtNombreCompetencia.Enabled = false;
            this.txtTipoCompetencia.Enabled = false;
            this.dtpFechaInscripcion.Enabled = false;
            this.txtJuego.Enabled = false;
            this.txtEquipo.Enabled = false;
            panelVerInscripciones.Visible = false;
            panelVerInscripciones.Left = 727;
            panel1.Visible = false;
            panel1.Left = 25;
            panel1.Visible = true;
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

        #region Configuracion Campos Gestionar

        #region Limpiar Campo Buscar Equipo Competencia al hacer click
        private void txtBuscarEquipo_Enter(object sender, EventArgs e)
        {
            if (txtBuscarEquipo.Text == "Equipo..")
            {
                txtBuscarEquipo.Text = "";
                dropdownBuscarTipoCompetencia.selectedIndex = 0;
            }
        }

        private void txtBuscarEquipo_Leave(object sender, EventArgs e)
        {
            if (txtBuscarEquipo.Text != "Equipo..")
            {
                txtBuscarEquipo.Text = "Equipo..";
            }
        }
        #endregion

        #region Limpiar Campo Buscar Juego al hacer click
        private void txtBuscarJuego_Enter(object sender, EventArgs e)
        {
            if (txtBuscarJuego.Text == "Juego...")
            {
                txtBuscarJuego.Text = "";
                dropdownBuscarTipoCompetencia.selectedIndex = 0;
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

        #region Click en el Formulario
        private void GestionarInscripciones_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBuscarEquipo.Text))
            {
                txtBuscarEquipo.Text = "Equipo..";
            }
            if (String.IsNullOrEmpty(txtBuscarJuego.Text))
            {
                txtBuscarJuego.Text = "Juego...";
            }
        }

        #endregion

        #endregion

        #region Buscar Inscripcion Por Equipo
        private void BuscarInscripcionPorEquipo()
        {
            if (String.IsNullOrEmpty(txtBuscarEquipo.Text) || txtBuscarEquipo.Text == "Equipo..")
            {
                ListarInscripciones();
                //this.txtBuscarUsuario.Text = "BUSCAR USUARIO...";
            }
            else
            {
                this.dgvInscripciones.DataSource = CInscripcion.BuscarInscripcionPorEquipo(txtBuscarEquipo.Text);
                //this.txt.Text = "BUSCAR USUARIO...";
            }

        }
        #endregion

        #region Buscar Inscripcion Por Juego
        private void BuscarInscripcionPorJuego()
        {
            if (String.IsNullOrEmpty(txtBuscarJuego.Text) || txtBuscarJuego.Text == "Juego...")
            {
                ListarInscripciones();
                //this.txtBuscarUsuario.Text = "BUSCAR USUARIO...";
            }
            else
            {
                this.dgvInscripciones.DataSource = CInscripcion.BuscarInscripcionPorJuego(txtBuscarJuego.Text);
                //this.txt.Text = "BUSCAR USUARIO...";
            }

        }
        #endregion

        #region Buscar Inscripcion Por Tipo
        private void BuscarInscripcionPorTipo()
        {
            if (dropdownBuscarTipoCompetencia.selectedValue == "Todos")
            {
                ListarInscripciones();
                //this.txtBuscarUsuario.Text = "BUSCAR USUARIO...";
            }
            else
            {
                this.dgvInscripciones.DataSource = CInscripcion.BuscarInscripcionPorTipo(dropdownBuscarTipoCompetencia.selectedValue);
                //this.txt.Text = "BUSCAR USUARIO...";
            }

        }
        #endregion

        #region Filtro Buscar Inscripcion Por Equipo
        private void txtBuscarEquipo_OnValueChanged(object sender, EventArgs e)
        {
            BuscarInscripcionPorEquipo();
        }

        #endregion

        #region Filtro Buscar Inscripcion Por Juego
        private void txtBuscarJuego_OnValueChanged(object sender, EventArgs e)
        {
            BuscarInscripcionPorJuego();
        }
        #endregion

        #region Filtro Buscar Inscripcion por Tipo
        private void dropdownBuscarTipoCompetencia_onItemSelected(object sender, EventArgs e)
        {
            BuscarInscripcionPorTipo();
        }
        #endregion

        #region Seleccionar Inscripcion
        private void dgvInscripciones_Click(object sender, EventArgs e)
        {
            idInscripcionSeleccionada = Convert.ToString(this.dgvInscripciones.CurrentRow.Cells["idInscripcion"].Value);
        }
        #endregion

        #region Boton Regresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel1.Left = 727;

            panelVerInscripciones.Visible = false;
            panelVerInscripciones.Left = 25;
            panelVerInscripciones.Visible = true;

            #region Resetear Dropdown Tipo de Competencia
            dropdownBuscarTipoCompetencia.selectedIndex = 0;
            #endregion
        }
        #endregion

        #region Boton Eliminar
        private void btnEliminarInscripcion_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                DialogResult VentanaEmergente;
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere eliminar la inscripción?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {
                    rpta = CInscripcion.Eliminar(Convert.ToInt32(idInscripcionSeleccionada));

                    if (rpta.Equals("OK"))
                    {
                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "La inscripción se ha eliminado exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                        //MessageBox.Show("Se eliminó correctamente!");
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "No se ha podido eliminar la inscripción correctamente!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }

                    this.ListarInscripciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Pantalla Arrastrable
        private void GestionarInscripciones_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void GestionarInscripciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

    }
}
