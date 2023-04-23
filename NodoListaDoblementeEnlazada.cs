using System;
using System.Collections;
using System.Collections.Generic;

namespace ListaDobleEnlazada
{
    public class ListaDoblementeEnlazada<T> : IDisposable, IEnumerable<T> where T : IComparable<T>
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
                InsertarAlFinal(dato);
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
                AñadeVacía(dato);
            }
            else
            {
                nuevoNodo.Siguiente = Primero;
                Primero.Anterior = nuevoNodo;
                Primero = nuevoNodo;
                Longitud++;
            }
        }

        public void InsertarAlFinal(T dato)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(dato);
            if (this.Primero == null)
            {
                this.Primero = nuevoNodo;
                this.Ultimo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Anterior = this.Ultimo;
                Ultimo.Siguiente = nuevoNodo;
                Ultimo = nuevoNodo;
            }
            Longitud++;
        }


        public void EditaNodo(T datoAnterior, T datoNuevo, string direccion)
        {
            Nodo<T> nodoActual = null;

            if (direccion == "primero")
            {
                nodoActual = Primero;
                while (nodoActual != null)
                {
                    if (nodoActual.Dato.CompareTo(datoAnterior) == 0)
                    {
                        nodoActual.Dato = datoNuevo;
                        break;
                    }
                    nodoActual = nodoActual.Siguiente;
                }
            }
            else if (direccion == "último")
            {
                nodoActual = Ultimo;
                while (nodoActual != null)
                {
                    if (nodoActual.Dato.CompareTo(datoAnterior) == 0)
                    {
                        nodoActual.Dato = datoNuevo;
                        break;
                    }
                    nodoActual = nodoActual.Anterior;
                }
            }
        }
        public void AñadeAntesDe(Nodo<T> nodo, ListaDoblementeEnlazada<T> nuevo)
        {
            if (Longitud == 0)
            {
                Console.WriteLine("La lista no puede estar vacía.");
                return;
            }

            Nodo<T> nodoActual = Primero;

            while (nodoActual != null)
            {
                if (nodoActual == nodo)
                {
                    nuevo.Ultimo.Siguiente = nodoActual;
                    nuevo.Primero.Anterior = nodoActual.Anterior;

                    if (nodoActual.Anterior != null)
                    {
                        nodoActual.Anterior.Siguiente = nuevo.Primero;
                    }
                    else
                    {
                        Primero = nuevo.Primero;
                    }

                    nodoActual.Anterior = nuevo.Ultimo;
                    Longitud += nuevo.Longitud;

                    break;
                }

                nodoActual = nodoActual.Siguiente;
            }
        }

        public void AñadeAntesDe(Nodo<T> nodo, T dato)
        {
            ListaDoblementeEnlazada<T> nuevaLista = new ListaDoblementeEnlazada<T>();
            nuevaLista.InsertarAlFinal(dato);
            AñadeAntesDe(nodo, nuevaLista);
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
