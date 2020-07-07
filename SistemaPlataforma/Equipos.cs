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
using System.Data.SqlClient;

namespace SistemaPlataforma
{
    public partial class Equipos : Form
    {

        #region Almacenar Credenciales del Equipo
        public static string idEquipoSeleccionado = "";
        public static string capitanEquipoSeleccionado = "";
        public static string jugadoresEquipoSeleccionado = "";
        public static string nombreEquipoSeleccionado = "";
        public static string descripcionEquipoSeleccionado = "";
        public static byte[] imagenEquipoSeleccionado;
        public static string cantidadEquiposCreadosPorElUsuario = "";
        #endregion

        #region Credenciales de los Equipos del Usuario
        public List<string> equiposUsuario = new List<string>();
        public List<byte[]> equiposImagenUsuario = new List<byte[]>();
        public static string equiposCapitanUsuario = Login.nicknameUsuario;
        public List<string> equiposDescripcionUsuario = new List<string>();
        public List<string> equiposJugadoresUsuario = new List<string>();
        #endregion

        #region Inicializar Componentes
        public Equipos()
        {
            InitializeComponent();

            this.dgvEquipos.RowTemplate.Height = 50;

            this.dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvEquipos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvEquipos.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            panelVerMisEquipos.Location = new Point(503,59);

            #region Configuracion Componentes y Cargas de Datos
            bunifuSeparator2.Visible = false;

            #region Cargar la grilla de Equipos existentes en el Sistema
            ListarEquipos();
            #endregion

            #endregion

            #region Validar Cantidad de Equipos Creados por el Usuario
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando = new SqlCommand("Select count(*) as cantidadEquipos from Equipos where capitan LIKE '%" + Login.nicknameUsuario + "%'", SqlCon);
                SqlCon.Open();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    cantidadEquiposCreadosPorElUsuario = registro["cantidadEquipos"].ToString();
                }
                SqlCon.Close();

                if (cantidadEquiposCreadosPorElUsuario == "6")
                {
                    btnCrearEquipo.Visible = false;
                }
                if (cantidadEquiposCreadosPorElUsuario == "1" || cantidadEquiposCreadosPorElUsuario == "2" || cantidadEquiposCreadosPorElUsuario == "3" || cantidadEquiposCreadosPorElUsuario == "4" || cantidadEquiposCreadosPorElUsuario == "5" || cantidadEquiposCreadosPorElUsuario == "6")
                {
                    btnVerMisEquipos.Visible = true;

                    #region Cargar Equipos Existentes del Usuario como Capitan

                    SqlConnection SqlConn = new SqlConnection();

                    try
                    {
                        //Establecemos la conexion, el comando y ejecutamos el mismo
                        SqlConn.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                        SqlCommand comando1 = new SqlCommand("Select * from equipos where capitan LIKE '%" + Login.nicknameUsuario + "%'", SqlConn);
                        SqlConn.Open();
                        SqlDataReader registro1 = comando1.ExecuteReader();
                        while (registro1.Read())
                        {
                            equiposUsuario.Add(registro1["nombre"].ToString());
                            equiposImagenUsuario.Add((byte[])registro1["imagenEquipo"]);
                            equiposDescripcionUsuario.Add(registro1["descripcion"].ToString());
                            equiposJugadoresUsuario.Add(registro1["jugadores"].ToString());
                        }
                        SqlConn.Close();
                    }
                    finally
                    {
                        if (SqlConn.State == ConnectionState.Open)
                        {
                            SqlConn.Close();
                        }
                    }
                    #endregion

                    EquiposDelUsuario();
                }
                if (cantidadEquiposCreadosPorElUsuario == "0")
                {
                    btnVerMisEquipos.Visible = false;
                }
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            #endregion

        }
        #endregion

        #region Desplazar al Panel de Buscar Equipos
        private void btnBuscarEquipo_Click(object sender, EventArgs e)
        {
            if (panelBuscarEquipo.Left == 856) //702
            {

                panelCrearEquipo.Visible = false;
                panelCrearEquipo.Left = 856; //702
                panelVerMisEquipos.Visible = false;
                panelVerMisEquipos.Left = 856; //702


                panelBuscarEquipo.Visible = false;
                panelBuscarEquipo.Left = 15;
                panelBuscarEquipo.Visible = true;

                bunifuSeparator1.Visible = true;
                bunifuSeparator2.Visible = false;
                bunifuSeparator1.Left = btnBuscarEquipo.Left;
                bunifuSeparator1.Width = btnBuscarEquipo.Width;
            }
        }
        #endregion

        #region Desplazar al Panel de Crear Equipos
        private void btnCrearEquipo_Click(object sender, EventArgs e)
        {
            if (panelCrearEquipo.Left == 856) //702
            {
                panelBuscarEquipo.Visible = false;
                panelBuscarEquipo.Left = 856; //702
                panelVerMisEquipos.Visible = false;
                panelVerMisEquipos.Left = 856; //702


                panelCrearEquipo.Visible = false;
                panelCrearEquipo.Left = 30;
                panelCrearEquipo.Visible = true;

                bunifuSeparator2.Visible = false;
                bunifuSeparator1.Visible = true;

                bunifuSeparator1.Left = btnCrearEquipo.Left;
                bunifuSeparator1.Width = btnCrearEquipo.Width;
            }
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

        #region Desplazar al Panel de Mis Equipos
        private void btnVerMisEquipos_Click(object sender, EventArgs e)
        {
            if (panelVerMisEquipos.Left == 1700 || panelVerMisEquipos.Left == 856) //1275 || 702
            {
                panelCrearEquipo.Visible = false;
                panelCrearEquipo.Left = 856; //702
                panelBuscarEquipo.Visible = false;
                panelBuscarEquipo.Left = 856; //702


                panelVerMisEquipos.Visible = false;
                panelVerMisEquipos.Left = 30;
                panelVerMisEquipos.Visible = true;

                bunifuSeparator1.Visible = false;
                bunifuSeparator2.Visible = true;
                bunifuSeparator2.Width = btnVerMisEquipos.Width;
            }
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
        private void Equipos_Load(object sender, EventArgs e)
        {

            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion

            this.panelCrearEquipo.Visible = false;
            this.panelVerMisEquipos.Visible = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Equipos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Boton Buscar
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            BuscarEquipoPorNombre();
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

        #region Listar Equipos
        private void ListarEquipos()
        {
            this.dgvEquipos.DataSource = CEquipo.Mostrar();
            this.dgvEquipos.Columns["idEquipo"].Visible = false;
            this.dgvEquipos.Columns["descripcion"].Visible = false;
            this.dgvEquipos.RowTemplate.Height = 50;
            this.dgvEquipos.RowHeadersVisible = false;
        }
        #endregion

        #region Limpiar Campo Buscar Equipo
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

        #region Seleccionar Equipo desde la Grilla de Equipos en el Panel de Buscar Equipos
        private void dgvEquipos_DoubleClick(object sender, EventArgs e)
        {

            #region Carga el ID del Equipo
            idEquipoSeleccionado = Convert.ToString(this.dgvEquipos.CurrentRow.Cells["idEquipo"].Value);
            #endregion

            #region Carga el Capitan del Equipo
            capitanEquipoSeleccionado = Convert.ToString(this.dgvEquipos.CurrentRow.Cells["colCapitan"].Value);
            #endregion

            #region Carga los Jugadores del Equipo
            jugadoresEquipoSeleccionado = Convert.ToString(this.dgvEquipos.CurrentRow.Cells["colJugadores"].Value);
            #endregion

            #region Carga el Nombre del Equipo
            nombreEquipoSeleccionado = Convert.ToString(this.dgvEquipos.CurrentRow.Cells["colNombre"].Value);
            #endregion

            #region Carga la Descripción del Equipo
            descripcionEquipoSeleccionado = Convert.ToString(this.dgvEquipos.CurrentRow.Cells["descripcion"].Value);
            #endregion

            #region Carga la Imagen del Equipo
            imagenEquipoSeleccionado = (byte[])dgvEquipos.CurrentRow.Cells["colIcono"].Value;
            #endregion

            #region Dirigir al Perfil del Equipo
            Perfil_Equipo frmPerfilEquipo = new Perfil_Equipo();
            frmPerfilEquipo.Show();
            this.Hide();
            #endregion

        }
        #endregion

        #region Limpiar Campo Nombre del Equipo
        private void bunifuMetroTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "Nombre del Equipo..")
            {
                bunifuMetroTextbox1.Text = "";
            }
        }

        private void bunifuMetroTextbox1_Leave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "")
            {
                bunifuMetroTextbox1.Text = "Nombre del Equipo..";
            }
        }

        #endregion

        #region Limpiar Campo Descripcion del Equipo
        private void bunifuMetroTextbox2_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "Descripción..")
            {
                bunifuMetroTextbox2.Text = "";
            }
        }

        private void bunifuMetroTextbox2_Leave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "")
            {
                bunifuMetroTextbox2.Text = "Descripción..";
            }
        }

        #endregion

        #region Boton Subir Imagen Equipo
        private void bunifuThinButton22_Click(object sender, EventArgs e)
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

        #region Boton Crear El Equipo!
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] imagen = ms.GetBuffer();
                rpta = CEquipo.Insertar(this.bunifuMetroTextbox1.Text.Trim(), this.bunifuMetroTextbox2.Text.Trim(), Convert.ToString(Login.nicknameUsuario), "", imagen);

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El equipo se ha creado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelCrearEquipo.Visible = false;
                    panelCrearEquipo.Left = 702;
                    panelBuscarEquipo.Visible = false;
                    panelBuscarEquipo.Left = 15;
                    panelBuscarEquipo.Visible = true;
                    bunifuSeparator1.Left = btnBuscarEquipo.Left;
                    bunifuSeparator1.Width = btnBuscarEquipo.Width;
                }

                this.ListarEquipos();
            }
            catch (Exception)
            {
                MensajeDeError msjError = new MensajeDeError();
                msjError.bunifuCustomLabel3.Text = "No se ha podido crear el equipo exitosamente!";
                msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                msjError.Show();
                //MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion
        
        #region Cargar Equipos del Usuario en PANEL VER MIS EQUIPOS
        private void EquiposDelUsuario()
        {
            #region Cant.Equipos "1"
            if (cantidadEquiposCreadosPorElUsuario == "1")
            {
                panel1.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;

                #region Cargar Nombre del Equipo
                this.label2.Text = equiposUsuario[0].ToString();
                #endregion

                #region Cargar Imagen del Equipo 1
                if (!DBNull.Value.Equals(equiposImagenUsuario[0]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[0];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox3.Image = Image.FromStream(ms);
                }
                #endregion
            }
            #endregion

            #region Cant.Equipos "2"
            if (cantidadEquiposCreadosPorElUsuario == "2")
            {
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;

                #region Cargar Nombre del Equipo
                this.label1.Text = equiposUsuario[0].ToString();
                this.label2.Text = equiposUsuario[1].ToString();
                #endregion

                #region Cargar Imagen del Equipo 1
                if (!DBNull.Value.Equals(equiposImagenUsuario[0]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[0];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox1.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 2
                if (!DBNull.Value.Equals(equiposImagenUsuario[1]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[1];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox3.Image = Image.FromStream(ms);
                }
                #endregion
            }
            #endregion

            #region Cant.Equipos "3"
            if (cantidadEquiposCreadosPorElUsuario == "3")
            {
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;

                #region Cargar Nombre del Equipo
                this.label1.Text = equiposUsuario[0].ToString();
                this.label2.Text = equiposUsuario[1].ToString();
                this.label3.Text = equiposUsuario[2].ToString();
                #endregion

                #region Cargar Imagen del Equipo 1
                if (!DBNull.Value.Equals(equiposImagenUsuario[0]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[0];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox1.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 2
                if (!DBNull.Value.Equals(equiposImagenUsuario[1]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[1];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox3.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 3
                if (!DBNull.Value.Equals(equiposImagenUsuario[2]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[2];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox4.Image = Image.FromStream(ms);
                }
                #endregion

            }
            #endregion

            #region Cant.Equipos "4"
            if (cantidadEquiposCreadosPorElUsuario == "4")
            {
                panel5.Visible = false;
                panel6.Visible = false;

                #region Cargar Nombre del Equipo
                this.label1.Text = equiposUsuario[0].ToString();
                this.label2.Text = equiposUsuario[1].ToString();
                this.label3.Text = equiposUsuario[2].ToString();
                this.label4.Text = equiposUsuario[3].ToString();
                #endregion

                #region Cargar Imagen del Equipo 1
                if (!DBNull.Value.Equals(equiposImagenUsuario[0]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[0];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox1.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 2
                if (!DBNull.Value.Equals(equiposImagenUsuario[1]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[1];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox3.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 3
                if (!DBNull.Value.Equals(equiposImagenUsuario[2]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[2];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox4.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 4
                if (!DBNull.Value.Equals(equiposImagenUsuario[3]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[3];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox5.Image = Image.FromStream(ms);
                }
                #endregion

            }
            #endregion

            #region Cant.Equipos "5"
            if (cantidadEquiposCreadosPorElUsuario == "5")
            {
                panel6.Visible = false;

                #region Cargar Nombre del Equipo
                this.label1.Text = equiposUsuario[0].ToString();
                this.label2.Text = equiposUsuario[1].ToString();
                this.label3.Text = equiposUsuario[2].ToString();
                this.label4.Text = equiposUsuario[3].ToString();
                this.label5.Text = equiposUsuario[4].ToString();
                #endregion

                #region Cargar Imagen del Equipo 1
                if (!DBNull.Value.Equals(equiposImagenUsuario[0]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[0];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox1.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 2
                if (!DBNull.Value.Equals(equiposImagenUsuario[1]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[1];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox3.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 3
                if (!DBNull.Value.Equals(equiposImagenUsuario[2]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[2];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox4.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 4
                if (!DBNull.Value.Equals(equiposImagenUsuario[3]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[3];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox5.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 5
                if (!DBNull.Value.Equals(equiposImagenUsuario[4]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[4];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox6.Image = Image.FromStream(ms);
                }
                #endregion

            }
            #endregion

            #region Cant.Equipos "6"
            if (cantidadEquiposCreadosPorElUsuario == "6")
            {

                #region Cargar Nombre del Equipo
                this.label1.Text = equiposUsuario[0].ToString();
                this.label2.Text = equiposUsuario[1].ToString();
                this.label3.Text = equiposUsuario[2].ToString();
                this.label4.Text = equiposUsuario[3].ToString();
                this.label5.Text = equiposUsuario[4].ToString();
                this.label6.Text = equiposUsuario[5].ToString();
                #endregion

                #region Cargar Imagen del Equipo 1
                if (!DBNull.Value.Equals(equiposImagenUsuario[0]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[0];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox1.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 2
                if (!DBNull.Value.Equals(equiposImagenUsuario[1]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[1];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox3.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 3
                if (!DBNull.Value.Equals(equiposImagenUsuario[2]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[2];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox4.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 4
                if (!DBNull.Value.Equals(equiposImagenUsuario[3]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[3];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox5.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 5
                if (!DBNull.Value.Equals(equiposImagenUsuario[4]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[4];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox6.Image = Image.FromStream(ms);
                }
                #endregion

                #region Cargar Imagen del Equipo 6
                if (!DBNull.Value.Equals(equiposImagenUsuario[5]))
                {
                    byte[] imageBuffer = (byte[])equiposImagenUsuario[5];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    pictureBox7.Image = Image.FromStream(ms);
                }
                #endregion

            }
            #endregion

        }
        #endregion

        #region Boton Equipo 1 PANEL VER MIS EQUIPOS
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            capitanEquipoSeleccionado = equiposCapitanUsuario;
            jugadoresEquipoSeleccionado = equiposJugadoresUsuario[0];
            nombreEquipoSeleccionado = equiposUsuario[0];
            descripcionEquipoSeleccionado = equiposDescripcionUsuario[0];
            imagenEquipoSeleccionado = equiposImagenUsuario[0];

            #region DIRIGIR AL PERFIL DEL EQUIPO
            Perfil_Equipo frmPerfilEquipo = new Perfil_Equipo();
            frmPerfilEquipo.Show();
            this.Hide();
            #endregion

        }
        #endregion

        #region Boton Equipo 2 PANEL VER MIS EQUIPOS
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (cantidadEquiposCreadosPorElUsuario == "1")
            {
                capitanEquipoSeleccionado = equiposCapitanUsuario;
                jugadoresEquipoSeleccionado = equiposJugadoresUsuario[0];
                nombreEquipoSeleccionado = equiposUsuario[0];
                descripcionEquipoSeleccionado = equiposDescripcionUsuario[0];
                imagenEquipoSeleccionado = equiposImagenUsuario[0];
            }
            else
            {
                capitanEquipoSeleccionado = equiposCapitanUsuario;
                jugadoresEquipoSeleccionado = equiposJugadoresUsuario[1];
                nombreEquipoSeleccionado = equiposUsuario[1];
                descripcionEquipoSeleccionado = equiposDescripcionUsuario[1];
                imagenEquipoSeleccionado = equiposImagenUsuario[1];
            }

            #region DIRIGIR AL PERFIL DEL EQUIPO
            Perfil_Equipo frmPerfilEquipo = new Perfil_Equipo();
            frmPerfilEquipo.Show();
            this.Hide();
            #endregion

        }
        #endregion

        #region Boton Equipo 3 PANEL VER MIS EQUIPOS
        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            capitanEquipoSeleccionado = equiposCapitanUsuario;
            jugadoresEquipoSeleccionado = equiposJugadoresUsuario[2];
            nombreEquipoSeleccionado = equiposUsuario[2];
            descripcionEquipoSeleccionado = equiposDescripcionUsuario[2];
            imagenEquipoSeleccionado = equiposImagenUsuario[2];

            #region DIRIGIR AL PERFIL DEL EQUIPO
            Perfil_Equipo frmPerfilEquipo = new Perfil_Equipo();
            frmPerfilEquipo.Show();
            this.Hide();
            #endregion
        }
        #endregion

        #region Boton Equipo 4 PANEL VER MIS EQUIPOS
        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            capitanEquipoSeleccionado = equiposCapitanUsuario;
            jugadoresEquipoSeleccionado = equiposJugadoresUsuario[3];
            nombreEquipoSeleccionado = equiposUsuario[3];
            descripcionEquipoSeleccionado = equiposDescripcionUsuario[3];
            imagenEquipoSeleccionado = equiposImagenUsuario[3];

            #region DIRIGIR AL PERFIL DEL EQUIPO
            Perfil_Equipo frmPerfilEquipo = new Perfil_Equipo();
            frmPerfilEquipo.Show();
            this.Hide();
            #endregion
        }
        #endregion

        #region Boton Equipo 5 PANEL VER MIS EQUIPOS
        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            capitanEquipoSeleccionado = equiposCapitanUsuario;
            jugadoresEquipoSeleccionado = equiposJugadoresUsuario[4];
            nombreEquipoSeleccionado = equiposUsuario[4];
            descripcionEquipoSeleccionado = equiposDescripcionUsuario[4];
            imagenEquipoSeleccionado = equiposImagenUsuario[4];

            #region DIRIGIR AL PERFIL DEL EQUIPO
            Perfil_Equipo frmPerfilEquipo = new Perfil_Equipo();
            frmPerfilEquipo.Show();
            this.Hide();
            #endregion

        }
        #endregion

        #region Boton Equipo 6 PANEL VER MIS EQUIPOS
        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            capitanEquipoSeleccionado = equiposCapitanUsuario;
            jugadoresEquipoSeleccionado = equiposJugadoresUsuario[5];
            nombreEquipoSeleccionado = equiposUsuario[5];
            descripcionEquipoSeleccionado = equiposDescripcionUsuario[5];
            imagenEquipoSeleccionado = equiposImagenUsuario[5];

            #region DIRIGIR AL PERFIL DEL EQUIPO
            Perfil_Equipo frmPerfilEquipo = new Perfil_Equipo();
            frmPerfilEquipo.Show();
            this.Hide();
            #endregion

        }
        #endregion

    }
}
