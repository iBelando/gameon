using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MInscripcion
    {
        private int _idInscripcion;
        private DateTime _fechaInscripcion;
        private int _idCompetencia;
        private int _idEquipo;

        //Texto que permite filtrar los equipos dentro de mi tabla
        private string _textoBuscar;

        public int idInscripcion { get => _idInscripcion; set => _idInscripcion = value; }
        public DateTime fechaInscripcion { get => _fechaInscripcion; set => _fechaInscripcion = value; }
        public int idCompetencia { get => _idCompetencia; set => _idCompetencia = value; }
        public int idEquipo { get => _idEquipo; set => _idEquipo = value; }
        public string textoBuscar { get => _textoBuscar; set => _textoBuscar = value; }

        #region Constructor Vacío
        //Constructor Vacío
        public MInscripcion()
        {

        }
        #endregion

        #region Constructor con Parametros
        //Constructor con Parametros
        public MInscripcion(int idinscripcion, DateTime fechainscripcion, int idcompetencia, int idequipo, string textobuscar)
        {
            this.idInscripcion = idinscripcion;
            this.fechaInscripcion = fechaInscripcion;
            this.idCompetencia = idcompetencia;
            this.idEquipo = idequipo;
            this.textoBuscar = textobuscar;
        }
        #endregion

        #region Metodo Insertar Competencia
        //Metodo Insertar
        public string Insertar(MInscripcion oInscripcion)
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
                SqlCmd.CommandText = "spinsertar_inscripcion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idInscripcion
                SqlParameter ParIdInscripcion = new SqlParameter();
                ParIdInscripcion.ParameterName = "@idInscripcion";
                ParIdInscripcion.SqlDbType = SqlDbType.Int;
                ParIdInscripcion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdInscripcion);

                //Estableciendo parametro de idCompetencia
                SqlParameter ParIdCompetencia = new SqlParameter();
                ParIdCompetencia.ParameterName = "@idCompetencia";
                ParIdCompetencia.SqlDbType = SqlDbType.Int;
                ParIdCompetencia.Value = oInscripcion.idCompetencia;
                SqlCmd.Parameters.Add(ParIdCompetencia);

                //Estableciendo parametro de idEquipo
                SqlParameter ParIdEquipo = new SqlParameter();
                ParIdEquipo.ParameterName = "@idequipo";
                ParIdEquipo.SqlDbType = SqlDbType.Int;
                ParIdEquipo.Value = oInscripcion.idEquipo;
                SqlCmd.Parameters.Add(ParIdEquipo);

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

        #region Metodo Eliminar Inscripcion
        //Metodo Eliminar Competencia
        public string Eliminar(MInscripcion oInscripcion)
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
                SqlCmd.CommandText = "speliminar_inscripcion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idCompetencia
                SqlParameter ParIdCompetencia = new SqlParameter();
                ParIdCompetencia.ParameterName = "@idinscripcion";
                ParIdCompetencia.SqlDbType = SqlDbType.Int;
                ParIdCompetencia.Value = oInscripcion.idInscripcion;
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

        #region Metodo Eliminar Inscripcion con el IdEquipo
        //Metodo Eliminar Inscripcion
        public string EliminarIdEquipo(MInscripcion oInscripcion)
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
                SqlCmd.CommandText = "speliminar_inscripcionIDEQUIPO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idCompetencia
                SqlParameter ParIdEquipo = new SqlParameter();
                ParIdEquipo.ParameterName = "@idequipo";
                ParIdEquipo.SqlDbType = SqlDbType.Int;
                ParIdEquipo.Value = oInscripcion.idEquipo;
                SqlCmd.Parameters.Add(ParIdEquipo);

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

        #region Metodo Buscar Inscripcion Por Equipo
        //Metodo Buscar Competencia por Nombre
        public DataTable BuscarInscripcionPorEquipo(MInscripcion oInscripcion)
        {
            DataTable DtResultado = new DataTable("Inscripciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_equipoinscripcion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oInscripcion.textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion

        #region Metodo Buscar Inscripcion Por Juego
        //Metodo Buscar Competencia por Nombre
        public DataTable BuscarInscripcionPorJuego(MInscripcion oInscripcion)
        {
            DataTable DtResultado = new DataTable("Inscripciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_juegoinscripcion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oInscripcion.textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion

        #region Metodo Buscar Inscripcion Por Tipo
        //Metodo Buscar Competencia por Nombre
        public DataTable BuscarInscripcionPorTipo(MInscripcion oInscripcion)
        {
            DataTable DtResultado = new DataTable("Inscripciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_tipoinscripcion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oInscripcion.textoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
        #endregion
    }
}
