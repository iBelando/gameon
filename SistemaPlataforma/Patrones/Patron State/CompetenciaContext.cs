using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPlataforma.Patrones.Patron_State
{
    public class CompetenciaContext
    {
        private CompetenciaState state;

        public CompetenciaState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public void AtenderSolicitud()
        {
            state.Respuesta();
        }
    }
}
