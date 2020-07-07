using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlataforma.Patrones.Patron_Observer
{
    public interface IObserver
    {
        //Metodo que sera invocado por el Subject
        //El objeto "o" seran los valores que el subject le pasara al observer
        void Update(Object o);
    }
}
