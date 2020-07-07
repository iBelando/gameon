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
    public partial class PanelDeAdmin : Form
    {

        #region Inicializar Componentes
        public PanelDeAdmin()
        {
            InitializeComponent();
            CargarEstadisticas();
        }
        #endregion

        #region Botones

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

        #region Boton Volver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Inicio frmInicio = new Inicio();
            frmInicio.Show();
            this.Hide();
        }

        #endregion

        #region Boton Gestionar Competencias
        private void btnGestionarCompetencias_Click(object sender, EventArgs e)
        {
            GestionarCompetencias frmGestionarCompetencias = new GestionarCompetencias();
            frmGestionarCompetencias.Show();
            this.Hide();
        }

        #endregion

        #region Boton Gestionar Partidos
        private void btnGestionarPartidos_Click(object sender, EventArgs e)
        {
            GestionarPartidos frmGestionarPartidos = new GestionarPartidos();
            frmGestionarPartidos.Show();
            this.Hide();
        }

        #endregion

        #region Boton Gestionar Inscripciones
        private void btnGestionarInscripciones_Click(object sender, EventArgs e)
        {
            GestionarInscripciones frmGestionarInscripciones = new GestionarInscripciones();
            frmGestionarInscripciones.Show();
            this.Hide();
        }

        #endregion

        #region Boton Gestionar Usuarios
        private void btnGestionarUsuarios_Click(object sender, EventArgs e)
        {
            GestionarUsuarios frmGestionarUsuarios = new GestionarUsuarios();
            frmGestionarUsuarios.Show();
            this.Hide();
        }

        #endregion

        #region Boton Gestionar Equipos
        private void btnGestionarEquipos_Click(object sender, EventArgs e)
        {
            GestionarEquipos frmGestionarEquipos = new GestionarEquipos();
            frmGestionarEquipos.Show();
            this.Hide();
        }

        #endregion

        #region Boton Gestionar Arbitros
        private void btnGestionarArbitros_Click(object sender, EventArgs e)
        {
            GestionarArbitros frmGestionarArbitros = new GestionarArbitros();
            frmGestionarArbitros.Show();
            this.Hide();
        }
        #endregion

        #region Boton Gestionar Roles
        private void btnGestionarRoles_Click(object sender, EventArgs e)
        {
            GestionarRoles frmGestionarRoles = new GestionarRoles();
            frmGestionarRoles.Show();
            this.Hide();
        }
        #endregion

        #region Boton Gestionar Grupos
        private void btnGrupos_Click(object sender, EventArgs e)
        {
            GestionarGrupos frmGestionarGrupos = new GestionarGrupos();
            frmGestionarGrupos.Show();
            this.Hide();
        }
        #endregion

        #region Boton Gestionar Juegos
        private void btnJuegos_Click(object sender, EventArgs e)
        {
            GestionarJuegos frmGestionarJuegos = new GestionarJuegos();
            frmGestionarJuegos.Show();
            this.Hide();
        }
        #endregion

        #endregion

        #region CargarEstadisticas
        private void CargarEstadisticas()
        {
            lblNumeroUsuarios.Text = Convert.ToString(CUsuario.DevolverNumeroUsuariosRegistrados());
            lblNumeroEquipos.Text = Convert.ToString(CEquipo.DevolverNumeroEquiposRegistrados());
            lblNumeroCompetencias.Text = Convert.ToString(CCompetencia.DevolverNumeroCompetenciasRealizadas());
            progressbarUsuarios.Value = Convert.ToInt32((CUsuario.DevolverNumeroUsuariosRegistrados() * 100) / 100);
            progressbarEquipos.Value = Convert.ToInt32((CEquipo.DevolverNumeroEquiposRegistrados() * 100) / 100);
            progressbarCompetencias.Value = Convert.ToInt32((CCompetencia.DevolverNumeroCompetenciasRealizadas() * 100) / 100);
        }
        #endregion

        #region Pantalla Arrastrable
        private void PanelDeAdmin_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelDeAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

    }
}
