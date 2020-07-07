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
using SistemaPlataforma.Patrones.Patron_Observer;

namespace SistemaPlataforma
{
    public partial class Partidos : Form
    {

        #region Almacenar Credenciales del Partido
        public static string idPartidoSeleccionado = "";
        public static string stringResultado = "";
        public static string[] resultado = new string[2];
        #endregion

        #region Inicializar Componentes
        public Partidos()
        {
            InitializeComponent();

            #region Cargamos la grilla con todos los partidos existentes en el sistema en el día de la fecha
            ListarPartidos();
            #endregion

            #region Configuracion Componentes
            this.dtpFecha.Value = DateTime.Now;
            this.dgvVerPartidos.Columns["nickname"].Visible = false;
            label7.Visible = false;

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

        #region Boton Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Boton Minimizar
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Boton Volver
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Inicio frmInicio = new Inicio();
            frmInicio.Show();
            this.Hide();
        }

        #endregion

        #region Pantalla Arrastrable
        private void Partidos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        private void Partidos_Load(object sender, EventArgs e)
        {

            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion

            #region Patron Observer

            foreach (DataGridViewRow row in dgvVerPartidos.Rows)
            {
                //Creamos un Subject
                ISubject partidos = new Partido(Convert.ToString(row.Cells[4].Value));

                //Creamos el observer
                //Se realiza la suscripción a traves del constructor
                IObserver observerDisplay = new ObserverDisplay(partidos);

                //Modificamos valores del subject. Los observers son automaticamente informados y actuan automaticamente
                ((Partido)partidos).ResultadoPartido += Convert.ToString(row.Cells[4].Value);
            }

            #endregion

        }
        
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

            #region Incializar Paneles y Componentes
            foreach (DataGridViewRow row in dgvVerPartidos.Rows)
            {
                if (Convert.ToString(row.Cells[4].Value) == "0-0")
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
                if (Convert.ToString(row.Cells[4].Value) == "2-0" || (Convert.ToString(row.Cells[4].Value) == "0-2") || (Convert.ToString(row.Cells[4].Value) == "2-1") || (Convert.ToString(row.Cells[4].Value) == "1-2"))
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
            #endregion

        }

        #endregion

        #region Configuracion Campo Buscar Equipo
        private void txtBuscadorEquipo_OnValueChanged(object sender, EventArgs e)
        {
            BuscarPartidoPorEquipo();
        }

        private void txtBuscadorEquipo_Leave(object sender, EventArgs e)
        {
            if (txtBuscadorEquipo.Text != "BUSCAR EQUIPO...")
            {
                txtBuscadorEquipo.Text = "BUSCAR EQUIPO...";
            }
        }

        private void txtBuscadorEquipo_Enter(object sender, EventArgs e)
        {
            if (txtBuscadorEquipo.Text == "BUSCAR EQUIPO...")
            {
                txtBuscadorEquipo.Text = "";
            }
        }

        #endregion

        #region Configuracion Campo Buscar Juego
        private void txtBuscadorJuego_OnValueChanged(object sender, EventArgs e)
        {
            BuscarPartidoPorJuego();
        }

        private void txtBuscadorJuego_Leave(object sender, EventArgs e)
        {
            if (txtBuscadorJuego.Text != "BUSCAR JUEGO...")
            {
                txtBuscadorJuego.Text = "BUSCAR JUEGO...";
            }
        }

        private void txtBuscadorJuego_Enter(object sender, EventArgs e)
        {
            if (txtBuscadorJuego.Text == "BUSCAR JUEGO...")
            {
                txtBuscadorJuego.Text = "";
            }
        }
        #endregion

        #region Configuracion Campo Filtrar Fecha Partido
        private void dtpFecha_onValueChanged(object sender, EventArgs e)
        {
            BuscarPartidoPorFecha();
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
                label3.Text = Convert.ToString(this.dgvVerPartidos.CurrentRow.Cells["colEquipoB"].Value);
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

                panelBuscarPartido.Visible = false;
                panelBuscarPartido.Left = 536;

                panelGestionarPartido.Visible = false;
                panelGestionarPartido.Left = 35;
                panelGestionarPartido.Visible = true;

                #region Ocultar Boton Volver Costado Izquierdo Superior
                this.bunifuImageButton1.Visible = false;
                #endregion

            }

        }

        #endregion

        #region Boton Regresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            panelGestionarPartido.Visible = false;
            panelGestionarPartido.Left = 536;

            panelBuscarPartido.Visible = false;
            panelBuscarPartido.Left = 23;
            panelBuscarPartido.Visible = true;

            this.bunifuImageButton1.Visible = true;
        }
        #endregion

    }
}
