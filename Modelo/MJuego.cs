using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MJuego
    {
        private int _idJuego;
        private string _nombreJuego;
        private string _reglamentoJuego;
        private byte[] _imagenJuego;

        //Texto que permite filtrar los juegos dentro de mi tabla
        private string _textoBuscar;

        public int idJuego { get => _idJuego; set => _idJuego = value; }
        public string nombreJuego { get => _nombreJuego; set => _nombreJuego = value; }
        public string reglamentoJuego { get => _reglamentoJuego; set => _reglamentoJuego = value; }
        public byte[] imagenJuego { get => _imagenJuego; set => _imagenJuego = value; }
        public string textoBuscar { get => _textoBuscar; set => _textoBuscar = value; }

        #region Constructor Vacío
        //Constructor Vacío
        public MJuego()
        {

        }
        #endregion

        #region Constructor con Parametros
        //Constructor con Parametros
        public MJuego(int idjuego, string nombrejuego, string textobuscar)
        {
            this.idJuego = idjuego;
            this.nombreJuego = nombrejuego;
            this.textoBuscar = textobuscar;
        }
        #endregion

        #region Metodo Insertar Juego
        //Metodo Insertar Juego
        public string Insertar(MJuego oJuego)
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
                SqlCmd.CommandText = "spinsertar_juego";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idJuego
                SqlParameter ParIdJuego = new SqlParameter();
                ParIdJuego.ParameterName = "@idjuego";
                ParIdJuego.SqlDbType = SqlDbType.Int;
                ParIdJuego.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdJuego);

                //Estableciendo parametro de nombreJuego
                SqlParameter ParNombreJuego = new SqlParameter();
                ParNombreJuego.ParameterName = "@nombrejuego";
                ParNombreJuego.SqlDbType = SqlDbType.NVarChar;
                ParNombreJuego.Size = 60;
                ParNombreJuego.Value = oJuego.nombreJuego;
                SqlCmd.Parameters.Add(ParNombreJuego);

                //Estableciendo parametro de imagenJuego
                SqlParameter ParImagenJuego = new SqlParameter();
                ParImagenJuego.ParameterName = "@imagenjuego";
                ParImagenJuego.SqlDbType = SqlDbType.Image;
                ParImagenJuego.Value = oJuego.imagenJuego;
                SqlCmd.Parameters.Add(ParImagenJuego);

                //Estableciendo parametro de reglamentoJuego
                SqlParameter ParReglamentoJuego = new SqlParameter();
                ParReglamentoJuego.ParameterName = "@reglamentojuego";
                ParReglamentoJuego.SqlDbType = SqlDbType.NVarChar;
                ParReglamentoJuego.Size = 1200;
                ParReglamentoJuego.Value = oJuego.reglamentoJuego;
                SqlCmd.Parameters.Add(ParReglamentoJuego);

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

        #region Metodo Editar Juego
        //Metodo Editar Juego
        public string Editar(MJuego oJuego)
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
                SqlCmd.CommandText = "speditar_juego";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idJuego
                SqlParameter ParIdJuego = new SqlParameter();
                ParIdJuego.ParameterName = "@idjuego";
                ParIdJuego.SqlDbType = SqlDbType.Int;
                ParIdJuego.Value = oJuego.idJuego;
                SqlCmd.Parameters.Add(ParIdJuego);

                //Estableciendo parametro de nombreJuego
                SqlParameter ParNombreJuego = new SqlParameter();
                ParNombreJuego.ParameterName = "@nombrejuego";
                ParNombreJuego.SqlDbType = SqlDbType.NVarChar;
                ParNombreJuego.Size = 60;
                ParNombreJuego.Value = oJuego.nombreJuego;
                SqlCmd.Parameters.Add(ParNombreJuego);

                //Estableciendo parametro de imagenJuego
                SqlParameter ParImagenJuego = new SqlParameter();
                ParImagenJuego.ParameterName = "@imagenjuego";
                ParImagenJuego.SqlDbType = SqlDbType.Image;
                ParImagenJuego.Value = oJuego.imagenJuego;
                SqlCmd.Parameters.Add(ParImagenJuego);

                //Estableciendo parametro de reglamentoJuego
                SqlParameter ParReglamentoJuego = new SqlParameter();
                ParReglamentoJuego.ParameterName = "@reglamento";
                ParReglamentoJuego.SqlDbType = SqlDbType.NVarChar;
                ParReglamentoJuego.Size = 1200;
                ParReglamentoJuego.Value = oJuego.reglamentoJuego;
                SqlCmd.Parameters.Add(ParReglamentoJuego);

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

        #region Metodo Eliminar Juego
        //Metodo Eliminar Juego
        public string Eliminar(MJuego oJuego)
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
                SqlCmd.CommandText = "speliminar_juego";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idJuego
                SqlParameter ParIdRol = new SqlParameter();
                ParIdRol.ParameterName = "@idjuego";
                ParIdRol.SqlDbType = SqlDbType.Int;
                ParIdRol.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdRol);

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

        #region Metodo Mostrar Juegos
        //Metodo Mostrar Juegos
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Juegos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_juegos";
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

        #region Metodo Buscar Juego Por Nombre de Juego
        //Metodo Buscar Juego por NombreJuego
        public DataTable BuscarJuegoPorNombre(MJuego oJuego)
        {
            DataTable DtResultado = new DataTable("Juegos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_juego";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oJuego.textoBuscar;
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