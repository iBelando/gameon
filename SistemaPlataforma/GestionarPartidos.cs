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
using SistemaPlataforma.Patrones.Patron_Facade;

namespace SistemaPlataforma
{
    public partial class GestionarPartidos : Form
    {

        #region Almacenar Credenciales del Partido
        public static string idPartidoSeleccionado = "";
        public static string idCompetenciaSeleccionada = "";
        public static string idArbitroSeleccionado = "";
        public static string stringResultado = "";
        public static string[] resultado = new string[2];
        #endregion

        #region Inicializar Componentes
        public GestionarPartidos()
        {
            InitializeComponent();

            #region Cargamos la grilla con todos los partidos existentes en el sistema en el día de la fecha
            ListarPartidos();
            #endregion

            #region Configuracion componentes
            label7.Visible = false;
            this.dtpFecha.Value = DateTime.Now;
            this.dgvVerPartidos.Columns["nickname"].Visible = false;
            //this.dgvVerPartidos.Columns["idCompetencia"].Visible = false;


            #region Carga de Arbitros Existentes en el sistema a DropdownArbitros

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando = new SqlCommand("select nickname from Usuarios where rolUsuario = 2", SqlCon);
                SqlCon.Open();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    txtArbitro.AddItem(registro["nickname"].ToString());
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

            #endregion

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

        #region Desplazar al Panel de Ver Partidos
        private void btnVerPartidos_Click(object sender, EventArgs e)
        {
            if (panelBuscarPartido.Left == 856) //703
            {
                panelGestionarPartido.Visible = false;
                panelGestionarPartido.Left = 856; //703

                panelBuscarPartido.Visible = false;
                panelBuscarPartido.Left = 30;
                panelBuscarPartido.Visible = true;


                bunifuSeparator1.Left = btnVerPartidos.Left;
                bunifuSeparator1.Width = btnVerPartidos.Width;

                #region Bloqueo de Panel Gestionar
                idPartidoSeleccionado = "0";
                this.dtpFecha.Value = DateTime.Now;
                #endregion

            }
        }
        #endregion

        #region Desplazar al Panel de Gestionar Partidos
        private void btnGestionarPartidos_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(idPartidoSeleccionado) && int.Parse(idPartidoSeleccionado) != 0 && idPartidoSeleccionado != "")
            {
                if (panelGestionarPartido.Left == 856) //703
                {
                    panelBuscarPartido.Visible = false;
                    panelBuscarPartido.Left = 856; //703

                    panelGestionarPartido.Visible = false;
                    panelGestionarPartido.Left = 77;
                    panelGestionarPartido.Visible = true;

                    bunifuSeparator1.Left = btnGestionarPartidos.Left;
                    bunifuSeparator1.Width = btnGestionarPartidos.Width;
                }
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

        #region Listar Partidos
        private void ListarPartidos()
        {
            this.dgvVerPartidos.DataSource = CPartido.Mostrar();
            this.dgvVerPartidos.Columns["idPartido"].Visible = false;
            this.dgvVerPartidos.Columns["arbitro"].Visible = false;
            //this.dgvVerPartidos.Columns["nickname"].Visible = false;
            this.dgvVerPartidos.RowHeadersVisible = false;
            this.dgvVerPartidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVerPartidos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvVerPartidos.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvVerPartidos.Columns)
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

        #region Buscar Partido Por Equipo
        private void BuscarPartidoPorEquipo()
        {
            if (String.IsNullOrEmpty(txtBuscadorEquipo.Text) || txtBuscadorEquipo.Text == "BUSCAR EQUIPO...")
            {
                //ListarPartidos();
            }
            else
            {
                this.dgvVerPartidos.DataSource = CPartido.BuscarPartidoPorEquipo(txtBuscadorEquipo.Text);
            }

        }
        #endregion

        #region Buscar Partido Por Juego
        private void BuscarPartidoPorJuego()
        {
            if (String.IsNullOrEmpty(txtBuscadorJuego.Text) || txtBuscadorJuego.Text == "BUSCAR JUEGO...")
            {
                //ListarPartidos();
            }
            else
            {
                this.dgvVerPartidos.DataSource = CPartido.BuscarPartidoPorJuego(txtBuscadorJuego.Text);
            }

        }
        #endregion

        #region Buscar Partido Por Fecha
        private void BuscarPartidoPorFecha()
        {
            if (dtpFecha.Value == DateTime.Today)
            {
                ListarPartidos();
            }
            else
            {
                this.dgvVerPartidos.DataSource = CPartido.BuscarPartidoPorFecha(Convert.ToString(dtpFecha.Value));
            }

        }
        #endregion

        #region Filtro Buscar Partido Por Equipo
        private void txtBuscadorEquipo_OnValueChanged(object sender, EventArgs e)
        {
            BuscarPartidoPorEquipo();
        }
        #endregion

        #region Filtro Buscar Partido Por Juego
        private void txtBuscadorJuego_OnValueChanged(object sender, EventArgs e)
        {
            BuscarPartidoPorJuego();
        }

        #endregion

        #region Filtro Buscar Partido Por Fecha
        private void dtpFecha_onValueChanged(object sender, EventArgs e)
        {
            BuscarPartidoPorFecha();
        }

        #endregion

        #region Seleccionar Partido
        private void dgvVerPartidos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvVerPartidos.Rows.Count != 0)
            {

                #region Cargamos la ID del Partido Seleccionado
                idPartidoSeleccionado = Convert.ToString(this.dgvVerPartidos.CurrentRow.Cells["idPartido"].Value);
                #endregion

                #region Cargamos el Nombre de la Competencia del Partido Seleccionado
                label6.Text = Convert.ToString(this.dgvVerPartidos.CurrentRow.Cells["colCompetencia"].Value);
                #endregion

                //#region Cargamos la ID de la Competencia del Partido Seleccionado
                //idCompetenciaSeleccionada = Convert.ToString(this.dgvVerPartidos.CurrentRow.Cells["Partidos.idCompetencia"].Value);
                //#endregion

                #region Cargamos el Juego de la Competencia del Partido Seleccionado
                label7.Text = Convert.ToString(this.dgvVerPartidos.CurrentRow.Cells["colJuego"].Value);
                #endregion

                #region Cargamos la Fecha del Partido Seleccionado
                dtpFechaPartido.Value = Convert.ToDateTime(this.dgvVerPartidos.CurrentRow.Cells["colFecha"].Value);
                #endregion

                #region Cargamos el Nombre del Equipo A del Partido Seleccionado
                label5.Text = Convert.ToString(this.dgvVerPartidos.CurrentRow.Cells["colEquipoA"].Value);
                #endregion

                #region Carga el Nombre del Equipo B del Partido Seleccionado
                label1.Text = Convert.ToString(this.dgvVerPartidos.CurrentRow.Cells["colEquipoB"].Value);
                #endregion

                #region Carga el Resultado del Partido Seleccionado
                string resultadoDB = Convert.ToString(this.dgvVerPartidos.CurrentRow.Cells["colResultado"].Value);
                resultado = resultadoDB.Split('-');
                txtResultado1.Text = resultado[0];
                txtResultado2.Text = resultado[1];
                #endregion

                #region Carga el Arbitro del Partido Seleccionado
                int Selected = -1;
                int count = 1000000000;
                for (int i = 0; (i <= (count - 1)); i++)
                {
                    txtArbitro.selectedIndex = i;
                    if ((string)(txtArbitro.selectedValue) == Convert.ToString(this.dgvVerPartidos.CurrentRow.Cells["nickname"].Value))
                    {
                        Selected = i;
                        break;
                    }

                }

                txtArbitro.selectedIndex = Selected;
                #endregion

                //#region Carga la Id del Arbitro del Partido Seleccionado
                //idArbitroSeleccionado = Convert.ToString(this.dgvVerPartidos.CurrentRow.Cells["arbitro"].Value);
                //#endregion

                panelBuscarPartido.Visible = false;
                panelBuscarPartido.Left = 856;

                panelGestionarPartido.Visible = false;
                panelGestionarPartido.Left = 50;
                panelGestionarPartido.Visible = true;
                bunifuSeparator1.Left = btnGestionarPartidos.Left;
                bunifuSeparator1.Width = btnGestionarPartidos.Width;

            }
            
        }

        #endregion

        #region Boton Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                resultado[0] = txtResultado1.Text;
                resultado[1] = txtResultado2.Text;
                stringResultado = String.Join("-", resultado);

                rpta = AuditoriaFacade.AuditarPartido(int.Parse(idPartidoSeleccionado), dtpFechaPartido.Value, label5.Text, label1.Text, stringResultado, label7.Text, (txtArbitro.selectedIndex - 1), 3, "M", Login.nicknameUsuario);

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El partido se ha modificado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarPartido.Visible = false;
                    panelGestionarPartido.Left = 703;
                    panelBuscarPartido.Visible = false;
                    panelBuscarPartido.Left = 15;
                    panelBuscarPartido.Visible = true;
                    bunifuSeparator1.Left = btnVerPartidos.Left;
                    bunifuSeparator1.Width = btnVerPartidos.Width;
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido modificar el partido correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                this.ListarPartidos();
                this.dgvVerPartidos.Columns["idCompetencia"].Visible = false;
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
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere eliminar el partido?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {
                    //rpta = CPartido.Eliminar(int.Parse(idPartidoSeleccionado));
                    rpta = AuditoriaFacade.AuditarPartido(int.Parse(idPartidoSeleccionado), dtpFechaPartido.Value, label5.Text, label1.Text, stringResultado, label7.Text, (txtArbitro.selectedIndex - 1), 3, "B", Login.nicknameUsuario);

                    if (rpta.Equals("OK"))
                    {
                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "El partido se ha eliminado exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                        //MessageBox.Show("Se eliminó correctamente!");
                        panelGestionarPartido.Visible = false;
                        panelGestionarPartido.Left = 703;
                        panelBuscarPartido.Visible = false;
                        panelBuscarPartido.Left = 15;
                        panelBuscarPartido.Visible = true;
                        bunifuSeparator1.Left = btnVerPartidos.Left;
                        bunifuSeparator1.Width = btnVerPartidos.Width;
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "El partido no se ha podido eliminar correctamente!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }

                    this.ListarPartidos();
                    this.dgvVerPartidos.Columns["idCompetencia"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Configuracion Campos Gestionar

        #region Limpiar Campo Buscar Equipo al hacer click
        private void txtBuscadorEquipo_Enter(object sender, EventArgs e)
        {
            if (txtBuscadorEquipo.Text == "BUSCAR EQUIPO...")
            {
                txtBuscadorEquipo.Text = "";
            }
        }

        private void txtBuscadorEquipo_Leave(object sender, EventArgs e)
        {
            if (txtBuscadorEquipo.Text != "BUSCAR EQUIPO...")
            {
                txtBuscadorEquipo.Text = "BUSCAR EQUIPO...";
            }
        }
        #endregion

        #region Limpiar Campo Buscar Juego al hacer click
        private void txtBuscadorJuego_Enter(object sender, EventArgs e)
        {
            if (txtBuscadorJuego.Text == "BUSCAR JUEGO...")
            {
                txtBuscadorJuego.Text = "";
            }
        }

        private void txtBuscadorJuego_Leave(object sender, EventArgs e)
        {
            if (txtBuscadorJuego.Text != "BUSCAR JUEGO...")
            {
                txtBuscadorJuego.Text = "BUSCAR JUEGO...";
            }
        }
        #endregion

        #region Click en el Formulario
        private void GestionarPartidos_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBuscadorEquipo.Text))
            {
                txtBuscadorEquipo.Text = "BUSCAR EQUIPO...";
            }
            if (String.IsNullOrEmpty(txtBuscadorJuego.Text))
            {
                txtBuscadorJuego.Text = "BUSCAR JUEGO...";
            }
        }
        #endregion

        #endregion

        #region Pantalla Arrastrable
        private void GestionarPartidos_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void GestionarPartidos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        
    }
}
