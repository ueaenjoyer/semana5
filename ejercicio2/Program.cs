// Lista de asignaturas
List<string> asignaturas = new List<string> 
{ 
    "Matemáticas", 
    "Física", 
    "Química", 
    "Historia", 
    "Lengua" 
};

// Mostrar cada asignatura con "Yo estudio"
foreach (string asignatura in asignaturas)
{
    Console.WriteLine($"Yo estudio {asignatura}");
}
