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
    public partial class Usuarios : Form
    {

        #region Almacenar Credenciales del Usuario
        public static string idUsuario = "";
        public static string nicknameUsuario = "";
        public static string rolUsuario = "";
        public static string paisUsuario = "";
        public static string fechaNacimientoUsuario = "";
        public static string equipoUsuario = "";
        public static byte[] imagenUsuario;
        #endregion

        #region Inicializar Componentes
        public Usuarios()
        {
            InitializeComponent();

            this.dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvUsuarios.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvUsuarios.RowTemplate.Height = 50;

            ListarUsuarios();

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
        private void Usuarios_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Usuarios_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        #region Limpiar Campo Buscar Usuario
        private void txtBuscaruUsuario_Enter(object sender, EventArgs e)
        {
            if (txtBuscaruUsuario.Text == "BUSCAR USUARIO...")
            {
                txtBuscaruUsuario.Text = "";
            }
        }

        private void txtBuscaruUsuario_Leave(object sender, EventArgs e)
        {
            if (txtBuscaruUsuario.Text == "")
            {
                txtBuscaruUsuario.Text = "BUSCAR USUARIO...";
            }
        }
        #endregion

        #region Listar Usuarios
        private void ListarUsuarios()
        {
            this.dgvUsuarios.DataSource = CUsuario.Mostrar();
            this.dgvUsuarios.Columns["idUsuario"].Visible = false;
            this.dgvUsuarios.Columns["contraseña"].Visible = false;
            this.dgvUsuarios.Columns["estadoUsuario"].Visible = false;
            this.dgvUsuarios.Columns["rolUsuario"].Visible = false;
            this.dgvUsuarios.Columns["fechaNacimiento"].Visible = false;
            this.dgvUsuarios.Columns["email"].Visible = false;
            this.dgvUsuarios.RowTemplate.Height = 50;
            this.dgvUsuarios.RowHeadersVisible = false;
            foreach (DataGridViewColumn col in dgvUsuarios.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region Boton Buscar
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            BuscarUsuarioPorNickname();
        }
        #endregion

        #region Buscar Usuario Por Nickname
        private void BuscarUsuarioPorNickname()
        {
            if (String.IsNullOrEmpty(txtBuscaruUsuario.Text) || txtBuscaruUsuario.Text == "BUSCAR USUARIO...")
            {
                ListarUsuarios();
                this.txtBuscaruUsuario.Text = "BUSCAR USUARIO...";
            }
            else
            {
                this.dgvUsuarios.DataSource = CUsuario.BuscarUsuarioPorNickname(txtBuscaruUsuario.Text);
                this.txtBuscaruUsuario.Text = "BUSCAR USUARIO...";
            }

        }


        #endregion

        #region Seleccionar Usuario

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            #region Carga el ID del Usuario
            idUsuario = Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["idUsuario"].Value);
            #endregion

            #region Carga el Nombre del Usuario
            nicknameUsuario = Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["colNickname"].Value);
            #endregion

            #region Carga la Fecha de Nacimiento del Usuario
            fechaNacimientoUsuario = Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["fechaNacimiento"].Value);
            #endregion

            #region Carga el Pais del Usuario
            paisUsuario = Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["colPais"].Value);
            #endregion

            #region Carga el Rol del Usuario
            rolUsuario = Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["rolUsuario"].Value);
            #endregion

            #region Carga la Imagen del Usuario
            imagenUsuario = (byte[])dgvUsuarios.CurrentRow.Cells["colImagen"].Value;
            #endregion

            #region Carga los Equipos de los Usuarios
            equipoUsuario = Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["colEquipos"].Value);
            #endregion

            #region Dirigir al Perfil del Usuario
            VerPerfilUsuario frmVerPerfilUsuario = new VerPerfilUsuario();
            frmVerPerfilUsuario.Show();
            this.Hide();
            #endregion

        }

        #endregion

    }
}
