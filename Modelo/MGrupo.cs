using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MGrupo
    {
        private int _idGrupo;
        private string _nombreGrupo;
        private int _idRol;

        //Texto que permite filtrar los juegos dentro de mi tabla
        private string _textoBuscar;

        public int idGrupo { get => _idGrupo; set => _idGrupo = value; }
        public string nombreGrupo { get => _nombreGrupo; set => _nombreGrupo = value; }
        public string textoBuscar { get => _textoBuscar; set => _textoBuscar = value; }
        public int idRol { get => _idRol; set => _idRol = value; }

        #region Constructor Vacío
        //Constructor Vacío
        public MGrupo()
        {

        }
        #endregion

        #region Constructor con Parametros
        //Constructor con Parametros
        public MGrupo(int idgrupo, string nombregrupo, string textobuscar)
        {
            this.idGrupo = idgrupo;
            this.nombreGrupo = nombregrupo;
            this.textoBuscar = textobuscar;
        }
        #endregion

        #region Metodo Insertar Grupo
        //Metodo Insertar Grupo
        public string Insertar(MGrupo oGrupo)
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
                SqlCmd.CommandText = "spinsertar_grupo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idGrupo
                SqlParameter ParIdGrupo = new SqlParameter();
                ParIdGrupo.ParameterName = "@idgrupo";
                ParIdGrupo.SqlDbType = SqlDbType.Int;
                ParIdGrupo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdGrupo);

                //Estableciendo parametro de nombreGrupo
                SqlParameter ParNombreGrupo = new SqlParameter();
                ParNombreGrupo.ParameterName = "@nombregrupo";
                ParNombreGrupo.SqlDbType = SqlDbType.NVarChar;
                ParNombreGrupo.Size = 60;
                ParNombreGrupo.Value = oGrupo.nombreGrupo;
                SqlCmd.Parameters.Add(ParNombreGrupo);

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

        #region Metodo Asociar Grupo con Rol
        //Metodo Insertar Grupo
        public string AsociarGrupoConRol(MGrupo oGrupo)
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
                SqlCmd.CommandText = "spinsertar_rolgrupo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idGrupo
                SqlParameter ParIdGrupo = new SqlParameter();
                ParIdGrupo.ParameterName = "@idgrupo";
                ParIdGrupo.SqlDbType = SqlDbType.Int;
                ParIdGrupo.Value = oGrupo.idGrupo;
                SqlCmd.Parameters.Add(ParIdGrupo);

                //Estableciendo parametro de idRol
                SqlParameter ParIdRol = new SqlParameter();
                ParIdRol.ParameterName = "@idrol";
                ParIdRol.SqlDbType = SqlDbType.Int;
                ParIdRol.Value = oGrupo.idRol;
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

        #region Metodo Editar Grupo
        //Metodo Editar Grupo
        public string Editar(MGrupo oGrupo)
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
                SqlCmd.CommandText = "speditar_grupo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idGrupo
                SqlParameter ParIdGrupo = new SqlParameter();
                ParIdGrupo.ParameterName = "@idgrupo";
                ParIdGrupo.SqlDbType = SqlDbType.Int;
                ParIdGrupo.Value = oGrupo.idGrupo;
                SqlCmd.Parameters.Add(ParIdGrupo);

                //Estableciendo parametro de nombreGrupo
                SqlParameter ParNombreGrupo = new SqlParameter();
                ParNombreGrupo.ParameterName = "@nombregrupo";
                ParNombreGrupo.SqlDbType = SqlDbType.NVarChar;
                ParNombreGrupo.Size = 60;
                ParNombreGrupo.Value = oGrupo.nombreGrupo;
                SqlCmd.Parameters.Add(ParNombreGrupo);

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

        #region Metodo Eliminar Grupo
        //Metodo Eliminar Grupo
        public string Eliminar(MGrupo oGrupo)
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
                SqlCmd.CommandText = "speliminar_grupo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idGrupo
                SqlParameter ParIdGrupo = new SqlParameter();
                ParIdGrupo.ParameterName = "@idgrupo";
                ParIdGrupo.SqlDbType = SqlDbType.Int;
                ParIdGrupo.Value = oGrupo.idGrupo;
                SqlCmd.Parameters.Add(ParIdGrupo);

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

        #region Metodo Eliminar Grupo con Roles Asociados
        //Metodo Eliminar Grupo
        public string EliminarGrupoConRolesAsociados(MGrupo oGrupo)
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
                SqlCmd.CommandText = "speliminar_gruporoles";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de idGrupo
                SqlParameter ParIdGrupo = new SqlParameter();
                ParIdGrupo.ParameterName = "@idgrupo";
                ParIdGrupo.SqlDbType = SqlDbType.Int;
                ParIdGrupo.Value = oGrupo.idGrupo;
                SqlCmd.Parameters.Add(ParIdGrupo);

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

        #region Metodo Mostrar Grupos
        //Metodo Mostrar Grupos
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Grupos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_grupos";
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

        #region Metodo Buscar Grupo Por Nombre de Grupo
        //Metodo Buscar Grupo por NombreGrupo
        public DataTable BuscarGrupoporNombre(MGrupo oGrupo)
        {
            DataTable DtResultado = new DataTable("Grupos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_grupo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oGrupo.textoBuscar;
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