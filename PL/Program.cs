using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ML.Libro libro = new ML.Libro();
            Console.WriteLine("CRUD LIBRO :");

            Console.WriteLine("\n 1.- Agregar \n 2.- Actualizar   \n 3.- Eliminar " +
                              "\n 4.- Getall \n 5.- GetById");

            Console.WriteLine(" ");

            Console.WriteLine("Eliga la opción : ");
            int Opcion = int.Parse(Console.ReadLine());

            switch (Opcion)
            {
                case 1: //Agrega 
                    Console.WriteLine(" ");
                    Libro.Add();
                    break;
                case 2: //Actualiza 
                    Console.WriteLine(" ");
                    Libro.Update();
                    break;
                case 3: //Elimina 
                    Console.WriteLine(" ");
                    Libro.Delete();
                    break;
                case 4: // GetAll
                    Console.WriteLine(" ");
                    Libro.GetAll();
                    break;
                case 5: // getbyid
                    Console.WriteLine(" ");
                    Libro.GetById();
                    break;
            }
            Console.ReadKey();
        }
    }
}
