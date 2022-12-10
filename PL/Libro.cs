using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        // ADD 

        public static void Add()
        {
            //INSTANCIA 
            ML.Libro libro = new ML.Libro();

            // AGREGAR LA INFORMACIÓN 

            Console.WriteLine("Ingrese el Nombre del libro:");
            libro.Nombre = Console.ReadLine();

            libro.Autor = new ML.Autor();
            Console.WriteLine("Ingrese el Id de Autor:");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine()); // parsear los int

            Console.WriteLine("Ingrese el Numero de paginas del libro:");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la Fecha de Publicacion del libro:");
            libro.FechaPublicacion = Console.ReadLine();

            libro.Editorial = new ML.Editorial();
            Console.WriteLine("Ingrese el Id Editorial del libro:");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la Edicion del libro:");
            libro.Edicion = Console.ReadLine();

            libro.Genero = new ML.Genero();
            Console.WriteLine("Ingrese el Id Genero del libro:");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());


            ML.Result result = new ML.Result();

            //Manda información al BL//
            result = BL.Libro.Add(libro);

            if (result.Correct == true)
            {
                Console.WriteLine("El usuario se agrego correctamente ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El usuario no se agrego " + result.ErrorMessage);
                Console.ReadKey();
            }

        }


        // UPDATE 
        public static void Update()
        {
            //INSTANCIA 
            ML.Libro libro = new ML.Libro();

            // AGREGAR LA INFORMACIÓN 
            Console.WriteLine("Actualiza el Id del Libro :");
            libro.IdLibro = int.Parse(Console.ReadLine());

            Console.WriteLine("Actualiza el Nombre del libro:");
            libro.Nombre = Console.ReadLine();

            libro.Autor = new ML.Autor();
            Console.WriteLine("Actualiza el Id de Autor:");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine()); // parsear los int

            Console.WriteLine("Actualiza el Numero de paginas del libro:");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Actualiza la Fecha de Publicacion del libro:");
            libro.FechaPublicacion = Console.ReadLine();

            libro.Editorial = new ML.Editorial();
            Console.WriteLine("Actualiza el Id Editorial del libro:");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("Actualiza la Edicion del libro:");
            libro.Edicion = Console.ReadLine();

            libro.Genero = new ML.Genero();
            Console.WriteLine("Actualiza el Id Genero del libro:");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());


            ML.Result result = new ML.Result();

            //Manda información al BL//
            result = BL.Libro.Update(libro);

            if (result.Correct == true)
            {
                Console.WriteLine("El libro se Actualizo correctamente ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El libro no se Actualiza " + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        // GETALL 
        public static void GetAll()
        {
            // Instancia de un Objeto // 
            ML.Result result = BL.Libro.GetAll(); //SP


            if (result.Correct)
            {
                foreach (ML.Libro libro in result.Objects)
                {
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("El id del Usuario es: " + libro.IdLibro);
                    Console.WriteLine("El nombre del usuario es: " + libro.Nombre);
                    Console.WriteLine("El apellido paterno del usuario es: " + libro.Autor.IdAutor);
                    Console.WriteLine("El materno del usuario es: " + libro.NumeroPaginas);
                    Console.WriteLine("La fecha de nacimiento del usuario es: " + libro.FechaPublicacion);
                    Console.WriteLine("El UserName del usuario es: " + libro.Editorial.IdEditorial);
                    Console.WriteLine("El password del usuario es: " + libro.Edicion);
                    Console.WriteLine("El Sexo del usuario es: " + libro.Genero.IdGenero);

                    Console.WriteLine("*******************************************************************");
                }
            }
            else
            {
                Console.WriteLine("Error al consultar :" + result.ErrorMessage);
            }
            Console.ReadLine();
        }

        // GETBYID 
        public static void GetById()
        {
            Console.WriteLine("Ingrese el id del libro que desea consultar");
            int IdLibro = int.Parse(Console.ReadLine());

            //ML.Result result = new ML.Result();

            ML.Result result = BL.Libro.GetById(IdLibro); //SP//SP



            if (result.Correct)
            {
                ML.Libro libro = new ML.Libro();

                //unboxing
                libro = (ML.Libro)result.Object;

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("El id del Usuario es: " + libro.IdLibro);
                Console.WriteLine("El nombre del usuario es: " + libro.Nombre);
                Console.WriteLine("El apellido paterno del usuario es: " + libro.Autor.IdAutor);
                Console.WriteLine("El materno del usuario es: " + libro.NumeroPaginas);
                Console.WriteLine("La fecha de nacimiento del usuario es: " + libro.FechaPublicacion);
                Console.WriteLine("El UserName del usuario es: " + libro.Editorial.IdEditorial);
                Console.WriteLine("El password del usuario es: " + libro.Edicion);
                Console.WriteLine("El Sexo del usuario es: " + libro.Genero.IdGenero);
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.WriteLine("Ocurrio un error " + result.ErrorMessage);
            }
            Console.ReadLine();
        }



        // DELETE 
        public static void Delete()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Eliminar Libro \n");

            Console.WriteLine("Ingrese el Id del Libro que desea eliminar");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            //Manda información al BL //
            result = BL.Libro.Delete(libro);

            if (result.Correct == true)
            {
                Console.WriteLine("El libro se elimino correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El libro no se elimino" + result.ErrorMessage);
                Console.ReadKey();
            }
            Console.ReadLine();
        }

    }
}

