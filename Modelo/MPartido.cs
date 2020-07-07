using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MPartido
    {
        private int _idPartido;
        private DateTime _fecha;
        private string _equipoA;
        private string _equipoB;
        private string _resultado;
        private string _juego;
        private int _idArbitro;
        private int _idCompetencia;

        //Texto que permite filtrar los partidos dentro de mi tabla
        private string _textoBuscar;

        public int idPartido { get => _idPartido; set => _idPartido = value; }
        public DateTime fecha { get => _fecha; set => _fecha = value; }
        public string equipoA { get => _equipoA; set => _equipoA = value; }
        public string equipoB { get => _equipoB; set => _equipoB = value; }
        public string resultado { get => _resultado; set => _resultado = value; }
        public string juego { get => _juego; set => _juego = value; }
        public int idArbitro { get => _idArbitro; set => _idArbitro = value; }
        public int idCompetencia { get => _idCompetencia; set => _idCompetencia = value; }
        public string textoBuscar { get => _textoBuscar; set => _textoBuscar = value; }

        #region Constructor Vacío
        //Constructor Vacío
        public MPartido()
        {

        }
        #endregion

        #region Constructor con Parametros
        //Constructor con Parametros
        public MPartido(int idpartido, DateTime fecha, string equipoa, string equipob, string resultado, string juego, int idarbitro, int idcompetencia, string textobuscar)
        {
            this.idPartido = idpartido;
            this.fecha = fecha;
            this.equipoA = equipoa;
            this.equipoB = equipob;
            this.resultado = resultado;
            this.idArbitro = idarbitro;
            this.idCompetencia = idcompetencia;
            this.textoBuscar = textobuscar;
        }
        #endregion

        #region Metodo Insertar Partido
        //Metodo Insertar Partido
        public string Insertar(MPartido oPartido)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Abriendo Conexión SQL
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCon.Open();

                //Estableciendo el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_partido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idPartido
                SqlParameter ParIdPartido = new SqlParameter();
                ParIdPartido.ParameterName = "@idpartido";
                ParIdPartido.SqlDbType = SqlDbType.Int;
                ParIdPartido.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdPartido);

                //Estableciendo parametro de fecha
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = oPartido.fecha;
                SqlCmd.Parameters.Add(ParFecha);

                //Estableciendo parametro de equipoA
                SqlParameter ParEquipoA = new SqlParameter();
                ParEquipoA.ParameterName = "@equipoa";
                ParEquipoA.SqlDbType = SqlDbType.Int;
                ParEquipoA.Value = oPartido.equipoA;
                SqlCmd.Parameters.Add(ParEquipoA);

                //Estableciendo parametro de equipoB
                SqlParameter ParEquipoB = new SqlParameter();
                ParEquipoB.ParameterName = "@equipob";
                ParEquipoB.SqlDbType = SqlDbType.Int;
                ParEquipoB.Value = oPartido.equipoB;
                SqlCmd.Parameters.Add(ParEquipoB);

                //Estableciendo parametro de resultado
                SqlParameter ParResultado = new SqlParameter();
                ParResultado.ParameterName = "@resultado";
                ParResultado.SqlDbType = SqlDbType.NVarChar;
                ParResultado.Size = 60;
                ParResultado.Value = oPartido.resultado;
                SqlCmd.Parameters.Add(ParResultado);

                //Estableciendo parametro de juego
                SqlParameter ParJuego = new SqlParameter();
                ParJuego.ParameterName = "@juego";
                ParJuego.SqlDbType = SqlDbType.NVarChar;
                ParJuego.Size = 60;
                ParJuego.Value = oPartido.juego;
                SqlCmd.Parameters.Add(ParJuego);

                //Estableciendo parametro de idArbitro
                SqlParameter ParIdArbitro = new SqlParameter();
                ParIdArbitro.ParameterName = "@idarbitro";
                ParIdArbitro.SqlDbType = SqlDbType.Int;
                ParIdArbitro.Value = oPartido.resultado;
                SqlCmd.Parameters.Add(ParIdArbitro);

                //Estableciendo parametro de idCompetencia
                SqlParameter ParIdCompetencia = new SqlParameter();
                ParIdCompetencia.ParameterName = "@idcompetencia";
                ParIdCompetencia.SqlDbType = SqlDbType.Int;
                ParIdCompetencia.Value = oPartido.resultado;
                SqlCmd.Parameters.Add(ParIdCompetencia);

                //Ejecutando SqlCmd
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }

            return respuesta;
        }
        #endregion

        #region Metodo Editar Partido
        public string Editar(MPartido oPartido)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Abriendo Conexión SQL
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCon.Open();

                //Estableciendo el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_partido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idPartido
                SqlParameter ParIdPartido = new SqlParameter();
                ParIdPartido.ParameterName = "@idpartido";
                ParIdPartido.SqlDbType = SqlDbType.Int;
                ParIdPartido.Value = oPartido.idPartido;
                SqlCmd.Parameters.Add(ParIdPartido);

                //Estableciendo parametro de fecha
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = oPartido.fecha;
                SqlCmd.Parameters.Add(ParFecha);

                //Estableciendo parametro de equipoA
                SqlParameter ParEquipoA = new SqlParameter();
                ParEquipoA.ParameterName = "@equipoa";
                ParEquipoA.SqlDbType = SqlDbType.NVarChar;
                ParEquipoA.Size = 60;
                ParEquipoA.Value = oPartido.equipoA;
                SqlCmd.Parameters.Add(ParEquipoA);

                //Estableciendo parametro de equipoB
                SqlParameter ParEquipoB = new SqlParameter();
                ParEquipoB.ParameterName = "@equipob";
                ParEquipoB.SqlDbType = SqlDbType.NVarChar;
                ParEquipoB.Size = 60;
                ParEquipoB.Value = oPartido.equipoB;
                SqlCmd.Parameters.Add(ParEquipoB);

                //Estableciendo parametro de resultado
                SqlParameter ParResultado = new SqlParameter();
                ParResultado.ParameterName = "@resultado";
                ParResultado.SqlDbType = SqlDbType.NVarChar;
                ParResultado.Size = 60;
                ParResultado.Value = oPartido.resultado;
                SqlCmd.Parameters.Add(ParResultado);

                //Estableciendo parametro de juego
                SqlParameter ParJuego = new SqlParameter();
                ParJuego.ParameterName = "@juego";
                ParJuego.SqlDbType = SqlDbType.NVarChar;
                ParJuego.Size = 60;
                ParJuego.Value = oPartido.juego;
                SqlCmd.Parameters.Add(ParJuego);

                //Estableciendo parametro de idArbitro
                SqlParameter ParIdArbitro = new SqlParameter();
                ParIdArbitro.ParameterName = "@arbitro";
                ParIdArbitro.SqlDbType = SqlDbType.Int;
                ParIdArbitro.Value = oPartido.idArbitro;
                SqlCmd.Parameters.Add(ParIdArbitro);

                //Estableciendo parametro de idCompetencia
                SqlParameter ParIdCompetencia = new SqlParameter();
                ParIdCompetencia.ParameterName = "@idcompetencia";
                ParIdCompetencia.SqlDbType = SqlDbType.Int;
                ParIdCompetencia.Value = oPartido.idCompetencia;
                SqlCmd.Parameters.Add(ParIdCompetencia);

                //Ejecutando SqlCmd
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }

            return respuesta;
        }
        #endregion

        #region Metodo Eliminar Partido
        //Metodo Eliminar Partido
        public string Eliminar(MPartido oPartido)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Abriendo Conexión SQL
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCon.Open();

                //Estableciendo el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_partido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idEquipo
                SqlParameter ParIdPartido = new SqlParameter();
                ParIdPartido.ParameterName = "@idpartido";
                ParIdPartido.SqlDbType = SqlDbType.Int;
                ParIdPartido.Value = oPartido.idPartido;
                SqlCmd.Parameters.Add(ParIdPartido);

                //Ejecutando SqlCmd
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }

            return respuesta;
        }
        #endregion

        #region Metodo Mostrar Partidos
        //Metodo Mostrar Partidos
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Partidos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_partidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion

        #region Metodo Buscar Partido Por Juego
        //Metodo Buscar Partido por Juego
        public DataTable BuscarPartidoPorJuego(MPartido oPartido)
        {
            DataTable DtResultado = new DataTable("Partidos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_partido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oPartido.textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion

        #region Metodo Buscar Partido Por Equipo
        //Metodo Buscar Partido por Juego
        public DataTable BuscarPartidoPorEquipo(MPartido oPartido)
        {
            DataTable DtResultado = new DataTable("Partidos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_equipopartido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oPartido.textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion

        #region Metodo Buscar Partido Por Fecha
        //Metodo Buscar Partido por Juego
        public DataTable BuscarPartidoPorFecha(MPartido oPartido)
        {
            DataTable DtResultado = new DataTable("Partidos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_fechapartido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oPartido.textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion

    }
}
