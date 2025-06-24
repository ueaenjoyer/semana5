
namespace GestorMaterias
{
    public class MateriaManager
    {
        private readonly List<Materia> materias = new List<Materia>();

        public void AgregarMateria()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Profesor: ");
            string profesor = Console.ReadLine();

            materias.Add(new Materia(nombre, profesor));
            Console.WriteLine("✅ Materia agregada. Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        public void EditarMateria()
        {
            if (!HayMaterias()) return;
            ListarMaterias(false);

            Console.Write("Índice de la materia a editar: ");
            int idx = LeerEnteroPositivo();

            if (idx < 0 || idx >= materias.Count)
            {
                Console.WriteLine("❌ Índice fuera de rango.");
                Console.ReadKey(); return;
            }

            var mat = materias[idx];
            Console.WriteLine($"Editando {mat.Nombre}: (ENTER para dejar igual)");

            Console.Write($"Nuevo nombre ({mat.Nombre}): ");
            string nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) mat.Nombre = nombre;

            Console.Write($"Nuevo profesor ({mat.Profesor}): ");
            string profesor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(profesor)) mat.Profesor = profesor;

            Console.WriteLine("✅ Materia actualizada.");
            Console.ReadKey();
        }

        public void EliminarMateria()
        {
            if (!HayMaterias()) return;
            ListarMaterias(false);

            Console.Write("Índice a eliminar: ");
            int idx = LeerEnteroPositivo();

            if (idx < 0 || idx >= materias.Count)
            {
                Console.WriteLine("❌ Índice fuera de rango.");
                Console.ReadKey(); return;
            }

            Console.WriteLine($"¿Seguro que deseas eliminar '{materias[idx].Nombre}'? (s/n)");
            if (Console.ReadKey().Key == ConsoleKey.S)
            {
                materias.RemoveAt(idx);
                Console.WriteLine("\n✅ Materia eliminada.");
            }
            else
            {
                Console.WriteLine("\n❌ Operación cancelada.");
            }
            Console.ReadKey();
        }

        public void ListarMaterias(bool pausar = true)
        {
            Console.Clear();
            Console.WriteLine("===== LISTA DE MATERIAS =====");
            if (materias.Count == 0)
            {
                Console.WriteLine("No hay materias.");
            }
            else
            {
                Console.WriteLine($"{"#",2}  {"NOMBRE",-25}  {"PROFESOR",-15}  CR");
                Console.WriteLine(new string('-', 50));
                for (int i = 0; i < materias.Count; i++)
                    Console.WriteLine($"{i,2}: {materias[i]}");
            }

            if (pausar)
            {
                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }
        }

        private int LeerEnteroPositivo()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int valor) && valor >= 0)
                    return valor;
                Console.Write("Ingresa un número válido (0 o mayor): ");
            }
        }

        private bool HayMaterias()
        {
            if (materias.Count == 0)
            {
                Console.WriteLine("⚠️ No hay materias registradas.");
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}
