using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Controladora;

namespace SistemaPlataforma
{
    public partial class VerPerfilUsuario : Form
    {

        #region Inicializar Componentes
        public VerPerfilUsuario()
        {
            InitializeComponent();

            #region Cargar Información del Usuario

            #region Carga el Nombre del Usuario
            this.bunifuCustomLabel1.Text = Usuarios.nicknameUsuario;
            #endregion

            #region Carga el Rol del Usuario
            this.bunifuCustomLabel2.Text = Usuarios.rolUsuario;
            #endregion

            #region Carga el Pais del Usuario
            this.bunifuCustomLabel7.Text = Usuarios.paisUsuario;
            #endregion

            #region Carga la Imagen del Usuario
            DevolverImagenUsuario();
            #endregion

            #region Carga la Fecha de Nacimiento del Usuario
            string fechaNacimientoCompleta = Convert.ToString(Usuarios.fechaNacimientoUsuario);
            string fechaNacimientoSoloFecha = fechaNacimientoCompleta.Replace("00:00:00"," ");
            this.bunifuCustomLabel6.Text = Convert.ToString(fechaNacimientoSoloFecha);
            #endregion

            #region Carga el Equipo del Usuario
            this.bunifuCustomLabel8.Text = Usuarios.equipoUsuario;
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

        #region Pantalla Arrastrable
        private void VerPerfilUsuario_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void VerPerfilUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        #endregion

        #region Boton Volver
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Usuarios frmUsuarios = new Usuarios();
            frmUsuarios.Show();
            this.Hide();
        }
        #endregion

        #region Devolver Imagen del Usuario
        private void DevolverImagenUsuario()
        {
            if (!DBNull.Value.Equals(Usuarios.imagenUsuario))
            {
                // Se crea un MemoryStream a partir de ese buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Usuarios.imagenUsuario);
                // Se utiliza el MemoryStream para extraer la imagen
                pictureBox2.Image = Image.FromStream(ms);
            }
        }
        #endregion

    }
}
