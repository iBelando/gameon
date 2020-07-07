using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPlataforma.Patrones.Patron_Observer;
using System.Collections;

namespace SistemaPlataforma.Patrones.Patron_Observer
{
    public class Partido : ISubject
    {
        #region Estado
        //Atributos que modelan el estado
        private string resultadoPartido;
        #endregion

        //Listado de Observers
        IList suscriptores;

        #region Properties

        public string ResultadoPartido
        {
            get { return this.resultadoPartido; }

            //Cada vez que se modifique el estado, se invocará el método Notificar
            set
            {
                if(this.resultadoPartido != value)
                {
                    this.resultadoPartido = value;
                    NotificarObservers();
                }
            }
        }

        #endregion

        #region Métodos de la Interfaz ISubject

        //Constructor que creará un partido con los valores iniciales del resultado
        public Partido(string resultadoPartido)
        {
            this.suscriptores = new ArrayList();
            this.resultadoPartido = resultadoPartido;
        }

        //Comprobamos si el observer se encuentra en la lista. En caso contrario, se lo incluye en la lista
        public void RegistrarObserver(IObserver o)
        {
            if (!suscriptores.Contains(o))
            {
                suscriptores.Add(o);
            }
        }

        //Comprobamos si el observer se encuentra en la lista. En caso afirmativo, se lo elimina de la lista
        public void EliminarObserver(IObserver o)
        {
            if (suscriptores.Contains(o))
            {
                suscriptores.Remove(o);
            }
        }

        //Recorre la lista de observers e invoca su metodo Update()
        public void NotificarObservers()
        {
            //Creamos un array con el estado del Subject
            string[] valores = { this.resultadoPartido };

            //Recorremos todos los objetos suscritos (observers)
            IObserver observer;

            foreach(Object o in suscriptores)
            {
                //Invocamos el metodo Update de cada observer, pasandole el array del subject como parametro
                //Cada observer ya hara lo que estime necesario con esa informacion
                observer = (IObserver)o;
                observer.Update(valores);
            }
        }
        #endregion
    }
}
