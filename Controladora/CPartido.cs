using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Controladora
{
    public class CPartido
    {

        #region Singleton
        private static CPartido _instance = null;
        private CPartido()
        { }

        public static CPartido Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CPartido();
                return _instance;
            }
        }
        #endregion

        #region Función Insertar Partido
        //Metodo Insertar que llama al metodo Insertar en la clase MPartido de la Capa de Modelo
        public static string Insertar(DateTime fecha, string equipoa, string equipob, string resultado, string juego, int idarbitro, int idcompetencia)
        {
            MPartido oPartido = new MPartido();
            oPartido.fecha = fecha;
            oPartido.equipoA = equipoa;
            oPartido.equipoB = equipob;
            oPartido.resultado = resultado;
            oPartido.juego = juego;
            oPartido.idArbitro = idarbitro;
            oPartido.idCompetencia = idcompetencia;

            return oPartido.Insertar(oPartido);
        }
        #endregion

        #region Función Editar Partido
        //Metodo Editar que llama al metodo Editar en la clase MPartido de la Capa de Modelo
        public static string Editar(int idpartido, DateTime fecha, string equipoa, string equipob, string resultado, string juego, int idarbitro, int idcompetencia)
        {
            MPartido oPartido = new MPartido();
            oPartido.idPartido = idpartido;
            oPartido.fecha = fecha;
            oPartido.equipoA = equipoa;
            oPartido.equipoB = equipob;
            oPartido.resultado = resultado;
            oPartido.juego = juego;
            oPartido.idArbitro = idarbitro;
            oPartido.idCompetencia = idcompetencia;

            return oPartido.Editar(oPartido);
        }
        #endregion

        #region Función Eliminar Partido
        //Metodo Eliminar que llama al metodo Eliminar en la clase MPartido de la Capa de Modelo
        public static string Eliminar(int idpartido)
        {
            MPartido oPartido = new MPartido();
            oPartido.idPartido = idpartido;

            return oPartido.Eliminar(oPartido);
        }
        #endregion

        #region Función Mostrar Partidos
        //Metodo Mostrar que llama al metodo Mostrar en la clase MPartido de la Capa de Modelo
        public static DataTable Mostrar()
        {
            return new MPartido().Mostrar();
        }
        #endregion

        #region Función BuscarPartidoPorJuego
        //Metodo BuscarPartidoPorJuego que llama al metodo BuscarPartidoPorJuego en la clase MPartido de la Capa de Modelo
        public static DataTable BuscarPartidoPorJuego(string textobuscar)
        {
            MPartido oPartido = new MPartido();
            oPartido.textoBuscar = textobuscar;

            return oPartido.BuscarPartidoPorJuego(oPartido);
        }
        #endregion

        #region Función BuscarPartidoPorEquipo
        //Metodo BuscarPartidoPorJuego que llama al metodo BuscarPartidoPorJuego en la clase MPartido de la Capa de Modelo
        public static DataTable BuscarPartidoPorEquipo(string textobuscar)
        {
            MPartido oPartido = new MPartido();
            oPartido.textoBuscar = textobuscar;

            return oPartido.BuscarPartidoPorEquipo(oPartido);
        }
        #endregion

        #region Función BuscarPartidoPorFecha
        //Metodo BuscarPartidoPorJuego que llama al metodo BuscarPartidoPorJuego en la clase MPartido de la Capa de Modelo
        public static DataTable BuscarPartidoPorFecha(string textobuscar)
        {
            DateTime fecha = DateTime.Parse(textobuscar);
            fecha = fecha.Date;
            string fechaString = fecha.ToString("yyyy-MM-dd");
            fechaString = fechaString.Replace("00:00:00", "");
            MPartido oPartido = new MPartido();
            oPartido.textoBuscar = fechaString;

            return oPartido.BuscarPartidoPorFecha(oPartido);
        }
        #endregion

        /*#region Función Enviar Email de Partido Programado
        public static void EnviarMailPartidoProgramado()
        {
            //Configuración Host SMTP
            SmtpClient servidorSMTP = new SmtpClient("c0490099.ferozo.com");
            MailMessage msg = new MailMessage();
            System.Net.NetworkCredential smtpCreds = new System.Net.NetworkCredential("plataforma@arenalegends.net", "ZBKz*5W4eS");
            servidorSMTP.Port = 587;
            servidorSMTP.UseDefaultCredentials = false;
            servidorSMTP.Credentials = smtpCreds;
            servidorSMTP.EnableSsl = true;

            //Rellenar Email
            string subject = "Partido Programado";
            string body = "Hay un nuevo partido programado";

            //Configuración Settings
            msg.Subject = subject;
            msg.Body = body;
            msg.From = new MailAddress("plataforma@arenalegends.net");
            msg.To.Add("ignaciobelando@gmail.com");

            //Enviar Email
            servidorSMTP.Send(msg);
        }
        #endregion

        #region Función Enviar Email de Partido En Curso
        public static void EnviarMailPartidoEnCurso()
        {
            //Configuración Host SMTP
            SmtpClient servidorSMTP = new SmtpClient("c0490099.ferozo.com");
            MailMessage msg = new MailMessage();
            System.Net.NetworkCredential smtpCreds = new System.Net.NetworkCredential("plataforma@arenalegends.net", "ZBKz*5W4eS");
            servidorSMTP.Port = 587;
            servidorSMTP.UseDefaultCredentials = false;
            servidorSMTP.Credentials = smtpCreds;
            servidorSMTP.EnableSsl = true;

            //Rellenar Email
            string subject = "Partido En Curso";
            string body = "Ya comenzó el partido";

            //Configuración Settings
            msg.Subject = subject;
            msg.Body = body;
            msg.From = new MailAddress("plataforma@arenalegends.net");
            msg.To.Add("ignaciobelando@gmail.com");

            //Enviar Email
            servidorSMTP.Send(msg);
        }
        #endregion

        #region Función Enviar Email de Partido Finalizado
        public static void EnviarMailPartidoFinalizado()
        {
            //Configuración Host SMTP
            SmtpClient servidorSMTP = new SmtpClient("c0490099.ferozo.com");
            MailMessage msg = new MailMessage();
            System.Net.NetworkCredential smtpCreds = new System.Net.NetworkCredential("plataforma@arenalegends.net", "ZBKz*5W4eS");
            servidorSMTP.Port = 587;
            servidorSMTP.UseDefaultCredentials = false;
            servidorSMTP.Credentials = smtpCreds;
            servidorSMTP.EnableSsl = true;

            //Rellenar Email
            string subject = "Partido Finalizado";
            string body = "El partido ya finalizó";

            //Configuración Settings
            msg.Subject = subject;
            msg.Body = body;
            msg.From = new MailAddress("plataforma@arenalegends.net");
            msg.To.Add("ignaciobelando@gmail.com");

            //Enviar Email
            servidorSMTP.Send(msg);
        }
        #endregion

        #region Patron State
        public class estadoPartido
        {
            public interface State
            {
                void Programado();
                void EnCurso();
                void Finalizado();
            }

            #region Atributos

            private State estado;                 // Estado actual del partido

            #endregion

            #region Propiedades

            // Asigna o recupera el estado del partido
            public State Estado
            {
                get { return estado; }
                set { estado = value; }
            }
   
            #endregion

            #region Metodos relacionados con los estados

            // Los metodos del contexto invocaran el metodo de la interfaz State, delegando las operaciones
            // dependientes del estado en las clases que los implementen.
            public void Programado()
            {
                //estado.Programado();
                EnviarMailPartidoProgramado();
            }

            public void EnCurso()
            {
                //estado.EnCurso();
                EnviarMailPartidoEnCurso();
            }

            public void Finalizado()
            {
                //estado.Finalizado();
                EnviarMailPartidoFinalizado();
            }

            #endregion

        }
        #endregion*/

        #region Función Auditoria Partidos
        public static string Auditar(int idpartido, DateTime fecha, string equipoa, string equipob, string resultado, string juego, int idarbitro, int idcompetencia, string tipoMovimiento, string nombreusuario)
        {

            #region Definicion Variables
            string rta = "";
            string resultadoOriginal = "";
            string EquipoAOriginal = "";
            string EquipoBOriginal = "";
            string JuegoOriginal = "";
            string ArbitroOriginal = "";
            string FechaOriginal = "";
            string idCompetenciaOriginal = "";
            #endregion

            #region Obtener Datos Originales del Registro
            SqlConnection SqlCon3 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon3.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando3 = new SqlCommand("Select * from Partidos where idPartido = " + idpartido, SqlCon3);
                SqlCon3.Open();
                SqlDataReader registro3 = comando3.ExecuteReader();
                while (registro3.Read())
                {
                    FechaOriginal = registro3["fecha"].ToString();
                    EquipoAOriginal = registro3["equipoA"].ToString();
                    EquipoBOriginal = registro3["equipoB"].ToString();
                    resultadoOriginal = registro3["resultado"].ToString();
                    JuegoOriginal = registro3["juego"].ToString();
                    ArbitroOriginal = registro3["arbitro"].ToString();
                    idCompetenciaOriginal = registro3["idCompetencia"].ToString();
                }
                SqlCon3.Close();
            }
            finally
            {
                if (SqlCon3.State == ConnectionState.Open)
                {
                    SqlCon3.Close();
                }
            }

            #endregion


            if (tipoMovimiento == "M")
            {

                #region Guardar Registro Original en la BD de Auditoria
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    var dateAndTime = DateTime.Now;
                    var date = dateAndTime.Date;
                    var time = dateAndTime.TimeOfDay;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaAuditoria;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("Insert into Partidos Values ('" + idpartido + "','" + FechaOriginal + "','" + EquipoAOriginal + "','" + EquipoBOriginal + "','" + resultadoOriginal + "','" + JuegoOriginal + "','" + ArbitroOriginal + "','" + idCompetenciaOriginal + "','" + nombreusuario + "','" + date + "','" + time + "','M')", SqlCon4);
                    SqlCon4.Open();
                    comando4.ExecuteNonQuery();
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

                rta = Editar(idpartido, fecha, equipoa, equipob, resultado, juego, idarbitro, idcompetencia);

            }
            else if (tipoMovimiento == "B")
            {
                #region Guardar Registro Original en la BD de Auditoria
                SqlConnection SqlCon8 = new SqlConnection();

                try
                {
                    var dateAndTime = DateTime.Now;
                    var date = dateAndTime.Date;
                    var time = dateAndTime.TimeOfDay;
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon8.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaAuditoria;Integrated Security=True";
                    SqlCommand comando8 = new SqlCommand("Insert into Partidos Values ('" + idpartido + "','" + FechaOriginal + "','" + EquipoAOriginal + "','" + EquipoBOriginal + "','" + resultadoOriginal + "','" + JuegoOriginal + "','" + ArbitroOriginal + "','" + idCompetenciaOriginal + "','" + nombreusuario + "','" + date + "','" + time + "','B')", SqlCon8);
                    SqlCon8.Open();
                    comando8.ExecuteNonQuery();
                    SqlCon8.Close();
                }
                finally
                {
                    if (SqlCon8.State == ConnectionState.Open)
                    {
                        SqlCon8.Close();
                    }
                }
                #endregion

                rta = Eliminar(idpartido);
            }

            return rta;

        }
        #endregion

    }
}
