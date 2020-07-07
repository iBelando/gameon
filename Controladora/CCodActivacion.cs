using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CCodActivacion
    {

        #region Singleton
        private static CCodActivacion _instance = null;
        private CCodActivacion()
        { }

        public static CCodActivacion Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CCodActivacion();
                return _instance;
            }
        }
        #endregion

        #region Función Insertar Codigo Activación
        //Metodo InsertarCodigoActivacion que llama al metodo InsertarCodigoActivacion en la clase MCodActivacion de la Capa de Modelo
        public static string InsertarCodigoActivacion(int idusuario, string codigoactivacion)
        {
            MCodActivacion oCodActivacion = new MCodActivacion();
            oCodActivacion.idUsuario = idusuario;
            oCodActivacion.codigoActivacion = codigoactivacion;

            return oCodActivacion.InsertarCodigoActivacion(oCodActivacion);
        }
        #endregion

        #region Funcion Generar Codigo Aleatorio de Activacion
        public static string GenerarCodigoActivacion()
        {
            Random obj = new Random();
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            int longitudnuevacadena = 5;
            string nuevacadena = "";
            for (int i = 0; i < longitudnuevacadena; i++)
            {
                letra = posibles[obj.Next(longitud)];
                nuevacadena += letra.ToString();
            }

            return nuevacadena;
        }
        #endregion

        #region Función Validar Codigo Activacion
        //Metodo Validar Registro
        public static DataTable ValidarCodigoActivacion(int idusuario, string codigoactivacion)
        {
            MCodActivacion oCodActivacion = new MCodActivacion();
            oCodActivacion.idUsuario = idusuario;
            oCodActivacion.codigoActivacion = codigoactivacion;

            return oCodActivacion.ValidarCodigoActivacion(oCodActivacion);
        }
        #endregion

        #region Función Auditar Codigos Activación
        public static string Auditar(string codigoactivacion)
        {
            codigoactivacion = "1";
            return codigoactivacion;
        }
        #endregion

    }
}
