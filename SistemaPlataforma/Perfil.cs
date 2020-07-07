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
    public partial class Perfil : Form
    {

        #region Mostrar Fecha de Nacimiento del Usuario
        private void MostrarFechaNacimientoUsuario()
        {
            if (String.IsNullOrEmpty(Login.fechaNacimientoUsuario))
            {
                this.bunifuCustomLabel7.Text = "No configurada por el Usuario";
                this.dtpEditarFechaNacimiento.Value = DateTime.Now;
            }
            else
            {
                //Seteamos la Fecha de Nacimiento del Usuario en el Label
                string fechaNacimientoCompleta = Convert.ToString(Login.fechaNacimientoUsuario);
                string fechaNacimientoSoloFecha = fechaNacimientoCompleta.Replace("00:00:00", " ");
                this.bunifuCustomLabel7.Text = Convert.ToString(fechaNacimientoSoloFecha);
                //Seteamos la Fecha de Nacimiento del Usuario en el DataTimePicker
                dtpEditarFechaNacimiento.Value = DateTime.Parse(Login.fechaNacimientoUsuario);
                dtpEditarFechaNacimiento.Format = DateTimePickerFormat.Short;
            }
        }
        #endregion

        #region Actualizar Campos
        private void ActualizarCampos(byte[] imagenSubida)
        {

            #region Nickname Usuario
            Login.nicknameUsuario = this.txtEditarNickname.Text;
            this.lblNombre.Text = this.txtEditarNickname.Text;
            #endregion

            #region Pais Usuario
            Login.paisUsuario = dropdownEditarPais.selectedValue;
            this.lblPaisUsuario.Text = dropdownEditarPais.selectedValue;
            #endregion

            #region Fecha Nacimiento de Usuario
            Login.fechaNacimientoUsuario = dtpEditarFechaNacimiento.Value.ToShortDateString();
            string fechaNacimientoCompleta1 = Convert.ToString(Login.fechaNacimientoUsuario);
            string fechaNacimientoSoloFecha1 = fechaNacimientoCompleta1.Replace("00:00:00", " ");
            this.bunifuCustomLabel7.Text = Convert.ToString(fechaNacimientoSoloFecha1);
            #endregion

            #region Email de Usuario
            Login.emailUsuario = this.txtEditarEmail.Text;
            #endregion

            #region Imagen Usuario
            Login.imagenUsuario = imagenSubida;
            #endregion

        }
        #endregion

        #region Cargar Paises en DropDownList
        private void CargarPaisesDropDownList()
        {
            dropdownEditarPais.AddItem("Argentina");
            dropdownEditarPais.AddItem("Bolivia");
            dropdownEditarPais.AddItem("Brasil");
            dropdownEditarPais.AddItem("Chile");
            dropdownEditarPais.AddItem("Colombia");
            dropdownEditarPais.AddItem("Ecuador");
            dropdownEditarPais.AddItem("Guyana");
            dropdownEditarPais.AddItem("Paraguay");
            dropdownEditarPais.AddItem("Perú");
            dropdownEditarPais.AddItem("Trinidad y Tobago");
            dropdownEditarPais.AddItem("Surinam");
            dropdownEditarPais.AddItem("Uruguay");
            dropdownEditarPais.AddItem("Venezuela");
        }
        #endregion

        #region Validar Pais Usuario
        private void ValidarPaisUsuario(string paisUsuario)
        {
            switch(paisUsuario)
            {
                case "Argentina":
                    dropdownEditarPais.selectedIndex = 0;
                    break;
                case "Bolivia":
                    dropdownEditarPais.selectedIndex = 1;
                    break;
                case "Brasil":
                    dropdownEditarPais.selectedIndex = 2;
                    break;
                case "Chile":
                    dropdownEditarPais.selectedIndex = 3;
                    break;
                case "Colombia":
                    dropdownEditarPais.selectedIndex = 4;
                    break;
                case "Ecuador":
                    dropdownEditarPais.selectedIndex = 5;
                    break;
                case "Guyana":
                    dropdownEditarPais.selectedIndex = 6;
                    break;
                case "Paraguay":
                    dropdownEditarPais.selectedIndex = 7;
                    break;
                case "Perú":
                    dropdownEditarPais.selectedIndex = 8;
                    break;
                case "Trinidad y Tobago":
                    dropdownEditarPais.selectedIndex = 9;
                    break;
                case "Surinam":
                    dropdownEditarPais.selectedIndex = 10;
                    break;
                case "Uruguay":
                    dropdownEditarPais.selectedIndex = 11;
                    break;
                case "Venezuela":
                    dropdownEditarPais.selectedIndex = 12;
                    break;
            }
        }
        #endregion

        #region Devolver Imagen del Usuario
        private void DevolverImagenUsuario()
        {
            if (Login.imagenUsuario != null)
            {
                byte[] imageLength = Login.imagenUsuario;
                if (imageLength.Length > 0)
                {
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Login.imagenUsuario);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox2.Image = Image.FromStream(ms);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }
        #endregion

        #region Inicializar Componentes
        public Perfil()
        {
            InitializeComponent();
            //this.lblNombre.Text = Login.nicknameUsuario;
            //this.lblNombreRol.Text = CUsuario.MostrarNombreRol(Login.rolUsuario);
            //this.lblPaisUsuario.Text = CUsuario.MostrarPaisUsuario(Login.paisUsuario);
            //MostrarFechaNacimientoUsuario();
            //this.txtEditarNickname.Text = Login.nicknameUsuario;
            //this.bunifuCustomLabel9.Text = Login.emailUsuario;
            //this.txtEditarEmail.Text = Login.emailUsuario;
            //CargarPaisesDropDownList();
            //ValidarPaisUsuario(CUsuario.MostrarPaisUsuario(Login.paisUsuario));
        }
        #endregion

        #region Desplazar al Panel de Mi Perfil
        private void btnMiPerfil_Click(object sender, EventArgs e)
        {
            if (panelMiPerfil.Left == 856) //437
            {
                panelEditarPerfil.Visible = false;
                panelEditarPerfil.Left = 856; //437

                panelMiPerfil.Visible = false;
                panelMiPerfil.Left = 30;
                panelMiPerfil.Visible = true;


                bunifuSeparator1.Left = btnMiPerfil.Left;
                bunifuSeparator1.Width = btnMiPerfil.Width;
            }
        }
        #endregion

        #region Desplazar al Panel de Editar Perfil
        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            if (panelEditarPerfil.Left == 856) //437
            {
                panelMiPerfil.Visible = false;
                panelMiPerfil.Left = 856; //437

                panelEditarPerfil.Visible = false;
                panelEditarPerfil.Left = 30;
                panelEditarPerfil.Visible = true;

                bunifuSeparator1.Left = btnEditarPerfil.Left;
                bunifuSeparator1.Width = btnEditarPerfil.Width;
            }
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

        #region Opciones Extra
        private void label2_Click(object sender, EventArgs e)
        {
            //bunifuSeparator1.Visible = false;
            //bunifuSeparator1.Left = ((Control)sender).Left;
            //bunifuSeparator1.Width = ((Control)sender).Width;
            //bunifuTransition1.ShowSync(bunifuSeparator1);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            panelMiPerfil.BringToFront();
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            panelEditarPerfil.BringToFront();
        }

        private void panelEditarPerfil_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Boton Cerrar Sesion
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            frmLogin.Show();
            this.Hide();
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

        #region Boton Editar Imagen
        private void btnEditarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox1.Image = Image.FromFile(dialog.FileName);
            }
        }
        #endregion

        #region Boton Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] imagen = ms.GetBuffer();
                CUsuario.EditarMiPerfil(int.Parse(Login.idUsuario), this.txtEditarNickname.Text.Trim(), this.dropdownEditarPais.selectedValue.Trim(), this.dtpEditarFechaNacimiento.Value, this.txtEditarEmail.Text.Trim(), CUsuario.ValidarNuevaContraseña(Login.contraseñaEncriptada, txtEditarContraseña.Text.Trim()), imagen);
                MessageBox.Show("Se guardó todo!");
                ActualizarCampos(imagen);
                pictureBox2.Image = Image.FromStream(ms);
                this.bunifuCustomLabel9.Text = Login.emailUsuario;
                this.lblPaisUsuario.Text = Login.paisUsuario;
                this.btnCerrar.Visible = true;
                this.btnVolver.Visible = true;
                this.btnMinimizar.Location = new Point(774,5);

                #region Desplazar al Panel de Mi Perfil
                if (panelMiPerfil.Left == 856) //437
                {
                    panelEditarPerfil.Visible = false;
                    panelEditarPerfil.Left = 856; //437

                    panelMiPerfil.Visible = false;
                    panelMiPerfil.Left = 30;
                    panelMiPerfil.Visible = true;


                    bunifuSeparator1.Left = btnMiPerfil.Left;
                    bunifuSeparator1.Width = btnMiPerfil.Width;
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Pantalla Arrastrable
        private void Perfil_Load(object sender, EventArgs e)
        {

            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion

            this.lblNombre.Text = Login.nicknameUsuario;
            this.lblNombreRol.Text = CUsuario.MostrarNombreRol(Login.rolUsuario);
            this.lblPaisUsuario.Text = CUsuario.MostrarPaisUsuario(Login.paisUsuario);
            MostrarFechaNacimientoUsuario();
            this.txtEditarNickname.Text = Login.nicknameUsuario;
            this.bunifuCustomLabel9.Text = Login.emailUsuario;
            this.txtEditarEmail.Text = Login.emailUsuario;
            CargarPaisesDropDownList();
            ValidarPaisUsuario(CUsuario.MostrarPaisUsuario(Login.paisUsuario));
            DevolverImagenUsuario();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Perfil_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        #endregion

        #region Limpiar Textbox Editar Contraseña al Hacer Click
        private void txtEditarContraseña_Enter(object sender, EventArgs e)
        {
            if (txtEditarContraseña.Text == "Contraseña..")
            {
                txtEditarContraseña.Text = "";
                txtEditarContraseña.isPassword = true;
            }
        }

        private void txtEditarContraseña_Leave(object sender, EventArgs e)
        {
            if (txtEditarContraseña.Text == "")
            {
                txtEditarContraseña.isPassword = false;
                txtEditarContraseña.Text = "Contraseña..";
            }
        }
        #endregion

    }
}