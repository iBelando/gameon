using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MCompetencia
    {
        private int _idCompetencia;
        private string _nombreCompetencia;
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private string _juego;
        private string _tipoCompetencia;
        private string _equiposInscriptos;
        private int _cupos;

        //Texto que permite filtrar los equipos dentro de mi tabla
        private string _textoBuscar;

        public int idCompetencia { get => _idCompetencia; set => _idCompetencia = value; }
        public string nombreCompetencia { get => _nombreCompetencia; set => _nombreCompetencia = value; }
        public DateTime fechaInicio { get => _fechaInicio; set => _fechaInicio = value; }
        public DateTime fechaFin { get => _fechaFin; set => _fechaFin = value; }
        public string juego { get => _juego; set => _juego = value; }
        public string tipoCompetencia { get => _tipoCompetencia; set => _tipoCompetencia = value; }
        public string equiposInscriptos { get => _equiposInscriptos; set => _equiposInscriptos = value; }
        public int cupos { get => _cupos; set => _cupos = value; }
        public string textoBuscar { get => _textoBuscar; set => _textoBuscar = value; }

        #region Constructor Vacío
        //Constructor Vacío
        public MCompetencia()
        {

        }
        #endregion

        #region Constructor con Parametros
        //Constructor con Parametros
        public MCompetencia(int idcompetencia, string nombrecompetencia, DateTime fechainicio, DateTime fechafin, string juego, string tipocompetencia, string equiposinscriptos, string textobuscar, int cupos)
        {
            this.idCompetencia = idcompetencia;
            this.nombreCompetencia = nombrecompetencia;
            this.fechaInicio = fechainicio;
            this.fechaFin = fechafin;
            this.juego = juego;
            this.tipoCompetencia = tipocompetencia;
            this.equiposInscriptos = equiposinscriptos;
            this.textoBuscar = textobuscar;
            this.cupos = cupos;
        }
        #endregion

        #region Metodo Insertar Competencia
        //Metodo Insertar
        public string Insertar(MCompetencia oCompetencia)
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
                SqlCmd.CommandText = "spinsertar_competencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idCompetencia
                SqlParameter ParIdCompetencia = new SqlParameter();
                ParIdCompetencia.ParameterName = "@idcompetencia";
                ParIdCompetencia.SqlDbType = SqlDbType.Int;
                ParIdCompetencia.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCompetencia);

                //Estableciendo parametro de nombreCompetencia
                SqlParameter ParNombreCompetencia = new SqlParameter();
                ParNombreCompetencia.ParameterName = "@nombrecompetencia";
                ParNombreCompetencia.SqlDbType = SqlDbType.NVarChar;
                ParNombreCompetencia.Size = 60;
                ParNombreCompetencia.Value = oCompetencia.nombreCompetencia;
                SqlCmd.Parameters.Add(ParNombreCompetencia);

                //Estableciendo parametro de fechaInicio
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fechainicio";
                ParFechaInicio.SqlDbType = SqlDbType.DateTime;
                ParFechaInicio.Value = oCompetencia.fechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);

                //Estableciendo parametro de fechaFin
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fechafin";
                ParFechaFin.SqlDbType = SqlDbType.DateTime;
                ParFechaFin.Value = oCompetencia.fechaFin;
                SqlCmd.Parameters.Add(ParFechaFin);

                //Estableciendo parametro de juego
                SqlParameter ParJuego = new SqlParameter();
                ParJuego.ParameterName = "@juego";
                ParJuego.SqlDbType = SqlDbType.NVarChar;
                ParJuego.Size = 60;
                ParJuego.Value = oCompetencia.juego;
                SqlCmd.Parameters.Add(ParJuego);

                //Estableciendo parametro de tipoCompetencia
                SqlParameter ParTipoCompetencia = new SqlParameter();
                ParTipoCompetencia.ParameterName = "@tipocompetencia";
                ParTipoCompetencia.SqlDbType = SqlDbType.NVarChar;
                ParTipoCompetencia.Size = 60;
                ParTipoCompetencia.Value = oCompetencia.tipoCompetencia;
                SqlCmd.Parameters.Add(ParTipoCompetencia);
                
                //Estableciendo parametro de equiposInscriptos
                SqlParameter ParCupos = new SqlParameter();
                ParCupos.ParameterName = "@cupos";
                ParCupos.SqlDbType = SqlDbType.Int;
                ParCupos.Value = oCompetencia.cupos;
                SqlCmd.Parameters.Add(ParCupos);

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

        #region Metodo Editar Competencia
        //Metodo Modificar
        public string Editar(MCompetencia oCompetencia)
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
                SqlCmd.CommandText = "speditar_competencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idCompetencia
                SqlParameter ParIdCompetencia = new SqlParameter();
                ParIdCompetencia.ParameterName = "@idcompetencia";
                ParIdCompetencia.SqlDbType = SqlDbType.Int;
                ParIdCompetencia.Value = oCompetencia.idCompetencia;
                SqlCmd.Parameters.Add(ParIdCompetencia);

                //Estableciendo parametro de nombreCompetencia
                SqlParameter ParNombreCompetencia = new SqlParameter();
                ParNombreCompetencia.ParameterName = "@nombrecompetencia";
                ParNombreCompetencia.SqlDbType = SqlDbType.NVarChar;
                ParNombreCompetencia.Size = 60;
                ParNombreCompetencia.Value = oCompetencia.nombreCompetencia;
                SqlCmd.Parameters.Add(ParNombreCompetencia);

                //Estableciendo parametro de fechaInicio
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fechainicio";
                ParFechaInicio.SqlDbType = SqlDbType.DateTime;
                ParFechaInicio.Value = oCompetencia.fechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);

                //Estableciendo parametro de fechaFin
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fechafin";
                ParFechaFin.SqlDbType = SqlDbType.DateTime;
                ParFechaFin.Value = oCompetencia.fechaFin;
                SqlCmd.Parameters.Add(ParFechaFin);

                //Estableciendo parametro de juego
                SqlParameter ParJuego = new SqlParameter();
                ParJuego.ParameterName = "@juego";
                ParJuego.SqlDbType = SqlDbType.NVarChar;
                ParJuego.Size = 60;
                ParJuego.Value = oCompetencia.juego;
                SqlCmd.Parameters.Add(ParJuego);

                //Estableciendo parametro de tipoCompetencia
                SqlParameter ParTipoCompetencia = new SqlParameter();
                ParTipoCompetencia.ParameterName = "@tipocompetencia";
                ParTipoCompetencia.SqlDbType = SqlDbType.NVarChar;
                ParTipoCompetencia.Size = 60;
                ParTipoCompetencia.Value = oCompetencia.tipoCompetencia;
                SqlCmd.Parameters.Add(ParTipoCompetencia);

                //Estableciendo parametro de cupos
                SqlParameter ParCupos = new SqlParameter();
                ParCupos.ParameterName = "@cupos";
                ParCupos.SqlDbType = SqlDbType.Int;
                ParCupos.Value = oCompetencia.cupos;
                SqlCmd.Parameters.Add(ParCupos);

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

        #region Metodo Eliminar Competencia
        //Metodo Eliminar Competencia
        public string Eliminar(MCompetencia oCompetencia)
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
                SqlCmd.CommandText = "speliminar_competencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idCompetencia
                SqlParameter ParIdCompetencia = new SqlParameter();
                ParIdCompetencia.ParameterName = "@idcompetencia";
                ParIdCompetencia.SqlDbType = SqlDbType.Int;
                ParIdCompetencia.Value = oCompetencia.idCompetencia;
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

        #region Metodo Mostrar Competencias
        //Metodo Mostrar Competencias
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Competencias");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_competencias";
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

        #region Metodo Mostrar Competencias
        //Metodo Mostrar Competencias
        public DataTable MostrarInscripcionesEnCompetencias()
        {
            DataTable DtResultado = new DataTable("Inscripciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_inscripcionescompetencias";
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

        #region Metodo Buscar Competencia Por Nombre
        //Metodo Buscar Competencia por Nombre
        public DataTable BuscarCompetenciaPorNombre(MCompetencia oCompetencia)
        {
            DataTable DtResultado = new DataTable("Competencias");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_competencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oCompetencia.textoBuscar;
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

        #region Metodo Buscar Competencia Por Juego
        //Metodo Buscar Competencia por Juego
        public DataTable BuscarCompetenciaPorJuego(MCompetencia oCompetencia)
        {
            DataTable DtResultado = new DataTable("Competencias");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_juegocompetencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oCompetencia.textoBuscar;
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

        #region Metodo Buscar Competencia Por Tipo
        //Metodo Buscar Competencia por Juego
        public DataTable BuscarCompetenciaPorTipo(MCompetencia oCompetencia)
        {
            DataTable DtResultado = new DataTable("Competencias");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_tipocompetencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oCompetencia.textoBuscar;
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

        #region Metodo Buscar Inscripciones de la Competencia
        //Metodo Buscar Competencia por Juego
        public DataTable BuscarInscripcionesCompetencia(MCompetencia oCompetencia)
        {
            DataTable DtResultado = new DataTable("Inscripciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_inscripcionescompetencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oCompetencia.textoBuscar;
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

        #region Metodo DevolverNumeroCompetenciasRealizadas
        //Metodo DevolverNumeroCompetenciasRealizadas
        public static Int32 DevolverNumeroCompetenciasRealizadas()
        {
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Abriendo Conexión SQL
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCon.Open();

                //Estableciendo el comando
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SqlCon;
                SQLCmd.CommandText = "spcontar_competencias";
                SQLCmd.CommandType = CommandType.StoredProcedure;
                Int32 count = (Int32)SQLCmd.ExecuteScalar();

                return count;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }
        #endregion

    }
}
