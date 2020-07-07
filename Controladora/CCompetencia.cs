using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CCompetencia
    {

        #region Singleton
        private static CCompetencia _instance = null;
        private CCompetencia()
        { }

        public static CCompetencia Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CCompetencia();
                return _instance;
            }
        }
        #endregion

        #region Función Insertar Competencia
        //Metodo Insertar que llama al metodo Insertar en la clase MCompetencia de la Capa de Modelo
        public static string Insertar(string nombrecompetencia, DateTime fechainicio, DateTime fechafin, string juego, string tipocompetencia, int cupos)
        {
            MCompetencia oCompetencia = new MCompetencia();
            oCompetencia.nombreCompetencia = nombrecompetencia;
            oCompetencia.fechaInicio = fechainicio;
            oCompetencia.fechaFin = fechafin;
            oCompetencia.juego = juego;
            oCompetencia.tipoCompetencia = tipocompetencia;
            oCompetencia.cupos = cupos;

            return oCompetencia.Insertar(oCompetencia);
        }
        #endregion

        #region Función Editar Competencia
        //Metodo Editar que llama al metodo Editar en la clase MCompetencia de la Capa de Modelo
        public static string Editar(int idcompetencia, string nombrecompetencia, DateTime fechainicio, DateTime fechafin, string juego, string tipocompetencia, int cupos)
        {
            MCompetencia oCompetencia = new MCompetencia();
            oCompetencia.idCompetencia = idcompetencia;
            oCompetencia.nombreCompetencia = nombrecompetencia;
            oCompetencia.fechaInicio = fechainicio;
            oCompetencia.fechaFin = fechafin;
            oCompetencia.juego = juego;
            oCompetencia.tipoCompetencia = tipocompetencia;
            oCompetencia.cupos = cupos;

            return oCompetencia.Editar(oCompetencia);
        }
        #endregion

        #region Función Eliminar Competencia
        //Metodo Eliminar que llama al metodo Eliminar en la clase MCompetencia de la Capa de Modelo
        public static string Eliminar(int idcompetencia)
        {
            MCompetencia oCompetencia = new MCompetencia();
            oCompetencia.idCompetencia = idcompetencia;

            return oCompetencia.Eliminar(oCompetencia);
        }
        #endregion

        #region Función Mostrar Competencias
        //Metodo Mostrar que llama al metodo Mostrar en la clase MCompetencia de la Capa de Modelo
        public static DataTable Mostrar()
        {
            return new MCompetencia().Mostrar();
        }
        #endregion

        #region Función Mostrar Inscripciones en Competencias
        //Metodo Mostrar que llama al metodo Mostrar en la clase MCompetencia de la Capa de Modelo
        public static DataTable MostrarInscripcionesEnCompetencias()
        {
            return new MCompetencia().MostrarInscripcionesEnCompetencias();
        }
        #endregion

        #region Función BuscarCompetenciaPorNombre
        //Metodo BuscarCompetenciaPorNombre que llama al metodo BuscarCompetenciaPorNombre en la clase MCompetencia de la Capa de Modelo
        public static DataTable BuscarCompetenciaPorNombre(string textobuscar)
        {
            MCompetencia oCompetencia = new MCompetencia();
            oCompetencia.textoBuscar = textobuscar;

            return oCompetencia.BuscarCompetenciaPorNombre(oCompetencia);
        }
        #endregion

        #region Función BuscarCompetenciaPorJuego
        //Metodo BuscarCompetenciaPorNombre que llama al metodo BuscarCompetenciaPorNombre en la clase MCompetencia de la Capa de Modelo
        public static DataTable BuscarCompetenciaPorJuego(string textobuscar)
        {
            MCompetencia oCompetencia = new MCompetencia();
            oCompetencia.textoBuscar = textobuscar;

            return oCompetencia.BuscarCompetenciaPorJuego(oCompetencia);
        }
        #endregion

        #region Función BuscarCompetenciaPorTipo
        //Metodo BuscarCompetenciaPorNombre que llama al metodo BuscarCompetenciaPorNombre en la clase MCompetencia de la Capa de Modelo
        public static DataTable BuscarCompetenciaPorTipo(string textobuscar)
        {
            MCompetencia oCompetencia = new MCompetencia();
            oCompetencia.textoBuscar = textobuscar;

            return oCompetencia.BuscarCompetenciaPorTipo(oCompetencia);
        }
        #endregion

        #region Función BuscarInscripcionesCompetencia
        //Metodo BuscarCompetenciaPorNombre que llama al metodo BuscarCompetenciaPorNombre en la clase MCompetencia de la Capa de Modelo
        public static DataTable BuscarInscripcionesCompetencia(string textobuscar)
        {
            MCompetencia oCompetencia = new MCompetencia();
            oCompetencia.textoBuscar = textobuscar;

            return oCompetencia.BuscarInscripcionesCompetencia(oCompetencia);
        }
        #endregion

        #region Funcion Devolver Numero de Competencias Realizadas
        public static Int32 DevolverNumeroCompetenciasRealizadas()
        {
            Int32 count = MCompetencia.DevolverNumeroCompetenciasRealizadas();
            return count;
        }
        #endregion

        #region Función Auditar Competencia
        public static string Auditar(string competencias)
        {
            competencias = "1";
            return competencias;
        }
        #endregion

    }
}
