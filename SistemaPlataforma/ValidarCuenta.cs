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
    public partial class ValidarCuenta : Form
    {

        #region Recibir Credenciales del Usuario
        public string idUsuario = "";
        public string nombreUsuario = "";
        public string emailUsuario = "";
        public string contraseñaEncriptadaUsuario = "";
        #endregion

        #region Inicializar Componentes
        public ValidarCuenta()
        {
            InitializeComponent();
            this.TTMensaje.SetToolTip(this.txtCodigo, "¡Ingrese un Código de Activación Válido!");
        }
        #endregion

        #region Mensaje de Confirmación
        //Mostar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Mensaje de Error
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Limpiar Todos Los Controles
        //Limpiar todos los controles
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
        }
        #endregion

        #region Minimizar Formulario
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Boton Validar Cuenta
        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                //string rpta = "";
                if (this.txtCodigo.Text == string.Empty)
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "El código de activación ingresado, no es válido!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError("Falta ingresar algunos datos, serán remarcados!");
                    //errorIcono.SetError(txtCodigo, "Ingrese un Código de Activación Válido!");
                }
                else
                {
                    int idusuario = int.Parse(idUsuario);
                    DataTable ValidarCodActivacion = CCodActivacion.ValidarCodigoActivacion(idusuario, this.txtCodigo.Text);
                    if (ValidarCodActivacion.Rows.Count == 0)
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "El código de activación ingresado, no es válido!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MessageBox.Show("El codigo ingresado, no existe.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        CUsuario.ActivarUsuario(idusuario);

                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "Su cuenta ha sido validada exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();

                        #region Instancias Form
                        Perfil frmPerfil = new Perfil();

                        #region Dirigimos al Form Perfil Usuario
                        frmPerfil.Show();
                        this.Hide();
                        #endregion

                        #endregion

                        #region Desplazar al Panel Editar
                        frmPerfil.panelMiPerfil.Visible = false;
                        frmPerfil.panelMiPerfil.Left = 856; //437

                        frmPerfil.panelEditarPerfil.Visible = false;
                        frmPerfil.panelEditarPerfil.Left = 30;
                        frmPerfil.panelEditarPerfil.Visible = true;

                        frmPerfil.bunifuSeparator1.Left = frmPerfil.btnEditarPerfil.Left;
                        frmPerfil.bunifuSeparator1.Width = frmPerfil.btnEditarPerfil.Width;
                        #endregion

                        #region Ocultamos Botones para impedir de que el usuario cierre la sesión
                        frmPerfil.btnCerrar.Visible = false;
                        frmPerfil.btnVolver.Visible = false;
                        frmPerfil.btnMinimizar.Location = new Point(809,5);
                        #endregion

                        #region Cargamos los datos del Usuario
                        Login.nicknameUsuario = nombreUsuario;
                        Login.emailUsuario = emailUsuario;
                        Login.contraseñaEncriptada = contraseñaEncriptadaUsuario;
                        Login.fechaNacimientoUsuario = Convert.ToString(DateTime.Now);
                        Login.paisUsuario = "Argentina";
                        Login.idUsuario = Convert.ToString(idusuario);
                        frmPerfil.dtpEditarFechaNacimiento.Value = DateTime.Now;
                        frmPerfil.dropdownEditarPais.selectedIndex = 0;
                        frmPerfil.txtEditarEmail.Text = emailUsuario;
                        frmPerfil.txtEditarNickname.Text = nombreUsuario;
                        frmPerfil.lblNombreRol.Text = "Jugador";
                        frmPerfil.bunifuCustomLabel9.Text = emailUsuario;
                        frmPerfil.lblNombre.Text = nombreUsuario;
                        frmPerfil.lblPaisUsuario.Text = "Argentina";
                        #endregion

                        //Inicio frmInicio = new Inicio();
                        //frmInicio.Show();
                        //this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Pantalla Arrastrable
        private void ValidarCuenta_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ValidarCuenta_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Boton Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

    }
}
