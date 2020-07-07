using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CJuego
    {

        #region Singleton
        private static CJuego _instance = null;
        private CJuego()
        { }

        public static CJuego Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CJuego();
                return _instance;
            }
        }
        #endregion

        #region Función Insertar Juego
        //Metodo Insertar que llama al metodo Insertar en la clase MJuego de la Capa de Modelo
        public static string Insertar(string nombrejuego, byte[] imagenjuego, string reglamentojuego)
        {
            MJuego oJuego = new MJuego();
            oJuego.nombreJuego = nombrejuego;
            oJuego.imagenJuego = imagenjuego;
            oJuego.reglamentoJuego = reglamentojuego;

            return oJuego.Insertar(oJuego);
        }
        #endregion

        #region Función Editar Juego
        //Metodo Editar que llama al metodo Editar en la clase MJuego de la Capa de Modelo
        public static string Editar(int idjuego, string nombrejuego, byte[] imagenjuego, string reglamentojuego)
        {
            MJuego oJuego = new MJuego();
            oJuego.idJuego = idjuego;
            oJuego.nombreJuego = nombrejuego;
            oJuego.imagenJuego = imagenjuego;
            oJuego.reglamentoJuego = reglamentojuego;

            return oJuego.Editar(oJuego);
        }
        #endregion

        #region Función Eliminar Juego
        //Metodo Eliminar que llama al metodo Eliminar en la clase MJuego de la Capa de Modelo
        public static string Eliminar(int idjuego)
        {
            MJuego oJuego = new MJuego();
            oJuego.idJuego = idjuego;

            return oJuego.Eliminar(oJuego);
        }
        #endregion

        #region Función Mostrar Juegos
        //Metodo Mostrar que llama al metodo Mostrar en la clase MJuego de la Capa de Modelo
        public static DataTable Mostrar()
        {
            return new MJuego().Mostrar();
        }
        #endregion

        #region Función BuscarJuegoPorNombre
        //Metodo BuscarJuegoPorNombre que llama al metodo BuscarJuegoPorNombre en la clase MJuego de la Capa de Modelo
        public static DataTable BuscarJuegoPorNombre(string textobuscar)
        {
            MJuego oJuego = new MJuego();
            oJuego.textoBuscar = textobuscar;

            return oJuego.BuscarJuegoPorNombre(oJuego);
        }
        #endregion

        #region Función Auditoria Juegos
        public static string Auditar(string juegos)
        {
            juegos = "1";
            return juegos;
        }
        #endregion

    }
}