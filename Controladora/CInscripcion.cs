using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CInscripcion
    {

        #region Singleton
        private static CInscripcion _instance = null;
        private CInscripcion()
        { }

        public static CInscripcion Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CInscripcion();
                return _instance;
            }
        }
        #endregion

        #region Función Mostrar Inscripciones
        //Metodo Mostrar que llama al metodo Mostrar en la clase MCompetencia de la Capa de Modelo
        public static DataTable Mostrar()
        {
            return new MInscripcion().Mostrar();
        }
        #endregion

        #region Función Eliminar Inscripcion
        //Metodo Eliminar que llama al metodo Eliminar en la clase MCompetencia de la Capa de Modelo
        public static string Eliminar(int idinscripcion)
        {
            MInscripcion oInscripcion = new MInscripcion();
            oInscripcion.idInscripcion = idinscripcion;

            return oInscripcion.Eliminar(oInscripcion);
        }
        #endregion

        #region Función Eliminar Inscripcion con IdEquipo
        //Metodo Eliminar que llama al metodo Eliminar en la clase MCompetencia de la Capa de Modelo
        public static string EliminarConIdEquipo(int idequipo)
        {
            MInscripcion oInscripcion = new MInscripcion();
            oInscripcion.idEquipo = idequipo;

            return oInscripcion.EliminarIdEquipo(oInscripcion);
        }
        #endregion

        #region Función BuscarInscripcionPorEquipo
        //Metodo BuscarCompetenciaPorNombre que llama al metodo BuscarCompetenciaPorNombre en la clase MCompetencia de la Capa de Modelo
        public static DataTable BuscarInscripcionPorEquipo(string textobuscar)
        {
            MInscripcion oInscripcion = new MInscripcion();
            oInscripcion.textoBuscar = textobuscar;

            return oInscripcion.BuscarInscripcionPorEquipo(oInscripcion);
        }
        #endregion

        #region Función BuscarInscripcionPorJuego
        //Metodo BuscarCompetenciaPorNombre que llama al metodo BuscarCompetenciaPorNombre en la clase MCompetencia de la Capa de Modelo
        public static DataTable BuscarInscripcionPorJuego(string textobuscar)
        {
            MInscripcion oInscripcion = new MInscripcion();
            oInscripcion.textoBuscar = textobuscar;

            return oInscripcion.BuscarInscripcionPorJuego(oInscripcion);
        }
        #endregion

        #region Función BuscarInscripcionPorTipo
        //Metodo BuscarCompetenciaPorNombre que llama al metodo BuscarCompetenciaPorNombre en la clase MCompetencia de la Capa de Modelo
        public static DataTable BuscarInscripcionPorTipo(string textobuscar)
        {
            MInscripcion oInscripcion = new MInscripcion();
            oInscripcion.textoBuscar = textobuscar;

            return oInscripcion.BuscarInscripcionPorTipo(oInscripcion);
        }
        #endregion

        #region Función Insertar Inscripcion
        //Metodo Insertar que llama al metodo Insertar en la clase MCompetencia de la Capa de Modelo
        public static string Insertar(int idcompetencia, int idequipo)
        {
            MInscripcion oInscripcion = new MInscripcion();
            oInscripcion.idCompetencia = idcompetencia;
            oInscripcion.idEquipo = idequipo;

            return oInscripcion.Insertar(oInscripcion);
        }
        #endregion

        #region Función Auditoria Inscripciones
        public static string Auditar(string inscripcion)
        {
            inscripcion = "1";
            return inscripcion;
        }
        #endregion

    }
}
