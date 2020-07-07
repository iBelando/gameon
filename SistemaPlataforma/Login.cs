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
    public partial class Login : Form
    {

        #region Almacenar Credenciales del Usuario

        public static string idUsuario = "";
        public static string nicknameUsuario = "";
        public static string rolUsuario = "";
        public static string paisUsuario = "";
        public static string fechaNacimientoUsuario = "";
        public static string emailUsuario = "";
        public static string contraseñaEncriptada = "";
        public static byte[] imagenUsuario;
        public static string estadoUsuario = "";

        #endregion

        #region Inicializar Componentes
        public Login()
        {
            InitializeComponent();
            this.TTMensaje.SetToolTip(this.txtNickname, "Ingrese un Nombre de Usuario Válido.");
            this.TTMensaje.SetToolTip(this.txtEmail, "Ingrese un Email Válido.");
            this.TTMensaje.SetToolTip(this.txtContraseña, "Ingrese una Contraseña Válida");
            this.txtContraseña.isPassword = true;
            this.txtContraseñaLogin.isPassword = true;
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
            this.txtNickname.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtContraseña.Text = string.Empty;
        }
        #endregion

        #region Desplazar al Panel de Registro
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (panel1.Left == 441)
            {
                panel2.Visible = false;
                panel2.Left = 441;

                panel1.Visible = false;
                panel1.Left = 40;
                panel1.Visible = true;
            

                bunifuSeparator1.Left = bunifuThinButton21.Left;
                bunifuSeparator1.Width = bunifuThinButton21.Width;
            }
        }
        #endregion

        #region Desplazar al Panel de Login
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //359

            if (panel2.Left == 441)
            {
                panel1.Visible = false;
                panel1.Left = 441;

                panel2.Visible = false;
                panel2.Left = 45;
                panel2.Visible = true;

                bunifuSeparator1.Left = bunifuThinButton22.Left;
                bunifuSeparator1.Width = bunifuThinButton22.Width;
            }
        }
        #endregion

        #region Cerrar Formulario
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Minimizar Formulario
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Boton Registrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNickname.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados!");
                    errorIcono.SetError(txtNickname, "Ingrese un Nickname Válido");
                    errorIcono.SetError(txtEmail, "Ingrese un Email Válido");
                    errorIcono.SetError(txtContraseña, "Ingrese una Contraseña Válida");
                }
                else
                {
                    DataTable ValidarRegistroUsuario = CUsuario.ValidarRegistro(this.txtNickname.Text, this.txtEmail.Text);
                    if (ValidarRegistroUsuario.Rows.Count != 0)
                    {
                        //MensajeExito msjexito = new MensajeExito();
                        //msjexito.Show();
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "Usuario o Correo Electrónico ya en uso!";
                        msjError.bunifuCustomLabel3.Location = new Point(10,101);
                        msjError.Show();
                        //this.Hide();
                        //MessageBox.Show("El usuario ya se encuentra registrado.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string contraseñaEncriptada = CUsuario.EncriptarContraseña(this.txtContraseña.Text.Trim());
                        rpta = CUsuario.Registrar(this.txtNickname.Text.Trim(), this.txtEmail.Text.Trim(), contraseñaEncriptada);

                        if (rpta.Equals("OK"))
                        {
                            MensajeExito msjExito = new MensajeExito();
                            msjExito.bunifuCustomLabel3.Text = "Cuenta creada exitosamente!";
                            msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                            msjExito.Show();
                            //MessageBox.Show("Se agregó correctamente papu!");
                            string codigoactivacion = CCodActivacion.GenerarCodigoActivacion();
                            CUsuario.EnviarMailRegistro(txtEmail.Text, codigoactivacion);
                            DataTable TablaUsuarios = CUsuario.BuscarUsuarioPorNickname(this.txtNickname.Text);
                            string idUsuarioTabla = TablaUsuarios.Rows[0][0].ToString();
                            int idUsuario = int.Parse(idUsuarioTabla);
                            CCodActivacion.InsertarCodigoActivacion(idUsuario, codigoactivacion);
                            ValidarCuenta frmValidarCuenta = new ValidarCuenta();
                            frmValidarCuenta.idUsuario = TablaUsuarios.Rows[0][0].ToString();
                            frmValidarCuenta.nombreUsuario = this.txtNickname.Text;
                            frmValidarCuenta.emailUsuario = this.txtEmail.Text;
                            frmValidarCuenta.contraseñaEncriptadaUsuario = contraseñaEncriptada;
                            frmValidarCuenta.Show();
                            this.Hide();
                        }

                        else
                        {
                            MensajeDeError msjError = new MensajeDeError();
                            msjError.bunifuCustomLabel3.Text = "No se ha podido crear el usuario correctamente!";
                            msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                            msjError.Show();
                            //this.MensajeError(rpta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Abrir Formulario Reestablecer Contraseña
        private void labelReestablecerPass_Click(object sender, EventArgs e)
        {
            ReestablecerContraseña frmReestablecerContraseña = new ReestablecerContraseña();
            frmReestablecerContraseña.Show();
            this.Hide();
        }
        #endregion

        #region Boton Iniciar Sesion
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            contraseñaEncriptada = CUsuario.EncriptarContraseña(this.txtContraseñaLogin.Text);
            DataTable Datos = CUsuario.Login(this.txtNickNameLogin.Text, contraseñaEncriptada);

            //Evaluar si existe el usuario
            if (Datos.Rows.Count == 0)
            {
                MensajeDeError msjError = new MensajeDeError();
                msjError.bunifuCustomLabel3.Text = "Usuario o Contraseña incorrecto!";
                msjError.bunifuCustomLabel3.Location = new Point(32, 101);
                msjError.Show();
                //MessageBox.Show("Usuario no existente", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                imagenUsuario = CUsuario.MostrarImagenUsuario(Datos);
                idUsuario = CUsuario.CredencialesUsuario(Datos, "idUsuario");
                nicknameUsuario = CUsuario.CredencialesUsuario(Datos, "nicknameUsuario");
                rolUsuario = CUsuario.CredencialesUsuario(Datos, "rolUsuario");
                paisUsuario = CUsuario.CredencialesUsuario(Datos, "paisUsuario");
                fechaNacimientoUsuario = CUsuario.CredencialesUsuario(Datos, "fechaNacimientoUsuario");
                emailUsuario = CUsuario.CredencialesUsuario(Datos, "emailUsuario");
                estadoUsuario = CUsuario.CredencialesUsuario(Datos, "estadoUsuario");

                if (estadoUsuario == "1")
                {
                    Inicio frmInicio = new Inicio();
                    frmInicio.Show();
                    this.Hide();
                }
                else
                {
                    ValidarCuenta frmValidarCuenta = new ValidarCuenta();
                    frmValidarCuenta.Show();
                    this.Hide();
                }
            }
        }
        #endregion

        #region Pantalla Arrastrable
        private void Login_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Boton Minimizar
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
