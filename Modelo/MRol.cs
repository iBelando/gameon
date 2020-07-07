using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MRol
    {
        private int _idRol;
        private string _nombreRol;
        private string _frmRoles;

        //Texto que permite filtrar los roles dentro de mi tabla
        private string _textoBuscar;

        public int idRol { get => _idRol; set => _idRol = value; }
        public string nombreRol { get => _nombreRol; set => _nombreRol = value; }
        public string textoBuscar { get => _textoBuscar; set => _textoBuscar = value; }
        public string frmRoles { get => _frmRoles; set => _frmRoles = value; }

        #region Constructor Vacío
        //Constructor Vacío
        public MRol()
        {

        }
        #endregion

        #region Constructor con Parametros
        //Constructor con Parametros
        public MRol(int idrol, string nombrerol, string textobuscar)
        {
            this.idRol = idrol;
            this.nombreRol = nombrerol;
            this.textoBuscar = textobuscar;
        }
        #endregion

        #region Metodo Insertar Rol
        //Metodo Insertar
        public string Insertar(MRol oRol)
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
                SqlCmd.CommandText = "spinsertar_rol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idRol
                SqlParameter ParIdRol = new SqlParameter();
                ParIdRol.ParameterName = "@idrol";
                ParIdRol.SqlDbType = SqlDbType.Int;
                ParIdRol.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdRol);

                //Estableciendo parametro de nombreRol
                SqlParameter ParNombreRol = new SqlParameter();
                ParNombreRol.ParameterName = "@nombrerol";
                ParNombreRol.SqlDbType = SqlDbType.NVarChar;
                ParNombreRol.Size = 60;
                ParNombreRol.Value = oRol.nombreRol;
                SqlCmd.Parameters.Add(ParNombreRol);

                //Estableciendo parametro de frmRoles
                SqlParameter ParFormRoles = new SqlParameter();
                ParFormRoles.ParameterName = "@frmroles";
                ParFormRoles.SqlDbType = SqlDbType.NVarChar;
                ParFormRoles.Size = 900;
                ParFormRoles.Value = oRol.frmRoles;
                SqlCmd.Parameters.Add(ParFormRoles);

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

        #region Metodo Editar Rol
        //Metodo Editar Rol
        public string Editar(MRol oRol)
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
                SqlCmd.CommandText = "speditar_rol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idRol
                SqlParameter ParIdRol = new SqlParameter();
                ParIdRol.ParameterName = "@idrol";
                ParIdRol.SqlDbType = SqlDbType.Int;
                ParIdRol.Value = oRol.idRol;
                SqlCmd.Parameters.Add(ParIdRol);

                //Estableciendo parametro de nombreRol
                SqlParameter ParNombreRol = new SqlParameter();
                ParNombreRol.ParameterName = "@nombrerol";
                ParNombreRol.SqlDbType = SqlDbType.NVarChar;
                ParNombreRol.Size = 60;
                ParNombreRol.Value = oRol.nombreRol;
                SqlCmd.Parameters.Add(ParNombreRol);

                //Estableciendo parametro de frmRoles
                SqlParameter ParFrmRoles = new SqlParameter();
                ParFrmRoles.ParameterName = "@frmroles";
                ParFrmRoles.SqlDbType = SqlDbType.NVarChar;
                ParFrmRoles.Size = 900;
                ParFrmRoles.Value = oRol.frmRoles;
                SqlCmd.Parameters.Add(ParFrmRoles);

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

        #region Metodo Eliminar Rol
        //Metodo Eliminar Rol
        public string Eliminar(MRol oRol)
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
                SqlCmd.CommandText = "speliminar_rol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idRol
                SqlParameter ParIdRol = new SqlParameter();
                ParIdRol.ParameterName = "@idrol";
                ParIdRol.SqlDbType = SqlDbType.Int;
                ParIdRol.Value = oRol.idRol;
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

        #region Metodo Mostrar Roles
        //Metodo Mostrar Roles
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Roles");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_roles";
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

        #region Metodo Buscar Rol Por Nombre de Rol
        //Metodo Buscar Rol por NombreRol
        public DataTable BuscarRolporNombre(MRol oRol)
        {
            DataTable DtResultado = new DataTable("Roles");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_rol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oRol.textoBuscar;
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
