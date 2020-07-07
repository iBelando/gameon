using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MCodActivacion
    {
        private int _idCodigo;
        private int _idUsuario;
        private string _codigoActivacion;

        public int idCodigo { get => _idCodigo; set => _idCodigo = value; }
        public int idUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string codigoActivacion { get => _codigoActivacion; set => _codigoActivacion = value; }

        #region Constructor Vacío
        //Constructor vacío
        public MCodActivacion()
        {

        }
        #endregion

        #region Constructor con Parametros
        public MCodActivacion(int idcodigo, int idusuario, string codigoactivacion)
        {
            this.idCodigo = idcodigo;
            this.idUsuario = idusuario;
            this.codigoActivacion = codigoactivacion;
        }
        #endregion

        #region Metodo Insertar Codigo Activacion
        //Metodo Insertar Codigo Activacion
        public string InsertarCodigoActivacion(MCodActivacion oCodActivacion)
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
                SqlCmd.CommandText = "spinsertarcodigo_activacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idCodigo
                SqlParameter ParIdCodigo = new SqlParameter();
                ParIdCodigo.ParameterName = "@idcodigo";
                ParIdCodigo.SqlDbType = SqlDbType.Int;
                ParIdCodigo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCodigo);

                //Estableciendo parametro de usuarioID
                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@usuarioID";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = oCodActivacion.idUsuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                //Estableciendo parametro de codigoActivacion
                SqlParameter ParCodigoActivacion = new SqlParameter();
                ParCodigoActivacion.ParameterName = "@codigoactivacion";
                ParCodigoActivacion.SqlDbType = SqlDbType.NVarChar;
                ParCodigoActivacion.Size = 60;
                ParCodigoActivacion.Value = oCodActivacion.codigoActivacion;
                SqlCmd.Parameters.Add(ParCodigoActivacion);

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

        #region Metodo Validar Codigo Activacion
        //Metodo Realizar Login
        public DataTable ValidarCodigoActivacion(MCodActivacion oCodActivacion)
        {
            DataTable DtResultado = new DataTable("CodigosActivacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spvalidar_codactivacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@idusuario";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = oCodActivacion.idUsuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParCodActivacion = new SqlParameter();
                ParCodActivacion.ParameterName = "@codigoactivacion";
                ParCodActivacion.SqlDbType = SqlDbType.VarChar;
                ParCodActivacion.Size = 60;
                ParCodActivacion.Value = oCodActivacion.codigoActivacion;
                SqlCmd.Parameters.Add(ParCodActivacion);

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
