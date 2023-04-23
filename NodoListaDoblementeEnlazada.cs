using System;
using System.Collections;

namespace ListaDobleEnlazada
{
    public class ListaDoblementeEnlazada<T> : IDisposable, IEnumerable where T : IComparable<T>
    {
        public Nodo<T> Primero { get; private set; }
        public Nodo<T> Ultimo { get; private set; }
        public int Longitud { get; private set; }
        public bool Vacia
        {
            get
            {
                if (Longitud == 0) return true;
                return false;
            }
        }


        public ListaDoblementeEnlazada()
        {
            Primero = null;
            Ultimo = null;
            Longitud = 0;
        }
         

        public ListaDoblementeEnlazada(IEnumerable<T> secuencia)
        {
            foreach (T dato in secuencia)
            {
                AñadeAlFinal(dato);
            }
        }

        public void AñadeVacía(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);

            Primero = nuevo;
            Ultimo = nuevo;
            Longitud++;
        }

        public void AñadeAlPrincipio(T dato)
        {

            Nodo<T> nuevoNodo = new Nodo<T>(dato);
            if (Vacia)
            {
                Primero = nuevoNodo;
                Ultimo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = Primero;
                Primero.Anterior = nuevoNodo;
                Primero = nuevoNodo;
            }

            Longitud++;
        }

        public void AñadeAlFinal(T dato)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(dato);

            if (Vacia)
            {
                Primero = nuevoNodo;
                Ultimo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Anterior = Ultimo;
                Ultimo.Siguiente = nuevoNodo;
                Ultimo = nuevoNodo;
            }

            Longitud++;
        }


        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T> nodoActual = Primero;

            while (nodoActual != null)
            {
                yield return nodoActual.Dato;
                nodoActual = nodoActual.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Dispose()
        {
            // Dejar vacío, ya que no tenemos recursos no administrados
        }


    }
}