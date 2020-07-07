using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Plataforma
    {
        #region String de Conexión a la Base de Datos PlataformaProduccion
        public static string PPCn = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
        #endregion

        #region String de Conexión a la Base de Datos PlataformaAuditoria
        public static string PACn = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaAuditoria;Integrated Security=True";
        #endregion
    }
}
