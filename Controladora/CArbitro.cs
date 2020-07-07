using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CArbitro
    {

        #region Singleton
        private static CArbitro _instance = null;
        private CArbitro()
        { }

        public static CArbitro Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CArbitro();
                return _instance;
            }
        }
        #endregion

        #region Función Insertar Arbitro
        //Metodo Insertar que llama al metodo Insertar en la clase MArbitro de la Capa de Modelo
        public static string Insertar(int idusuario)
        {
            MArbitro oArbitro = new MArbitro();
            oArbitro.idUsuario = idusuario;

            return oArbitro.Insertar(oArbitro);
        }
        #endregion

        #region Función Editar Arbitro
        //Metodo Editar que llama al metodo Editar en la clase MArbitro de la Capa de Modelo
        public static string Editar(int idusuario)
        {
            MArbitro oArbitro = new MArbitro();
            oArbitro.idUsuario = idusuario;

            return oArbitro.Editar(oArbitro);
        }
        #endregion

        #region Función Eliminar Arbitro
        //Metodo Eliminar que llama al metodo Eliminar en la clase MArbitro de la Capa de Modelo
        public static string Eliminar(int idarbitro)
        {
            MArbitro oArbitro = new MArbitro();
            oArbitro.idArbitro = idarbitro;

            return oArbitro.Eliminar(oArbitro);
        }
        #endregion

        #region Función Mostrar Arbitros
        //Metodo Mostrar que llama al metodo Mostrar en la clase MArbitro de la Capa de Modelo
        public static DataTable Mostrar()
        {
            return new MArbitro().Mostrar();
        }
        #endregion

        #region Función BuscarArbitroPorNombre
        //Metodo BuscarArbitroPorNombre que llama al metodo BuscarArbitroPorNombre en la clase MArbitro de la Capa de Modelo
        public static DataTable BuscarArbitroPorNombre(string textobuscar)
        {
            MArbitro oArbitro = new MArbitro();
            oArbitro.textoBuscar = textobuscar;

            return oArbitro.BuscarArbitroPorNickname(oArbitro);
        }
        #endregion

        #region Funcion Auditar Arbitros
        public static string Auditar(string idusuario)
        {
            idusuario = "1";
            return idusuario;
        }
        #endregion

    }
}
