using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controladora;

namespace SistemaPlataforma.Patrones.Patron_Facade
{
    public class AuditoriaFacade
    {

        #region Definir Variables
        public static string rta = "";
        #endregion

        #region Auditar Arbitro
        public static string AuditarArbitro(string arbitro)
        {
            rta = CArbitro.Auditar(arbitro);
            return rta;
        }
        #endregion

        #region Auditar Codigo de Activacion
        public static string AuditarCodigoActivacion(string codigoactivacion)
        {
            rta = CCodActivacion.Auditar(codigoactivacion);
            return rta;
        }
        #endregion

        #region Auditar Competencia
        public static string AuditarCompetencia(string competencia)
        {
            rta = CCompetencia.Auditar(competencia);
            return rta;
        }
        #endregion

        #region Auditar Equipo
        public static string AuditarEquipo(string equipo)
        {
            rta = CEquipo.Auditar(equipo);
            return rta;
        }
        #endregion

        #region Auditar Grupo
        public static string AuditarGrupo(string grupo)
        {
            rta = CGrupo.Auditar(grupo);
            return rta;
        }
        #endregion

        #region Auditar Inscripcion
        public static string AuditarInscripcion(string inscripcion)
        {
            rta = CInscripcion.Auditar(inscripcion);
            return rta;
        }
        #endregion

        #region Auditar Juego
        public static string AuditarJuego(string juego)
        {
            rta = CJuego.Auditar(juego);
            return rta;
        }
        #endregion

        #region Auditar Partido
        public static string AuditarPartido(int idpartido, DateTime fecha, string equipoa, string equipob, string resultado, string juego, int idarbitro, int idcompetencia, string tipoMovimiento, string nombreUsuario)
        {
            rta = CPartido.Auditar(idpartido, fecha, equipoa, equipob, resultado, juego, idarbitro, idcompetencia, tipoMovimiento, nombreUsuario);
            return rta;
        }
        #endregion

        #region Auditar Rol
        public static string AuditarRol(string rol)
        {
            rta = CRol.Auditar(rol);
            return rta;
        }
        #endregion

        #region Auditar Usuario
        public static string Usuario(string usuario)
        {
            rta = CUsuario.Auditar(usuario);
            return rta;
        }
        #endregion

    }
}
