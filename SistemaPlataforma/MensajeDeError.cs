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

namespace SistemaPlataforma
{
    public partial class MensajeDeError : Form
    {

        #region Inicializar Componentes
        public MensajeDeError()
        {
            InitializeComponent();
        }
        #endregion

        #region Pantalla Arrastrable
        private void MensajeDeError_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void MensajeDeError_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Boton Aceptar
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

    }
}
