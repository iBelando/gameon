using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SistemaPlataforma.Patrones.Patron_Observer
{
    public class ObserverDisplay : IObserver
    {

        #region Atributos

        //Atributos que modelan el estado
        private string resultadoPartido;

        //Subject al que se encuentra suscrito el observer
        private ISubject subject;

        #endregion

        #region Constructores

        //El constructor suscribira el observer al subject
        public ObserverDisplay(ISubject subject)
        {
            this.subject = subject;
            subject.RegistrarObserver(this);
        }

        #endregion

        #region Métodos de IObserver

        //Comprobamos el tipo del objeto recibido como parametro
        public void Update (object o)
        {
            string[] arrayString = null;
            if (o.GetType().Equals(typeof(string[])))
            {
                arrayString = (string[])o;
            }

            //Si es del tipo esperado (string[]) y del tamaño esperado (1), actualiza los atributos
            if ((arrayString != null) && (arrayString.Length == 1))
            {
                resultadoPartido = arrayString[0];
            }

            //Modificamos el color del Partido en la grilla de partidos
            ModificarAparienciaPartido();
        }
        
        #endregion

        //Método que cambia la apariencia de los partidos en la grilla
        private void ModificarAparienciaPartido()
        {
            Partidos frmPartidos = new Partidos();
            foreach (DataGridViewRow row in frmPartidos.dgvVerPartidos.Rows)
            {
                if (Convert.ToString(row.Cells[4].Value) == "0-0")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                if (Convert.ToString(row.Cells[4].Value) == "2-0" || (Convert.ToString(row.Cells[4].Value) == "0-2") || (Convert.ToString(row.Cells[4].Value) == "2-1") || (Convert.ToString(row.Cells[4].Value) == "1-2"))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

    }
}