using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MArbitro
    {
        private int _idArbitro;
        private int _idUsuario;

        //Texto que permite filtrar los arbitros dentro de mi tabla

        private string _textoBuscar;

        public int idArbitro { get => _idArbitro; set => _idArbitro = value; }
        public int idUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string textoBuscar { get => _textoBuscar; set => _textoBuscar = value; }

        #region Constructor Vacío
        //Constructor Vacío
        public MArbitro()
        {

        }
        #endregion

        #region Constructor con Parametros
        //Constructor con Parametros
        public MArbitro(int idarbitro, int idusuario, string textobuscar)
        {
            this.idArbitro = idarbitro;
            this.idUsuario = idusuario;
            this.textoBuscar = textobuscar;
        }
        #endregion

        #region Metodo Insertar Arbitro
        //Metodo Insertar 
        public string Insertar(MArbitro oArbitro)
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
                SqlCmd.CommandText = "spinsertar_arbitro";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idArbitro
                SqlParameter ParIdArbitro = new SqlParameter();
                ParIdArbitro.ParameterName = "@idarbitro";
                ParIdArbitro.SqlDbType = SqlDbType.Int;
                ParIdArbitro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdArbitro);

                //Estableciendo parametro de idUsuario
                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = oArbitro.idUsuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

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

        #region Metodo Editar Usuario
        //Metodo Editar Usuario
        public string Editar(MArbitro oArbitro)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_arbitro";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idArbitro
                SqlParameter ParIdArbitro = new SqlParameter();
                ParIdArbitro.ParameterName = "@idarbitro";
                ParIdArbitro.SqlDbType = SqlDbType.Int;
                ParIdArbitro.Value = oArbitro.idArbitro;
                SqlCmd.Parameters.Add(ParIdArbitro);

                //Estableciendo parametro de idUsuario
                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = oArbitro.idUsuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                //Ejecutamos nuestro comando
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizó el registro";
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

        #region Metodo Eliminar Usuario
        //Metodo Eliminar Usuario
        public string Eliminar(MArbitro oArbitro)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_arbitro";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idArbitro
                SqlParameter ParIdArbitro = new SqlParameter();
                ParIdArbitro.ParameterName = "@idarbitro";
                ParIdArbitro.SqlDbType = SqlDbType.Int;
                ParIdArbitro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdArbitro);

                //Ejecutamos nuestro comando
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el registro";
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

        #region Metodo Mostrar Arbitros
        //Metodo Mostrar Arbitros
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_usuarbitros";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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

        #region Metodo Buscar Arbitro Por Nickname
        //Metodo Buscar Arbitro por Nickname
        public DataTable BuscarArbitroPorNickname(MArbitro oArbitro)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_usuarbitros";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto a buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oArbitro.textoBuscar;
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
