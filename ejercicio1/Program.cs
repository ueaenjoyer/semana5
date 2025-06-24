//Escribir un programa que almacene las asignaturas de un curso 
//(por ejemplo Matemáticas, Física, Química, Historia y Lengua) 
//en una lista y la muestre por pantalla.

using System;

namespace GestorMaterias
{
    class Program
    {
        static void Main()
        {
            MateriaManager gestor = new MateriaManager();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                MostrarMenu();
                Console.Write("Opción: ");
                string opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1": gestor.AgregarMateria();   break;
                    case "2": gestor.EditarMateria();    break;
                    case "3": gestor.EliminarMateria();  break;
                    case "4": gestor.ListarMaterias();   break;
                    case "0": salir = true;              break;
                    default:
                        Console.WriteLine("❌ Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("===== GESTOR DE MATERIAS =====");
            Console.WriteLine("1) Agregar materia");
            Console.WriteLine("2) Editar materia");
            Console.WriteLine("3) Eliminar materia");
            Console.WriteLine("4) Listar todas");
            Console.WriteLine("0) Salir");
            Console.WriteLine("===============================");
        }
    }
}
