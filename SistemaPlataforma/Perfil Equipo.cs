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
    public partial class Perfil_Equipo : Form
    {

        #region Definir Variables
        List<string> jugadoresPendientesIDS = new List<string>();
        List<string> jugadoresPendientesNOMBRES = new List<string>();
        List<byte[]> jugadoresPendientesIMAGENES = new List<byte[]>();
        List<string> jugadores = new List<string>();
        List<byte[]> jugadoresImagenes = new List<byte[]>();
        string estadoJugadorSeleccionado = "";
        string nombreJugadorSeleccionado = "";
        #endregion

        #region Inicializar Componentes
        public Perfil_Equipo()
        {
          
            InitializeComponent();

            this.btnUnirseAlEquipo.Visible = false;

            this.btnRemoverJugador.Visible = true;

            this.btnAceptar.Visible = false;

            this.btnRechazar.Visible = false;

            this.btnEliminarEquipo.Visible = false;

            #region Configuracion dgvSolicitudes
            this.dgvSolicitudes.RowTemplate.Height = 50;
            #endregion

            #region Validar si el jugador tiene una solicitud pendiente
            SqlConnection SqlCon14 = new SqlConnection();
            var idUsuario = "";
            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon14.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando14 = new SqlCommand("Select * from SolicitudesEquipos_Usuarios where idEquipo = " + Equipos.idEquipoSeleccionado + " and idUsuario = '" + Login.idUsuario + "'", SqlCon14);
                SqlCon14.Open();
                SqlDataReader registro4 = comando14.ExecuteReader();
                if (registro4.HasRows == false) //Si está NO ESTÁ inscripto el Equipo entra acá
                {
                    this.btnUnirseAlEquipo.Visible = true;
                }
                else //Si el equipo ESTÁ inscripto entra acá
                {

                    while (registro4.Read())
                    {
                        idUsuario = registro4["idUsuario"].ToString();
                    }

                    this.btnUnirseAlEquipo.Visible = false;
                }
                SqlCon14.Close();
            }
            finally
            {
                if (SqlCon14.State == ConnectionState.Open)
                {
                    SqlCon14.Close();
                }
            }
            #endregion

            #region Hacer invisible BtnUnirseAlEquipo si es un jugador del equipo
            if (Login.nicknameUsuario == Equipos.capitanEquipoSeleccionado)
            {
                this.btnUnirseAlEquipo.Visible = false;
            }

            List<string> jugadores = new List<string>();
            string jugadoresDB = Equipos.jugadoresEquipoSeleccionado;
            jugadores = jugadoresDB.Split(',').ToList();

            for (var i = 0; i < jugadores.Count; i++)
            {
                if (Login.nicknameUsuario == jugadores[i])
                {
                    this.btnUnirseAlEquipo.Visible = false;
                }
            }
            #endregion

            #region Validar que el Usuario corresponda al del Perfil para poder Editar
            if (Login.nicknameUsuario == Equipos.capitanEquipoSeleccionado)
            {
                #region Habilitar Boton Editar Perfil
                btnEditarPerfil.Visible = true;
                btnGestionarJugadores.Visible = true;
                #endregion

                #region Habilitar Boton Eliminar Equipo
                this.btnEliminarEquipo.Visible = true;
                #endregion

                #region Reposicionar Boton Perfil del Equipo
                this.btnPerfilEquipo.Location = new Point(233, 11); //68,24 || 302,14 || 213,11
                this.bunifuSeparator1.Location = new Point(233, 68); //68,82 || 302,14 || 213,11
                #endregion

            }
            else
            {
                #region Deshabilitar Boton Editar Perfil
                btnEditarPerfil.Visible = false;
                btnGestionarJugadores.Visible = false;
                #endregion

                #region Deshabilitar Boton Eliminar Equipo
                this.btnEliminarEquipo.Visible = false;
                #endregion

                #region Reposicionar Boton Perfil del Equipo
                this.btnPerfilEquipo.Location = new Point(360, 11); //131,24 || 360,14
                this.bunifuSeparator1.Location = new Point(360, 68); //131,82 || 360,72
                #endregion

            }
            #endregion

            #region Cargar Datos al Perfil del Equipo

            #region Carga el Nombre del Equipo
            this.bunifuCustomLabel1.Text = Equipos.nombreEquipoSeleccionado;
            this.bunifuMetroTextbox3.Text = Equipos.nombreEquipoSeleccionado;
            #endregion

            #region Carga la Descripción del Equipo
            this.bunifuCustomLabel2.Text = Equipos.descripcionEquipoSeleccionado;
            this.bunifuMetroTextbox1.Text = Equipos.descripcionEquipoSeleccionado;
            #endregion

            #region Carga la Imagen del Equipo
            DevolverImagenEquipo();
            #endregion

            #region Carga el Capitan del Equipo
            this.bunifuCustomLabel4.Text = Equipos.capitanEquipoSeleccionado + " [CAPITAN]";
            #endregion

            #region Carga Jugadores del Equipo
            //string jugadoresDB = Equipos.jugadoresEquipoSeleccionado;
            //List<string> jugadores = new List<string>();
            jugadores = jugadoresDB.Split(',').ToList();
            //string[] jugadores = new string[4];
            //jugadores = jugadoresDB.Split(',');

            #region Setear Labels Jugadores Invisibles
            this.bunifuCustomLabel7.Visible = false;
            this.bunifuCustomLabel8.Visible = false;
            this.bunifuCustomLabel9.Visible = false;
            this.bunifuCustomLabel10.Visible = false;
            this.bunifuCustomLabel15.Visible = false;
            this.bunifuCustomLabel14.Visible = false;
            this.bunifuCustomLabel13.Visible = false;
            this.bunifuCustomLabel12.Visible = false;
            this.bunifuCustomLabel11.Visible = false;
            #endregion

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

            #endregion

            #endregion

            #region Configuracion Inicial Componentes
            this.bunifuSeparator2.Visible = false;
            #endregion
            
        }
        #endregion

        #region Desplazar al Panel de Perfil Equipo
        private void btnPerfilEquipo_Click(object sender, EventArgs e)
        {
            if (panelPerfilEquipo.Left == 856) //411
            {
                //panelEditarPerfilEquipo.Visible = false;
                //panelEditarPerfilEquipo.Left = 856; //411

                //panelPerfilEquipo.Visible = false;
                //panelSolicitudes.Visible = false;
                //panelPerfilEquipo.Left = 20;
                //panelPerfilEquipo.Visible = true;


                //bunifuSeparator1.Left = btnPerfilEquipo.Left;
                //bunifuSeparator1.Width = btnPerfilEquipo.Width;

                panelEditarPerfilEquipo.Visible = false;
                panelEditarPerfilEquipo.Left = 856; //702
                panelSolicitudes.Visible = false;
                panelSolicitudes.Left = 856; //702


                panelPerfilEquipo.Visible = false;
                panelPerfilEquipo.Left = 20;
                panelPerfilEquipo.Visible = true;

                bunifuSeparator1.Visible = true;
                bunifuSeparator2.Visible = false;
                bunifuSeparator1.Left = btnPerfilEquipo.Left;
                bunifuSeparator1.Width = btnPerfilEquipo.Width;


                this.dgvSolicitudes.DataSource = null;

            }
        }
        #endregion

        #region Desplazar al Panel de Editar Perfil Equipo
        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            if (panelEditarPerfilEquipo.Left == 856) //411
            {
                //panelPerfilEquipo.Visible = false;
                //panelPerfilEquipo.Left = 856; //411

                //panelEditarPerfilEquipo.Visible = false;
                //panelSolicitudes.Visible = false;
                //panelEditarPerfilEquipo.Left = 5;
                //panelEditarPerfilEquipo.Visible = true;

                //bunifuSeparator1.Left = btnEditarPerfil.Left;
                //bunifuSeparator1.Width = btnEditarPerfil.Width;

                panelPerfilEquipo.Visible = false;
                panelPerfilEquipo.Left = 856; //702
                panelSolicitudes.Visible = false;
                panelSolicitudes.Left = 856; //702


                panelEditarPerfilEquipo.Visible = false;
                panelEditarPerfilEquipo.Left = 5;
                panelEditarPerfilEquipo.Visible = true;

                bunifuSeparator2.Visible = false;
                bunifuSeparator1.Visible = true;

                bunifuSeparator1.Left = btnEditarPerfil.Left;
                bunifuSeparator1.Width = btnEditarPerfil.Width;

                this.dgvSolicitudes.DataSource = null;
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

        #region Pantalla Arrastrable
        private void Perfil_Equipo_Load(object sender, EventArgs e)
        {

            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion

            #region Listar dgvSolicitudes

            #region Cargar Gestionar Jugadores
            //List<string> jugadoresPendientesIDS = new List<string>();
            //List<string> jugadoresPendientesNOMBRES = new List<string>();
            SqlConnection SqlConn = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlConn.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando1 = new SqlCommand("Select Usuarios.imagenPerfil, Usuarios.idUsuario as 'idUsuario', nickname from SolicitudesEquipos_Usuarios inner join Usuarios on SolicitudesEquipos_Usuarios.idUsuario = Usuarios.idUsuario where idEquipo = '" + Equipos.idEquipoSeleccionado + "'", SqlConn);
                SqlConn.Open();
                SqlDataReader registro1 = comando1.ExecuteReader();
                while (registro1.Read())
                {
                    jugadoresPendientesIDS.Add(registro1["idUsuario"].ToString());
                    jugadoresPendientesNOMBRES.Add(registro1["nickname"].ToString());
                    jugadoresPendientesIMAGENES.Add((byte[])registro1["imagenPerfil"]);
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

            string jugadoresDB = Equipos.jugadoresEquipoSeleccionado;
            jugadores = jugadoresDB.Split(',').ToList();

            #region Cargar Imagenes Jugadores Activos
            SqlConnection SqlConn25 = new SqlConnection();

            try
            {
                
                    
                
                for (var i = 0; i < jugadores.Count; i++)
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlConn25.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";

                    SqlConn25.Open();
                        SqlCommand comando25 = new SqlCommand("Select Usuarios.imagenPerfil from Usuarios where nickname LIKE '" + jugadores[i].Trim() + "'", SqlConn25);
                        
                        SqlDataReader registro25 = comando25.ExecuteReader();
                        while (registro25.Read())
                        {
                            jugadoresImagenes.Add((byte[])registro25["imagenPerfil"]);
                        }
                        SqlConn25.Close();
                }
                
            }
            finally
            {
                if (SqlConn25.State == ConnectionState.Open)
                {
                    SqlConn25.Close();
                }
            }
            #endregion

            if (jugadores.Count >= 1)
            {
                for (var i = 0; i < jugadores.Count; i++)
                {
                    if (jugadores.Count >= 2)
                    {
                        this.dgvSolicitudes.Rows.Add(jugadoresImagenes[i], jugadores[i], "ACTIVO");
                    }
                }
            }

            if (jugadoresPendientesNOMBRES.Count >= 1)
            {
                for (var i = 0; i < jugadoresPendientesNOMBRES.Count; i++)
                {
                    if (jugadoresPendientesNOMBRES.Count >= 1)
                    {
                        this.dgvSolicitudes.Rows.Add(jugadoresPendientesIMAGENES[i],jugadoresPendientesNOMBRES[i], "PENDIENTE");
                    }
                }
            }
            
            this.dgvSolicitudes.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolicitudes.RowHeadersVisible = false;
            foreach (DataGridViewColumn col in this.dgvSolicitudes.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            foreach (DataGridViewRow row in dgvSolicitudes.Rows)
            {
                for (var i = 0; i < jugadoresPendientesNOMBRES.Count; i++)
                {
                    if (Convert.ToString(row.Cells[2].Value) == "PENDIENTE")
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }

            this.dgvSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #endregion

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Perfil_Equipo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Boton Volver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Equipos frmEquipos = new Equipos();
            frmEquipos.Show();
            this.Hide();
        }
        #endregion

        #region Devolver Imagen del Equipo
        private void DevolverImagenEquipo()
        {
            if (!DBNull.Value.Equals(Equipos.imagenEquipoSeleccionado))
            {
                // Se crea un MemoryStream a partir de ese buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Equipos.imagenEquipoSeleccionado);
                // Se utiliza el MemoryStream para extraer la imagen
                pictureBox2.Image = Image.FromStream(ms);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }
        #endregion

        #region Funcion Validar Jugador Existentes

        #region Verificar Jugador 1
        public void VerificarCampoJugadorNoVacio1(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador))
            {
                this.bunifuCustomLabel7.Text = jugador.Replace(" ", "");
                this.bunifuCustomLabel7.Visible = true;
            }
            else
            {
                this.bunifuCustomLabel7.Visible = false;
            }
        }
        #endregion

        #region Verificar Jugador 2
        public void VerificarCampoJugadorNoVacio2(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador))
            {
                this.bunifuCustomLabel8.Text = jugador.Replace(" ", "");
                this.bunifuCustomLabel8.Visible = true;
            }
            else
            {
                this.bunifuCustomLabel8.Visible = false;
            }
        }
        #endregion

        #region Verificar Jugador 3
        public void VerificarCampoJugadorNoVacio3(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador))
            {
                this.bunifuCustomLabel9.Text = jugador.Replace(" ", "");
                this.bunifuCustomLabel9.Visible = true;
            }
            else
            {
                this.bunifuCustomLabel9.Visible = false;
            }
        }
        #endregion

        #region Verificar Jugador 4
        public void VerificarCampoJugadorNoVacio4(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador))
            {
                this.bunifuCustomLabel10.Text = jugador.Replace(" ", "");
                this.bunifuCustomLabel10.Visible = true;
            }
            else
            {
                this.bunifuCustomLabel10.Visible = false;
            }
        }
        #endregion

        #region Verificar Jugador 5
        public void VerificarCampoJugadorNoVacio5(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador))
            {
                this.bunifuCustomLabel15.Text = jugador.Replace(" ", "");
                this.bunifuCustomLabel15.Visible = true;
            }
            else
            {
                this.bunifuCustomLabel15.Visible = false;
            }
        }
        #endregion

        #region Verificar Jugador 6
        public void VerificarCampoJugadorNoVacio6(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador))
            {
                this.bunifuCustomLabel14.Text = jugador.Replace(" ", "");
                this.bunifuCustomLabel14.Visible = true;
            }
            else
            {
                this.bunifuCustomLabel14.Visible = false;
            }
        }
        #endregion

        #region Verificar Jugador 7
        public void VerificarCampoJugadorNoVacio7(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador))
            {
                this.bunifuCustomLabel13.Text = jugador.Replace(" ", "");
                this.bunifuCustomLabel13.Visible = true;
            }
            else
            {
                this.bunifuCustomLabel13.Visible = false;
            }
        }
        #endregion

        #region Verificar Jugador 8
        public void VerificarCampoJugadorNoVacio8(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador))
            {
                this.bunifuCustomLabel12.Text = jugador.Replace(" ", "");
                this.bunifuCustomLabel12.Visible = true;
            }
            else
            {
                this.bunifuCustomLabel12.Visible = false;
            }
        }
        #endregion

        #region Verificar Jugador 9
        public void VerificarCampoJugadorNoVacio9(string jugador)
        {
            if (!String.IsNullOrEmpty(jugador))
            {
                this.bunifuCustomLabel11.Text = jugador.Replace(" ", "");
                this.bunifuCustomLabel11.Visible = true;
            }
            else
            {
                this.bunifuCustomLabel11.Visible = false;
            }
        }
        #endregion

        #endregion

        #region Boton Editar Imagen Equipo
        private void bunifuThinButton21_Click(object sender, EventArgs e)
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
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] imagen = ms.GetBuffer();

                rpta = CEquipo.Editar(int.Parse(Equipos.idEquipoSeleccionado), this.bunifuMetroTextbox3.Text.Trim(), this.bunifuMetroTextbox1.Text.Trim(), Equipos.capitanEquipoSeleccionado, Equipos.jugadoresEquipoSeleccionado, imagen);

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El equipo se ha modificado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelEditarPerfilEquipo.Visible = false;
                    panelEditarPerfilEquipo.Left = 411;
                    panelPerfilEquipo.Visible = false;
                    panelPerfilEquipo.Left = 5;
                    panelPerfilEquipo.Visible = true;
                    bunifuSeparator1.Left = btnPerfilEquipo.Left;
                    bunifuSeparator1.Width = btnPerfilEquipo.Width;
                    this.pictureBox2.Image = this.pictureBox1.Image;
                    this.bunifuCustomLabel1.Text = this.bunifuMetroTextbox3.Text;
                    this.bunifuCustomLabel2.Text = this.bunifuMetroTextbox1.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Desplazar al Panel de Gestionar Jugadores
        private void btnVerMisEquipos_Click(object sender, EventArgs e)
        {
            if (panelSolicitudes.Left == 1707 || panelSolicitudes.Left == 856) //1275 || 702
            {
                panelEditarPerfilEquipo.Visible = false;
                panelEditarPerfilEquipo.Left = 856; //702
                panelPerfilEquipo.Visible = false;
                panelPerfilEquipo.Left = 856; //702


                panelSolicitudes.Visible = false;
                panelSolicitudes.Left = 30;
                panelSolicitudes.Visible = true;

                bunifuSeparator1.Visible = false;
                bunifuSeparator2.Visible = true;
                bunifuSeparator2.Width = btnGestionarJugadores.Width;
                
            }
        }


        #endregion

        #region Boton Rechazar Solicitud
        private void btnRechazar_Click(object sender, EventArgs e)
        {

            #region Eliminar Solicitud Pendiente del Jugador al Equipo
            SqlConnection SqlCon2242 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon2242.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando2242 = new SqlCommand("Delete from SolicitudesEquipos_Usuarios where idEquipo = " + Equipos.idEquipoSeleccionado + " and idUsuario in (Select idUsuario from Usuarios where Usuarios.nickname = '" + nombreJugadorSeleccionado + "')", SqlCon2242);
                SqlCon2242.Open();
                comando2242.ExecuteNonQuery();
                SqlCon2242.Close();
            }
            finally
            {
                if (SqlCon2242.State == ConnectionState.Open)
                {
                    SqlCon2242.Close();
                }
            }
            #endregion

            #region Eliminar Fila del Jugador que fue rechazado
            foreach (DataGridViewRow row in dgvSolicitudes.Rows)
            {
                for (var i = 0; i < jugadoresPendientesNOMBRES.Count; i++)
                {
                    if (Convert.ToString(row.Cells[1].Value) == nombreJugadorSeleccionado)
                    {
                        row.Visible = false;
                    }
                }
            }
            #endregion

            #region Mostrar Mensaje de Jugador Aceptado Exitosamente
            MensajeExito msjExito = new MensajeExito();
            msjExito.bunifuCustomLabel3.Text = "El jugador se ha rechazado exitosamente!";
            msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
            msjExito.Show();
            #endregion

            #region Reseteamos los botones por defecto
            this.btnAceptar.Visible = false;
            this.btnRechazar.Visible = false;
            this.btnRemoverJugador.Visible = true;
            #endregion

        }
        #endregion

        #region Boton Aceptar Solicitud
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            #region Agregamos el jugador seleccionado a la lista de jugadores
            jugadores.Add(nombreJugadorSeleccionado);
            string stringJugadores = string.Join(",", jugadores);
            #endregion

            #region Insertar nuevo jugador al Equipo
            SqlConnection SqlCon224 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon224.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando224 = new SqlCommand("Update Equipos set jugadores = '" + stringJugadores + "' where idEquipo = " + Equipos.idEquipoSeleccionado, SqlCon224);
                SqlCon224.Open();
                comando224.ExecuteNonQuery();
                SqlCon224.Close();
            }
            finally
            {
                if (SqlCon224.State == ConnectionState.Open)
                {
                    SqlCon224.Close();
                }
            }
            #endregion

            #region Eliminar Solicitud Pendiente del Jugador al Equipo
            SqlConnection SqlCon2242 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon2242.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando2242 = new SqlCommand("Delete from SolicitudesEquipos_Usuarios where idEquipo = " + Equipos.idEquipoSeleccionado + " and idUsuario in (Select idUsuario from Usuarios where Usuarios.nickname = '" + nombreJugadorSeleccionado + "')", SqlCon2242);
                SqlCon2242.Open();
                comando2242.ExecuteNonQuery();
                SqlCon2242.Close();
            }
            finally
            {
                if (SqlCon2242.State == ConnectionState.Open)
                {
                    SqlCon2242.Close();
                }
            }
            #endregion

            #region Mostrar Mensaje de Jugador Aceptado Exitosamente
            MensajeExito msjExito = new MensajeExito();
            msjExito.bunifuCustomLabel3.Text = "El jugador se ha aceptado exitosamente!";
            msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
            msjExito.Show();
            #endregion

            #region Limpiar dgvSolicitudes
            this.dgvSolicitudes.DataSource = null;
            //this.dgvSolicitudes.Columns.Clear();
            this.dgvSolicitudes.Rows.Clear();
            if (dgvSolicitudes.RowCount > 0)
            {
                for (int i = 0; i <= dgvSolicitudes.RowCount; i++)
                {
                    dgvSolicitudes.Rows.RemoveAt(1);
                }
            }
            this.dgvSolicitudes.Refresh();
            #endregion

            #region Listar dgvSolicitudes

            #region Cargar Gestionar Jugadores
            //List<string> jugadoresPendientesIDS = new List<string>();
            //List<string> jugadoresPendientesNOMBRES = new List<string>();
            SqlConnection SqlConn = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlConn.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando1 = new SqlCommand("Select Usuarios.imagenPerfil, Usuarios.idUsuario as 'idUsuario', nickname from SolicitudesEquipos_Usuarios inner join Usuarios on SolicitudesEquipos_Usuarios.idUsuario = Usuarios.idUsuario where idEquipo = '" + Equipos.idEquipoSeleccionado + "'", SqlConn);
                SqlConn.Open();
                SqlDataReader registro1 = comando1.ExecuteReader();
                while (registro1.Read())
                {
                    jugadoresPendientesIDS.Add(registro1["idUsuario"].ToString());
                    jugadoresPendientesNOMBRES.Add(registro1["nickname"].ToString());
                    jugadoresPendientesIMAGENES.Add((byte[])registro1["imagenPerfil"]);
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

            string jugadoresDB = Equipos.jugadoresEquipoSeleccionado;
            jugadores = jugadoresDB.Split(',').ToList();

            #region Cargar Imagenes Jugadores Activos
            SqlConnection SqlConn25 = new SqlConnection();

            try
            {



                for (var i = 0; i < jugadores.Count; i++)
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlConn25.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";

                    SqlConn25.Open();
                    SqlCommand comando25 = new SqlCommand("Select Usuarios.imagenPerfil from Usuarios where nickname LIKE '" + jugadores[i].Trim() + "'", SqlConn25);

                    SqlDataReader registro25 = comando25.ExecuteReader();
                    while (registro25.Read())
                    {
                        jugadoresImagenes.Add((byte[])registro25["imagenPerfil"]);
                    }
                    SqlConn25.Close();
                }

            }
            finally
            {
                if (SqlConn25.State == ConnectionState.Open)
                {
                    SqlConn25.Close();
                }
            }
            #endregion

            if (jugadores.Count >= 1)
            {
                for (var i = 0; i < jugadores.Count; i++)
                {
                    if (jugadores.Count >= 2)
                    {
                        this.dgvSolicitudes.Rows.Add(jugadoresImagenes[i], jugadores[i], "ACTIVO");
                    }
                }
            }

            if (jugadoresPendientesNOMBRES.Count >= 1)
            {
                for (var i = 0; i < jugadoresPendientesNOMBRES.Count; i++)
                {
                    if (jugadoresPendientesNOMBRES.Count >= 1)
                    {
                        this.dgvSolicitudes.Rows.Add(jugadoresPendientesIMAGENES[i], jugadoresPendientesNOMBRES[i], "PENDIENTE");
                    }
                }
            }

            this.dgvSolicitudes.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolicitudes.RowHeadersVisible = false;
            foreach (DataGridViewColumn col in this.dgvSolicitudes.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            foreach (DataGridViewRow row in dgvSolicitudes.Rows)
            {
                for (var i=0;i < jugadoresPendientesNOMBRES.Count; i++)
                {
                    if (Convert.ToString(row.Cells[1].Value) == nombreJugadorSeleccionado)
                    {
                        row.Cells[2].Value = "ACTIVO";
                    }
                }
            }

            foreach (DataGridViewRow row in dgvSolicitudes.Rows)
            {
                for (var i = 0; i < jugadoresPendientesNOMBRES.Count; i++)
                {
                    if (Convert.ToString(row.Cells[2].Value) == "PENDIENTE")
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }

            this.dgvSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #endregion

            #region Actualizar Lista de Jugadores
            var cantidadJugadores = jugadores.Count;

            if (cantidadJugadores == 0)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel7.Text = nombreJugadorSeleccionado;
                this.bunifuCustomLabel8.Visible = false;
                this.bunifuCustomLabel9.Visible = false;
                this.bunifuCustomLabel10.Visible = false;
                this.bunifuCustomLabel15.Visible = false;
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 1)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel8.Text = nombreJugadorSeleccionado;
                this.bunifuCustomLabel9.Visible = false;
                this.bunifuCustomLabel10.Visible = false;
                this.bunifuCustomLabel15.Visible = false;
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 2)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel9.Text = nombreJugadorSeleccionado;
                this.bunifuCustomLabel10.Visible = false;
                this.bunifuCustomLabel15.Visible = false;
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 3)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel10.Text = nombreJugadorSeleccionado;
                this.bunifuCustomLabel15.Visible = false;
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 4)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel15.Visible = true;
                this.bunifuCustomLabel15.Text = nombreJugadorSeleccionado;
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 5)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel15.Visible = true;
                this.bunifuCustomLabel14.Visible = true;
                this.bunifuCustomLabel14.Text = nombreJugadorSeleccionado;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 6)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel15.Visible = true;
                this.bunifuCustomLabel14.Visible = true;
                this.bunifuCustomLabel13.Visible = true;
                this.bunifuCustomLabel13.Text = nombreJugadorSeleccionado;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 7)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel15.Visible = true;
                this.bunifuCustomLabel14.Visible = true;
                this.bunifuCustomLabel13.Visible = true;
                this.bunifuCustomLabel12.Visible = true;
                this.bunifuCustomLabel12.Text = nombreJugadorSeleccionado;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 8)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel15.Visible = true;
                this.bunifuCustomLabel14.Visible = true;
                this.bunifuCustomLabel13.Visible = true;
                this.bunifuCustomLabel12.Visible = true;
                this.bunifuCustomLabel11.Visible = true;
                this.bunifuCustomLabel11.Text = nombreJugadorSeleccionado;
            }
            #endregion

            #region Reseteamos los botones por defecto
            this.btnAceptar.Visible = false;
            this.btnRechazar.Visible = false;
            this.btnRemoverJugador.Visible = true;
            #endregion

        }
        #endregion

        #region Boton Solicitar Unirse Al Equipo
        private void btnUnirseAlEquipo_Click(object sender, EventArgs e)
        {

            #region Insertar en la tabla de Solicitudes Pendientes
            SqlConnection SqlCon24 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon24.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando24 = new SqlCommand("Insert into SolicitudesEquipos_Usuarios Values ('" + int.Parse(Equipos.idEquipoSeleccionado) + "','" + int.Parse(Login.idUsuario) + "')", SqlCon24);
                SqlCon24.Open();
                comando24.ExecuteNonQuery();
                SqlCon24.Close();
            }
            finally
            {
                if (SqlCon24.State == ConnectionState.Open)
                {
                    SqlCon24.Close();
                }
            }
            #endregion

            #region Mostrar Mensaje de Solicitud Enviada Exitosamente
            MensajeExito msjExito = new MensajeExito();
            msjExito.bunifuCustomLabel3.Text = "La solicitud se ha enviado exitosamente!";
            msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
            msjExito.Show();
            #endregion

            this.btnUnirseAlEquipo.Visible = false;
        }
        #endregion

        #region Seleccionar Jugador
        private void dgvSolicitudes_Click(object sender, EventArgs e)
        {

            #region Cargar Nombre del Jugador Seleccionado
            nombreJugadorSeleccionado = Convert.ToString(this.dgvSolicitudes.CurrentRow.Cells["colNombre"].Value);
            #endregion

            #region Cargar Estado del Jugador Seleccionado
            estadoJugadorSeleccionado = Convert.ToString(this.dgvSolicitudes.CurrentRow.Cells["colEstado"].Value);
            #endregion

            if (estadoJugadorSeleccionado == "PENDIENTE")
            {
                this.btnAceptar.Visible = true;
                this.btnRechazar.Visible = true;
                this.btnRemoverJugador.Visible = false;
            }
            else if (estadoJugadorSeleccionado == "ACTIVO")
            {
                this.btnAceptar.Visible = false;
                this.btnRechazar.Visible = false;
                this.btnRemoverJugador.Visible = true;
            }
        }
        #endregion

        #region Boton Remover Jugador
        private void btnRemoverJugador_Click(object sender, EventArgs e)
        {

            #region Verificar la posición en la Lista de Jugadores
            if (jugadores.Count >= 1)
            {
                if (jugadores[0] == nombreJugadorSeleccionado)
                {
                    jugadores.RemoveAt(0);
                }

                if (jugadores.Count >= 2)
                {
                    if (jugadores[1] == nombreJugadorSeleccionado)
                    {
                        jugadores.RemoveAt(1);
                    }

                    if (jugadores.Count >= 3)
                    {
                        if (jugadores[2] == nombreJugadorSeleccionado)
                        {
                            jugadores.RemoveAt(2);
                        }

                        if (jugadores.Count >= 4)
                        {
                            if (jugadores[3] == nombreJugadorSeleccionado)
                            {
                                jugadores.RemoveAt(3);
                            }

                            if (jugadores.Count >= 5)
                            {
                                if (jugadores[4] == nombreJugadorSeleccionado)
                                {
                                    jugadores.RemoveAt(4);
                                }

                                if (jugadores.Count >= 6)
                                {
                                    if (jugadores[5] == nombreJugadorSeleccionado)
                                    {
                                        jugadores.RemoveAt(5);
                                    }

                                    if (jugadores.Count >= 7)
                                    {
                                        if (jugadores[6] == nombreJugadorSeleccionado)
                                        {
                                            jugadores.RemoveAt(6);
                                        }

                                        if (jugadores.Count >= 8)
                                        {
                                            if (jugadores[7] == nombreJugadorSeleccionado)
                                            {
                                                jugadores.RemoveAt(7);
                                            }

                                            if (jugadores.Count >= 9)
                                            {
                                                if (jugadores[8] == nombreJugadorSeleccionado)
                                                {
                                                    jugadores.RemoveAt(8);
                                                }
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

            #region Insertar nueva lista de jugadores del Equipo
            string stringJugadores = string.Join(",", jugadores);
            SqlConnection SqlCon224 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon224.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando224 = new SqlCommand("Update Equipos set jugadores = '" + stringJugadores + "' where idEquipo = " + Equipos.idEquipoSeleccionado, SqlCon224);
                SqlCon224.Open();
                comando224.ExecuteNonQuery();
                SqlCon224.Close();
            }
            finally
            {
                if (SqlCon224.State == ConnectionState.Open)
                {
                    SqlCon224.Close();
                }
            }
            #endregion

            #region Definir Variables a Utilizar
            List<string> nuevosJugadores = new List<string>();
            string stringNuevosJugadores = "";
            #endregion

            #region Cargar Nuevos Jugadores del Equipo
            
            SqlConnection SqlConn = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlConn.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando1 = new SqlCommand("Select jugadores from Equipos where idEquipo = '" + Equipos.idEquipoSeleccionado + "'", SqlConn);
                SqlConn.Open();
                SqlDataReader registro1 = comando1.ExecuteReader();
                while (registro1.Read())
                {
                    stringNuevosJugadores = registro1["jugadores"].ToString();
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

            #region Cargar Gestionar Jugadores
            //List<string> jugadoresPendientesIDS = new List<string>();
            //List<string> jugadoresPendientesNOMBRES = new List<string>();
            SqlConnection SqlConn222 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlConn222.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando222 = new SqlCommand("Select Usuarios.imagenPerfil, Usuarios.idUsuario as 'idUsuario', nickname from SolicitudesEquipos_Usuarios inner join Usuarios on SolicitudesEquipos_Usuarios.idUsuario = Usuarios.idUsuario where idEquipo = '" + Equipos.idEquipoSeleccionado + "'", SqlConn222);
                SqlConn222.Open();
                SqlDataReader registro222 = comando222.ExecuteReader();
                while (registro222.Read())
                {
                    jugadoresPendientesIDS.Add(registro222["idUsuario"].ToString());
                    jugadoresPendientesNOMBRES.Add(registro222["nickname"].ToString());
                    jugadoresPendientesIMAGENES.Add((byte[])registro222["imagenPerfil"]);
                }
                SqlConn222.Close();

            }
            finally
            {
                if (SqlConn222.State == ConnectionState.Open)
                {
                    SqlConn222.Close();
                }
            }
            #endregion

            nuevosJugadores = stringJugadores.Split(',').ToList();

            #region Cargar Imagenes Jugadores Nuevos Activos
            SqlConnection SqlConn25 = new SqlConnection();

            try
            {
                
                for (var i = 0; i < nuevosJugadores.Count; i++)
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlConn25.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";

                    SqlConn25.Open();
                    SqlCommand comando25 = new SqlCommand("Select Usuarios.imagenPerfil from Usuarios where nickname LIKE '" + nuevosJugadores[i].Trim() + "'", SqlConn25);

                    SqlDataReader registro25 = comando25.ExecuteReader();
                    while (registro25.Read())
                    {
                        jugadoresImagenes.Add((byte[])registro25["imagenPerfil"]);
                    }
                    SqlConn25.Close();
                }

            }
            finally
            {
                if (SqlConn25.State == ConnectionState.Open)
                {
                    SqlConn25.Close();
                }
            }
            #endregion

            #region Mostrar Mensaje de Jugador Removido Exitosamente
            MensajeExito msjExito = new MensajeExito();
            msjExito.bunifuCustomLabel3.Text = "El jugador ha sido removido exitosamente!";
            msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
            msjExito.Show();
            #endregion

            this.dgvSolicitudes.Rows.Clear();

            #region Listar dgvSolicitudes
            if (nuevosJugadores.Count >= 1)
            {
                for (var i = 0; i < nuevosJugadores.Count; i++)
                {
                    if (nuevosJugadores.Count >= 2)
                    {
                        this.dgvSolicitudes.Rows.Add(jugadoresImagenes[i], nuevosJugadores[i], "ACTIVO");
                    }
                }
            }

            if (jugadoresPendientesNOMBRES.Count >= 1)
            {
                for (var i = 0; i < jugadoresPendientesNOMBRES.Count; i++)
                {
                    if (jugadoresPendientesNOMBRES.Count >= 1)
                    {
                        this.dgvSolicitudes.Rows.Add(jugadoresPendientesIMAGENES[i], jugadoresPendientesNOMBRES[i], "PENDIENTE");
                    }
                }
            }

            this.dgvSolicitudes.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolicitudes.RowHeadersVisible = false;
            foreach (DataGridViewColumn col in this.dgvSolicitudes.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            foreach (DataGridViewRow row in dgvSolicitudes.Rows)
            {
                for (var i = 0; i < jugadoresPendientesNOMBRES.Count; i++)
                {
                    if (Convert.ToString(row.Cells[2].Value) == "PENDIENTE")
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }

            this.dgvSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            #endregion

            #region Actualizar Lista de Nuevos Jugadores
            var cantidadJugadores = nuevosJugadores.Count;

            if (cantidadJugadores == 0)
            {
                this.bunifuCustomLabel7.Visible = false;
                this.bunifuCustomLabel8.Visible = false;
                this.bunifuCustomLabel9.Visible = false;
                this.bunifuCustomLabel10.Visible = false;
                this.bunifuCustomLabel15.Visible = false;
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 1)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel7.Text = nuevosJugadores[0];
                this.bunifuCustomLabel8.Visible = false;
                this.bunifuCustomLabel9.Visible = false;
                this.bunifuCustomLabel10.Visible = false;
                this.bunifuCustomLabel15.Visible = false;
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 2)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel7.Text = nuevosJugadores[0];
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel8.Text = nuevosJugadores[1];
                this.bunifuCustomLabel9.Visible = false;
                this.bunifuCustomLabel10.Visible = false;
                this.bunifuCustomLabel15.Visible = false;
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 3)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel7.Text = nuevosJugadores[0];
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel8.Text = nuevosJugadores[1];
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel9.Text = nuevosJugadores[2];
                this.bunifuCustomLabel10.Visible = false;
                this.bunifuCustomLabel15.Visible = false;
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 4)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel7.Text = nuevosJugadores[0];
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel8.Text = nuevosJugadores[1];
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel9.Text = nuevosJugadores[2];
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel10.Text = nuevosJugadores[3];
                this.bunifuCustomLabel15.Visible = false;
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 5)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel7.Text = nuevosJugadores[0];
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel8.Text = nuevosJugadores[1];
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel9.Text = nuevosJugadores[2];
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel10.Text = nuevosJugadores[3];
                this.bunifuCustomLabel15.Visible = true;
                this.bunifuCustomLabel15.Text = nuevosJugadores[4];
                this.bunifuCustomLabel14.Visible = false;
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 6)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel7.Text = nuevosJugadores[0];
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel8.Text = nuevosJugadores[1];
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel9.Text = nuevosJugadores[2];
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel10.Text = nuevosJugadores[3];
                this.bunifuCustomLabel15.Visible = true;
                this.bunifuCustomLabel15.Text = nuevosJugadores[4];
                this.bunifuCustomLabel14.Visible = true;
                this.bunifuCustomLabel14.Text = nuevosJugadores[5];
                this.bunifuCustomLabel13.Visible = false;
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 7)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel7.Text = nuevosJugadores[0];
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel8.Text = nuevosJugadores[1];
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel9.Text = nuevosJugadores[2];
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel10.Text = nuevosJugadores[3];
                this.bunifuCustomLabel15.Visible = true;
                this.bunifuCustomLabel15.Text = nuevosJugadores[4];
                this.bunifuCustomLabel14.Visible = true;
                this.bunifuCustomLabel14.Text = nuevosJugadores[5];
                this.bunifuCustomLabel13.Visible = true;
                this.bunifuCustomLabel13.Text = nuevosJugadores[6];
                this.bunifuCustomLabel12.Visible = false;
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 8)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel7.Text = nuevosJugadores[0];
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel8.Text = nuevosJugadores[1];
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel9.Text = nuevosJugadores[2];
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel10.Text = nuevosJugadores[3];
                this.bunifuCustomLabel15.Visible = true;
                this.bunifuCustomLabel15.Text = nuevosJugadores[4];
                this.bunifuCustomLabel14.Visible = true;
                this.bunifuCustomLabel14.Text = nuevosJugadores[5];
                this.bunifuCustomLabel13.Visible = true;
                this.bunifuCustomLabel13.Text = nuevosJugadores[6];
                this.bunifuCustomLabel12.Visible = true;
                this.bunifuCustomLabel12.Text = nuevosJugadores[7];
                this.bunifuCustomLabel11.Visible = false;
            }
            if (cantidadJugadores == 9)
            {
                this.bunifuCustomLabel7.Visible = true;
                this.bunifuCustomLabel7.Text = nuevosJugadores[0];
                this.bunifuCustomLabel8.Visible = true;
                this.bunifuCustomLabel8.Text = nuevosJugadores[1];
                this.bunifuCustomLabel9.Visible = true;
                this.bunifuCustomLabel9.Text = nuevosJugadores[2];
                this.bunifuCustomLabel10.Visible = true;
                this.bunifuCustomLabel10.Text = nuevosJugadores[3];
                this.bunifuCustomLabel15.Visible = true;
                this.bunifuCustomLabel15.Text = nuevosJugadores[4];
                this.bunifuCustomLabel14.Visible = true;
                this.bunifuCustomLabel14.Text = nuevosJugadores[5];
                this.bunifuCustomLabel13.Visible = true;
                this.bunifuCustomLabel13.Text = nuevosJugadores[6];
                this.bunifuCustomLabel12.Visible = true;
                this.bunifuCustomLabel12.Text = nuevosJugadores[7];
                this.bunifuCustomLabel11.Visible = true;
                this.bunifuCustomLabel11.Text = nuevosJugadores[8];
            }
            #endregion

            #region Reseteamos los botones por defecto
            this.btnAceptar.Visible = false;
            this.btnRechazar.Visible = false;
            this.btnRemoverJugador.Visible = true;
            #endregion

        }
        #endregion

        #region Boton Eliminar Equipo
        private void btnEliminarEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult VentanaEmergente;
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere eliminar el equipo?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {

                    #region Definir Variables a Utilizar
                    List<string> nuevosJugadores = new List<string>();
                    string stringNuevosJugadores = "";
                    #endregion

                    #region Cargar Nuevos Jugadores del Equipo
                    SqlConnection SqlConn = new SqlConnection();

                    try
                    {
                        //Establecemos la conexion, el comando y ejecutamos el mismo
                        SqlConn.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                        SqlCommand comando1 = new SqlCommand("Select jugadores from Equipos where idEquipo = '" + Equipos.idEquipoSeleccionado + "'", SqlConn);
                        SqlConn.Open();
                        SqlDataReader registro1 = comando1.ExecuteReader();
                        while (registro1.Read())
                        {
                            stringNuevosJugadores = registro1["jugadores"].ToString();
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

                    nuevosJugadores = stringNuevosJugadores.Split(',').ToList();

                    #region Remover Equipo de Jugadores Tabla Usuarios
                    SqlConnection SqlConn25 = new SqlConnection();

                    try
                    {
                        if (nuevosJugadores.Count >= 2)
                        {
                            for (var i = 0; i < nuevosJugadores.Count; i++)
                            {
                                //Establecemos la conexion, el comando y ejecutamos el mismo
                                SqlConn25.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                                SqlCommand comando25 = new SqlCommand("Updates Usuarios set equipos = 'Sin Equipo' where nickname LIKE '" + nuevosJugadores[i].Trim() + "'", SqlConn25);
                                SqlConn25.Open();
                                comando25.ExecuteNonQuery();
                                SqlConn25.Close();
                            }
                        }
                    }
                    finally
                    {
                        if (SqlConn25.State == ConnectionState.Open)
                        {
                            SqlConn25.Close();
                        }
                    }
                    #endregion

                    #region Eliminar Equipo de la Tabla SolicitudesEquipos_Usuarios
                    SqlConnection SqlCon2242 = new SqlConnection();

                    try
                    {
                        //Establecemos la conexion, el comando y ejecutamos el mismo
                        SqlCon2242.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                        SqlCommand comando2242 = new SqlCommand("Delete from SolicitudesEquipos_Usuarios where idEquipo = " + Equipos.idEquipoSeleccionado, SqlCon2242);
                        SqlCon2242.Open();
                        comando2242.ExecuteNonQuery();
                        SqlCon2242.Close();
                    }
                    finally
                    {
                        if (SqlCon2242.State == ConnectionState.Open)
                        {
                            SqlCon2242.Close();
                        }
                    }
                    #endregion

                    #region Eliminar Equipo de la Tabla de Equipos
                    SqlConnection SqlCon2243 = new SqlConnection();

                    try
                    {
                        //Establecemos la conexion, el comando y ejecutamos el mismo
                        SqlCon2243.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                        SqlCommand comando2243 = new SqlCommand("Delete from Equipos where idEquipo = " + Equipos.idEquipoSeleccionado, SqlCon2243);
                        SqlCon2243.Open();
                        comando2243.ExecuteNonQuery();
                        SqlCon2243.Close();
                    }
                    finally
                    {
                        if (SqlCon2243.State == ConnectionState.Open)
                        {
                            SqlCon2243.Close();
                        }
                    }
                    #endregion
                    
                    #region Dirigir al Formulario de Equipos
                    Equipos frmEquipos = new Equipos();
                    frmEquipos.Show();
                    this.Hide();
                    #endregion

                    #region Mostrar Mensaje de Equipo Eliminado Exitosamente
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El equipo ha sido eliminado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    #endregion

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

    }
}