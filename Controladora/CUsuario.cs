using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Mail;
using Modelo;

namespace Controladora
{
    public class CUsuario
    {
        #region Singleton
        private static CUsuario _instance = null;
        private CUsuario()
        { }

        public static CUsuario Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CUsuario();
                return _instance;
            }
        }
        #endregion

        #region Función Insertar Usuario
        //Metodo Insertar que llama al metodo Insertar en la clase MUsuario de la Capa de Modelo
        public static string Insertar(string nickname, string pais, DateTime fechanacimiento, string email, string equipos, string contraseña, int idrol, byte[] imagenperfil)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.nickname = nickname;
            oUsuario.pais = pais;
            oUsuario.fechaNacimiento = fechanacimiento;
            oUsuario.email = email;
            oUsuario.equipos = equipos;
            oUsuario.contraseña = contraseña;
            oUsuario.idRol = idrol;
            oUsuario.imagenPerfil = imagenperfil;

            return oUsuario.Insertar(oUsuario);
        }
        #endregion

        #region Función Editar Usuario
        //Metodo Modificar que llama al metodo Modificar en la clase MUsuario de la Capa de Modelo
        public static string Editar(int idusuario, string nickname, string pais, DateTime fechanacimiento, string email, string equipos, string contraseña, int idrol, byte[] imagenperfil, int estadousuario)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.idUsuario = idusuario;
            oUsuario.nickname = nickname;
            oUsuario.pais = pais;
            oUsuario.fechaNacimiento = fechanacimiento;
            oUsuario.email = email;
            oUsuario.equipos = equipos;
            oUsuario.contraseña = contraseña;
            oUsuario.idRol = idrol;
            oUsuario.imagenPerfil = imagenperfil;
            oUsuario.estadoUsuario = estadousuario;

            return oUsuario.Editar(oUsuario);
        }
        #endregion

        #region Función Editar Mi Perfil
        //Metodo EditarMiPerfil que llama al metodo Modificar en la clase MUsuario de la Capa de Modelo
        public static string EditarMiPerfil(int idusuario, string nickname, string pais, DateTime fechanacimiento, string email, string contraseña, byte[] imagenperfil)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.idUsuario = idusuario;
            oUsuario.nickname = nickname;
            oUsuario.pais = pais;
            oUsuario.fechaNacimiento = fechanacimiento;
            oUsuario.email = email;
            oUsuario.contraseña = contraseña;
            oUsuario.imagenPerfil = imagenperfil;

            return oUsuario.EditarMiPerfil(oUsuario);
        }
        #endregion

        #region Función Eliminar Usuario
        //Metodo Eliminar que llama al metodo Eliminar en la clase MUsuario de la Capa de Modelo
        public static string Eliminar(int idusuario)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.idUsuario = idusuario;

            return oUsuario.Eliminar(oUsuario);
        }
        #endregion

        #region Función Mostrar Usuarios
        //Metodo Mostrar que llama al metodo Mostrar en la clase MUsuario de la Capa de Modelo
        public static DataTable Mostrar()
        {
            return new MUsuario().Mostrar();
        }
        #endregion

        #region Función BuscarUsuarioPorNickname
        //Metodo BuscarUsuarioPorNickname que llama al metodo BuscarUsuarioPorNickname en la clase MUsuario de la Capa de Modelo
        public static DataTable BuscarUsuarioPorNickname(string textobuscar)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.textoBuscar = textobuscar;

            return oUsuario.BuscarUsuarioPorNickname(oUsuario);
        }
        #endregion

        #region Función BuscarEmailUsuario
        //Metodo BuscarUsuarioPorNickname que llama al metodo BuscarUsuarioPorNickname en la clase MUsuario de la Capa de Modelo
        public static DataTable BuscarEmailUsuario(string emailUsuario)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.email = emailUsuario;

            return oUsuario.BuscarEmailUsuario(oUsuario);
        }
        #endregion

        #region Función Login
        //Metodo Realizar Login
        public static DataTable Login(string usuario, string password)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.nickname = usuario;
            oUsuario.contraseña = password;

            return oUsuario.Login(oUsuario);
        }
        #endregion

        #region Función Reestablecer Contraseña
        //Metodo Activar Usuario que llama al metodo Activar Usuario en la clase MUsuario de la Capa de Modelo
        public static string ReestablecerContraseña(string emailUsuario, string contraseñanueva)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.email = emailUsuario;
            oUsuario.contraseña = contraseñanueva;

            return oUsuario.ReestablecerContraseña(oUsuario);
        }
        #endregion

        #region Función Generar Nueva Contraseña
        public static string GenerarNuevaContraseña()
        {
            int longitud = 12;
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }
        #endregion

        #region Función Registrar
        //Metodo Registrar que llama al metodo Registrar en la clase MUsuario de la Capa de Modelo
        public static string Registrar(string nickname, string email, string contraseña)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.nickname = nickname;
            oUsuario.email = email;
            oUsuario.contraseña = contraseña;

            return oUsuario.Registrar(oUsuario);
        }
        #endregion

        #region Función Validar Registro
        //Metodo Validar Registro
        public static DataTable ValidarRegistro(string usuario, string email)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.nickname = usuario;
            oUsuario.email = email;

            return oUsuario.ValidarRegistro(oUsuario);
        }
        #endregion

        #region Función Activar Usuario
        //Metodo Activar Usuario que llama al metodo Activar Usuario en la clase MUsuario de la Capa de Modelo
        public static string ActivarUsuario(int idusuario)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.idUsuario = idusuario;

            return oUsuario.ActivarUsuario(oUsuario);
        }
        #endregion

        #region Función Enviar Email de Registro
        public static void EnviarMailRegistro(string sendto, string codigoActivacion)
        {
            //Configuración Host SMTP
            SmtpClient servidorSMTP = new SmtpClient("mail.arenalegends.net");
            MailMessage msg = new MailMessage();
            System.Net.NetworkCredential smtpCreds = new System.Net.NetworkCredential("plataforma@arenalegends.net", "(bhL-)V0or5y");
            servidorSMTP.Port = 587;
            servidorSMTP.UseDefaultCredentials = false;
            servidorSMTP.Credentials = smtpCreds;
            servidorSMTP.EnableSsl = true;

            //Rellenar Email
            string subject = "¡Bienvenido a Arena Legends!";
            string body = "Para finalizar tu registro en la plataforma, por favor, ingresa el siguiente código de activación: " + codigoActivacion;

            //Configuración Settings
            msg.Subject = subject;
            msg.Body = body;
            msg.From = new MailAddress("plataforma@arenalegends.net");
            msg.To.Add(sendto);

            //Enviar Email
            servidorSMTP.Send(msg);
        }
        #endregion

        #region Función Enviar Email de Reestablecer Contraseña
        public static void EnviarMailReestablecerContraseña(string sendto, string contraseñanueva)
        {
            //Configuración Host SMTP
            SmtpClient servidorSMTP = new SmtpClient("mail.arenalegends.net");
            MailMessage msg = new MailMessage();
            System.Net.NetworkCredential smtpCreds = new System.Net.NetworkCredential("plataforma@arenalegends.net", "(bhL-)V0or5y");
            servidorSMTP.Port = 587;
            servidorSMTP.UseDefaultCredentials = false;
            servidorSMTP.Credentials = smtpCreds;
            servidorSMTP.EnableSsl = true;

            //Rellenar Email
            string subject = "¡Nueva Contraseña para Arena Legends!";
            string body = "Te envíamos tu nueva contraseña para que puedas acceder a la plataforma: " + contraseñanueva;

            //Configuración Settings
            msg.Subject = subject;
            msg.Body = body;
            msg.From = new MailAddress("plataforma@arenalegends.net");
            msg.To.Add(sendto);

            //Enviar Email
            servidorSMTP.Send(msg);
        }
        #endregion

        #region Encriptar Contraseña
        public static string EncriptarContraseña(string contraseña)
        {
            string contraseñaEncriptada = string.Empty;
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(contraseña);
            contraseñaEncriptada = Convert.ToBase64String(encrypted);
            return contraseñaEncriptada;
        }
        #endregion

        #region Desencriptar Contraseña
        public static string DesencriptarContraseña(string contraseñaEncriptada)
        {
            string contraseñaDesencriptada = string.Empty;
            byte[] decrypted = Convert.FromBase64String(contraseñaEncriptada);
            contraseñaDesencriptada = System.Text.Encoding.Unicode.GetString(decrypted);
            return contraseñaDesencriptada;
        }
        #endregion

        #region Función Credenciales del Usuario
        public static string CredencialesUsuario(DataTable datos, string infoSolicitada)
        {
            string infoDevuelta = string.Empty;
            switch (infoSolicitada)
            {
                case "idUsuario":
                    infoDevuelta = datos.Rows[0][0].ToString();
                    break;
                case "nicknameUsuario":
                    infoDevuelta = datos.Rows[0][1].ToString();
                    break;
                case "paisUsuario":
                    infoDevuelta = datos.Rows[0][2].ToString();
                    break;
                case "fechaNacimientoUsuario":
                    infoDevuelta = datos.Rows[0][3].ToString();
                    break;
                case "emailUsuario":
                    infoDevuelta = datos.Rows[0][4].ToString();
                    break;
                case "rolUsuario":
                    infoDevuelta = datos.Rows[0][6].ToString();
                    break;
                case "imagenPerfilUsuario":
                    infoDevuelta = datos.Rows[0][7].ToString();
                    break;
                case "estadoUsuario":
                    infoDevuelta = datos.Rows[0][8].ToString();
                    break;
                case "equiposUsuario":
                    infoDevuelta = datos.Rows[0][9].ToString();
                    break;
            }

            return infoDevuelta;
        }
        #endregion

        #region Función EsRolAdministrador
        public static bool EsRolAdministrador(string rolUsuario)
        {
            bool resultado;

            if (rolUsuario == "1")
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }

            return resultado;
        }
        #endregion

        #region Función Mostrar Nombre del Rol
        public static string MostrarNombreRol(string rolUsuario)
        {
            string nombreRol = string.Empty;
            switch (rolUsuario)
            {
                case "1":
                    nombreRol = "Administrador";
                    break;
                case "2":
                    nombreRol = "Arbitro";
                    break;
                case "3":
                    nombreRol = "Jugador";
                    break;
            }

            return nombreRol;
        }
        #endregion

        #region Función Mostrar Pais del Usuario
        public static string MostrarPaisUsuario(string paisUsuario)
        {
            string paisDevuelto = string.Empty;
            if (String.IsNullOrEmpty(paisUsuario))
            {
                paisDevuelto = "";
            }
            else
            {
                paisDevuelto = paisUsuario;
            }

            return paisDevuelto;
        }
        #endregion

        #region Función Mostrar Imagen del Usuario
        public static byte[] MostrarImagenUsuario(DataTable datos)
        {
            // Se almacena en un buffer
            byte[] imageBuffer = (byte[])datos.Rows[0]["imagenPerfil"];
            return imageBuffer;
        }
        #endregion

        #region Validar Nueva Contraseña
        public static string ValidarNuevaContraseña(string contraseñausuario, string txtNuevaContraseña)
        {
            string nuevaContraseña = "";
            if (String.IsNullOrEmpty(txtNuevaContraseña) || txtNuevaContraseña == "Contraseña..")
            {
                nuevaContraseña = contraseñausuario;
            }
            else
            {
                nuevaContraseña = CUsuario.EncriptarContraseña(txtNuevaContraseña);
            }

            return nuevaContraseña;

        }
        #endregion

        #region Funcion Devolver Numero de Usuarios Registrados
        public static Int32 DevolverNumeroUsuariosRegistrados()
        {
            Int32 count = MUsuario.DevolverNumeroUsuariosRegistrados();
            return count;
        }
        #endregion

        #region Función Validar Usuario Existente
        //Metodo Realizar Login
        public static DataTable ValidarUsuarioExistente(string nicknameUsuario)
        {
            MUsuario oUsuario = new MUsuario();
            oUsuario.nickname = nicknameUsuario;

            return oUsuario.ValidarUsuarioExistente(oUsuario);
        }
        #endregion

        #region Función Auditoria Usuarios
        public static string Auditar(string idusuario)
        {
            idusuario = "1";
            return idusuario;
        }
        #endregion

    }
}