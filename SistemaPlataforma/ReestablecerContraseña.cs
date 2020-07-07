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
    public partial class ReestablecerContraseña : Form
    {

        #region Inicializar Componentes
        public ReestablecerContraseña()
        {
            InitializeComponent();
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
            this.txtEmailReestablecer.Text = string.Empty;
        }
        #endregion

        #region Boton Enviar
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                //string rpta = "";
                if (this.txtEmailReestablecer.Text == string.Empty)
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "El email ingresado, no es válido!";
                    msjError.bunifuCustomLabel3.Location = new Point(40, 101);
                    msjError.Show();
                    //MensajeError("Falta ingresar algunos datos, serán remarcados!");
                    //errorIcono.SetError(txtEmailReestablecer, "Ingrese un Código de Activación Válido!");
                }
                else
                {
                    DataTable EmailsUsuariosTabla = CUsuario.BuscarEmailUsuario(this.txtEmailReestablecer.Text);
                    if (EmailsUsuariosTabla.Rows.Count == 0)
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "El email ingresado, no es válido!";
                        msjError.bunifuCustomLabel3.Location = new Point(40, 101);
                        msjError.Show();
                        //MessageBox.Show("El codigo ingresado, no existe.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string nuevaContraseña = CUsuario.GenerarNuevaContraseña();
                        string contraseñaEncriptada = CUsuario.EncriptarContraseña(nuevaContraseña);
                        CUsuario.ReestablecerContraseña(this.txtEmailReestablecer.Text, contraseñaEncriptada);
                        CUsuario.EnviarMailReestablecerContraseña(this.txtEmailReestablecer.Text, nuevaContraseña);
                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "Nueva contraseña enviada al email!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                        //MessageBox.Show("Nueva contraseña enviada al email!");
                        Login frmLogin = new Login();
                        frmLogin.Show();
                        this.Hide();
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
        private void ReestablecerContraseña_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ReestablecerContraseña_MouseDown(object sender, MouseEventArgs e)
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
