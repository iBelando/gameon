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
    public partial class RankingEquipos : Form
    {
        
        public RankingEquipos()
        {
            InitializeComponent();
        }

        
        private void RankingEquipos_Load(object sender, EventArgs e)
        {

            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion

            #region Definir Variable a Llenar
            List<string> nombresEquipo = new List<string>();
            #endregion

            #region Obtener Victorias de los Equipos
            SqlConnection SqlCon4 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) group by nombre order by Victorias desc", SqlCon4);
                SqlCon4.Open();
                SqlDataReader registro4 = comando4.ExecuteReader();
                while (registro4.Read())
                {
                    nombresEquipo.Add(registro4["nombre"].ToString());
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

            #region Llenar Posiciones Equipos
            this.btnEquipo1.ButtonText = nombresEquipo[0];
            this.btnEquipo2.ButtonText = nombresEquipo[1];
            this.btnEquipo3.ButtonText = nombresEquipo[2];
            this.btnEquipo4.ButtonText = nombresEquipo[3];
            this.btnEquipo5.ButtonText = nombresEquipo[4];
            this.btnEquipo6.ButtonText = nombresEquipo[5];
            this.btnEquipo7.ButtonText = nombresEquipo[6];
            this.btnEquipo8.ButtonText = "Boca Juniors";//nombresEquipo[7];
            this.btnEquipo9.ButtonText = "Doriux"; //nombresEquipo[8];
            this.btnEquipo10.ButtonText = "Fnatic"; //nombresEquipo[9];
            #endregion
        }

        #region Pantalla Arrastrable
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void RankingEquipos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        #region Boton Volver desde Panel Estadisticas
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
                panel3.Visible = false;
                panel1.Visible = true;
                panel2.Visible = true;

                #region Resetear Campos
                this.label1.Text = "TOP 10 MEJORES EQUIPOS";
                this.bunifuImageButton2.Visible = false;
                this.bunifuImageButton1.Visible = true;
                #endregion

        }
        #endregion

        #region Equipo Top 1
        private void btnEquipo1_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //723
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //723

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
                this.bunifuImageButton1.Visible = false;
                this.bunifuImageButton2.Visible = true;
                this.bunifuImageButton2.Location = new Point(1,0);

                #region Cargar Porcentaje Victorias
                SqlConnection SqlCon4 = new SqlConnection();
                
                try
                {
                    int cantVictorias = 0;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo1.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 700) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo1.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo1.ButtonText + "'", SqlCon8);
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
                dic.Add("MARZO", (cantidadInscripciones * 6));
                dic.Add("AGOSTO", (cantidadInscripciones * 2));
                dic.Add("SEPTIEMBRE", (cantidadInscripciones * 3));
                dic.Add("NOVIEMBRE", (cantidadInscripciones * 4));
                foreach (KeyValuePair<string, int> d in dic)
                {
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo1.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo1.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 700) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo1.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo1.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo1.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }

        #endregion

        #region Equipo Top 2
        private void btnEquipo2_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //723
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //723

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo2.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo2.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo2.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo2.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo2.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo2.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo2.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo2.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }


        #endregion

        #region Equipo Top 3
        private void btnEquipo3_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //723
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856;

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo3.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo3.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo3.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo3.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion
            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo3.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo3.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo3.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo3.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }

        #endregion

        #region Equipo Top 4
        private void btnEquipo4_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //723
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856;

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo4.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo4.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo4.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo4.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo4.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo4.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo4.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo4.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }

        #endregion

        #region Equipo Top 5
        private void btnEquipo5_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //723
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856;

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo5.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo5.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo5.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo5.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo5.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo5.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo5.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo5.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }

        #endregion

        #region Equipo Top 6
        private void btnEquipo6_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //723
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //723

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo6.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo6.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo6.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo6.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo6.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo6.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo6.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo6.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }

        #endregion

        #region Equipo Top 7
        private void btnEquipo7_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //723
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //723

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo7.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo7.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo7.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo7.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo7.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo7.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo7.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo7.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }

        #endregion

        #region Equipo Top 8
        private void btnEquipo8_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //723
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856;

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo8.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo8.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo8.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo8.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo8.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo8.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo8.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo8.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }

        #endregion

        #region Equipo Top 9
        private void btnEquipo9_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //723
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //723

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo9.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo9.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo9.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo9.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo9.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo9.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo9.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo9.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }

        #endregion

        #region Equipo Top 10
        private void btnEquipo10_Click(object sender, EventArgs e)
        {
            if (panel3.Left == 856) //723
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                panel3.Left = 856; //723

                panel3.Visible = false;
                panel3.Left = 45;
                panel3.Visible = true;

                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo10.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo10.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo10.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo10.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = false;
                panel3.Visible = true;
                this.label1.Text = "ESTADISTICAS DEL EQUIPO";
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
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) and nombre = '" + this.btnEquipo10.ButtonText + "' group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        cantVictorias = Convert.ToInt32(registro4["Victorias"].ToString());
                    }
                    SqlCon4.Close();
                    progressbarEquipos.Value = (cantVictorias * 1000) / 100;
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
                    SqlCommand comando5 = new SqlCommand("select nombre, count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) and nombre = '" + this.btnEquipo10.ButtonText + "' group by nombre order by Derrotas desc", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        cantDerrotas = Convert.ToInt32(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                    bunifuCircleProgressbar1.Value = (cantDerrotas * 1000) / 100;
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
                    SqlCommand comando8 = new SqlCommand("select count(*) as Cantidad from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where Equipos.nombre = '" + btnEquipo10.ButtonText + "'", SqlCon8);
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
                    chart2.Series["Series1"].Points.AddXY(d.Key, d.Value);
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
                    SqlCommand comando9 = new SqlCommand("select count(*) as Cantidad from Partidos inner join Equipos on((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where Equipos.nombre = '" + btnEquipo10.ButtonText + "'", SqlCon9);
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
                    chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
                }
                #endregion

            }
        }
        #endregion
    }
}
