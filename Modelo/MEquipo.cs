using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MEquipo
    {
        private int _idEquipo;
        private string _nombre;
        private string _descripcion;
        private string _capitan;
        private string _jugadores;
        private byte[] _imagenequipo;

        //Texto que permite filtrar los equipos dentro de mi tabla
        private string _textoBuscar;

        public int idEquipo { get => _idEquipo; set => _idEquipo = value; }
        public string nombre { get => _nombre; set => _nombre = value; }
        public string descripcion { get => _descripcion; set => _descripcion = value; }
        public string capitan { get => _capitan; set => _capitan = value; }
        public string jugadores { get => _jugadores; set => _jugadores = value; }
        public byte[] imagenEquipo { get => _imagenequipo; set => _imagenequipo = value; }
        public string textoBuscar { get => _textoBuscar; set => _textoBuscar = value; }

        #region Constructor Vacío
        //Constructor Vacío
        public MEquipo()
        {

        }
        #endregion

        #region Constructor con Parametros
        //Constructor con Parametros
        public MEquipo(int idequipo, string nombre, string descripcion, string capitan, string jugadores, string textobuscar, byte[] imagenequipo)
        {
            this.idEquipo = idequipo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.capitan = capitan;
            this.jugadores = jugadores;
            this.imagenEquipo = imagenEquipo;
            this.textoBuscar = textobuscar;
        }
        #endregion

        #region Metodo Insertar Equipo
        //Metodo Insertar
        public string Insertar(MEquipo oEquipo)
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
                SqlCmd.CommandText = "spinsertar_equipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idEquipo
                SqlParameter ParIdEquipo = new SqlParameter();
                ParIdEquipo.ParameterName = "@idequipo";
                ParIdEquipo.SqlDbType = SqlDbType.Int;
                ParIdEquipo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdEquipo);

                //Estableciendo parametro de nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 60;
                ParNombre.Value = oEquipo.nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Estableciendo parametro de descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.NVarChar;
                ParDescripcion.Size = 60;
                ParDescripcion.Value = oEquipo.descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Estableciendo parametro de capitan
                SqlParameter ParCapitan = new SqlParameter();
                ParCapitan.ParameterName = "@capitan";
                ParCapitan.SqlDbType = SqlDbType.NVarChar;
                ParCapitan.Size = 60;
                ParCapitan.Value = oEquipo.capitan;
                SqlCmd.Parameters.Add(ParCapitan);

                //Estableciendo parametro de jugadores
                SqlParameter ParJugadores = new SqlParameter();
                ParJugadores.ParameterName = "@jugadores";
                ParJugadores.SqlDbType = SqlDbType.NVarChar;
                ParJugadores.Size = 60;
                ParJugadores.Value = oEquipo.jugadores;
                SqlCmd.Parameters.Add(ParJugadores);

                //Estableciendo parametro de imagenEquipo
                SqlParameter ParImagenEquipo = new SqlParameter();
                ParImagenEquipo.ParameterName = "@imagenequipo";
                ParImagenEquipo.SqlDbType = SqlDbType.Image;
                ParImagenEquipo.Value = oEquipo.imagenEquipo;
                SqlCmd.Parameters.Add(ParImagenEquipo);

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

        #region Metodo Editar Equipo
        //Metodo Editar
        public string Editar(MEquipo oEquipo)
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
                SqlCmd.CommandText = "speditar_equipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idEquipo
                SqlParameter ParIdEquipo = new SqlParameter();
                ParIdEquipo.ParameterName = "@idequipo";
                ParIdEquipo.SqlDbType = SqlDbType.Int;
                ParIdEquipo.Value = oEquipo.idEquipo;
                SqlCmd.Parameters.Add(ParIdEquipo);

                //Estableciendo parametro de nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 60;
                ParNombre.Value = oEquipo.nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Estableciendo parametro de descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.NVarChar;
                ParDescripcion.Size = 60;
                ParDescripcion.Value = oEquipo.descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Estableciendo parametro de capitan
                SqlParameter ParCapitan = new SqlParameter();
                ParCapitan.ParameterName = "@capitan";
                ParCapitan.SqlDbType = SqlDbType.NVarChar;
                ParCapitan.Size = 60;
                ParCapitan.Value = oEquipo.capitan;
                SqlCmd.Parameters.Add(ParCapitan);

                //Estableciendo parametro de jugadores
                SqlParameter ParJugadores = new SqlParameter();
                ParJugadores.ParameterName = "@jugadores";
                ParJugadores.SqlDbType = SqlDbType.NVarChar;
                ParJugadores.Size = 60;
                ParJugadores.Value = oEquipo.jugadores;
                SqlCmd.Parameters.Add(ParJugadores);

                //Estableciendo parametro de imagenEquipo
                SqlParameter ParImagenEquipo = new SqlParameter();
                ParImagenEquipo.ParameterName = "@imagenequipo";
                ParImagenEquipo.SqlDbType = SqlDbType.Image;
                ParImagenEquipo.Value = oEquipo.imagenEquipo;
                SqlCmd.Parameters.Add(ParImagenEquipo);

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

        #region Metodo Eliminar Equipo
        //Metodo Eliminar Equipo
        public string Eliminar(MEquipo oEquipo)
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
                SqlCmd.CommandText = "speliminar_equipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idEquipo
                SqlParameter ParIdEquipo = new SqlParameter();
                ParIdEquipo.ParameterName = "@idequipo";
                ParIdEquipo.SqlDbType = SqlDbType.Int;
                ParIdEquipo.Value = oEquipo.idEquipo;
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

        #region Metodo Mostrar Equipos
        //Metodo Mostrar Equipos
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Equipos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_equipos";
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

        #region Metodo Buscar Equipo Por Nombre
        //Metodo Buscar Equipo por Nombre
        public DataTable BuscarEquipoPorNombre(MEquipo oEquipo)
        {
            DataTable DtResultado = new DataTable("Equipos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_equipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oEquipo.textoBuscar;
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

        #region Metodo DevolverNumeroEquiposRegistrados
        //Metodo DevolverNumeroEquiposRegistrados
        public static Int32 DevolverNumeroEquiposRegistrados()
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
                SQLCmd.CommandText = "spcontar_equipos";
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
