using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial01eje01
{
    internal class Libro
    {
        public  int ID;
        public string Titulo;
        public string Autor;
        public int NumeroCopias;
        public Libro() { }

        public Libro(int iD, string titulo, string autor, int numeroCopias)
        {
            ID = iD;
            Titulo = titulo;
            Autor = autor;
            NumeroCopias = numeroCopias;
        }
        public bool validar(int id)
        {
            if (this.ID == id) return true;
            else return false;
        }
        public void prestar()
        {

        }
        public string ToString() => $"ID-> {ID}, Titulo-> {Titulo}, Autor-> {Autor}, Numero de copias-> {NumeroCopias}";
    }
}
