using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial01eje01
{

    internal class Program
    {

        // Carlos manuel melendez villatoro mv213036
        static void Main(string[] args)
        {
            List<Libro> Biblioteca = new List<Libro>();
            List<Libro> Usuario = new List<Libro>();
            int iD = 1;
            int menu = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Agregar libros");
                Console.WriteLine("2. Eliminar libros");
                Console.WriteLine("3. Mostrar todos los libros");
                Console.WriteLine("4. Prestar un libro");
                Console.WriteLine("5. Devolver libro");
                Console.WriteLine("6. Mostrar los libros prestados");
                Console.WriteLine("7. Salir");
                menu = validar(1, 7);

                if (menu == 1){
                    Console.WriteLine("Ingrese el titulo");
                    string titulo = Console.ReadLine();
                    Console.WriteLine("Ingrese el autor");
                    string autor = Console.ReadLine();
                    Console.WriteLine("Ingrese el numero de copias");
                    int numeroCopias = validar();
                    Biblioteca.Add(new Libro(iD, titulo, autor, numeroCopias));
                    Console.WriteLine("Libro agregado");
                    iD++;
                }
                else if (menu == 2){
                    var libroEliminado = new List<Libro>();
                    mostrarlibros(Biblioteca);
                    int id = 0;
                    bool libroExiste = false;
                    Console.WriteLine("Ingrese el ID para eliminar");
                    id = validar();

                    foreach (var libro in Biblioteca)
                    {
                        if (libro.validar(id))
                        {
                            libroExiste = true;
                            libroEliminado.Add(libro);
                        }
                    }
                    foreach (var item in libroEliminado)
                    {
                        Biblioteca.Remove(item);
                    }
                    if (!libroExiste)
                    {
                        Console.WriteLine("El libro no existe.");
                    }
                }
                else if (menu == 3)
                {
                    mostrarlibros(Biblioteca);
                }
                else if (menu == 4)
                {
                    bool libroexisteUsuario = false;
                    bool libroExiste = false;
                    mostrarlibros(Biblioteca);
                    Console.WriteLine("Ingrese el id del libro");
                    int id = validar();
                    foreach (var libro in Biblioteca)
                    {
                        if (libro.validar(id))
                        {
                            libroExiste = true;
                            foreach (var item in Usuario)
                            {
                                if (item.validar(id))
                                {
                                    libroexisteUsuario = true;
                                    item.NumeroCopias++;
                                    libro.NumeroCopias--;
                                }
                            }
                            if (!libroexisteUsuario)
                            {
                                Usuario.Add(new Libro(libro.ID, libro.Titulo, libro.Autor, 1));
                                libro.NumeroCopias--;
                                Console.WriteLine("Libro agregado");
                            }
                        }
                    }
                    if (!libroExiste)
                    {
                        Console.WriteLine("El libro no existe.");
                    }
                }
                else if (menu == 5)
                {
                    var libroEliminado = new List<Libro>();
                    mostrarlibros(Usuario);
                    Console.WriteLine("Ingrese el id del libro");
                    int id = validar();

                    foreach (var libro in Biblioteca)
                    {
                        if (libro.validar(id))
                        {
                            libro.NumeroCopias++;
                        }
                    }
                    foreach (var item in libroEliminado)
                    {
                        Usuario.Remove(item);
                    }
                    foreach (var item in Usuario)
                    {
                        if (item.validar(id))
                        {
                            if (item.NumeroCopias == 0) libroEliminado.Add(item);
                            else item.NumeroCopias--;
                        }
                    }
                }
                else if(menu==6)
                {
                    mostrarlibros(Usuario);
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (menu != 7);
        }
        static void mostrarlibros(List<Libro> libros)
        {
            Console.WriteLine("Libros");
            foreach (var libro in libros)
            {
                Console.WriteLine(libro.ToString());
            }
        }
        static int validar()
        {
            int numero = 0;

            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0)
            {
                Console.WriteLine("Ingrese un numero valido");
            }
            return numero;
        }
        static int validar(int min, int max)
        {
            int numero = 0;

            while (!int.TryParse(Console.ReadLine(), out numero) || !(numero >= min && numero <= max))
            {
                Console.WriteLine($"Ingrese un numero valido entre {min} y {max}");
            }
            return numero;
        }
    }
}
