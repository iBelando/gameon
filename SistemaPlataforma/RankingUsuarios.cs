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
    public partial class RankingUsuarios : Form
    {
        public RankingUsuarios()
        {
            InitializeComponent();
        }

        
        private void RankingUsuarios_Load(object sender, EventArgs e)
        {

            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion

            #region Definir Variable a Llenar
            List<string> usuariosEquipo = new List<string>();
            #endregion

            #region Obtener Victorias de los Usuarios
            SqlConnection SqlCon4 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) group by nickname order by Victorias desc", SqlCon4);
                SqlCon4.Open();
                SqlDataReader registro4 = comando4.ExecuteReader();
                while (registro4.Read())
                {
                    usuariosEquipo.Add(registro4["nickname"].ToString());
                }
                SqlCon4.Close();
            }
            finally
            {
                if (SqlCon4.State == ConnectionState.Open)
                {
                    SqlCon4.Close();
                }
            }
            #endregion

            #region Llenar Posiciones Usuarios
            this.btnJugador1.ButtonText = usuariosEquipo[0];
            this.btnJugador2.ButtonText = usuariosEquipo[1];
            this.btnJugador3.ButtonText = usuariosEquipo[2];
            this.btnJugador4.ButtonText = usuariosEquipo[3];
            this.btnJugador5.ButtonText = usuariosEquipo[4];
            this.btnJugador6.ButtonText = usuariosEquipo[5];
            this.btnJugador7.ButtonText = usuariosEquipo[6];
            this.btnJugador8.ButtonText = "Astrid"; //usuariosEquipo[7]
            this.btnJugador9.ButtonText = "Zeke"; //usuariosEquipo[8]
            this.btnJugador10.ButtonText = "Sneaky"; //usuariosEquipo[9];
            #endregion
        }

        #region Pantalla Arrastrable
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void RankingUsuarios_MouseDown(object sender, MouseEventArgs e)
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

        #region Boton Volver
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Inicio frmInicio = new Inicio();
            frmInicio.Show();
            this.Close();
        }
        #endregion

        #region Boton Volver
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Boton Volver desde el Panel de Estadisticas
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = true;
            panel2.Visible = true;

            #region Resetear Campos
            this.label1.Text = "TOP 10 MEJORES JUGADORES";
            this.bunifuImageButton2.Visible = false;
            this.bunifuImageButton1.Visible = true;
            #endregion
        }


        #endregion

        #region Jugador Top 1
        private void btnJugador1_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //738
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //738

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador1.ButtonText +"' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador1.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador1.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador1.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador1.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador1.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador1.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador1.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion

        #region Jugador Top 2
        private void btnJugador2_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //738
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //738

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador2.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador2.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador2.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador2.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador2.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador2.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador2.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador2.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion

        #region Jugador Top 3
        private void btnJugador3_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //738
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //738

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador3.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador3.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador3.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador3.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador3.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador3.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador3.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador3.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion

        #region Jugador Top 4
        private void btnJugador4_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //738
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //738

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador4.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador4.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador4.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador4.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador4.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador4.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador4.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador4.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion

        #region Jugador Top 5
        private void btnJugador5_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //738
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //738

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador5.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador5.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador5.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador5.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador5.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador5.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador5.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador5.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion

        #region Jugador Top 6
        private void btnJugador6_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //738
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //738

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador6.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador6.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador6.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador6.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador6.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador6.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador6.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador6.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion

        #region Jugador Top 7
        private void btnJugador7_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //738
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //738

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador7.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador7.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador7.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador7.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador7.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador7.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador7.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador7.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion

        #region Jugador Top 8
        private void btnJugador8_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //738
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //738

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador8.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador8.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador8.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador8.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador8.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador8.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador8.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador8.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion

        #region Jugador Top 9
        private void btnJugador9_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //738
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //738

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador9.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador9.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador9.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador9.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador9.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador9.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador9.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador9.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion

        #region Jugador Top 10
        private void btnJugador10_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //738
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //738

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador10.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador10.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador10.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador10.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL JUGADOR";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1, 0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nickname, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nickname = '" + btnJugador10.ButtonText + "' group by nickname order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    bunifuCircleProgressbar2.Value = (cantVictorias * 1000) / 100;
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                #region Cargar Porcentaje Derrotas
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    int cantDerrotas = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select nickname, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) inner join Usuarios on Equipos.capitan = Usuarios.nickname where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nickname = '" + btnJugador10.ButtonText + "' group by nickname order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar3.Value = (cantDerrotas * 1000) / 100;
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Configuracion Grafico Torneos Disputados

                #region Obtener Inscripciones Equipos
                int cantidadInscripciones = 0;
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.capitan = '" + btnJugador10.ButtonText + "'", SqlCon8);
                    SqlCon8.Open();
                    SqlDataReader registro8 = comando8.ExecuteReader();
                    while (registro8.Read())
                    {
                        cantidadInscripciones = Convert.ToInt32(registro8["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic.Add("FEBRERO", (cantidadInscripciones * 6));
                dic.Add("MARZO", (cantidadInscripciones * 12));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 7));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 15));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart3.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

                #region Configuracion Grafico Ultimos Partidos

                #region Obtener Partidos Jugados Equipos
                int cantidadPartidos = 0;
                SqlConnection SqlCon9 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon9.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.capitan = '" + btnJugador10.ButtonText + "'", SqlCon9);
                    SqlCon9.Open();
                    SqlDataReader registro9 = comando9.ExecuteReader();
                    while (registro9.Read())
                    {
                        cantidadPartidos = Convert.ToInt32(registro9["Cantidad"].ToString());
                    }
                    SqlCon4.Close();
                }
                finally
                {
                    if (SqlCon4.State == ConnectionState.Open)
                    {
                        SqlCon4.Close();
                    }
                }
                #endregion

                Dictionary<string, int> dic1 = new Dictionary<string, int>();
                dic1.Add("FEBRERO", (cantidadPartidos * 6));
                dic1.Add("MARZO", (cantidadPartidos * 12));
                dic1.Add("AGOSTO", (cantidadPartidos * 2));
                dic1.Add("SEPTIEMBRE", (cantidadPartidos * 7));
                dic1.Add("NOVIEMBRE", (cantidadPartidos * 15));
                foreach (KeyValuePair<string, int> d in dic1)
                {
                    chart4.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion

    }
}
