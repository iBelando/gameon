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
    public partial class GestionarEquipos : Form
    {

        #region Almacenar Credenciales del Usuario
        public static string idEquipoSeleccionado = "";
        public static string stringJugadores = "";
        //public static string[] jugadores = new string[9];
        List<string> jugadores = new List<string>();
        #endregion

        #region Inicializar Componentes
        public GestionarEquipos()
        {
            InitializeComponent();
            ListarEquipos();
            ModoAlta();
        }
        #endregion

        #region Mensaje de Error
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Modo Alta
        private void ModoAlta()
        {
            this.btnNuevo.Visible = true;
            this.btnModificar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnAgregar1.Visible = true;
            this.btnRemover1.Visible = false;
            this.btnAgregar2.Visible = true;
            this.btnRemover2.Visible = false;
            this.btnAgregar3.Visible = true;
            this.btnRemover3.Visible = false;
            this.btnAgregar4.Visible = true;
            this.btnRemover4.Visible = false;
            this.btnAgregar5.Visible = true;
            this.btnRemover5.Visible = false;
            this.btnAgregar6.Visible = true;
            this.btnRemover6.Visible = false;
            this.btnAgregar7.Visible = true;
            this.btnRemover7.Visible = false;
            this.btnAgregar8.Visible = true;
            this.btnRemover8.Visible = false;
            this.btnAgregar9.Visible = true;
            this.btnRemover9.Visible = false;
            this.txtJugador1.Enabled = true;
            this.txtJugador2.Enabled = true;
            this.txtJugador3.Enabled = true;
            this.txtJugador4.Enabled = true;
            this.txtJugador5.Enabled = true;
            this.txtJugador6.Enabled = true;
            this.txtJugador7.Enabled = true;
            this.txtJugador8.Enabled = true;
            this.txtJugador9.Enabled = true;
            this.btnNuevo.Width = 562; //495
            this.txtNombreEquipo.Text = "Nombre del Equipo..";
            this.txtDescripcion.Text = "Descripción..";
            this.txtCapitan.Text = "Capitán..";
            this.txtJugador1.Text = "Jugador 1..";
            this.txtJugador2.Text = "Jugador 2..";
            this.txtJugador3.Text = "Jugador 3..";
            this.txtJugador4.Text = "Jugador 4..";
            this.txtJugador5.Text = "Jugador 5..";
            this.txtJugador6.Text = "Jugador 6..";
            this.txtJugador7.Text = "Jugador 7..";
            this.txtJugador8.Text = "Jugador 8..";
            this.txtJugador9.Text = "Jugador 9..";
            this.pictureBox2.Image = global::SistemaPlataforma.Properties.Resources.equipo;
        }
        #endregion

        #region Listar Equipos
        private void ListarEquipos()
        {
            this.dgvEquipos.DataSource = CEquipo.Mostrar();
            this.dgvEquipos.Columns["idEquipo"].Visible = false;
            this.dgvEquipos.Columns["imagenEquipo"].Visible = false;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvEquipos.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvEquipos.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region Buscar Equipo Por Nombre
        private void BuscarEquipoPorNombre()
        {
            if (String.IsNullOrEmpty(txtBuscarEquipo.Text) || txtBuscarEquipo.Text == "BUSCAR EQUIPO...")
            {
                ListarEquipos();
                this.txtBuscarEquipo.Text = "BUSCAR EQUIPO...";
            }
            else
            {
                this.dgvEquipos.DataSource = CEquipo.BuscarEquipoPorNombre(txtBuscarEquipo.Text);
                this.txtBuscarEquipo.Text = "BUSCAR EQUIPO...";
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

        #region Desplazar al Panel de Ver Equipos
        private void btnVerEquipos_Click(object sender, EventArgs e)
        {
            if (panelBuscarEquipo.Left == 694) //694
            {
                panelGestionarEquipo.Visible = false;
                panelGestionarEquipo.Left = 694; //694

                panelBuscarEquipo.Visible = false;
                panelBuscarEquipo.Left = 30;
                panelBuscarEquipo.Visible = true;


                bunifuSeparator1.Left = btnVerEquipos.Left;
                bunifuSeparator1.Width = btnVerEquipos.Width;

                ModoAlta();
            }
        }
        #endregion

        #region Desplazar al Panel de Gestionar Equipos
        private void btnGestionarEquipos_Click(object sender, EventArgs e)
        {
            if (panelGestionarEquipo.Left == 856) //694
            {
                panelBuscarEquipo.Visible = false;
                panelBuscarEquipo.Left = 856; //694

                panelGestionarEquipo.Visible = false;
                panelGestionarEquipo.Left = 77;
                panelGestionarEquipo.Visible = true;

                bunifuSeparator1.Left = btnGestionarEquipos.Left;
                bunifuSeparator1.Width = btnGestionarEquipos.Width;

                txtBuscarEquipo.Text = "BUSCAR EQUIPO...";
                ListarEquipos();
            }
        }
        #endregion

        #region Boton Volver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            PanelDeAdmin frmPanelGestion = new PanelDeAdmin();
            frmPanelGestion.Show();
            this.Hide();
        }
        #endregion

        #region Boton Buscar
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            BuscarEquipoPorNombre();
        }


        #endregion

        #region Limpiar Botones en Panel de Gestionar

        #region Campo Nombre del Equipo
        private void txtNombreEquipo_Enter(object sender, EventArgs e)
        {
            if (txtNombreEquipo.Text == "Nombre del Equipo..")
            {
                txtNombreEquipo.Text = "";
            }
        }

        private void txtNombreEquipo_Leave(object sender, EventArgs e)
        {
            if (txtNombreEquipo.Text == "")
            {
                txtNombreEquipo.Text = "Nombre del Equipo..";
            }
        }
        #endregion

        #region Campo Descripcion del Equipo
        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripción..")
            {
                txtDescripcion.Text = "";
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Descripción..";
            }
        }
        #endregion

        #region Campo Capitan del Equipo
        private void txtCapitan_Enter(object sender, EventArgs e)
        {
            if (txtCapitan.Text == "Capitán..")
            {
                txtCapitan.Text = "";
            }
        }

        private void txtCapitan_Leave(object sender, EventArgs e)
        {
            if (txtCapitan.Text == "")
            {
                txtCapitan.Text = "Capitán..";
            }
        }

        #endregion

        #region Campo Jugador1 del Equipo
        private void txtJugador1_Enter(object sender, EventArgs e)
        {
            if (txtJugador1.Text == "Jugador 1..")
            {
                txtJugador1.Text = "";
            }
        }

        private void txtJugador1_Leave(object sender, EventArgs e)
        {
            if (txtJugador1.Text == "")
            {
                txtJugador1.Text = "Jugador 1..";
            }
        }

        #endregion

        #region Campo Jugador2 del Equipo
        private void txtJugador2_Enter(object sender, EventArgs e)
        {
            if (txtJugador2.Text == "Jugador 2..")
            {
                txtJugador2.Text = "";
            }
        }

        private void txtJugador2_Leave(object sender, EventArgs e)
        {
            if (txtJugador2.Text == "")
            {
                txtJugador2.Text = "Jugador 2..";
            }
        }

        #endregion

        #region Campo Jugador3 del Equipo
        private void txtJugador3_Enter(object sender, EventArgs e)
        {
            if (txtJugador3.Text == "Jugador 3..")
            {
                txtJugador3.Text = "";
            }
        }

        private void txtJugador3_Leave(object sender, EventArgs e)
        {
            if (txtJugador3.Text == "")
            {
                txtJugador3.Text = "Jugador 3..";
            }
        }

        #endregion

        #region Campo Jugador4 del Equipo
        private void txtJugador4_Enter(object sender, EventArgs e)
        {
            if (txtJugador4.Text == "Jugador 4..")
            {
                txtJugador4.Text = "";
            }
        }

        private void txtJugador4_Leave(object sender, EventArgs e)
        {
            if (txtJugador4.Text == "")
            {
                txtJugador4.Text = "Jugador 4..";
            }
        }
        #endregion

        #region Campo Jugador5 del Equipo
        private void txtJugador5_Enter(object sender, EventArgs e)
        {
            if (txtJugador5.Text == "Jugador 5..")
            {
                txtJugador5.Text = "";
            }
        }

        private void txtJugador5_Leave(object sender, EventArgs e)
        {
            if (txtJugador5.Text == "")
            {
                txtJugador5.Text = "Jugador 5..";
            }
        }
        #endregion

        #region Campo Jugador6 del Equipo
        private void txtJugador6_Enter(object sender, EventArgs e)
        {
            if (txtJugador6.Text == "Jugador 6..")
            {
                txtJugador6.Text = "";
            }
        }

        private void txtJugador6_Leave(object sender, EventArgs e)
        {
            if (txtJugador6.Text == "")
            {
                txtJugador6.Text = "Jugador 6..";
            }
        }
        #endregion

        #region Campo Jugador7 del Equipo
        private void txtJugador7_Enter(object sender, EventArgs e)
        {
            if (txtJugador7.Text == "Jugador 7..")
            {
                txtJugador7.Text = "";
            }
        }

        private void txtJugador7_Leave(object sender, EventArgs e)
        {
            if (txtJugador7.Text == "")
            {
                txtJugador7.Text = "Jugador 7..";
            }
        }
        #endregion

        #region Campo Jugador8 del Equipo
        private void txtJugador8_Enter(object sender, EventArgs e)
        {
            if (txtJugador8.Text == "Jugador 8..")
            {
                txtJugador8.Text = "";
            }
        }

        private void txtJugador8_Leave(object sender, EventArgs e)
        {
            if (txtJugador8.Text == "")
            {
                txtJugador8.Text = "Jugador 8..";
            }
        }
        #endregion

        #region Campo Jugador9 del Equipo
        private void txtJugador9_Enter(object sender, EventArgs e)
        {
            if (txtJugador9.Text == "Jugador 9..")
            {
                txtJugador9.Text = "";
            }
        }

        private void txtJugador9_Leave(object sender, EventArgs e)
        {
            if (txtJugador9.Text == "")
            {
                txtJugador9.Text = "Jugador 9..";
            }
        }
        #endregion

        #endregion

        #region Boton Subir Imagen
        private void btnSubirImagen_Click(object sender, EventArgs e)
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

        #region Boton Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] imagen = ms.GetBuffer();
                DataTable Datos = CUsuario.ValidarUsuarioExistente(txtCapitan.Text);
                if (Datos.Rows.Count != 0 && (this.txtCapitan.Text != this.txtJugador1.Text || this.txtCapitan.Text != this.txtJugador2.Text || this.txtCapitan.Text != this.txtJugador3.Text || this.txtCapitan.Text != this.txtJugador4.Text))
                {
                    stringJugadores = String.Join(",", jugadores);
                    rpta = CEquipo.Insertar(this.txtNombreEquipo.Text.Trim(), this.txtDescripcion.Text.Trim(), this.txtCapitan.Text.Trim(), stringJugadores, imagen);
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "El usuario ingresado, no existe en la Plataforma!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MessageBox.Show("El usuario ingresado no existe en la Plataforma.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCapitan.Text = "Capitán..";
                }

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El equipo se ha creado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarEquipo.Visible = false;
                    panelGestionarEquipo.Left = 698;
                    panelBuscarEquipo.Visible = false;
                    panelBuscarEquipo.Left = 15;
                    panelBuscarEquipo.Visible = true;
                    bunifuSeparator1.Left = btnVerEquipos.Left;
                    bunifuSeparator1.Width = btnVerEquipos.Width;
                    ModoAlta();
                }

                this.ListarEquipos();
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
                DataTable Datos = CUsuario.ValidarUsuarioExistente(txtCapitan.Text);
                if (Datos.Rows.Count != 0)
                {
                    if (this.txtCapitan.Text != this.txtJugador1.Text && this.txtCapitan.Text != this.txtJugador2.Text && this.txtCapitan.Text != this.txtJugador3.Text && this.txtCapitan.Text != this.txtJugador4.Text && this.txtCapitan.Text != this.txtJugador5.Text && this.txtCapitan.Text != this.txtJugador6.Text && this.txtCapitan.Text != this.txtJugador7.Text && this.txtCapitan.Text != this.txtJugador8.Text && this.txtCapitan.Text != this.txtJugador9.Text)
                    {
                        stringJugadores = String.Join(",", jugadores);
                        rpta = CEquipo.Editar(int.Parse(idEquipoSeleccionado), this.txtNombreEquipo.Text.Trim(), this.txtDescripcion.Text.Trim(), this.txtCapitan.Text.Trim(), stringJugadores, imagen);
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "El Capitán no puede ser agregado también como jugador!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MessageBox.Show(".", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtJugador1.Text = "Jugador 1..";
                        this.txtJugador1.Enabled = true;
                        this.btnAgregar1.Visible = true;
                        this.btnRemover1.Visible = false;
                        this.txtJugador2.Text = "Jugador 2..";
                        this.txtJugador2.Enabled = true;
                        this.btnAgregar2.Visible = true;
                        this.btnRemover2.Visible = false;
                        this.txtJugador3.Text = "Jugador 3..";
                        this.txtJugador3.Enabled = true;
                        this.btnAgregar3.Visible = true;
                        this.btnRemover3.Visible = false;
                        this.txtJugador4.Text = "Jugador 4..";
                        this.txtJugador4.Enabled = true;
                        this.btnAgregar4.Visible = true;
                        this.btnRemover4.Visible = false;
                        this.txtJugador5.Text = "Jugador 5..";
                        this.txtJugador5.Enabled = true;
                        this.btnAgregar5.Visible = true;
                        this.btnRemover5.Visible = false;
                        this.txtJugador6.Text = "Jugador 6..";
                        this.txtJugador6.Enabled = true;
                        this.btnAgregar6.Visible = true;
                        this.btnRemover6.Visible = false;
                        this.txtJugador7.Text = "Jugador 7..";
                        this.txtJugador7.Enabled = true;
                        this.btnAgregar7.Visible = true;
                        this.btnRemover7.Visible = false;
                        this.txtJugador8.Text = "Jugador 8..";
                        this.txtJugador8.Enabled = true;
                        this.btnAgregar8.Visible = true;
                        this.btnRemover8.Visible = false;
                        this.txtJugador9.Text = "Jugador 9..";
                        this.txtJugador9.Enabled = true;
                        this.btnAgregar9.Visible = true;
                        this.btnRemover9.Visible = false;
                    }
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "El usuario ingresado no existe en la Plataforma!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MessageBox.Show(".", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCapitan.Text = "Capitán..";
                }

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El equipo se ha modificado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarEquipo.Visible = false;
                    panelGestionarEquipo.Left = 698;
                    panelBuscarEquipo.Visible = false;
                    panelBuscarEquipo.Left = 15;
                    panelBuscarEquipo.Visible = true;
                    bunifuSeparator1.Left = btnVerEquipos.Left;
                    bunifuSeparator1.Width = btnVerEquipos.Width;
                    ModoAlta();
                }

                this.ListarEquipos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Boton Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                DialogResult VentanaEmergente;
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere eliminar el equipo?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {
                    rpta = CEquipo.Eliminar(Convert.ToInt32(idEquipoSeleccionado));

                    if (rpta.Equals("OK"))
                    {
                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "El equipo se ha eliminado exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                        //MessageBox.Show("Se eliminó correctamente!");
                        panelGestionarEquipo.Visible = false;
                        panelGestionarEquipo.Left = 694;
                        panelBuscarEquipo.Visible = false;
                        panelBuscarEquipo.Left = 15;
                        panelBuscarEquipo.Visible = true;
                        bunifuSeparator1.Left = btnVerEquipos.Left;
                        bunifuSeparator1.Width = btnVerEquipos.Width;
                        ModoAlta();
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "No se ha podido eliminar el equipo correctamente!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }

                    this.ListarEquipos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Limpiar Campo Buscar Equipo al hacer click
        private void txtBuscarEquipo_Enter(object sender, EventArgs e)
        {
            if (txtBuscarEquipo.Text == "BUSCAR EQUIPO...")
            {
                txtBuscarEquipo.Text = "";
            }
        }

        private void txtBuscarEquipo_Leave(object sender, EventArgs e)
        {
            if (txtBuscarEquipo.Text == "")
            {
                txtBuscarEquipo.Text = "BUSCAR EQUIPO...";
            }
        }
        #endregion

        #region Verificar Campo Jugador No Vacio
        public void VerificarCampoJugadorNoVacio1(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador)) //!String.IsNullOrEmpty(jugadoresComprobar[0])
            {
                this.txtJugador1.Text = jugador;
                this.txtJugador1.Enabled = false;
                this.btnAgregar1.Visible = false;
                this.btnRemover1.Visible = true;
            }
            else
            {
                this.txtJugador1.Text = "Jugador 1..";
                this.txtJugador1.Enabled = true;
                this.btnAgregar1.Visible = true;
                this.btnRemover1.Visible = false;
            }
        }
        public void VerificarCampoJugadorNoVacio2(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador)) //!String.IsNullOrEmpty(jugadoresComprobar[1])
            {
                this.txtJugador2.Text = jugador;
                this.txtJugador2.Enabled = false;
                this.btnAgregar2.Visible = false;
                this.btnRemover2.Visible = true;
            }
            else
            {
                this.txtJugador2.Text = "Jugador 2..";
                this.txtJugador2.Enabled = true;
                this.btnAgregar2.Visible = true;
                this.btnRemover2.Visible = false;
            }
        }
        public void VerificarCampoJugadorNoVacio3(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador)) //!String.IsNullOrEmpty(jugadoresComprobar[2])
            {
                this.txtJugador3.Text = jugador;
                this.txtJugador3.Enabled = false;
                this.btnAgregar3.Visible = false;
                this.btnRemover3.Visible = true;
            }
            else
            {
                this.txtJugador3.Text = "Jugador 3..";
                this.txtJugador3.Enabled = true;
                this.btnAgregar3.Visible = true;
                this.btnRemover3.Visible = false;
            }
        }
        public void VerificarCampoJugadorNoVacio4(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador)) //!String.IsNullOrEmpty(jugadoresComprobar[3])
            {
                this.txtJugador4.Text = jugador;
                this.txtJugador4.Enabled = false;
                this.btnAgregar4.Visible = false;
                this.btnRemover4.Visible = true;
            }
            else
            {
                this.txtJugador4.Text = "Jugador 4..";
                this.txtJugador4.Enabled = true;
                this.btnAgregar4.Visible = true;
                this.btnRemover4.Visible = false;
            }
        }
        public void VerificarCampoJugadorNoVacio5(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador)) //!String.IsNullOrEmpty(jugadoresComprobar[4])
            {
                this.txtJugador5.Text = jugador;
                this.txtJugador5.Enabled = false;
                this.btnAgregar5.Visible = false;
                this.btnRemover5.Visible = true;
            }
            else
            {
                this.txtJugador5.Text = "Jugador 5..";
                this.txtJugador5.Enabled = true;
                this.btnAgregar5.Visible = true;
                this.btnRemover5.Visible = false;
            }
        }
        public void VerificarCampoJugadorNoVacio6(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador)) //!String.IsNullOrEmpty(jugadoresComprobar[5])
            {
                this.txtJugador6.Text = jugador;
                this.txtJugador6.Enabled = false;
                this.btnAgregar6.Visible = false;
                this.btnRemover6.Visible = true;
            }
            else
            {
                this.txtJugador6.Text = "Jugador 6..";
                this.txtJugador6.Enabled = true;
                this.btnAgregar6.Visible = true;
                this.btnRemover6.Visible = false;
            }
        }
        public void VerificarCampoJugadorNoVacio7(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador)) //!String.IsNullOrEmpty(jugadoresComprobar[6])
            {
                this.txtJugador7.Text = jugador;
                this.txtJugador7.Enabled = false;
                this.btnAgregar7.Visible = false;
                this.btnRemover7.Visible = true;
            }
            else
            {
                this.txtJugador7.Text = "Jugador 7..";
                this.txtJugador7.Enabled = true;
                this.btnAgregar7.Visible = true;
                this.btnRemover7.Visible = false;
            }
        }
        public void VerificarCampoJugadorNoVacio8(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador)) //!String.IsNullOrEmpty(jugadoresComprobar[7])
            {
                this.txtJugador8.Text = jugador;
                this.txtJugador8.Enabled = false;
                this.btnAgregar8.Visible = false;
                this.btnRemover8.Visible = true;
            }
            else
            {
                this.txtJugador8.Text = "Jugador 8..";
                this.txtJugador8.Enabled = true;
                this.btnAgregar8.Visible = true;
                this.btnRemover8.Visible = false;
            }
        }
        public void VerificarCampoJugadorNoVacio9(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador)) //!String.IsNullOrEmpty(jugadoresComprobar[8])
            {
                this.txtJugador9.Text = jugador;
                this.txtJugador9.Enabled = false;
                this.btnAgregar9.Visible = false;
                this.btnRemover9.Visible = true;
            }
            else
            {
                this.txtJugador9.Text = "Jugador 9..";
                this.txtJugador9.Enabled = true;
                this.btnAgregar9.Visible = true;
                this.btnRemover9.Visible = false;
            }
        }
        #endregion

        #region Modo Modificar y Eliminar
        private void dgvEquipos_DoubleClick(object sender, EventArgs e)
        {
            this.btnNuevo.Visible = false;
            this.btnModificar.Visible = true;
            this.btnEliminar.Visible = true;
            DevolverImagenEquipo();
            idEquipoSeleccionado = Convert.ToString(this.dgvEquipos.CurrentRow.Cells["idEquipo"].Value);
            this.txtNombreEquipo.Text = Convert.ToString(this.dgvEquipos.CurrentRow.Cells["colNombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dgvEquipos.CurrentRow.Cells["colDescripcion"].Value);
            this.txtCapitan.Text = Convert.ToString(this.dgvEquipos.CurrentRow.Cells["colCapitan"].Value);
            string jugadoresDB = Convert.ToString(this.dgvEquipos.CurrentRow.Cells["colJugadores"].Value);
            jugadores = jugadoresDB.Split(',').ToList();
            //VerificarCampoJugadorNoVacio1(jugadores[0]);
            //VerificarCampoJugadorNoVacio2(jugadores[1]);
            //VerificarCampoJugadorNoVacio3(jugadores[2]);
            //VerificarCampoJugadorNoVacio4(jugadores[3]);
            //VerificarCampoJugadorNoVacio5(jugadores[4]);
            //VerificarCampoJugadorNoVacio6(jugadores[5]);
            //VerificarCampoJugadorNoVacio7(jugadores[6]);
            //VerificarCampoJugadorNoVacio8(jugadores[7]);
            //VerificarCampoJugadorNoVacio9(jugadores[8]);

            #region Verificar Jugadores
            if (jugadores.Count >= 1)
            {
                VerificarCampoJugadorNoVacio1(jugadores[0]);

                if (jugadores.Count >= 2)
                {
                    VerificarCampoJugadorNoVacio2(jugadores[1]);

                    if (jugadores.Count >= 3)
                    {
                        VerificarCampoJugadorNoVacio3(jugadores[2]);

                        if (jugadores.Count >= 4)
                        {
                            VerificarCampoJugadorNoVacio4(jugadores[3]);

                            if (jugadores.Count >= 5)
                            {
                                VerificarCampoJugadorNoVacio5(jugadores[4]);

                                if (jugadores.Count >= 6)
                                {
                                    VerificarCampoJugadorNoVacio6(jugadores[5]);

                                    if (jugadores.Count >= 7)
                                    {
                                        VerificarCampoJugadorNoVacio7(jugadores[6]);

                                        if (jugadores.Count >= 8)
                                        {
                                            VerificarCampoJugadorNoVacio8(jugadores[7]);

                                            if (jugadores.Count >= 9)
                                            {
                                                VerificarCampoJugadorNoVacio9(jugadores[8]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            panelBuscarEquipo.Visible = false;
            panelBuscarEquipo.Left = 694;
            panelGestionarEquipo.Visible = false;
            panelGestionarEquipo.Left = 77;
            panelGestionarEquipo.Visible = true;
            bunifuSeparator1.Left = btnGestionarEquipos.Left;
            bunifuSeparator1.Width = btnGestionarEquipos.Width;
        }
        #endregion

        #region Devolver Imagen del Equipo
        private void DevolverImagenEquipo()
        {
            if (!DBNull.Value.Equals(dgvEquipos.CurrentRow.Cells["imagenEquipo"].Value))
            {
                byte[] imageBuffer = (byte[])dgvEquipos.CurrentRow.Cells["imagenEquipo"].Value;
                // Se crea un MemoryStream a partir de ese buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                // Se utiliza el MemoryStream para extraer la imagen
                this.pictureBox2.Image = Image.FromStream(ms);
            }
        }

        #endregion

        #region Boton Agregar Jugador 1

        #region Click en el Boton Agregar Jugador 1
        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            DataTable Datos = CUsuario.ValidarUsuarioExistente(txtJugador1.Text);

            if (!String.IsNullOrEmpty(txtJugador1.Text) && txtJugador1.Text != "Jugador 1.." && Datos.Rows.Count != 0)
            {
                txtJugador1.Enabled = false;
                btnAgregar1.Visible = false;
                btnRemover1.Visible = true;
                jugadores.Add(txtJugador1.Text);
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe en la Plataforma.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJugador1.Text = "Jugador 1..";
            }
        }

        #endregion

        #region Click en el Boton Remover Jugador 1
        private void btnRemover1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtJugador1.Text) && txtJugador1.Text != "Jugador 1..")
            {
                txtJugador1.Text = "Jugador 1..";
                txtJugador1.Enabled = true;
                btnRemover1.Visible = false;
                btnAgregar1.Visible = true;
                jugadores.RemoveAt(0);
            }
        }
        #endregion

        #endregion

        #region Boton Agregar Jugador 2

        #region Click en el Boton Agregar Jugador 2
        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            DataTable Datos = CUsuario.ValidarUsuarioExistente(txtJugador2.Text);

            if (!String.IsNullOrEmpty(txtJugador2.Text) && txtJugador2.Text != "Jugador 2.." && Datos.Rows.Count != 0)
            {
                txtJugador2.Enabled = false;
                btnAgregar2.Visible = false;
                btnRemover2.Visible = true;
                jugadores.Add(txtJugador2.Text);
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe en la Plataforma.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJugador2.Text = "Jugador 2..";
            }
        }

        #endregion

        #region Click en el Boton Remover Jugador 2
        private void btnRemover2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtJugador2.Text) && txtJugador2.Text != "Jugador 2..")
            {
                txtJugador2.Text = "Jugador 2..";
                txtJugador2.Enabled = true;
                btnRemover2.Visible = false;
                btnAgregar2.Visible = true;
                jugadores.RemoveAt(1);
            }
        }
        #endregion

        #endregion

        #region Boton Agregar Jugador 3

        #region Click en el Boton Agregar Jugador 3
        private void btnAgregar3_Click(object sender, EventArgs e)
        {
            DataTable Datos = CUsuario.ValidarUsuarioExistente(txtJugador3.Text);

            if (!String.IsNullOrEmpty(txtJugador3.Text) && txtJugador3.Text != "Jugador 3.." && Datos.Rows.Count != 0)
            {
                txtJugador3.Enabled = false;
                btnAgregar3.Visible = false;
                btnRemover3.Visible = true;
                jugadores.Add(txtJugador3.Text);
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe en la Plataforma.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJugador3.Text = "Jugador 3..";
            }
        }

        #endregion

        #region Click en el Boton Remover Jugador 3
        private void btnRemover3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtJugador3.Text) && txtJugador3.Text != "Jugador 3..")
            {
                txtJugador3.Text = "Jugador 3..";
                txtJugador3.Enabled = true;
                btnRemover3.Visible = false;
                btnAgregar3.Visible = true;
                jugadores.RemoveAt(2);
            }
        }
        #endregion

        #endregion

        #region Boton Agregar Jugador 4

        #region Click en el Boton Agregar Jugador 4
        private void btnAgregar4_Click(object sender, EventArgs e)
        {
            DataTable Datos = CUsuario.ValidarUsuarioExistente(txtJugador4.Text);

            if (!String.IsNullOrEmpty(txtJugador4.Text) && txtJugador4.Text != "Jugador 4.." && Datos.Rows.Count != 0)
            {
                txtJugador4.Enabled = false;
                btnAgregar4.Visible = false;
                btnRemover4.Visible = true;
                jugadores.Add(txtJugador4.Text);
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe en la Plataforma.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJugador4.Text = "Jugador 4..";
            }
        }
        #endregion

        #region Click en el Boton Remover Jugador 4
        private void btnRemover4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtJugador4.Text) && txtJugador4.Text != "Jugador 4..")
            {
                txtJugador4.Text = "Jugador 4..";
                txtJugador4.Enabled = true;
                btnRemover4.Visible = false;
                btnAgregar4.Visible = true;
                jugadores.RemoveAt(3);
            }
        }
        #endregion

        #endregion

        #region Pantalla Arrastrable
        private void GestionarEquipos_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void GestionarEquipos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void GestionarEquipos_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Boton Agregar Jugador 5

        #region Click en el Boton Agregar Jugador 5
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            DataTable Datos = CUsuario.ValidarUsuarioExistente(txtJugador5.Text);

            if (!String.IsNullOrEmpty(txtJugador5.Text) && txtJugador5.Text != "Jugador 5.." && Datos.Rows.Count != 0)
            {
                txtJugador5.Enabled = false;
                btnAgregar5.Visible = false;
                btnRemover5.Visible = true;
                jugadores.Add(txtJugador5.Text);
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe en la Plataforma.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJugador5.Text = "Jugador 5..";
            }
        }
        #endregion

        #region Click en el Boton Remover Jugador 5
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtJugador5.Text) && txtJugador5.Text != "Jugador 5..")
            {
                txtJugador5.Text = "Jugador 5..";
                txtJugador5.Enabled = true;
                btnRemover5.Visible = false;
                btnAgregar5.Visible = true;
                jugadores.RemoveAt(4);
            }
        }
        #endregion

        #endregion

        #region Boton Agregar Jugador 6

        #region Click en el Boton Agregar Jugador 6
        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            DataTable Datos = CUsuario.ValidarUsuarioExistente(txtJugador6.Text);

            if (!String.IsNullOrEmpty(txtJugador6.Text) && txtJugador6.Text != "Jugador 6.." && Datos.Rows.Count != 0)
            {
                txtJugador6.Enabled = false;
                btnAgregar6.Visible = false;
                btnRemover6.Visible = true;
                jugadores.Add(txtJugador6.Text);
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe en la Plataforma.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJugador6.Text = "Jugador 6..";
            }
        }

        #endregion

        #region Click en el Boton Remover Jugador 6
        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtJugador6.Text) && txtJugador6.Text != "Jugador 6..")
            {
                txtJugador6.Text = "Jugador 6..";
                txtJugador6.Enabled = true;
                btnRemover6.Visible = false;
                btnAgregar6.Visible = true;
                jugadores.RemoveAt(5);
            }
        }
        #endregion

        #endregion

        #region Boton Agregar Jugador 7

        #region Click en el Boton Agregar Jugador 7
        private void btnAgregar7_Click(object sender, EventArgs e)
        {
            DataTable Datos = CUsuario.ValidarUsuarioExistente(txtJugador7.Text);

            if (!String.IsNullOrEmpty(txtJugador7.Text) && txtJugador7.Text != "Jugador 7.." && Datos.Rows.Count != 0)
            {
                txtJugador7.Enabled = false;
                btnAgregar7.Visible = false;
                btnRemover7.Visible = true;
                jugadores.Add(txtJugador7.Text);
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe en la Plataforma.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJugador7.Text = "Jugador 7..";
            }
        }
        #endregion

        #region Click en el Boton Remover Jugador 7
        private void btnRemover7_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtJugador7.Text) && txtJugador7.Text != "Jugador 7..")
            {
                txtJugador7.Text = "Jugador 7..";
                txtJugador7.Enabled = true;
                btnRemover7.Visible = false;
                btnAgregar7.Visible = true;
                jugadores.RemoveAt(6);
            }
        }

        #endregion

        #endregion

        #region Boton Agregar Jugador 8

        #region Click en el Boton Agregar Jugador 8
        private void btnAgregar8_Click(object sender, EventArgs e)
        {
            DataTable Datos = CUsuario.ValidarUsuarioExistente(txtJugador8.Text);

            if (!String.IsNullOrEmpty(txtJugador8.Text) && txtJugador8.Text != "Jugador 8.." && Datos.Rows.Count != 0)
            {
                txtJugador8.Enabled = false;
                btnAgregar8.Visible = false;
                btnRemover8.Visible = true;
                jugadores.Add(txtJugador8.Text);
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe en la Plataforma.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJugador8.Text = "Jugador 8..";
            }
        }
        #endregion

        #region Click en el Boton Remover Jugador 8
        private void btnRemover8_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtJugador8.Text) && txtJugador8.Text != "Jugador 8..")
            {
                txtJugador8.Text = "Jugador 8..";
                txtJugador8.Enabled = true;
                btnRemover8.Visible = false;
                btnAgregar8.Visible = true;
                jugadores.RemoveAt(7);
            }
        }
        #endregion

        #endregion

        #region Boton Agregar Jugador 9

        #region Click en el Boton Agregar Jugador 9
        private void btnAgregar9_Click(object sender, EventArgs e)
        {
            DataTable Datos = CUsuario.ValidarUsuarioExistente(txtJugador9.Text);

            if (!String.IsNullOrEmpty(txtJugador9.Text) && txtJugador9.Text != "Jugador 9.." && Datos.Rows.Count != 0)
            {
                txtJugador9.Enabled = false;
                btnAgregar9.Visible = false;
                btnRemover9.Visible = true;
                jugadores.Add(txtJugador9.Text);
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe en la Plataforma.", "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJugador9.Text = "Jugador 9..";
            }
        }

        #endregion

        #region Click en el Boton Remover Jugador 9
        private void btnRemover9_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtJugador9.Text) && txtJugador9.Text != "Jugador 9..")
            {
                txtJugador9.Text = "Jugador 9..";
                txtJugador9.Enabled = true;
                btnRemover9.Visible = false;
                btnAgregar9.Visible = true;
                jugadores.RemoveAt(8);
            }
        }
        #endregion

        #endregion

    }
}