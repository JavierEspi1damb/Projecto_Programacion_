using System.Collections.Generic;
namespace ListaDobleEnlazada
{
    public class Nodo<T> : IDisposable
    {
        public Nodo<T> Siguiente { get; set; }
        public Nodo<T> Anterior { get; set; }
        public T Dato { get; }

        public Nodo(T dato)
        {
            Dato = dato;
            Siguiente = null;
            Anterior = null;
        }
        public void Dispose()
        {
            if (Siguiente == null)
            {
                Siguiente.Dispose();
            }
            else if (Anterior == null)
            {
                Anterior.Dispose();
            }
        }
    }
}