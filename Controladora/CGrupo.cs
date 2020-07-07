using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CGrupo
    {

        #region Singleton
        private static CGrupo _instance = null;
        private CGrupo()
        { }

        public static CGrupo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CGrupo();
                return _instance;
            }
        }
        #endregion

        #region Función Insertar Grupo
        //Metodo Insertar que llama al metodo Insertar en la clase MGrupo de la Capa de Modelo
        public static string Insertar(string nombregrupo)
        {
            MGrupo oGrupo = new MGrupo();
            oGrupo.nombreGrupo = nombregrupo;

            return oGrupo.Insertar(oGrupo);
        }
        #endregion

        #region Función Asociar Grupo con Rol
        //Metodo Insertar que llama al metodo Insertar en la clase MGrupo de la Capa de Modelo
        public static string AsociarGrupoConRol(int idgrupo, int idrol)
        {
            MGrupo oGrupo = new MGrupo();
            oGrupo.idGrupo = idgrupo;
            oGrupo.idRol = idrol;

            return oGrupo.AsociarGrupoConRol(oGrupo);
        }
        #endregion

        #region Función Editar Grupo
        //Metodo Editar que llama al metodo Editar en la clase MGrupo de la Capa de Modelo
        public static string Editar(int idgrupo, string nombregrupo)
        {
            MGrupo oGrupo = new MGrupo();
            oGrupo.nombreGrupo = nombregrupo;
            oGrupo.idGrupo = idgrupo;

            return oGrupo.Editar(oGrupo);
        }
        #endregion

        #region Función Eliminar Grupo
        //Metodo Eliminar que llama al metodo Eliminar en la clase MGrupo de la Capa de Modelo
        public static string Eliminar(int idgrupo)
        {
            MGrupo oGrupo = new MGrupo();
            oGrupo.idGrupo = idgrupo;

            return oGrupo.Eliminar(oGrupo);
        }
        #endregion

        #region Función Eliminar Grupo
        //Metodo Eliminar que llama al metodo Eliminar en la clase MGrupo de la Capa de Modelo
        public static string EliminarGrupoConRolesAsociados(int idgrupo)
        {
            MGrupo oGrupo = new MGrupo();
            oGrupo.idGrupo = idgrupo;

            return oGrupo.EliminarGrupoConRolesAsociados(oGrupo);
        }
        #endregion

        #region Función Mostrar Grupos
        //Metodo Mostrar que llama al metodo Mostrar en la clase MGrupo de la Capa de Modelo
        public static DataTable Mostrar()
        {
            return new MGrupo().Mostrar();
        }
        #endregion

        #region Función BuscarGrupoPorNombre
        //Metodo BuscarGrupoPorNombre que llama al metodo BuscarGrupoPorNombre en la clase MGrupo de la Capa de Modelo
        public static DataTable BuscarGrupoPorNombre(string textobuscar)
        {
            MGrupo oGrupo = new MGrupo();
            oGrupo.textoBuscar = textobuscar;

            return oGrupo.BuscarGrupoporNombre(oGrupo);
        }
        #endregion

        #region Función Auditoria Grupos
        public static string Auditar(string grupos)
        {
            grupos = "1";
            return grupos;
        }
        #endregion

    }
}
