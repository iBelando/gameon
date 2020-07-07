using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using System.Runtime.InteropServices;

namespace SistemaPlataforma
{
    public partial class Inicio : Form
    {

        #region Validar Administrador
        private void HabilitarPanelGestion()
        {
            if (CUsuario.EsRolAdministrador(Login.rolUsuario) == true)
            {
                btnPanelGestion.Visible = true;
                logoPanelGestion.Visible = true;
                btnAuditoria.Visible = true;
            }
        }
        #endregion

        #region Devolver Imagen del Usuario
        private void DevolverImagenUsuario()
        {
            byte[] imageLength = Login.imagenUsuario;
            if (imageLength.Length > 0)
            {
                // Se crea un MemoryStream a partir de ese buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Login.imagenUsuario);
                // Se utiliza el MemoryStream para extraer la imagen
                pictureBox2.Image = Image.FromStream(ms);
            }
        }
        #endregion

        #region Inicializar Componentes
        public Inicio()
        {
            InitializeComponent();
            btnPanelGestion.Visible = false;
            logoPanelGestion.Visible = false;
            HabilitarPanelGestion();
            DevolverImagenUsuario();
            this.lblnickname1.Text = Login.nicknameUsuario;
        }
        #endregion

        #region Botones

        #region Minimizar Formulario
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Cerrar Formulario 
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Boton Desplegar Panel
        private void btnDesplegarPanel_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 72)

            {
                panel1.Visible = false;
                panel1.Width = 265;
                PanelAnimator.ShowSync(panel1);
                LogoAnimator.ShowSync(Logo);
            }
            else
            {
                LogoAnimator.Hide(Logo);
                panel1.Visible = false;
                panel1.Width = 72;
                PanelAnimator.ShowSync(panel1);


            }
        }
        #endregion

        #region Boton Desconectar
        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            frmLogin.Show();
            this.Hide();
        }
        #endregion

        #region Boton Ranking Equipos
        private void btnRankingEquipos_Click(object sender, EventArgs e)
        {
            RankingEquipos frmRankingEquipos = new RankingEquipos();
            frmRankingEquipos.Show();
            this.Hide();
        }
        #endregion

        #region Boton Ranking Equipos Menu Izquierda
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            RankingEquipos frmRankingEquipos = new RankingEquipos();
            frmRankingEquipos.Show();
            this.Hide();
        }
        #endregion

        #region Boton Ranking Usuarios
        private void btnRankingUsuarios_Click(object sender, EventArgs e)
        {
            RankingUsuarios frmRankingUsuarios = new RankingUsuarios();
            frmRankingUsuarios.Show();
            this.Hide();
        }
        #endregion

        #region Boton Ranking Usuarios Menu Izquierda
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            RankingUsuarios frmRankingUsuarios = new RankingUsuarios();
            frmRankingUsuarios.Show();
            this.Hide();
        }
        #endregion

        #endregion

        #region Opciones

        #region Opcion Mi Perfil

        #region Boton Mi Perfil
        private void btnPerfil_Click(object sender, EventArgs e)
        {
            Perfil frmPerfil = new Perfil();
            frmPerfil.Show();
            this.Hide();
        }
        #endregion

        #region Logo Mi Perfil
        private void logoMiPerfil_Click(object sender, EventArgs e)
        {
            Perfil frmPerfil = new Perfil();
            frmPerfil.Show();
            this.Hide();
        }
        #endregion

        #endregion

        #region Opcion Equipos

        #region Boton Equipos
        private void btnEquipos_Click(object sender, EventArgs e)
        {
            Equipos frmEquipos = new Equipos();
            frmEquipos.Show();
            this.Hide();
        }
        #endregion

        #region Logo Equipos
        private void logoEquipos_Click(object sender, EventArgs e)
        {
            Equipos frmEquipos = new Equipos();
            frmEquipos.Show();
            this.Hide();
        }
        #endregion

        #endregion

        #region Opcion Usuarios

        #region Boton Usuarios
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios frmUsuarios = new Usuarios();
            frmUsuarios.Show();
            this.Hide();
        }

        #endregion

        #region Logo Usuarios
        private void logoUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios frmUsuarios = new Usuarios();
            frmUsuarios.Show();
            this.Hide();
        }
        #endregion

        #endregion

        #region Opcion Ligas

        #region Boton Ligas
        private void btnLigas_Click(object sender, EventArgs e)
        {
            LigasDisponibles frmLigas = new LigasDisponibles();
            frmLigas.Show();
            this.Hide();
        }
        #endregion

        #region Logo Ligas
        private void logoLigas_Click(object sender, EventArgs e)
        {
            LigasDisponibles frmLigas = new LigasDisponibles();
            frmLigas.Show();
            this.Hide();
        }
        #endregion

        #endregion

        #region Opcion Torneos

        #region Boton Torneos
        private void btnTorneos_Click(object sender, EventArgs e)
        {
            TorneosDisponibles frmTorneos = new TorneosDisponibles();
            frmTorneos.Show();
            this.Hide();
        }

        #endregion

        #region Logo Torneos
        private void logoTorneos_Click(object sender, EventArgs e)
        {
            TorneosDisponibles frmTorneos = new TorneosDisponibles();
            frmTorneos.Show();
            this.Hide();
        }
        #endregion

        #endregion

        #region Opcion Panel de Gestion

        #region Boton Panel de Gestion
        private void btnPanelGestion_Click(object sender, EventArgs e)
        {
            PanelDeAdmin frmPanelGestion = new PanelDeAdmin();
            frmPanelGestion.Show();
            this.Hide();
        }
        #endregion

        #region Logo Panel de Gestion
        private void logoPanelGestion_Click(object sender, EventArgs e)
        {
            PanelDeAdmin frmPanelGestion = new PanelDeAdmin();
            frmPanelGestion.Show();
            this.Hide();
        }
        #endregion

        #endregion

        #region Opcion Jugar

        #region Boton Jugar Torneo
        private void btnJugarTorneo_Click(object sender, EventArgs e)
        {
            TorneosDisponibles frmTorneos = new TorneosDisponibles();
            frmTorneos.Show();
            this.Hide();
        }

        #endregion

        #region Boton Jugar Liga
        private void btnJugarLiga_Click(object sender, EventArgs e)
        {
            LigasDisponibles frmLigas = new LigasDisponibles();
            frmLigas.Show();
            this.Hide();
        }

        #endregion

        #endregion

        #endregion

        #region Pantalla Arrastrable
        //Mover el Formulario
        private void Inicio_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Inicio_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }




        #endregion

        #region Boton Auditoria
        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            AuditoríaPartidos frmAuditoria = new AuditoríaPartidos();
            frmAuditoria.Show();
            this.Hide();
        }
        #endregion

    }
}
