using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CEquipo
    {

        #region Singleton
        private static CEquipo _instance = null;
        private CEquipo()
        { }

        public static CEquipo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CEquipo();
                return _instance;
            }
        }
        #endregion

        #region Función Insertar Equipo
        //Metodo Insertar que llama al metodo Insertar en la clase MEquipo de la Capa de Modelo
        public static string Insertar(string nombre, string descripcion, string capitan, string jugadores, byte[] imagenequipo)
        {
            MEquipo oEquipo = new MEquipo();
            oEquipo.nombre = nombre;
            oEquipo.descripcion = descripcion;
            oEquipo.capitan = capitan;
            oEquipo.jugadores = jugadores;
            oEquipo.imagenEquipo = imagenequipo;

            return oEquipo.Insertar(oEquipo);
        }
        #endregion

        #region Función Editar Equipo
        //Metodo Editar que llama al metodo Editar en la clase MEquipo de la Capa de Modelo
        public static string Editar(int idequipo, string nombre, string descripcion, string capitan, string jugadores, byte[] imagenequipo)
        {
            MEquipo oEquipo = new MEquipo();
            oEquipo.idEquipo = idequipo;
            oEquipo.nombre = nombre;
            oEquipo.descripcion = descripcion;
            oEquipo.capitan = capitan;
            oEquipo.jugadores = jugadores;
            oEquipo.imagenEquipo = imagenequipo;

            return oEquipo.Editar(oEquipo);
        }
        #endregion

        #region Función Eliminar Equipo
        //Metodo Eliminar que llama al metodo Eliminar en la clase MEquipo de la Capa de Modelo
        public static string Eliminar(int idequipo)
        {
            MEquipo oEquipo = new MEquipo();
            oEquipo.idEquipo = idequipo;

            return oEquipo.Eliminar(oEquipo);
        }
        #endregion

        #region Función Mostrar Equipos
        //Metodo Mostrar que llama al metodo Mostrar en la clase MEquipo de la Capa de Modelo
        public static DataTable Mostrar()
        {
            return new MEquipo().Mostrar();
        }
        #endregion

        #region Función BuscarEquipoPorNombre
        //Metodo BuscarEquipoPorNombre que llama al metodo Editar en la clase BuscarEquipoPorNombre de la Capa de Modelo
        public static DataTable BuscarEquipoPorNombre(string textobuscar)
        {
            MEquipo oEquipo = new MEquipo();
            oEquipo.textoBuscar = textobuscar;

            return oEquipo.BuscarEquipoPorNombre(oEquipo);
        }
        #endregion

        #region Funcion Devolver Numero de Equipos Registrados
        public static Int32 DevolverNumeroEquiposRegistrados()
        {
            Int32 count = MEquipo.DevolverNumeroEquiposRegistrados();
            return count;
        }
        #endregion

        #region Función Auditar Equipos
        public static string Auditar(string equipos)
        {
            equipos = "1";
            return equipos;
        }
        #endregion

    }
}
