using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MUsuario
    {
        private int _idUsuario;
        private string _nickname;
        private string _pais;
        private DateTime _fechaNacimiento;
        private string _email;
        private string _equipos;
        private string _contraseña;
        private int _idRol;
        private byte[] _imagenPerfil;
        private int _estadoUsuario;

        //Texto que me permite filtrar los usuarios dentro de mi tabla
        private string _textoBuscar;

        public int idUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string nickname { get => _nickname; set => _nickname = value; }
        public string pais { get => _pais; set => _pais = value; }
        public DateTime fechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string email { get => _email; set => _email = value; }
        public string equipos { get => _equipos; set => _equipos = value; }
        public string contraseña { get => _contraseña; set => _contraseña = value; }
        public int idRol { get => _idRol; set => _idRol = value; }
        public byte[] imagenPerfil { get => _imagenPerfil; set => _imagenPerfil = value; }
        public int estadoUsuario { get => _estadoUsuario; set => _estadoUsuario = value; }
        public string textoBuscar { get => _textoBuscar; set => _textoBuscar = value; }

        #region Constructor Vacío
        //Constructor Vacío
        public MUsuario()
        {

        }
        #endregion

        #region Constructor con Parametros
        //Constructor con Parametros
        public MUsuario(int idusuario, string nickname, string pais, DateTime fechanacimiento, string email, string equipos, string contraseña, int idrol, byte[] imagenperfil, string textobuscar, int estadousuario)
        {
            this.idUsuario = idusuario;
            this.nickname = nickname;
            this.pais = pais;
            this.fechaNacimiento = fechanacimiento;
            this.email = email;
            this.equipos = equipos;
            this.contraseña = contraseña;
            this.idRol = idrol;
            this.imagenPerfil = imagenperfil;
            this.textoBuscar = textobuscar;
            this.estadoUsuario = estadousuario;
        }
        #endregion

        #region Metodo Insertar Usuario
        //Metodo Insertar Usuario
        public string Insertar(MUsuario oUsuario)
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
                SqlCmd.CommandText = "spinsertar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de IdUsuario
                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdUsuario);

                //Estableciendo parametro de nickname
                SqlParameter ParNickname = new SqlParameter();
                ParNickname.ParameterName = "@nickname";
                ParNickname.SqlDbType = SqlDbType.NVarChar;
                ParNickname.Size = 60;
                ParNickname.Value = oUsuario.nickname;
                SqlCmd.Parameters.Add(ParNickname);

                //Estableciendo parametro de Pais
                SqlParameter ParPais = new SqlParameter();
                ParPais.ParameterName = "@pais";
                ParPais.SqlDbType = SqlDbType.NVarChar;
                ParPais.Size = 60;
                ParPais.Value = oUsuario.pais;
                SqlCmd.Parameters.Add(ParPais);

                //Estableciendo parametro de fechaNacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fechanacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = oUsuario.fechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //Estableciendo parametro de email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.NVarChar;
                ParEmail.Size = 60;
                ParEmail.Value = oUsuario.email;
                SqlCmd.Parameters.Add(ParEmail);

                //Estableciendo parametro de equipos
                SqlParameter ParEquipos = new SqlParameter();
                ParEquipos.ParameterName = "@equipos";
                ParEquipos.SqlDbType = SqlDbType.NVarChar;
                ParEquipos.Size = 60;
                ParEquipos.Value = oUsuario.equipos;
                SqlCmd.Parameters.Add(ParEquipos);

                //Estableciendo parametro de contraseña
                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.NVarChar;
                ParContraseña.Size = 60;
                ParContraseña.Value = oUsuario.contraseña;
                SqlCmd.Parameters.Add(ParContraseña);

                //Estableciendo parametro de rolUsuario
                SqlParameter ParRolUsuario = new SqlParameter();
                ParRolUsuario.ParameterName = "@rolUsuario";
                ParRolUsuario.SqlDbType = SqlDbType.Int;
                ParRolUsuario.Value = oUsuario.idRol;
                SqlCmd.Parameters.Add(ParRolUsuario);

                //Estableciendo parametro de imagenPerfil
                SqlParameter ParImagenPerfil = new SqlParameter();
                ParImagenPerfil.ParameterName = "@imagenperfil";
                ParImagenPerfil.SqlDbType = SqlDbType.Image;
                ParImagenPerfil.Value = oUsuario.imagenPerfil;
                SqlCmd.Parameters.Add(ParImagenPerfil);

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
        public string Editar(MUsuario oUsuario)
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
                SqlCmd.CommandText = "speditar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de IdUsuario
                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = oUsuario.idUsuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                //Estableciendo parametro de nickname
                SqlParameter ParNickname = new SqlParameter();
                ParNickname.ParameterName = "@nickname";
                ParNickname.SqlDbType = SqlDbType.NVarChar;
                ParNickname.Size = 60;
                ParNickname.Value = oUsuario.nickname;
                SqlCmd.Parameters.Add(ParNickname);

                //Estableciendo parametro de Pais
                SqlParameter ParPais = new SqlParameter();
                ParPais.ParameterName = "@pais";
                ParPais.SqlDbType = SqlDbType.NVarChar;
                ParPais.Size = 60;
                ParPais.Value = oUsuario.pais;
                SqlCmd.Parameters.Add(ParPais);

                //Estableciendo parametro de fechaNacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fechanacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = oUsuario.fechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //Estableciendo parametro de email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.NVarChar;
                ParEmail.Size = 60;
                ParEmail.Value = oUsuario.email;
                SqlCmd.Parameters.Add(ParEmail);

                //Estableciendo parametro de idEquipo
                SqlParameter ParEquipos = new SqlParameter();
                ParEquipos.ParameterName = "@equipos";
                ParEquipos.SqlDbType = SqlDbType.NVarChar;
                ParEquipos.Size = 60;
                ParEquipos.Value = oUsuario.equipos;
                SqlCmd.Parameters.Add(ParEquipos);

                //Estableciendo parametro de contraseña
                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.NVarChar;
                ParContraseña.Size = 60;
                ParContraseña.Value = oUsuario.contraseña;
                SqlCmd.Parameters.Add(ParContraseña);

                //Estableciendo parametro de rolUsuario
                SqlParameter ParRolUsuario = new SqlParameter();
                ParRolUsuario.ParameterName = "@rolusuario";
                ParRolUsuario.SqlDbType = SqlDbType.Int;
                ParRolUsuario.Value = oUsuario.idRol;
                SqlCmd.Parameters.Add(ParRolUsuario);

                //Estableciendo parametro de imagenPerfil
                SqlParameter ParImagenPerfil = new SqlParameter();
                ParImagenPerfil.ParameterName = "@imagenperfil";
                ParImagenPerfil.SqlDbType = SqlDbType.Image;
                ParImagenPerfil.Value = oUsuario.imagenPerfil;
                SqlCmd.Parameters.Add(ParImagenPerfil);

                //Estableciendo parametro de estadoUsuario
                SqlParameter ParEstadoUsuario = new SqlParameter();
                ParEstadoUsuario.ParameterName = "@estadousuario";
                ParEstadoUsuario.SqlDbType = SqlDbType.Int;
                ParEstadoUsuario.Value = oUsuario.estadoUsuario;
                SqlCmd.Parameters.Add(ParEstadoUsuario);

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

        #region Metodo Editar Mi Perfil
        //Metodo Editar Mi Perfil
        public string EditarMiPerfil(MUsuario oUsuario)
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
                SqlCmd.CommandText = "speditar_miperfil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de IdUsuario
                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = oUsuario.idUsuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                //Estableciendo parametro de nickname
                SqlParameter ParNickname = new SqlParameter();
                ParNickname.ParameterName = "@nickname";
                ParNickname.SqlDbType = SqlDbType.NVarChar;
                ParNickname.Size = 60;
                ParNickname.Value = oUsuario.nickname;
                SqlCmd.Parameters.Add(ParNickname);

                //Estableciendo parametro de Pais
                SqlParameter ParPais = new SqlParameter();
                ParPais.ParameterName = "@pais";
                ParPais.SqlDbType = SqlDbType.NVarChar;
                ParPais.Size = 60;
                ParPais.Value = oUsuario.pais;
                SqlCmd.Parameters.Add(ParPais);

                //Estableciendo parametro de fechaNacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fechanacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = oUsuario.fechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //Estableciendo parametro de email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.NVarChar;
                ParEmail.Size = 60;
                ParEmail.Value = oUsuario.email;
                SqlCmd.Parameters.Add(ParEmail);

                //Estableciendo parametro de contraseña
                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.NVarChar;
                ParContraseña.Size = 60;
                ParContraseña.Value = oUsuario.contraseña;
                SqlCmd.Parameters.Add(ParContraseña);

                //Estableciendo parametro de imagenPerfil
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagenperfil";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = oUsuario.imagenPerfil;
                SqlCmd.Parameters.Add(ParImagen);

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

        #region Metodo Eliminar Usuario
        //Metodo Eliminar Usuario
        public string Eliminar(MUsuario oUsuario)
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
                SqlCmd.CommandText = "speliminar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de IdUsuario
                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = oUsuario.idUsuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

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

        #region Metodo Mostrar Usuarios
        //Metodo Mostrar Usuarios
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_usuarios";
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

        #region Metodo Buscar Usuario Por Nickname
        //Metodo Buscar Usuario por Nickname
        public DataTable BuscarUsuarioPorNickname(MUsuario oUsuario)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = oUsuario.textoBuscar;
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

        #region Metodo Buscar Email de Usuario
        //Metodo Buscar Email de Usuario
        public DataTable BuscarEmailUsuario(MUsuario oUsuario)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscaremail_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Establecer el parametro del texto buscar
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 60;
                ParEmail.Value = oUsuario.email;
                SqlCmd.Parameters.Add(ParEmail);

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

        #region Metodo Login
        //Metodo Realizar Login
        public DataTable Login(MUsuario oUsuario)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 60;
                ParUsuario.Value = oUsuario.nickname;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 60;
                ParPassword.Value = oUsuario.contraseña;
                SqlCmd.Parameters.Add(ParPassword);

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

        #region Metodo Reestablecer Contraseña de Usuario
        //Metodo Realizar Login
        public string ReestablecerContraseña(MUsuario oUsuario)
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
                SqlCmd.CommandText = "spreestablecercontraseña_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 60;
                ParEmail.Value = oUsuario.email;
                SqlCmd.Parameters.Add(ParEmail);

                //Estableciendo parametro de email
                SqlParameter ParNuevaContraseña = new SqlParameter();
                ParNuevaContraseña.ParameterName = "@nuevacontraseña";
                ParNuevaContraseña.SqlDbType = SqlDbType.VarChar;
                ParNuevaContraseña.Size = 60;
                ParNuevaContraseña.Value = oUsuario.contraseña;
                SqlCmd.Parameters.Add(ParNuevaContraseña);

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

        #region Metodo Registrar Usuario
        //Metodo Registrar Usuario
        public string Registrar(MUsuario oUsuario)
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
                SqlCmd.CommandText = "spregistrar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de IdUsuario
                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdUsuario);

                //Estableciendo parametro de nickname
                SqlParameter ParNickname = new SqlParameter();
                ParNickname.ParameterName = "@nickname";
                ParNickname.SqlDbType = SqlDbType.NVarChar;
                ParNickname.Size = 60;
                ParNickname.Value = oUsuario.nickname;
                SqlCmd.Parameters.Add(ParNickname);

                //Estableciendo parametro de email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.NVarChar;
                ParEmail.Size = 60;
                ParEmail.Value = oUsuario.email;
                SqlCmd.Parameters.Add(ParEmail);

                //Estableciendo parametro de contraseña
                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.NVarChar;
                ParContraseña.Size = 60;
                ParContraseña.Value = oUsuario.contraseña;
                SqlCmd.Parameters.Add(ParContraseña);

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

        #region Metodo Validar Registro
        //Metodo Realizar Login
        public DataTable ValidarRegistro(MUsuario oUsuario)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spvalidar_registro";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 60;
                ParUsuario.Value = oUsuario.nickname;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 60;
                ParEmail.Value = oUsuario.email;
                SqlCmd.Parameters.Add(ParEmail);

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

        #region Metodo Activar Usuario
        //Metodo Realizar Login
        public string ActivarUsuario(MUsuario oUsuario)
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
                SqlCmd.CommandText = "spactivar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo parametro de IdUsuario
                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = oUsuario.idUsuario;
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

        #region Metodo DevolverNumeroUsuariosRegistrados
        //Metodo DevolverNumeroUsuariosRegistrados
        public static Int32 DevolverNumeroUsuariosRegistrados()
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
                SQLCmd.CommandText = "spcontar_usuarios";
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

        #region Metodo Validar Usuario Existente
        //Metodo Realizar Login
        public DataTable ValidarUsuarioExistente(MUsuario oUsuario)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Plataforma.PPCn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spvalidarusuarioexistente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 60;
                ParUsuario.Value = oUsuario.nickname;
                SqlCmd.Parameters.Add(ParUsuario);

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
