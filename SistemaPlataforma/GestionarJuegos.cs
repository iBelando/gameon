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
    public partial class GestionarJuegos : Form
    {

        #region Almacenar Credenciales del Juego
        public static string idJuegoSeleccionado = "";
        #endregion

        #region Inicializar Componentes
        public GestionarJuegos()
        {
            InitializeComponent();

            ListarJuegos();

            ModoNuevo();

        }
        #endregion

        #region Modo Nuevo
        private void ModoNuevo()
        {
            this.btnNuevo.Visible = true;
            this.btnModificar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnNuevo.Width = 575; //495 || 592
            this.txtNombre.Text = "Nombre del Juego..";
            this.txtReglas.Text = "Reglamento del Juego..";
            this.pictureBox2.Image = global::SistemaPlataforma.Properties.Resources.equipo;
        }
        #endregion

        #region Listar Juegos
        private void ListarJuegos()
        {
            this.dgvJuegos.DataSource = CJuego.Mostrar();
            this.dgvJuegos.RowHeadersVisible = false;
            this.dgvJuegos.Columns["idJuego"].Visible = false;
            this.dgvJuegos.Columns["reglamentoJuego"].Visible = false;
            this.dgvJuegos.RowHeadersVisible = false;
            this.dgvJuegos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJuegos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvJuegos.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvJuegos.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region Pantalla Arrastrable
        private void GestionarJuegos_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void GestionarJuegos_MouseDown(object sender, MouseEventArgs e)
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

        #region Boton Minimizar
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Boton Volver
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            PanelDeAdmin frmPanelGestion = new PanelDeAdmin();
            frmPanelGestion.Show();
            this.Hide();
        }

        #endregion

        #region Limpiar Campo Buscar Juego al Hacer Click
        private void txtBuscarJuego_Enter(object sender, EventArgs e)
        {
            if (txtBuscarJuego.Text == "BUSCAR JUEGO...")
            {
                txtBuscarJuego.Text = "";
            }
        }

        private void txtBuscarJuego_Leave(object sender, EventArgs e)
        {
            if (txtBuscarJuego.Text == "")
            {
                txtBuscarJuego.Text = "BUSCAR JUEGO...";
            }
        }
        #endregion

        #region Boton Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarJuegoPorNombre();
        }
        #endregion

        #region Buscar Juego Por Nombre
        private void BuscarJuegoPorNombre()
        {
            if (String.IsNullOrEmpty(txtBuscarJuego.Text) || txtBuscarJuego.Text == "BUSCAR JUEGO...")
            {
                ListarJuegos();
                this.txtBuscarJuego.Text = "BUSCAR JUEGO...";
            }
            else
            {
                this.dgvJuegos.DataSource = CJuego.BuscarJuegoPorNombre(txtBuscarJuego.Text);
                this.txtBuscarJuego.Text = "BUSCAR JUEGO...";
            }

        }
        #endregion

        #region Desplazar al Panel Ver Juegos
        private void btnVerJuegos_Click(object sender, EventArgs e)
        {
            if (panelBuscarJuego.Left == 856) //688
            {
                panelGestionarJuego.Visible = false;
                panelGestionarJuego.Left = 856; //688

                panelBuscarJuego.Visible = false;
                panelBuscarJuego.Left = 15;
                panelBuscarJuego.Visible = true;


                bunifuSeparator1.Left = btnVerJuegos.Left;
                bunifuSeparator1.Width = btnVerJuegos.Width;

                ModoNuevo();
                ListarJuegos();
            }
        }
        #endregion

        #region Desplazar al Panel Gestionar Juegos
        private void btnGestionarJuegos_Click(object sender, EventArgs e)
        {
            if (panelGestionarJuego.Left == 856) //688
            {
                panelBuscarJuego.Visible = false;
                panelBuscarJuego.Left = 856; //688

                panelGestionarJuego.Visible = false;
                panelGestionarJuego.Left = 70;
                panelGestionarJuego.Visible = true;

                bunifuSeparator1.Left = btnGestionarJuegos.Left;
                bunifuSeparator1.Width = btnGestionarJuegos.Width;

                txtBuscarJuego.Text = "BUSCAR JUEGO...";
                ListarJuegos();
            }
        }

        #endregion

        #region Limpiar Campos del Panel de Gestionar Juegos

        #region Limpiar Campo Nombre Juego al Hacer Click
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre del Juego..")
            {
                txtNombre.Text = "";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre del Juego..";
            }
        }
        #endregion

        #region Limpiar Campo Reglamento Juego al Hacer Click
        private void txtReglas_Enter(object sender, EventArgs e)
        {
            if (txtReglas.Text == "Reglamento del Juego..")
            {
                txtReglas.Text = "";
            }
        }

        private void txtReglas_Leave(object sender, EventArgs e)
        {
            if (txtReglas.Text == "")
            {
                txtReglas.Text = "Reglamento del Juego..";
            }
        }
        #endregion

        #endregion

        #region Boton Subir Imagen
        private void btnSubir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox2.Image = Image.FromFile(dialog.FileName);
            }
        }
        #endregion

        #region Devolver Imagen del Juego
        private void DevolverImagenJuego()
        {
            if (!DBNull.Value.Equals(dgvJuegos.CurrentRow.Cells["colIcono"].Value))
            {
                byte[] imageBuffer = (byte[])dgvJuegos.CurrentRow.Cells["colIcono"].Value;
                // Se crea un MemoryStream a partir de ese buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                // Se utiliza el MemoryStream para extraer la imagen
                pictureBox2.Image = Image.FromStream(ms);
            }
        }
        #endregion

        #region Mensaje de Error
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Modo Modificar y Eliminar

        private void dgvJuegos_DoubleClick(object sender, EventArgs e)
        {
            #region Configuracion Visibilidad Botones
            this.btnNuevo.Visible = false;
            this.btnModificar.Visible = true;
            this.btnEliminar.Visible = true;
            #endregion

            #region Devolver Imagen del Juego
            DevolverImagenJuego();
            #endregion

            #region Carga el ID del Juego
            idJuegoSeleccionado = Convert.ToString(this.dgvJuegos.CurrentRow.Cells["idJuego"].Value);
            #endregion

            #region Carga el Nombre del Juego
            this.txtNombre.Text = Convert.ToString(this.dgvJuegos.CurrentRow.Cells["colNombre"].Value);
            #endregion

            #region Carga el Reglamento del Juego
            this.txtReglas.Text = Convert.ToString(this.dgvJuegos.CurrentRow.Cells["reglamentoJuego"].Value);
            #endregion

            #region Configuracion de los Paneles
            panelBuscarJuego.Visible = false;
            panelBuscarJuego.Left = 688;

            panelGestionarJuego.Visible = false;
            panelGestionarJuego.Left = 70;
            panelGestionarJuego.Visible = true;

            bunifuSeparator1.Left = btnGestionarJuegos.Left;
            bunifuSeparator1.Width = btnGestionarJuegos.Width;
            #endregion
        }

        #endregion

        #region Boton Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                DialogResult VentanaEmergente;
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere eliminar el juego?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {
                    rpta = CJuego.Eliminar(Convert.ToInt32(idJuegoSeleccionado));

                    if (rpta.Equals("OK"))
                    {
                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "El juego se ha eliminado exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                        //MessageBox.Show("Se eliminó correctamente!");
                        panelGestionarJuego.Visible = false;
                        panelGestionarJuego.Left = 688;
                        panelBuscarJuego.Visible = false;
                        panelBuscarJuego.Left = 15;
                        panelBuscarJuego.Visible = true;
                        bunifuSeparator1.Left = btnVerJuegos.Left;
                        bunifuSeparator1.Width = btnVerJuegos.Width;
                        ModoNuevo();
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "No se ha podido eliminar el juego correctamente!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }

                    this.ListarJuegos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        #endregion

        #region Boton Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] imagen = ms.GetBuffer();
                rpta = CJuego.Editar(int.Parse(idJuegoSeleccionado), this.txtNombre.Text.Trim(), imagen, this.txtReglas.Text.Trim());

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El juego se ha modificado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarJuego.Visible = false;
                    panelGestionarJuego.Left = 688;
                    panelBuscarJuego.Visible = false;
                    panelBuscarJuego.Left = 15;
                    panelBuscarJuego.Visible = true;
                    bunifuSeparator1.Left = btnVerJuegos.Left;
                    bunifuSeparator1.Width = btnVerJuegos.Width;
                    ModoNuevo();
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido modificar el Juego correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                this.ListarJuegos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        #endregion

        #region Boton Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] imagen = ms.GetBuffer();
                rpta = CJuego.Insertar(this.txtNombre.Text.Trim(), imagen, this.txtReglas.Text.Trim());

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El juego se ha creado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarJuego.Visible = false;
                    panelGestionarJuego.Left = 856; //688
                    panelBuscarJuego.Visible = false;
                    panelBuscarJuego.Left = 15;
                    panelBuscarJuego.Visible = true;
                    bunifuSeparator1.Left = btnVerJuegos.Left;
                    bunifuSeparator1.Width = btnVerJuegos.Width;
                    ModoNuevo();
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido crear el Juego correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                this.ListarJuegos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

    }
}
