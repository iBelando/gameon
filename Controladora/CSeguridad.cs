using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Controladora
{
    public class CSeguridad
    {

        #region Definir Variables
        public static List<string> permisosUsuario = new List<string>();
        #endregion

        //#region Función VerificarPermisos
        //public static void VerificarPermisos(int idusuario, Form oForm)
        //{

        //    //#region Cargar Permisos del Usuario

        //    //SqlConnection SqlCon = new SqlConnection();
        //    ////Establecemos la conexion, el comando y ejecutamos el mismo
        //    //SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
        //    //SqlCommand comando = new SqlCommand("Select frmRoles from Grupos_Usuarios inner join Grupos_Roles on Grupos_Usuarios.idGrupo = Grupos_Roles.idGrupo inner join Roles on Grupos_Roles.idRol = Roles.idRol where idUsuario = '" + idusuario + "'", SqlCon);
        //    //SqlCon.Open();
        //    //SqlDataReader registro = comando.ExecuteReader();
        //    //while (registro.Read())
        //    //{
        //    //    permisosUsuario.Add(registro["frmRoles"].ToString());
        //    //}
        //    //SqlCon.Close();
        //    //#endregion

        //    //#region Validar Permisos Form para Usuario

        //    //for (var i = 0; i < permisosUsuario.Count; i++)
        //    //{
        //    //    if (oForm.Name == permisosUsuario[i])
        //    //    {

        //    //    }
        //    //    else
        //    //    {
        //    //        oForm.Close();
        //    //        Application.Exit();
        //    //    }
        //    //}
        //    //#endregion

        //}
        //#endregion

    }
}
