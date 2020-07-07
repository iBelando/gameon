using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CRol
    {

        #region Singleton
        private static CRol _instance = null;
        private CRol()
        { }

        public static CRol Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CRol();
                return _instance;
            }
        }
        #endregion

        #region Función Insertar Rol
        //Metodo Insertar que llama al metodo Insertar en la clase MRol de la Capa de Modelo
        public static string Insertar(string nombrerol, string frmroles)
        {
            MRol oRol = new MRol();
            oRol.nombreRol = nombrerol;
            oRol.frmRoles = frmroles;

            return oRol.Insertar(oRol);
        }
        #endregion

        #region Función Editar Rol
        //Metodo Editar que llama al metodo Editar en la clase MRol de la Capa de Modelo
        public static string Editar(int idrol, string nombrerol, string frmroles)
        {
            MRol oRol = new MRol();
            oRol.idRol = idrol;
            oRol.nombreRol = nombrerol;
            oRol.frmRoles = frmroles;

            return oRol.Editar(oRol);
        }
        #endregion

        #region Función Eliminar Rol
        //Metodo Eliminar que llama al metodo Eliminar en la clase MRol de la Capa de Modelo
        public static string Eliminar(int idrol)
        {
            MRol oRol = new MRol();
            oRol.idRol = idrol;

            return oRol.Eliminar(oRol);
        }
        #endregion

        #region Función Mostrar Roles
        //Metodo Mostrar que llama al metodo Mostrar en la clase MRol de la Capa de Modelo
        public static DataTable Mostrar()
        {
            return new MRol().Mostrar();
        }
        #endregion

        #region Función BuscarRolPorNombre
        //Metodo BuscarRolPorNombre que llama al metodo BuscarRolPorNombre en la clase MRol de la Capa de Modelo
        public static DataTable BuscarRolPorNombre(string textobuscar)
        {
            MRol oRol = new MRol();
            oRol.textoBuscar = textobuscar;

            return oRol.BuscarRolporNombre(oRol);
        }
        #endregion

        #region Función InsertarRolUsuario
        public static int InsertarRolUsuario(string nombreRol)
        {
            int idRol = 0;
            switch(nombreRol)
            {
                case "Administrador":
                    idRol = 1;
                    break;
                case "Arbitro":
                    idRol = 2;
                    break;
                case "Jugador":
                    idRol = 3;
                    break;
            }
            return idRol;
        }
        #endregion

        #region Función Auditoria Roles
        public static string Auditar(string roles)
        {
            roles = "1";
            return roles;
        }
        #endregion

    }
}
