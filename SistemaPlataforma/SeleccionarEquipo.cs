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
using System.Data.SqlClient;
using Controladora;

namespace SistemaPlataforma
{
    public partial class SeleccionarEquipo : Form
    {

        #region Definir Variables
        public List<string> equiposIDUsuario = new List<string>();
        public List<string> equiposUsuario = new List<string>();
        public List<byte[]> equiposImagenUsuario = new List<byte[]>();
        public static string cantidadEquiposCreadosPorElUsuario = "";
        public static string IDequipoSeleccionado = "";
        public static string NOMBREequipoSeleccionado = "";
        #endregion

        #region Inicializar Componentes
        public SeleccionarEquipo()
        {
            InitializeComponent();

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

                if (cantidadEquiposCreadosPorElUsuario == "1" || cantidadEquiposCreadosPorElUsuario == "2" || cantidadEquiposCreadosPorElUsuario == "3" || cantidadEquiposCreadosPorElUsuario == "4" || cantidadEquiposCreadosPorElUsuario == "5" || cantidadEquiposCreadosPorElUsuario == "6")
                {

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
                            equiposIDUsuario.Add(registro1["idEquipo"].ToString());
                            equiposUsuario.Add(registro1["nombre"].ToString());
                            equiposImagenUsuario.Add((byte[])registro1["imagenEquipo"]);
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

        #region Pantalla Arrastrable
        private void SeleccionarEquipo_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void SeleccionarEquipo_MouseDown(object sender, MouseEventArgs e)
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

        #region Boton Minimizar Formulario
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Boton Volver
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        #region Cargar Equipos del Usuario
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

        #region Boton Seleccionar Equipo 1
        private void btnSeleccionar1_Click(object sender, EventArgs e)
        {
            IDequipoSeleccionado = equiposIDUsuario[0];
            NOMBREequipoSeleccionado = equiposUsuario[0];

            string rpta = "";

            if (Torneos.isTorneo == "YES")
            {
                Torneos frmTorneos = new Torneos();

                rpta = CInscripcion.Insertar(Int32.Parse(TorneosDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmTorneos.Show();

                this.Hide();
            }
            else
            {
                Ligas frmLigas = new Ligas();

                rpta = CInscripcion.Insertar(Int32.Parse(LigasDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmLigas.Show();

                this.Hide();
            }
            
        }
        #endregion

        #region Boton Seleccionar Equipo 2
        private void btnSeleccionar2_Click(object sender, EventArgs e)
        {
            if (equiposUsuario.Count == 1)
            {
                IDequipoSeleccionado = equiposIDUsuario[0];
                NOMBREequipoSeleccionado = equiposUsuario[0];
            }
            if (equiposUsuario.Count == 2)
            {
                IDequipoSeleccionado = equiposIDUsuario[1];
                NOMBREequipoSeleccionado = equiposUsuario[1];
            }
            
            string rpta = "";

            if (Torneos.isTorneo == "YES")
            {
                Torneos frmTorneos = new Torneos();

                rpta = CInscripcion.Insertar(Int32.Parse(TorneosDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmTorneos.Show();

                this.Hide();
            }
            else
            {
                Ligas frmLigas = new Ligas();

                rpta = CInscripcion.Insertar(Int32.Parse(LigasDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmLigas.Show();

                this.Hide();
            }
        }

        #endregion

        #region Boton Seleccionar Equipo 3
        private void btnSeleccionar3_Click(object sender, EventArgs e)
        {
            IDequipoSeleccionado = equiposIDUsuario[2];
            NOMBREequipoSeleccionado = equiposUsuario[2];

            string rpta = "";

            if (Torneos.isTorneo == "YES")
            {
                Torneos frmTorneos = new Torneos();

                rpta = CInscripcion.Insertar(Int32.Parse(TorneosDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmTorneos.Show();

                this.Hide();
            }
            else
            {
                Ligas frmLigas = new Ligas();

                rpta = CInscripcion.Insertar(Int32.Parse(LigasDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmLigas.Show();

                this.Hide();
            }
        }
        #endregion

        #region Boton Seleccionar Equipo 4
        private void btnSeleccionar4_Click(object sender, EventArgs e)
        {
            IDequipoSeleccionado = equiposIDUsuario[3];
            NOMBREequipoSeleccionado = equiposUsuario[3];

            string rpta = "";

            if (Torneos.isTorneo == "YES")
            {
                Torneos frmTorneos = new Torneos();

                rpta = CInscripcion.Insertar(Int32.Parse(TorneosDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmTorneos.Show();

                this.Hide();
            }
            else
            {
                Ligas frmLigas = new Ligas();

                rpta = CInscripcion.Insertar(Int32.Parse(LigasDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmLigas.Show();

                this.Hide();
            }
        }
        #endregion

        #region Boton Seleccionar Equipo 5
        private void btnSeleccionar5_Click(object sender, EventArgs e)
        {
            IDequipoSeleccionado = equiposIDUsuario[4];
            NOMBREequipoSeleccionado = equiposUsuario[4];

            string rpta = "";

            if (Torneos.isTorneo == "YES")
            {
                Torneos frmTorneos = new Torneos();

                rpta = CInscripcion.Insertar(Int32.Parse(TorneosDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmTorneos.Show();

                this.Hide();
            }
            else
            {
                Ligas frmLigas = new Ligas();

                rpta = CInscripcion.Insertar(Int32.Parse(LigasDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmLigas.Show();

                this.Hide();
            }
        }
        #endregion

        #region Boton Seleccionar Equipo 6
        private void btnSeleccionar6_Click(object sender, EventArgs e)
        {
            IDequipoSeleccionado = equiposIDUsuario[5];
            NOMBREequipoSeleccionado = equiposUsuario[5];

            string rpta = "";

            if (Torneos.isTorneo == "YES")
            {
                Torneos frmTorneos = new Torneos();

                rpta = CInscripcion.Insertar(Int32.Parse(TorneosDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmTorneos.Show();

                this.Hide();
            }
            else
            {
                Ligas frmLigas = new Ligas();

                rpta = CInscripcion.Insertar(Int32.Parse(LigasDisponibles.idCompetenciaSeleccionada), Int32.Parse(SeleccionarEquipo.IDequipoSeleccionado));

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "Se ha inscripto a la competencia exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido inscribir a la competencia correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                frmLigas.Show();

                this.Hide();
            }
        }
        #endregion

    }
}
